namespace HSTechService
{
    public partial class NovaOsControl : UserControl
    {
        private Cliente? clienteSelecionado;
        private readonly Font fonteStatus;

        public event EventHandler? NovoClienteSolicitado;

        public NovaOsControl()
        {
            InitializeComponent();
            Tema.Aplicar(this);

            fonteStatus = new Font(dgvHistorico.Font, FontStyle.Bold);
            Disposed += (s, e) => fonteStatus.Dispose();
        }

        private void NovaOsControl_Load(object? sender, EventArgs e)
        {
            if (DesignMode)
                return;

            CarregarClientes();
            LimparCampos();
        }

        private void CarregarClientes()
        {
            dgvClientes.DataSource = ClienteRepository.Listar(txtBuscaCliente.Text.Trim());
            dgvClientes.ClearSelection();
        }

        private void AtualizarSelecionado()
        {
            if (clienteSelecionado == null)
            {
                lblSelecionado.Text = "Nenhum cliente selecionado. Busque e clique no cliente na lista.";
                return;
            }

            var partes = new List<string> { clienteSelecionado.Nome };

            if (clienteSelecionado.CpfCnpj.Length > 0)
                partes.Add("CPF/CNPJ: " + clienteSelecionado.CpfCnpj);

            if (clienteSelecionado.Telefone.Length > 0)
                partes.Add("Tel: " + clienteSelecionado.Telefone);

            if (clienteSelecionado.EnderecoCompleto.Length > 0)
                partes.Add(clienteSelecionado.EnderecoCompleto);

            lblSelecionado.Text = "Selecionado:  " + string.Join("   |   ", partes);
        }

        private void CarregarHistorico()
        {
            if (clienteSelecionado == null)
            {
                dgvHistorico.DataSource = null;
                lblHistorico.Text = "Selecione um cliente para ver as OS anteriores.";
                btnUsarEquip.Enabled = false;
                return;
            }

            List<OrdemServico> ordens;

            try
            {
                ordens = OrdemServicoRepository.ListarPorCliente(clienteSelecionado.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar o histórico do cliente: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvHistorico.DataSource = ordens;
            dgvHistorico.ClearSelection();

            if (ordens.Count == 0)
            {
                lblHistorico.Text = "Este cliente ainda não tem nenhuma OS.";
                return;
            }

            int emAndamento = ordens.Count(o => o.Status != "Entregue");

            lblHistorico.Text = ordens.Count == 1
                ? $"Este cliente já tem 1 OS ({emAndamento} em andamento). Selecione para reutilizar os dados do equipamento."
                : $"Este cliente já tem {ordens.Count} OS ({emAndamento} em andamento). Selecione uma para reutilizar os dados do equipamento.";
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

        private void LimparCampos()
        {
            clienteSelecionado = null;
            txtBuscaCliente.Clear();
            AtualizarSelecionado();
            CarregarHistorico();

            cmbTipo.SelectedIndex = 0;
            txtMarca.Clear();
            txtModelo.Clear();
            txtSerie.Clear();
            txtSenha.Clear();
            txtProcessador.Clear();
            txtMemoria.Clear();
            txtArmazenamento.Clear();
            txtAcessorios.Clear();
            txtObs.Clear();
            txtDefeito.Clear();

            for (int i = 0; i < clbDefeitos.Items.Count; i++)
                clbDefeitos.SetItemChecked(i, false);
        }

        private string MontarDefeito()
        {
            var marcados = clbDefeitos.CheckedItems.Cast<object>().Select(o => o.ToString() ?? "");
            string defeito = string.Join("; ", marcados);
            string detalhes = txtDefeito.Text.Trim();

            if (detalhes.Length > 0)
                defeito += (defeito.Length > 0 ? ". " : "") + detalhes;

            return defeito;
        }

        private void txtBuscaCliente_TextChanged(object? sender, EventArgs e)
        {
            CarregarClientes();
        }

        private void dgvClientes_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvClientes.Rows[e.RowIndex].DataBoundItem is not Cliente c)
                return;

            clienteSelecionado = c;
            AtualizarSelecionado();
            CarregarHistorico();
        }

        private void dgvHistorico_SelectionChanged(object? sender, EventArgs e)
        {
            btnUsarEquip.Enabled = dgvHistorico.SelectedRows.Count > 0;
        }

        private void dgvHistorico_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colHStatus.Index || e.CellStyle == null)
                return;

            Color cor = CorStatus(e.Value?.ToString() ?? "");
            e.CellStyle.ForeColor = cor;
            e.CellStyle.SelectionForeColor = cor;
            e.CellStyle.Font = fonteStatus;
        }

        private void btnUsarEquip_Click(object? sender, EventArgs e)
        {
            if (dgvHistorico.SelectedRows.Count == 0 ||
                dgvHistorico.SelectedRows[0].DataBoundItem is not OrdemServico os)
                return;

            int indiceTipo = cmbTipo.FindStringExact(os.Tipo);
            cmbTipo.SelectedIndex = indiceTipo >= 0 ? indiceTipo : cmbTipo.FindStringExact("Outro");

            txtMarca.Text = os.Marca;
            txtModelo.Text = os.Modelo;
            txtSerie.Text = os.NumeroSerie;
            txtSenha.Text = os.Senha;
            txtProcessador.Text = os.Processador;
            txtMemoria.Text = os.Memoria;
            txtArmazenamento.Text = os.Armazenamento;
            txtAcessorios.Text = os.Acessorios;
            txtObs.Text = os.Observacoes;

            clbDefeitos.Focus();
        }

        private void btnNovoCliente_Click(object? sender, EventArgs e)
        {
            NovoClienteSolicitado?.Invoke(this, EventArgs.Empty);
        }

        private void btnSalvar_Click(object? sender, EventArgs e)
        {
            if (clienteSelecionado == null)
            {
                MessageBox.Show(
                    "Busque e clique no cliente na lista. Se ele ainda não está cadastrado, use o botão Cadastrar novo cliente.",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBuscaCliente.Focus();
                return;
            }

            string defeito = MontarDefeito();
            if (defeito.Length == 0)
            {
                MessageBox.Show("Marque ou descreva o defeito relatado.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                clbDefeitos.Focus();
                return;
            }

            var equipamento = new Equipamento
            {
                Tipo = cmbTipo.Text,
                Marca = txtMarca.Text.Trim(),
                Modelo = txtModelo.Text.Trim(),
                NumeroSerie = txtSerie.Text.Trim(),
                Senha = txtSenha.Text.Trim(),
                Processador = txtProcessador.Text.Trim(),
                Memoria = txtMemoria.Text.Trim(),
                Armazenamento = txtArmazenamento.Text.Trim(),
                Acessorios = txtAcessorios.Text.Trim(),
                Observacoes = txtObs.Text.Trim()
            };

            int numero;

            try
            {
                numero = OrdemServicoRepository.Criar(clienteSelecionado.Id, equipamento, defeito);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir a OS: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LimparCampos();

            var resposta = MessageBox.Show(
                $"OS nº {numero:D5} aberta com sucesso.\n\nDeseja imprimir a OS para o cliente assinar?",
                "Ordem de serviço", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resposta != DialogResult.Yes)
                return;

            try
            {
                var os = OrdemServicoRepository.BuscarPorId(numero);

                if (os != null)
                    OsImpressao.Visualizar(FindForm(), os);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao preparar a impressão: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click(object? sender, EventArgs e)
        {
            LimparCampos();
        }
    }
}