using System.Globalization;
using Microsoft.Data.Sqlite;

namespace HSTechService
{
    public enum ResultadoLogin
    {
        Sucesso,
        SenhaIncorreta,
        Bloqueado
    }

    public static class UsuarioRepository
    {
        public const int MaxTentativas = 5;
        private const int MinutosBloqueio = 5;
        private const string FormatoData = "yyyy-MM-dd HH:mm:ss";

        public static bool ExisteAdmin()
        {
            using var con = Database.Abrir();
            using var cmd = con.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM usuarios";
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        public static string CriarAdmin(string senha)
        {
            string salt = SegurancaHelper.GerarSalt();
            string hash = SegurancaHelper.GerarHash(senha, salt);

            string chave = SegurancaHelper.GerarChaveRecuperacao();
            string saltChave = SegurancaHelper.GerarSalt();
            string hashChave = SegurancaHelper.GerarHash(SegurancaHelper.NormalizarChave(chave), saltChave);

            using var con = Database.Abrir();
            using var cmd = con.CreateCommand();
            cmd.CommandText = @"
INSERT INTO usuarios (login, senha_hash, salt, recovery_hash, recovery_salt)
VALUES ('admin', @hash, @salt, @rhash, @rsalt)";
            cmd.Parameters.AddWithValue("@hash", hash);
            cmd.Parameters.AddWithValue("@salt", salt);
            cmd.Parameters.AddWithValue("@rhash", hashChave);
            cmd.Parameters.AddWithValue("@rsalt", saltChave);
            cmd.ExecuteNonQuery();

            return chave;
        }

        public static bool TemChaveRecuperacao()
        {
            using var con = Database.Abrir();
            using var cmd = con.CreateCommand();
            cmd.CommandText = @"
SELECT COUNT(*) FROM usuarios
WHERE login = 'admin' AND recovery_hash IS NOT NULL AND recovery_hash <> ''";
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        public static string GerarNovaChave()
        {
            string chave = SegurancaHelper.GerarChaveRecuperacao();
            string salt = SegurancaHelper.GerarSalt();
            string hash = SegurancaHelper.GerarHash(SegurancaHelper.NormalizarChave(chave), salt);

            using var con = Database.Abrir();
            using var cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE usuarios SET recovery_hash = @hash, recovery_salt = @salt WHERE login = 'admin'";
            cmd.Parameters.AddWithValue("@hash", hash);
            cmd.Parameters.AddWithValue("@salt", salt);
            cmd.ExecuteNonQuery();

            return chave;
        }

        public static ResultadoLogin Autenticar(string login, string senha,
            out int tentativasRestantes, out TimeSpan bloqueioRestante)
        {
            tentativasRestantes = MaxTentativas;
            bloqueioRestante = TimeSpan.Zero;

            using var con = Database.Abrir();

            int id;
            string hash;
            string salt;
            int tentativas;
            string? bloqueadoAte;

            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT id, senha_hash, salt, tentativas, bloqueado_ate FROM usuarios WHERE login = @login";
                cmd.Parameters.AddWithValue("@login", login);

                using var r = cmd.ExecuteReader();
                if (!r.Read())
                    return ResultadoLogin.SenhaIncorreta;

                id = r.GetInt32(0);
                hash = r.GetString(1);
                salt = r.GetString(2);
                tentativas = r.GetInt32(3);
                bloqueadoAte = r.IsDBNull(4) ? null : r.GetString(4);
            }

            if (bloqueadoAte != null &&
                DateTime.TryParseExact(bloqueadoAte, FormatoData, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out var fim) &&
                fim > DateTime.Now)
            {
                tentativasRestantes = 0;
                bloqueioRestante = fim - DateTime.Now;
                return ResultadoLogin.Bloqueado;
            }

            if (SegurancaHelper.Verificar(senha, salt, hash))
            {
                AtualizarTentativas(con, id, 0, null);
                return ResultadoLogin.Sucesso;
            }

            tentativas++;

            if (tentativas >= MaxTentativas)
            {
                string fimBloqueio = DateTime.Now.AddMinutes(MinutosBloqueio)
                    .ToString(FormatoData, CultureInfo.InvariantCulture);

                AtualizarTentativas(con, id, 0, fimBloqueio);
                tentativasRestantes = 0;
                bloqueioRestante = TimeSpan.FromMinutes(MinutosBloqueio);
                return ResultadoLogin.Bloqueado;
            }

            AtualizarTentativas(con, id, tentativas, null);
            tentativasRestantes = MaxTentativas - tentativas;
            return ResultadoLogin.SenhaIncorreta;
        }

        public static ResultadoLogin AlterarSenha(string senhaAtual, string novaSenha,
            out int tentativasRestantes, out TimeSpan bloqueioRestante)
        {
            var resultado = Autenticar("admin", senhaAtual, out tentativasRestantes, out bloqueioRestante);

            if (resultado == ResultadoLogin.Sucesso)
                DefinirSenha(novaSenha);

            return resultado;
        }

        public static bool RedefinirComChave(string chave, string novaSenha)
        {
            string normalizada = SegurancaHelper.NormalizarChave(chave);
            if (normalizada.Length == 0)
                return false;

            string? hash;
            string? salt;

            using (var con = Database.Abrir())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT recovery_hash, recovery_salt FROM usuarios WHERE login = 'admin'";

                using var r = cmd.ExecuteReader();
                if (!r.Read())
                    return false;

                hash = r.IsDBNull(0) ? null : r.GetString(0);
                salt = r.IsDBNull(1) ? null : r.GetString(1);
            }

            if (string.IsNullOrEmpty(hash) || string.IsNullOrEmpty(salt))
                return false;

            if (!SegurancaHelper.Verificar(normalizada, salt, hash))
                return false;

            DefinirSenha(novaSenha);
            return true;
        }

        private static void DefinirSenha(string novaSenha)
        {
            string salt = SegurancaHelper.GerarSalt();
            string hash = SegurancaHelper.GerarHash(novaSenha, salt);

            using var con = Database.Abrir();
            using var cmd = con.CreateCommand();
            cmd.CommandText = @"
UPDATE usuarios
SET senha_hash = @hash, salt = @salt, tentativas = 0, bloqueado_ate = NULL
WHERE login = 'admin'";
            cmd.Parameters.AddWithValue("@hash", hash);
            cmd.Parameters.AddWithValue("@salt", salt);
            cmd.ExecuteNonQuery();
        }

        private static void AtualizarTentativas(SqliteConnection con, int id, int tentativas, string? bloqueadoAte)
        {
            using var cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE usuarios SET tentativas = @tentativas, bloqueado_ate = @bloqueio WHERE id = @id";
            cmd.Parameters.AddWithValue("@tentativas", tentativas);
            cmd.Parameters.AddWithValue("@bloqueio", (object?)bloqueadoAte ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}