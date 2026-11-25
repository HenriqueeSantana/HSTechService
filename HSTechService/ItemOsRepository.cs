namespace HSTechService
{
    public static class ItemOsRepository
    {
        public static List<OsItem> Listar(int osId)
        {
            var lista = new List<OsItem>();

            using var con = Database.Abrir();
            using var cmd = con.CreateCommand();
            cmd.CommandText = "SELECT id, os_id, descricao, quantidade FROM os_itens WHERE os_id = @os ORDER BY id";
            cmd.Parameters.AddWithValue("@os", osId);

            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                lista.Add(new OsItem
                {
                    Id = r.GetInt32(0),
                    OsId = r.GetInt32(1),
                    Descricao = r.GetString(2),
                    Quantidade = r.GetInt32(3)
                });
            }

            return lista;
        }

        public static void Adicionar(int osId, string descricao, int quantidade)
        {
            using var con = Database.Abrir();
            using var cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO os_itens (os_id, descricao, quantidade) VALUES (@os, @descricao, @quantidade)";
            cmd.Parameters.AddWithValue("@os", osId);
            cmd.Parameters.AddWithValue("@descricao", descricao);
            cmd.Parameters.AddWithValue("@quantidade", quantidade);
            cmd.ExecuteNonQuery();
        }

        public static void Remover(int itemId)
        {
            using var con = Database.Abrir();
            using var cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM os_itens WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", itemId);
            cmd.ExecuteNonQuery();
        }
    }
}