using System.Globalization;

namespace HSTechService
{
    public partial class HomeControl : UserControl
    {
        private static readonly CultureInfo PtBr = new("pt-BR");

        public HomeControl()
        {
            InitializeComponent();
            Tema.Aplicar(this);
        }

        private void HomeControl_Load(object? sender, EventArgs e)
        {
            if (DesignMode)
                return;

            AtualizarRelogio();

            try
            {
                lblNumClientes.Text = ResumoRepository.TotalClientes().ToString();
                lblNumAbertas.Text = ResumoRepository.OsAbertas().ToString();
                lblNumProntas.Text = ResumoRepository.OsProntas().ToString();
                lblNumEntregues.Text = ResumoRepository.OsEntregues().ToString();

                calendario.BoldedDates = ResumoRepository.DatasComOs().ToArray();
                calendario.UpdateBoldedDates();

                MostrarDia(calendario.SelectionStart);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar o painel: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarRelogio()
        {
            var agora = DateTime.Now;

            string dia = agora.ToString("dddd", PtBr);

            lblHora.Text = agora.ToString("HH:mm:ss");
            lblDiaSemana.Text = char.ToUpper(dia[0], PtBr) + dia.Substring(1);
            lblDataCompleta.Text = agora.ToString("dd 'de' MMMM 'de' yyyy", PtBr);
        }

        private void MostrarDia(DateTime dia)
        {
            int total = ResumoRepository.OsAbertasEm(dia);
            string data = dia.ToString("dd/MM/yyyy");

            lblDiaInfo.Text = total switch
            {
                0 => $"Nenhuma OS aberta em {data}.",
                1 => $"1 OS aberta em {data}.",
                _ => $"{total} OS abertas em {data}."
            };
        }

        private void timerRelogio_Tick(object? sender, EventArgs e)
        {
            AtualizarRelogio();
        }

        private void calendario_DateSelected(object? sender, DateRangeEventArgs e)
        {
            try
            {
                MostrarDia(e.Start);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar o dia: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}