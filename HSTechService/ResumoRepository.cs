using System.Globalization;

namespace HSTechService
{
    public static class ResumoRepository
    {
        public static int TotalClientes()
        {
            return Contar("SELECT COUNT(*) FROM clientes");
        }

        public static int OsAbertas()
        {
            return Contar("SELECT COUNT(*) FROM ordens_servico WHERE status <> 'Entregue'");
        }

        public static int OsProntas()
        {
            return Contar("SELECT COUNT(*) FROM ordens_servico WHERE status = 'Pronto'");
        }

        public static int OsEntregues()
        {
            return Contar("SELECT COUNT(*) FROM ordens_servico WHERE status = 'Entregue'");
        }

        public static int OsAbertasEm(DateTime dia)
        {
            using var con = Database.Abrir();
            using var cmd = con.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM ordens_servico WHERE substr(data_entrada, 1, 10) = @dia";
            cmd.Parameters.AddWithValue("@dia", dia.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public static List<DateTime> DatasComOs()
        {
            var datas = new List<DateTime>();

            using var con = Database.Abrir();
            using var cmd = con.CreateCommand();
            cmd.CommandText = "SELECT DISTINCT substr(data_entrada, 1, 10) FROM ordens_servico";

            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                if (!r.IsDBNull(0) &&
                    DateTime.TryParseExact(r.GetString(0), "yyyy-MM-dd", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out var data))
                {
                    datas.Add(data);
                }
            }

            return datas;
        }

        private static int Contar(string sql)
        {
            using var con = Database.Abrir();
            using var cmd = con.CreateCommand();
            cmd.CommandText = sql;
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }
}