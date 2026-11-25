using System.Globalization;

namespace HSTechService
{
    public static class RelatorioRepository
    {
        private const string Formato = "yyyy-MM-dd HH:mm:ss";

        private static readonly string[] OrdemSituacoes =
        {
            "Aguardando", "Em análise", "Aguardando peça", "Pronto", "Entregue"
        };

        public static RelatorioMensal Gerar(int ano, int mes)
        {
            var inicio = new DateTime(ano, mes, 1);
            string ini = inicio.ToString(Formato, CultureInfo.InvariantCulture);
            string fim = inicio.AddMonths(1).ToString(Formato, CultureInfo.InvariantCulture);

            var relatorio = new RelatorioMensal { Mes = inicio };

            using var con = Database.Abrir();

            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT(*) FROM ordens_servico WHERE data_entrada >= @ini AND data_entrada < @fim";
                cmd.Parameters.AddWithValue("@ini", ini);
                cmd.Parameters.AddWithValue("@fim", fim);
                relatorio.Abertas = Convert.ToInt32(cmd.ExecuteScalar());
            }

            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = @"
SELECT COUNT(*), COALESCE(SUM(valor), 0)
FROM ordens_servico
WHERE data_entrega IS NOT NULL AND data_entrega >= @ini AND data_entrega < @fim";
                cmd.Parameters.AddWithValue("@ini", ini);
                cmd.Parameters.AddWithValue("@fim", fim);

                using var r = cmd.ExecuteReader();
                if (r.Read())
                {
                    relatorio.Entregues = r.GetInt32(0);
                    relatorio.Faturamento = r.GetDouble(1);
                }
            }

            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = @"
SELECT status, COUNT(*)
FROM ordens_servico
WHERE data_entrada >= @ini AND data_entrada < @fim
GROUP BY status";
                cmd.Parameters.AddWithValue("@ini", ini);
                cmd.Parameters.AddWithValue("@fim", fim);

                using var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    relatorio.PorSituacao.Add(new SituacaoQuantidade
                    {
                        Situacao = r.GetString(0),
                        Quantidade = r.GetInt32(1)
                    });
                }
            }

            relatorio.PorSituacao = relatorio.PorSituacao
                .OrderBy(s =>
                {
                    int indice = Array.IndexOf(OrdemSituacoes, s.Situacao);
                    return indice < 0 ? int.MaxValue : indice;
                })
                .ToList();

            relatorio.Entregas = OrdemServicoRepository.ListarEntreguesNoPeriodo(ini, fim);

            return relatorio;
        }
    }
}