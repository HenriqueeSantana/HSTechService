using System.Diagnostics;

namespace HSTechService
{
    public partial class FormPrincipal : Form
    {
        private static readonly Color CorMenu = Color.FromArgb(10, 25, 47);
        private static readonly Color CorMenuAtivo = Color.FromArgb(25, 55, 100);

        private Button? botaoAtivo;

        public FormPrincipal()
        {
            InitializeComponent();
            menuPrincipal.Renderer = new TemaMenuRenderer();
        }

        private void FormPrincipal_Load(object? sender, EventArgs e)
        {
            AtualizarRelogio();
            AbrirHome();
            OferecerChaveRecuperacao();
        }

        private void FormPrincipal_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing)
                return;

            var resposta = MessageBox.Show("Deseja realmente sair do sistema?", "Sair",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resposta != DialogResult.Yes)
                e.Cancel = true;
        }

        private void FormPrincipal_FormClosed(object? sender, FormClosedEventArgs e)
        {
            Database.BackupAutomatico();
        }

        private void OferecerChaveRecuperacao()
        {
            try
            {
                if (UsuarioRepository.TemChaveRecuperacao())
                    return;

                var resposta = MessageBox.Show(
                    "Sua conta ainda não tem uma chave de recuperação de senha. " +
                    "Ela permite redefinir a senha caso você a esqueça.\n\nDeseja gerar a chave agora?",
                    "Chave de recuperação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resposta == DialogResult.Yes)
                    SegurancaHelper.MostrarChaveRecuperacao(this, UsuarioRepository.GerarNovaChave());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao verificar a chave de recuperação: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarRelogio()
        {
            tslRelogio.Text = DateTime.Now.ToString("dd/MM/yyyy  HH:mm");
        }

        private void timerRelogio_Tick(object? sender, EventArgs e)
        {
            AtualizarRelogio();
        }

        private void AbrirModulo(UserControl controle, Button botao)
        {
            var antigos = pnlConteudo.Controls.Cast<Control>().ToList();
            pnlConteudo.Controls.Clear();
            foreach (var c in antigos)
                c.Dispose();

            controle.Dock = DockStyle.Fill;
            pnlConteudo.Controls.Add(controle);

            if (botaoAtivo != null)
                botaoAtivo.BackColor = CorMenu;

            botao.BackColor = CorMenuAtivo;
            botaoAtivo = botao;

            pnlIndicador.Top = botao.Top;
            pnlIndicador.BringToFront();
        }

        private void AbrirHome()
        {
            AbrirModulo(new HomeControl(), btnHome);
        }

        private void AbrirClientes()
        {
            AbrirModulo(new ClientesControl(), btnClientes);
        }

        private void AbrirNovaOs()
        {
            var nova = new NovaOsControl();
            nova.NovoClienteSolicitado += (s, ev) => AbrirClientes();
            AbrirModulo(nova, btnNovaOS);
        }

        private void AbrirListaOs(string filtro = "Todos")
        {
            AbrirModulo(new ListaOsControl { FiltroInicial = filtro }, btnListaOS);
        }

        private void AbrirRelatorio()
        {
            AbrirModulo(new RelatorioControl(), btnRelatorios);
        }

        private void btnHome_Click(object? sender, EventArgs e)
        {
            AbrirHome();
        }

        private void btnClientes_Click(object? sender, EventArgs e)
        {
            AbrirClientes();
        }

        private void btnNovaOS_Click(object? sender, EventArgs e)
        {
            AbrirNovaOs();
        }

        private void btnListaOS_Click(object? sender, EventArgs e)
        {
            AbrirListaOs();
        }

        private void btnRelatorios_Click(object? sender, EventArgs e)
        {
            AbrirRelatorio();
        }

        private void miRelatorioMensal_Click(object? sender, EventArgs e)
        {
            AbrirRelatorio();
        }

        private void btnSair_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void miNovaOS_Click(object? sender, EventArgs e)
        {
            AbrirNovaOs();
        }

        private void miNovoCliente_Click(object? sender, EventArgs e)
        {
            AbrirClientes();
        }

        private void miGerenciarClientes_Click(object? sender, EventArgs e)
        {
            AbrirClientes();
        }

        private void miTodasOS_Click(object? sender, EventArgs e)
        {
            AbrirListaOs();
        }

        private void miStatus_Click(object? sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem item && item.Tag is string status)
                AbrirListaOs(status);
        }

        private void miPainel_Click(object? sender, EventArgs e)
        {
            AbrirHome();
        }

        private void miSair_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void miBackup_Click(object? sender, EventArgs e)
        {
            dlgBackup.FileName = $"HSTechService-backup-{DateTime.Now:yyyyMMdd-HHmm}.db";

            if (dlgBackup.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                Database.Backup(dlgBackup.FileName);

                MessageBox.Show("Backup salvo com sucesso em:\n" + dlgBackup.FileName, "Backup",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao fazer o backup: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void miRestaurar_Click(object? sender, EventArgs e)
        {
            var aviso = MessageBox.Show(
                "Restaurar um backup substitui TODOS os dados atuais (clientes, OS e senha) pelos do arquivo escolhido.\n\n" +
                "Uma cópia dos dados atuais será guardada automaticamente antes da troca.\n\nDeseja continuar?",
                "Restaurar backup", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (aviso != DialogResult.Yes)
                return;

            if (dlgRestaurar.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                Database.Restaurar(dlgRestaurar.FileName);

                MessageBox.Show("Backup restaurado com sucesso. O sistema será fechado: abra-o novamente.",
                    "Restaurar backup", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível restaurar o backup: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void miAbrirPasta_Click(object? sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo("explorer.exe", $"\"{Database.Pasta}\"")
                {
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível abrir a pasta: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void miDadosLoja_Click(object? sender, EventArgs e)
        {
            using var formulario = new FormLoja();
            formulario.ShowDialog(this);
        }

        private void miAlterarSenha_Click(object? sender, EventArgs e)
        {
            using var formulario = new FormSenha(ModoSenha.Alterar);
            formulario.ShowDialog(this);
        }

        private void miNovaChave_Click(object? sender, EventArgs e)
        {
            var resposta = MessageBox.Show(
                "Uma nova chave de recuperação será gerada e a chave anterior deixará de valer.\n\nDeseja continuar?",
                "Chave de recuperação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resposta != DialogResult.Yes)
                return;

            try
            {
                SegurancaHelper.MostrarChaveRecuperacao(this, UsuarioRepository.GerarNovaChave());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar a chave: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void miSobre_Click(object? sender, EventArgs e)
        {
            MessageBox.Show(
                "HSTechService\n" +
                "Sistema de ordens de serviço para assistência técnica\n\n" +
                "Versão 1.0\n" +
                "Desenvolvido por Henrique Santana\n\n" +
                "Os dados ficam salvos em:\n" + Database.Pasta,
                "Sobre o HSTechService", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}