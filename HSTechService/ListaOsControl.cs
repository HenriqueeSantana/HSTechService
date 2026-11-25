using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace HSTechService
{
    public partial class ListaOsControl : UserControl
    {
        private static readonly CultureInfo PtBr = new("pt-BR");

        private OrdemServico? osAtual;
        private readonly Font fonteStatus;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FiltroInicial { get; set; } = "Todos";

        public ListaOsControl()
        {
            InitializeComponent();
            Tema.Aplicar(this);

            fonteStatus = new Font(dgvOs.Font, FontStyle.Bold);
            Disposed += (s, e) => fonteStatus.Dispose();
        }

        private void ListaOsControl_Load(object? sender, EventArgs e)
        {
            if (DesignMode)
                return;

            LimparDetalhe();

            int indice = cmbFiltroStatus.FindStringExact(FiltroInicial);
            cmbFiltroStatus.SelectedIndex = indice >= 0 ? indice : 0;
        }

        private void CarregarLista(int manterId = 0)
        {
            string status = cmbFiltroStatus.SelectedItem?.ToString() ?? "Todos";

            List<OrdemServico> lista;
            try
            {
                lista = OrdemServicoRepository.Listar(txtBusca.Text.Trim(), status);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar as OS: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvOs.DataSource = lista;
            dgvOs.ClearSelection();
            lblTotal.Text = lista.Count == 1 ? "1 OS" : $"{lista.Count} OS";

            var os = manterId > 0 ? lista.FirstOrDefault(o => o.Id == manterId) : null;

            if (os == null)
            {
                LimparDetalhe();
                return;
            }

            foreach (DataGridViewRow linha in dgvOs.Rows)
            {
                if (linha.DataBoundItem is OrdemServico item && item.Id == os.Id)
                {
                    linha.Selected = true;
                    dgvOs.CurrentCell = linha.Cells[colNumero.Index];
                    break;
                }
            }

            MostrarDetalhe(os);
        }

        private void MostrarDetalhe(OrdemServico os)
        {
            osAtual = os;
            txtResumo.Text = MontarResumo(os);

            cmbStatusOs.SelectedIndex = cmbStatusOs.FindStringExact(os.Status);
            txtValor.Text = os.Valor.ToString("N2", PtBr);
            txtLaudo.Text = os.Laudo;

            cmbStatusOs.Enabled = true;
            txtValor.Enabled = true;
            txtLaudo.Enabled = true;
            btnSalvar.Enabled = true;
            btnExcluir.Enabled = true;
            btnImprimir.Enabled = true;
            btnWhatsApp.Enabled = true;

            txtItem.Enabled = true;
            nudQtd.Enabled = true;
            btnAddItem.Enabled = true;
            lstItens.Enabled = true;
            CarregarItens();
        }

        private void CarregarItens()
        {
            lstItens.Items.Clear();
            btnRemoverItem.Enabled = false;

            if (osAtual == null)
                return;

            try
            {
                foreach (var item in ItemOsRepository.Listar(osAtual.Id))
                    lstItens.Items.Add(item);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os serviços e peças: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparDetalhe()
        {
            osAtual = null;
            txtResumo.Text = "Selecione uma OS na lista para ver os detalhes.";
            cmbStatusOs.SelectedIndex = -1;
            txtValor.Clear();
            txtLaudo.Clear();

            cmbStatusOs.Enabled = false;
            txtValor.Enabled = false;
            txtLaudo.Enabled = false;
            btnSalvar.Enabled = false;
            btnExcluir.Enabled = false;
            btnImprimir.Enabled = false;
            btnWhatsApp.Enabled = false;

            txtItem.Clear();
            nudQtd.Value = 1;
            lstItens.Items.Clear();
            txtItem.Enabled = false;
            nudQtd.Enabled = false;
            btnAddItem.Enabled = false;
            lstItens.Enabled = false;
            btnRemoverItem.Enabled = false;
        }

        private static string MontarResumo(OrdemServico os)
        {
            var sb = new StringBuilder();
            string nl = Environment.NewLine;

            sb.AppendLine($"OS nº {os.Numero}  -  entrada em {os.DataEntradaFormatada}");

            if (os.DataEntrega.Length > 0)
                sb.AppendLine($"Entregue em {os.DataEntregaFormatada}");

            sb.AppendLine();
            sb.AppendLine("CLIENTE");
            sb.AppendLine(os.ClienteNome);

            if (os.Telefone.Length > 0)
                sb.AppendLine("Telefone: " + os.Telefone);

            if (os.WhatsApp.Length > 0)
                sb.AppendLine("WhatsApp: " + os.WhatsApp);

            sb.AppendLine();
            sb.AppendLine("EQUIPAMENTO");
            sb.AppendLine(os.EquipamentoResumo);

            if (os.NumeroSerie.Length > 0)
                sb.AppendLine("Nº de série: " + os.NumeroSerie);

            if (os.Senha.Length > 0)
                sb.AppendLine("Senha: " + os.Senha);

            if (os.Processador.Length > 0)
                sb.AppendLine("Processador: " + os.Processador);

            if (os.Memoria.Length > 0)
                sb.AppendLine("Memória: " + os.Memoria);

            if (os.Armazenamento.Length > 0)
                sb.AppendLine("Armazenamento: " + os.Armazenamento);

            if (os.Acessorios.Length > 0)
                sb.AppendLine("Acessórios: " + os.Acessorios);

            if (os.Observacoes.Length > 0)
                sb.AppendLine("Observações: " + os.Observacoes);

            sb.AppendLine();
            sb.AppendLine("DEFEITO RELATADO");
            sb.Append(os.DefeitoRelatado);

            return sb.ToString().Replace("\r\n", nl);
        }

        private static Color CorStatus(string status)
        {
            return status switch
            {
                "Aguardando" => Color.FromArgb(202, 138, 4),
                "Em análise" => Color.FromArgb(37, 99, 235),
                "Aguardando peça" => Color.FromArgb(234, 88, 12),
                "Pronto" => Color.FromArgb(22, 163, 74),
                "Entregue" => Color.FromArgb(107, 114, 128),
                _ => Tema.Texto
            };
        }

        private void cmbFiltroStatus_SelectedIndexChanged(object? sender, EventArgs e)
        {
            CarregarLista();
        }

        private void txtBusca_TextChanged(object? sender, EventArgs e)
        {
            CarregarLista();
        }

        private void dgvOs_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvOs.Rows[e.RowIndex].DataBoundItem is not OrdemServico os)
                return;

            MostrarDetalhe(os);
        }

        private void dgvOs_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colStatus.Index || e.CellStyle == null)
                return;

            Color cor = CorStatus(e.Value?.ToString() ?? "");
            e.CellStyle.ForeColor = cor;
            e.CellStyle.SelectionForeColor = cor;
            e.CellStyle.Font = fonteStatus;
        }

        private void txtItem_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.SuppressKeyPress = true;
            btnAddItem.PerformClick();
        }

        private void btnAddItem_Click(object? sender, EventArgs e)
        {
            if (osAtual == null)
                return;

            string descricao = txtItem.Text.Trim();

            if (descricao.Length == 0)
            {
                MessageBox.Show("Digite o serviço ou a peça, por exemplo: Formatação.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtItem.Focus();
                return;
            }

            try
            {
                ItemOsRepository.Adicionar(osAtual.Id, descricao, (int)nudQtd.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar o item: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtItem.Clear();
            nudQtd.Value = 1;
            CarregarItens();
            txtItem.Focus();
        }

        private void lstItens_SelectedIndexChanged(object? sender, EventArgs e)
        {
            btnRemoverItem.Enabled = osAtual != null && lstItens.SelectedItem != null;
        }

        private void btnRemoverItem_Click(object? sender, EventArgs e)
        {
            if (lstItens.SelectedItem is not OsItem item)
                return;

            try
            {
                ItemOsRepository.Remover(item.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao remover o item: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CarregarItens();
        }

        private void btnSalvar_Click(object? sender, EventArgs e)
        {
            if (osAtual == null)
                return;

            if (cmbStatusOs.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione o status da OS.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStatusOs.Focus();
                return;
            }

            double valor = 0;
            string textoValor = txtValor.Text.Replace("R$", "").Trim();

            if (textoValor.Length > 0)
            {
                if (!double.TryParse(textoValor, NumberStyles.Number, PtBr, out valor) || valor < 0)
                {
                    MessageBox.Show("Informe um valor válido, por exemplo: 150,00", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtValor.Focus();
                    return;
                }
            }

            try
            {
                OrdemServicoRepository.Atualizar(osAtual.Id, cmbStatusOs.Text, txtLaudo.Text.Trim(), valor);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar a OS: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id = osAtual.Id;
            CarregarLista(id);

            MessageBox.Show($"OS nº {id:D5} atualizada com sucesso.", "Ordem de serviço",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExcluir_Click(object? sender, EventArgs e)
        {
            if (osAtual == null)
                return;

            var resposta = MessageBox.Show(
                $"Deseja excluir a OS nº {osAtual.Numero} de \"{osAtual.ClienteNome}\"?\n\n" +
                "A OS e o equipamento dela serão apagados e não poderão ser recuperados.",
                "Confirmar exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (resposta != DialogResult.Yes)
                return;

            try
            {
                OrdemServicoRepository.Excluir(osAtual.Id, osAtual.EquipamentoId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir a OS: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CarregarLista();
        }

        private void btnWhatsApp_Click(object? sender, EventArgs e)
        {
            if (osAtual == null)
                return;

            if (cmbStatusOs.Text != osAtual.Status)
            {
                MessageBox.Show(
                    "O status da OS foi alterado na tela, mas ainda não foi salvo.\n\n" +
                    "Clique em Salvar alterações antes de avisar o cliente, para a mensagem sair com o status correto.",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            WhatsAppHelper.Avisar(FindForm(), osAtual);
        }

        private void btnImprimir_Click(object? sender, EventArgs e)
        {
            if (osAtual == null)
                return;

            OsImpressao.Visualizar(FindForm(), osAtual);
        }
    }
}