namespace HSTechService
{
    public enum ModoSenha
    {
        Alterar,
        Recuperar
    }

    public partial class FormSenha : Form
    {
        private readonly ModoSenha modo;

        public FormSenha() : this(ModoSenha.Alterar)
        {
        }

        public FormSenha(ModoSenha modo)
        {
            this.modo = modo;

            InitializeComponent();
            Tema.Aplicar(this);

            btnCancelar.BackColor = Tema.Branco;
            btnCancelar.ForeColor = Tema.Azul;
            btnCancelar.FlatAppearance.BorderColor = Tema.Cinza;
            btnCancelar.FlatAppearance.MouseOverBackColor = Color.FromArgb(235, 237, 241);

            ConfigurarModo();
        }

        private void ConfigurarModo()
        {
            if (modo == ModoSenha.Alterar)
            {
                Text = "Alterar senha";
                lblTitulo.Text = "Alterar senha";
                lblDescricao.Text = "Informe a senha atual e escolha uma nova senha.";
                lblCampoUm.Text = "Senha atual";
                txtCampoUm.UseSystemPasswordChar = true;
            }
            else
            {
                Text = "Recuperar senha";
                lblTitulo.Text = "Esqueci minha senha";
                lblDescricao.Text = "Digite a chave de recuperação gerada no primeiro acesso e escolha uma nova senha.";
                lblCampoUm.Text = "Chave de recuperação";
                txtCampoUm.UseSystemPasswordChar = false;
                txtCampoUm.CharacterCasing = CharacterCasing.Upper;
                txtCampoUm.PlaceholderText = "XXXX-XXXX-XXXX-XXXX";
            }
        }

        private void btnConfirmar_Click(object? sender, EventArgs e)
        {
            string nova = txtNova.Text;

            if (nova.Length < 6)
            {
                Aviso("A nova senha deve ter pelo menos 6 caracteres.");
                return;
            }

            if (nova != txtConfirmar.Text)
            {
                Aviso("As senhas não conferem.");
                return;
            }

            try
            {
                if (modo == ModoSenha.Alterar)
                    Alterar(nova);
                else
                    Recuperar(nova);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar a senha: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Alterar(string nova)
        {
            var resultado = UsuarioRepository.AlterarSenha(txtCampoUm.Text, nova,
                out int restantes, out TimeSpan bloqueio);

            switch (resultado)
            {
                case ResultadoLogin.Sucesso:
                    MessageBox.Show("Senha alterada com sucesso.", "Senha",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    break;

                case ResultadoLogin.Bloqueado:
                    Aviso($"Acesso bloqueado. Tente novamente em {Math.Ceiling(bloqueio.TotalMinutes):0} minuto(s).");
                    break;

                default:
                    Aviso($"Senha atual incorreta. Restam {restantes} tentativa(s).");
                    txtCampoUm.Clear();
                    txtCampoUm.Focus();
                    break;
            }
        }

        private void Recuperar(string nova)
        {
            if (!UsuarioRepository.RedefinirComChave(txtCampoUm.Text, nova))
            {
                Aviso("Chave de recuperação inválida.");
                txtCampoUm.Focus();
                return;
            }

            MessageBox.Show("Senha redefinida com sucesso. Entre com a nova senha.", "Senha",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
        }

        private void Aviso(string mensagem)
        {
            lblAviso.Text = mensagem;
        }
    }
}