namespace HSTechService
{
    public partial class ClientesControl : UserControl
    {
        private int clienteIdAtual = 0;

        public ClientesControl()
        {
            InitializeComponent();
            Tema.Aplicar(this);
        }

        private void ClientesControl_Load(object? sender, EventArgs e)
        {
            if (DesignMode)
                return;

            CarregarLista();
            LimparCampos();
        }

        private void CarregarLista()
        {
            dgvClientes.DataSource = ClienteRepository.Listar(txtBusca.Text.Trim());
            dgvClientes.ClearSelection();
        }

        private void LimparCampos()
        {
            clienteIdAtual = 0;
            txtNome.Clear();
            txtCpfCnpj.Clear();
            txtTelefone.Clear();
            txtWhatsApp.Clear();
            txtEmail.Clear();
            txtCidade.Clear();
            txtEndereco.Clear();
            txtNumero.Clear();
            txtBairro.Clear();
            btnExcluir.Enabled = false;
            txtNome.Focus();
        }

        private void btnNovo_Click(object? sender, EventArgs e)
        {
            LimparCampos();
            dgvClientes.ClearSelection();
        }

        private void btnSalvar_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Informe o nome do cliente.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return;
            }

            var cliente = new Cliente
            {
                Id = clienteIdAtual,
                Nome = txtNome.Text.Trim(),
                CpfCnpj = txtCpfCnpj.Text.Trim(),
                Telefone = txtTelefone.Text.Trim(),
                WhatsApp = txtWhatsApp.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Cidade = txtCidade.Text.Trim(),
                Endereco = txtEndereco.Text.Trim(),
                Numero = txtNumero.Text.Trim(),
                Bairro = txtBairro.Text.Trim()
            };

            try
            {
                if (clienteIdAtual == 0)
                    ClienteRepository.Inserir(cliente);
                else
                    ClienteRepository.Atualizar(cliente);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar o cliente: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CarregarLista();
            LimparCampos();
        }

        private void btnExcluir_Click(object? sender, EventArgs e)
        {
            if (clienteIdAtual == 0)
                return;

            try
            {
                string nome = txtNome.Text.Trim();
                int totalOs = ClienteRepository.ContarOrdens(clienteIdAtual);

                string mensagem = totalOs == 0
                    ? $"Deseja excluir o cliente \"{nome}\"?"
                    : $"O cliente \"{nome}\" possui {totalOs} ordem(ns) de serviço.\n\n" +
                      "Ao excluir, o cliente, os equipamentos e todas as OS dele serão apagados e não poderão ser recuperados.\n\n" +
                      "Deseja continuar?";

                var resposta = MessageBox.Show(mensagem, "Confirmar exclusão",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (resposta != DialogResult.Yes)
                    return;

                ClienteRepository.Excluir(clienteIdAtual);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir o cliente: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CarregarLista();
            LimparCampos();
        }

        private void txtBusca_TextChanged(object? sender, EventArgs e)
        {
            CarregarLista();
        }

        private void dgvClientes_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvClientes.Rows[e.RowIndex].DataBoundItem is not Cliente c)
                return;

            clienteIdAtual = c.Id;
            txtNome.Text = c.Nome;
            txtCpfCnpj.Text = c.CpfCnpj;
            txtTelefone.Text = c.Telefone;
            txtWhatsApp.Text = c.WhatsApp;
            txtEmail.Text = c.Email;
            txtCidade.Text = c.Cidade;
            txtEndereco.Text = c.Endereco;
            txtNumero.Text = c.Numero;
            txtBairro.Text = c.Bairro;
            btnExcluir.Enabled = true;
        }
    }
}