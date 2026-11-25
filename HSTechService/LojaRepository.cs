namespace HSTechService
{
    public static class LojaRepository
    {
        public static Loja Carregar()
        {
            var dados = new Dictionary<string, string>();

            using (var con = Database.Abrir())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT chave, valor FROM configuracoes WHERE chave LIKE 'loja%'";

                using var r = cmd.ExecuteReader();
                while (r.Read())
                    dados[r.GetString(0)] = r.GetString(1);
            }

            string Pegar(string chave, string padrao = "")
            {
                return dados.TryGetValue(chave, out var valor) && !string.IsNullOrWhiteSpace(valor)
                    ? valor
                    : padrao;
            }

            return new Loja
            {
                Nome = Pegar("loja_nome", Loja.NomePadrao),
                Subtitulo = Pegar("loja_subtitulo", Loja.SubtituloPadrao),
                Cnpj = Pegar("loja_cnpj"),
                Telefone = Pegar("loja_telefone"),
                WhatsApp = Pegar("loja_whatsapp"),
                Email = Pegar("loja_email"),
                Endereco = Pegar("loja_endereco"),
                LogoBase64 = Pegar("loja_logo")
            };
        }

        public static void Salvar(Loja loja)
        {
            using var con = Database.Abrir();
            using var tx = con.BeginTransaction();

            void Gravar(string chave, string valor)
            {
                using var cmd = con.CreateCommand();
                cmd.Transaction = tx;
                cmd.CommandText = @"
INSERT INTO configuracoes (chave, valor) VALUES (@chave, @valor)
ON CONFLICT(chave) DO UPDATE SET valor = excluded.valor";
                cmd.Parameters.AddWithValue("@chave", chave);
                cmd.Parameters.AddWithValue("@valor", valor);
                cmd.ExecuteNonQuery();
            }

            Gravar("loja_nome", loja.Nome);
            Gravar("loja_subtitulo", loja.Subtitulo);
            Gravar("loja_cnpj", loja.Cnpj);
            Gravar("loja_telefone", loja.Telefone);
            Gravar("loja_whatsapp", loja.WhatsApp);
            Gravar("loja_email", loja.Email);
            Gravar("loja_endereco", loja.Endereco);
            Gravar("loja_logo", loja.LogoBase64);

            tx.Commit();
        }
    }
}