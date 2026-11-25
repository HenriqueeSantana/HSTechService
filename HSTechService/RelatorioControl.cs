using System.Globalization;

namespace HSTechService
{
    public partial class RelatorioControl : UserControl
    {
        private static readonly CultureInfo PtBr = new("pt-BR");

        private RelatorioMensal? relatorioAtual;

        public RelatorioControl()
        {
            InitializeComponent();
            Tema.Aplicar(this);
        }

        private void RelatorioControl_Load(object? sender, EventArgs e)
        {
            if (DesignMode)
                return;

            Carregar();
        }

        private void dtpMes_ValueChanged(object? sender, EventArgs e)
        {
            if (DesignMode)
                return;

            Carregar();
        }

        private void Carregar()
        {
            RelatorioMensal relatorio;

            try
            {
                relatorio = RelatorioRepository.Gerar(dtpMes.Value.Year, dtpMes.Value.Month);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar o relatório: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            relatorioAtual = relatorio;

            lblAbertasValor.Text = relatorio.Abertas.ToString();
            lblEntreguesValor.Text = relatorio.Entregues.ToString();
            lblFaturamentoValor.Text = "R$ " + relatorio.Faturamento.ToString("N2", PtBr);
            lblTicketValor.Text = "R$ " + relatorio.TicketMedio.ToString("N2", PtBr);

            dgvStatus.DataSource = relatorio.PorSituacao;
            dgvStatus.ClearSelection();

            dgvEntregues.DataSource = relatorio.Entregas;
            dgvEntregues.ClearSelection();

            lblTotalEntregues.Text = relatorio.Entregas.Count == 0
                ? "Nenhuma OS entregue neste mês."
                : $"{relatorio.Entregas.Count} OS entregues  |  Total: R$ {relatorio.Faturamento.ToString("N2", PtBr)}";

            btnImprimir.Enabled = true;
        }

        private void btnImprimir_Click(object? sender, EventArgs e)
        {
            if (relatorioAtual == null)
                return;

            RelatorioImpressao.Visualizar(FindForm(), relatorioAtual);
        }
    }
}