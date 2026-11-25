using Microsoft.Data.Sqlite;

namespace HSTechService
{
    public static class ClienteRepository
    {
        public static List<Cliente> Listar(string busca = "")
        {
            var lista = new List<Cliente>();

            using var con = Database.Abrir();
            using var cmd = con.CreateCommand();
            cmd.CommandText = @"
SELECT id, nome, cpf_cnpj, telefone, whatsapp, email, endereco, numero, bairro, cidade, data_cadastro
FROM clientes
WHERE nome LIKE @busca OR cpf_cnpj LIKE @busca OR telefone LIKE @busca OR whatsapp LIKE @busca
ORDER BY nome";
            cmd.Parameters.AddWithValue("@busca", "%" + busca + "%");

            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                lista.Add(new Cliente
                {
                    Id = r.GetInt32(0),
                    Nome = Texto(r, 1),
                    CpfCnpj = Texto(r, 2),
                    Telefone = Texto(r, 3),
                    WhatsApp = Texto(r, 4),
                    Email = Texto(r, 5),
                    Endereco = Texto(r, 6),
                    Numero = Texto(r, 7),
                    Bairro = Texto(r, 8),
                    Cidade = Texto(r, 9),
                    DataCadastro = Texto(r, 10)
                });
            }

            return lista;
        }

        public static void Inserir(Cliente c)
        {
            using var con = Database.Abrir();
            using var cmd = con.CreateCommand();
            cmd.CommandText = @"
INSERT INTO clientes (nome, cpf_cnpj, telefone, whatsapp, email, endereco, numero, bairro, cidade, data_cadastro)
VALUES (@nome, @cpf, @telefone, @whatsapp, @email, @endereco, @numero, @bairro, @cidade, @data)";
            AdicionarParametros(cmd, c);
            cmd.Parameters.AddWithValue("@data", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.ExecuteNonQuery();
        }

        public static void Atualizar(Cliente c)
        {
            using var con = Database.Abrir();
            using var cmd = con.CreateCommand();
            cmd.CommandText = @"
UPDATE clientes SET
    nome = @nome,
    cpf_cnpj = @cpf,
    telefone = @telefone,
    whatsapp = @whatsapp,
    email = @email,
    endereco = @endereco,
    numero = @numero,
    bairro = @bairro,
    cidade = @cidade
WHERE id = @id";
            AdicionarParametros(cmd, c);
            cmd.Parameters.AddWithValue("@id", c.Id);
            cmd.ExecuteNonQuery();
        }

        public static int ContarOrdens(int clienteId)
        {
            using var con = Database.Abrir();
            using var cmd = con.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM ordens_servico WHERE cliente_id = @id";
            cmd.Parameters.AddWithValue("@id", clienteId);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public static void Excluir(int clienteId)
        {
            using var con = Database.Abrir();
            using var tx = con.BeginTransaction();

            Executar(con, tx, "DELETE FROM ordens_servico WHERE cliente_id = @id", clienteId);
            Executar(con, tx, "DELETE FROM equipamentos WHERE cliente_id = @id", clienteId);
            Executar(con, tx, "DELETE FROM clientes WHERE id = @id", clienteId);

            tx.Commit();
        }

        private static void Executar(SqliteConnection con, SqliteTransaction tx, string sql, int id)
        {
            using var cmd = con.CreateCommand();
            cmd.Transaction = tx;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        private static void AdicionarParametros(SqliteCommand cmd, Cliente c)
        {
            cmd.Parameters.AddWithValue("@nome", c.Nome);
            cmd.Parameters.AddWithValue("@cpf", c.CpfCnpj);
            cmd.Parameters.AddWithValue("@telefone", c.Telefone);
            cmd.Parameters.AddWithValue("@whatsapp", c.WhatsApp);
            cmd.Parameters.AddWithValue("@email", c.Email);
            cmd.Parameters.AddWithValue("@endereco", c.Endereco);
            cmd.Parameters.AddWithValue("@numero", c.Numero);
            cmd.Parameters.AddWithValue("@bairro", c.Bairro);
            cmd.Parameters.AddWithValue("@cidade", c.Cidade);
        }

        private static string Texto(SqliteDataReader r, int indice)
        {
            return r.IsDBNull(indice) ? "" : r.GetString(indice);
        }
    }
}