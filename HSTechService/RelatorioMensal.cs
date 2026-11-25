using System.Globalization;

namespace HSTechService
{
    public class SituacaoQuantidade
    {
        public string Situacao { get; set; } = "";
        public int Quantidade { get; set; }
    }

    public class RelatorioMensal
    {
        private static readonly CultureInfo PtBr = new("pt-BR");

        public DateTime Mes { get; set; }
        public int Abertas { get; set; }
        public int Entregues { get; set; }
        public double Faturamento { get; set; }
        public List<SituacaoQuantidade> PorSituacao { get; set; } = new();
        public List<OrdemServico> Entregas { get; set; } = new();

        public double TicketMedio => Entregues > 0 ? Faturamento / Entregues : 0;

        public string MesTexto
        {
            get
            {
                string texto = Mes.ToString("MMMM 'de' yyyy", PtBr);
                return char.ToUpper(texto[0], PtBr) + texto[1..];
            }
        }
    }
}