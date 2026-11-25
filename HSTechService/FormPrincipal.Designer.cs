namespace HSTechService
{
    partial class FormPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuPrincipal = new MenuStrip();
            miArquivo = new ToolStripMenuItem();
            miNovaOS = new ToolStripMenuItem();
            miNovoCliente = new ToolStripMenuItem();
            sepArquivo1 = new ToolStripSeparator();
            miBackup = new ToolStripMenuItem();
            miRestaurar = new ToolStripMenuItem();
            miAbrirPasta = new ToolStripMenuItem();
            sepArquivo2 = new ToolStripSeparator();
            miDadosLoja = new ToolStripMenuItem();
            miAlterarSenha = new ToolStripMenuItem();
            miNovaChave = new ToolStripMenuItem();
            sepArquivo3 = new ToolStripSeparator();
            miSair = new ToolStripMenuItem();
            miClientes = new ToolStripMenuItem();
            miGerenciarClientes = new ToolStripMenuItem();
            miOrdens = new ToolStripMenuItem();
            miTodasOS = new ToolStripMenuItem();
            sepOrdens = new ToolStripSeparator();
            miAguardando = new ToolStripMenuItem();
            miEmAnalise = new ToolStripMenuItem();
            miAguardandoPeca = new ToolStripMenuItem();
            miProntas = new ToolStripMenuItem();
            miEntregues = new ToolStripMenuItem();
            miRelatorios = new ToolStripMenuItem();
            miRelatorioMensal = new ToolStripMenuItem();
            miExibir = new ToolStripMenuItem();
            miPainel = new ToolStripMenuItem();
            miAjuda = new ToolStripMenuItem();
            miSobre = new ToolStripMenuItem();
            statusPrincipal = new StatusStrip();
            tslUsuario = new ToolStripStatusLabel();
            tslBanco = new ToolStripStatusLabel();
            tslEspaco = new ToolStripStatusLabel();
            tslRelogio = new ToolStripStatusLabel();
            timerRelogio = new System.Windows.Forms.Timer(components);
            dlgBackup = new SaveFileDialog();
            dlgRestaurar = new OpenFileDialog();
            pnlMenu = new Panel();
            lblMarca = new Label();
            btnHome = new Button();
            btnClientes = new Button();
            btnNovaOS = new Button();
            btnListaOS = new Button();
            btnRelatorios = new Button();
            btnSair = new Button();
            pnlIndicador = new Panel();
            pnlConteudo = new Panel();
            menuPrincipal.SuspendLayout();
            statusPrincipal.SuspendLayout();
            pnlMenu.SuspendLayout();
            SuspendLayout();
            //
            // menuPrincipal
            //
            menuPrincipal.BackColor = Color.FromArgb(10, 25, 47);
            menuPrincipal.Font = new Font("Segoe UI", 9.5F);
            menuPrincipal.ForeColor = Color.White;
            menuPrincipal.Items.AddRange(new ToolStripItem[] { miArquivo, miClientes, miOrdens, miRelatorios, miExibir, miAjuda });
            menuPrincipal.Location = new Point(0, 0);
            menuPrincipal.Name = "menuPrincipal";
            menuPrincipal.Padding = new Padding(6, 3, 0, 3);
            menuPrincipal.Size = new Size(1100, 30);
            menuPrincipal.TabIndex = 2;
            //
            // miArquivo
            //
            miArquivo.DropDownItems.AddRange(new ToolStripItem[] { miNovaOS, miNovoCliente, sepArquivo1, miBackup, miRestaurar, miAbrirPasta, sepArquivo2, miDadosLoja, miAlterarSenha, miNovaChave, sepArquivo3, miSair });
            miArquivo.Name = "miArquivo";
            miArquivo.Text = "&Arquivo";
            //
            // miNovaOS
            //
            miNovaOS.Name = "miNovaOS";
            miNovaOS.ShortcutKeys = Keys.Control | Keys.N;
            miNovaOS.Text = "Nova OS";
            miNovaOS.Click += miNovaOS_Click;
            //
            // miNovoCliente
            //
            miNovoCliente.Name = "miNovoCliente";
            miNovoCliente.ShortcutKeys = Keys.Control | Keys.Shift | Keys.N;
            miNovoCliente.Text = "Novo cliente";
            miNovoCliente.Click += miNovoCliente_Click;
            //
            // sepArquivo1
            //
            sepArquivo1.Name = "sepArquivo1";
            //
            // miBackup
            //
            miBackup.Name = "miBackup";
            miBackup.Text = "Fazer backup do banco de dados...";
            miBackup.Click += miBackup_Click;
            //
            // miRestaurar
            //
            miRestaurar.Name = "miRestaurar";
            miRestaurar.Text = "Restaurar backup...";
            miRestaurar.Click += miRestaurar_Click;
            //
            // miAbrirPasta
            //
            miAbrirPasta.Name = "miAbrirPasta";
            miAbrirPasta.Text = "Abrir pasta dos dados";
            miAbrirPasta.Click += miAbrirPasta_Click;
            //
            // sepArquivo2
            //
            sepArquivo2.Name = "sepArquivo2";
            //
            // miDadosLoja
            //
            miDadosLoja.Name = "miDadosLoja";
            miDadosLoja.Text = "Dados da loja...";
            miDadosLoja.Click += miDadosLoja_Click;
            //
            // miAlterarSenha
            //
            miAlterarSenha.Name = "miAlterarSenha";
            miAlterarSenha.Text = "Alterar senha...";
            miAlterarSenha.Click += miAlterarSenha_Click;
            //
            // miNovaChave
            //
            miNovaChave.Name = "miNovaChave";
            miNovaChave.Text = "Gerar nova chave de recuperação...";
            miNovaChave.Click += miNovaChave_Click;
            //
            // sepArquivo3
            //
            sepArquivo3.Name = "sepArquivo3";
            //
            // miSair
            //
            miSair.Name = "miSair";
            miSair.ShortcutKeyDisplayString = "Alt+F4";
            miSair.Text = "Sair";
            miSair.Click += miSair_Click;
            //
            // miClientes
            //
            miClientes.DropDownItems.AddRange(new ToolStripItem[] { miGerenciarClientes });
            miClientes.Name = "miClientes";
            miClientes.Text = "&Clientes";
            //
            // miGerenciarClientes
            //
            miGerenciarClientes.Name = "miGerenciarClientes";
            miGerenciarClientes.ShortcutKeys = Keys.Control | Keys.K;
            miGerenciarClientes.Text = "Gerenciar clientes";
            miGerenciarClientes.Click += miGerenciarClientes_Click;
            //
            // miOrdens
            //
            miOrdens.DropDownItems.AddRange(new ToolStripItem[] { miTodasOS, sepOrdens, miAguardando, miEmAnalise, miAguardandoPeca, miProntas, miEntregues });
            miOrdens.Name = "miOrdens";
            miOrdens.Text = "&Ordens de serviço";
            //
            // miTodasOS
            //
            miTodasOS.Name = "miTodasOS";
            miTodasOS.ShortcutKeys = Keys.Control | Keys.L;
            miTodasOS.Text = "Todas as OS";
            miTodasOS.Click += miTodasOS_Click;
            //
            // sepOrdens
            //
            sepOrdens.Name = "sepOrdens";
            //
            // miAguardando
            //
            miAguardando.Name = "miAguardando";
            miAguardando.Tag = "Aguardando";
            miAguardando.Text = "Aguardando";
            miAguardando.Click += miStatus_Click;
            //
            // miEmAnalise
            //
            miEmAnalise.Name = "miEmAnalise";
            miEmAnalise.Tag = "Em análise";
            miEmAnalise.Text = "Em análise";
            miEmAnalise.Click += miStatus_Click;
            //
            // miAguardandoPeca
            //
            miAguardandoPeca.Name = "miAguardandoPeca";
            miAguardandoPeca.Tag = "Aguardando peça";
            miAguardandoPeca.Text = "Aguardando peça";
            miAguardandoPeca.Click += miStatus_Click;
            //
            // miProntas
            //
            miProntas.Name = "miProntas";
            miProntas.Tag = "Pronto";
            miProntas.Text = "Prontas para retirada";
            miProntas.Click += miStatus_Click;
            //
            // miEntregues
            //
            miEntregues.Name = "miEntregues";
            miEntregues.Tag = "Entregue";
            miEntregues.Text = "Entregues";
            miEntregues.Click += miStatus_Click;
            //
            // miRelatorios
            //
            miRelatorios.DropDownItems.AddRange(new ToolStripItem[] { miRelatorioMensal });
            miRelatorios.Name = "miRelatorios";
            miRelatorios.Text = "&Relatórios";
            //
            // miRelatorioMensal
            //
            miRelatorioMensal.Name = "miRelatorioMensal";
            miRelatorioMensal.ShortcutKeys = Keys.Control | Keys.R;
            miRelatorioMensal.Text = "Relatório mensal";
            miRelatorioMensal.Click += miRelatorioMensal_Click;
            //
            // miExibir
            //
            miExibir.DropDownItems.AddRange(new ToolStripItem[] { miPainel });
            miExibir.Name = "miExibir";
            miExibir.Text = "E&xibir";
            //
            // miPainel
            //
            miPainel.Name = "miPainel";
            miPainel.ShortcutKeys = Keys.Control | Keys.H;
            miPainel.Text = "Painel inicial";
            miPainel.Click += miPainel_Click;
            //
            // miAjuda
            //
            miAjuda.DropDownItems.AddRange(new ToolStripItem[] { miSobre });
            miAjuda.Name = "miAjuda";
            miAjuda.Text = "A&juda";
            //
            // miSobre
            //
            miSobre.Name = "miSobre";
            miSobre.Text = "Sobre o HSTechService";
            miSobre.Click += miSobre_Click;
            //
            // statusPrincipal
            //
            statusPrincipal.BackColor = Color.FromArgb(229, 231, 235);
            statusPrincipal.Items.AddRange(new ToolStripItem[] { tslUsuario, tslBanco, tslEspaco, tslRelogio });
            statusPrincipal.Location = new Point(0, 708);
            statusPrincipal.Name = "statusPrincipal";
            statusPrincipal.Size = new Size(1100, 22);
            statusPrincipal.SizingGrip = false;
            statusPrincipal.TabIndex = 3;
            //
            // tslUsuario
            //
            tslUsuario.Name = "tslUsuario";
            tslUsuario.Padding = new Padding(8, 0, 8, 0);
            tslUsuario.Text = "Usuário: admin";
            //
            // tslBanco
            //
            tslBanco.Name = "tslBanco";
            tslBanco.Padding = new Padding(8, 0, 8, 0);
            tslBanco.Text = "Banco de dados local";
            //
            // tslEspaco
            //
            tslEspaco.Name = "tslEspaco";
            tslEspaco.Spring = true;
            //
            // tslRelogio
            //
            tslRelogio.Name = "tslRelogio";
            tslRelogio.Padding = new Padding(8, 0, 8, 0);
            //
            // timerRelogio
            //
            timerRelogio.Enabled = true;
            timerRelogio.Interval = 1000;
            timerRelogio.Tick += timerRelogio_Tick;
            //
            // dlgBackup
            //
            dlgBackup.AddExtension = true;
            dlgBackup.DefaultExt = "db";
            dlgBackup.Filter = "Banco de dados SQLite (*.db)|*.db";
            dlgBackup.OverwritePrompt = true;
            dlgBackup.Title = "Salvar backup do banco de dados";
            //
            // dlgRestaurar
            //
            dlgRestaurar.CheckFileExists = true;
            dlgRestaurar.Filter = "Banco de dados SQLite (*.db)|*.db";
            dlgRestaurar.Title = "Selecionar o backup para restaurar";
            //
            // pnlMenu
            //
            pnlMenu.BackColor = Color.FromArgb(10, 25, 47);
            pnlMenu.Controls.Add(lblMarca);
            pnlMenu.Controls.Add(btnHome);
            pnlMenu.Controls.Add(btnClientes);
            pnlMenu.Controls.Add(btnNovaOS);
            pnlMenu.Controls.Add(btnListaOS);
            pnlMenu.Controls.Add(btnRelatorios);
            pnlMenu.Controls.Add(btnSair);
            pnlMenu.Controls.Add(pnlIndicador);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 30);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(200, 678);
            pnlMenu.TabIndex = 0;
            //
            // lblMarca
            //
            lblMarca.AutoSize = true;
            lblMarca.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblMarca.ForeColor = Color.White;
            lblMarca.Location = new Point(14, 24);
            lblMarca.Name = "lblMarca";
            lblMarca.TabIndex = 0;
            lblMarca.Text = "HSTechService";
            //
            // btnHome
            //
            btnHome.BackColor = Color.FromArgb(10, 25, 47);
            btnHome.Cursor = Cursors.Hand;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 55, 100);
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI", 10F);
            btnHome.ForeColor = Color.White;
            btnHome.Location = new Point(0, 85);
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(18, 0, 0, 0);
            btnHome.Size = new Size(200, 45);
            btnHome.TabIndex = 1;
            btnHome.Text = "Home";
            btnHome.TextAlign = ContentAlignment.MiddleLeft;
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            //
            // btnClientes
            //
            btnClientes.BackColor = Color.FromArgb(10, 25, 47);
            btnClientes.Cursor = Cursors.Hand;
            btnClientes.FlatAppearance.BorderSize = 0;
            btnClientes.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 55, 100);
            btnClientes.FlatStyle = FlatStyle.Flat;
            btnClientes.Font = new Font("Segoe UI", 10F);
            btnClientes.ForeColor = Color.White;
            btnClientes.Location = new Point(0, 130);
            btnClientes.Name = "btnClientes";
            btnClientes.Padding = new Padding(18, 0, 0, 0);
            btnClientes.Size = new Size(200, 45);
            btnClientes.TabIndex = 2;
            btnClientes.Text = "Clientes";
            btnClientes.TextAlign = ContentAlignment.MiddleLeft;
            btnClientes.UseVisualStyleBackColor = false;
            btnClientes.Click += btnClientes_Click;
            //
            // btnNovaOS
            //
            btnNovaOS.BackColor = Color.FromArgb(10, 25, 47);
            btnNovaOS.Cursor = Cursors.Hand;
            btnNovaOS.FlatAppearance.BorderSize = 0;
            btnNovaOS.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 55, 100);
            btnNovaOS.FlatStyle = FlatStyle.Flat;
            btnNovaOS.Font = new Font("Segoe UI", 10F);
            btnNovaOS.ForeColor = Color.White;
            btnNovaOS.Location = new Point(0, 175);
            btnNovaOS.Name = "btnNovaOS";
            btnNovaOS.Padding = new Padding(18, 0, 0, 0);
            btnNovaOS.Size = new Size(200, 45);
            btnNovaOS.TabIndex = 3;
            btnNovaOS.Text = "Nova OS";
            btnNovaOS.TextAlign = ContentAlignment.MiddleLeft;
            btnNovaOS.UseVisualStyleBackColor = false;
            btnNovaOS.Click += btnNovaOS_Click;
            //
            // btnListaOS
            //
            btnListaOS.BackColor = Color.FromArgb(10, 25, 47);
            btnListaOS.Cursor = Cursors.Hand;
            btnListaOS.FlatAppearance.BorderSize = 0;
            btnListaOS.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 55, 100);
            btnListaOS.FlatStyle = FlatStyle.Flat;
            btnListaOS.Font = new Font("Segoe UI", 10F);
            btnListaOS.ForeColor = Color.White;
            btnListaOS.Location = new Point(0, 220);
            btnListaOS.Name = "btnListaOS";
            btnListaOS.Padding = new Padding(18, 0, 0, 0);
            btnListaOS.Size = new Size(200, 45);
            btnListaOS.TabIndex = 4;
            btnListaOS.Text = "Ordens de serviço";
            btnListaOS.TextAlign = ContentAlignment.MiddleLeft;
            btnListaOS.UseVisualStyleBackColor = false;
            btnListaOS.Click += btnListaOS_Click;
            //
            // btnRelatorios
            //
            btnRelatorios.BackColor = Color.FromArgb(10, 25, 47);
            btnRelatorios.Cursor = Cursors.Hand;
            btnRelatorios.FlatAppearance.BorderSize = 0;
            btnRelatorios.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 55, 100);
            btnRelatorios.FlatStyle = FlatStyle.Flat;
            btnRelatorios.Font = new Font("Segoe UI", 10F);
            btnRelatorios.ForeColor = Color.White;
            btnRelatorios.Location = new Point(0, 265);
            btnRelatorios.Name = "btnRelatorios";
            btnRelatorios.Padding = new Padding(18, 0, 0, 0);
            btnRelatorios.Size = new Size(200, 45);
            btnRelatorios.TabIndex = 7;
            btnRelatorios.Text = "Relatórios";
            btnRelatorios.TextAlign = ContentAlignment.MiddleLeft;
            btnRelatorios.UseVisualStyleBackColor = false;
            btnRelatorios.Click += btnRelatorios_Click;
            //
            // btnSair
            //
            btnSair.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSair.BackColor = Color.FromArgb(10, 25, 47);
            btnSair.Cursor = Cursors.Hand;
            btnSair.FlatAppearance.BorderSize = 0;
            btnSair.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 55, 100);
            btnSair.FlatStyle = FlatStyle.Flat;
            btnSair.Font = new Font("Segoe UI", 10F);
            btnSair.ForeColor = Color.White;
            btnSair.Location = new Point(0, 633);
            btnSair.Name = "btnSair";
            btnSair.Padding = new Padding(18, 0, 0, 0);
            btnSair.Size = new Size(200, 45);
            btnSair.TabIndex = 5;
            btnSair.Text = "Sair";
            btnSair.TextAlign = ContentAlignment.MiddleLeft;
            btnSair.UseVisualStyleBackColor = false;
            btnSair.Click += btnSair_Click;
            //
            // pnlIndicador
            //
            pnlIndicador.BackColor = Color.FromArgb(37, 99, 235);
            pnlIndicador.Location = new Point(0, 85);
            pnlIndicador.Name = "pnlIndicador";
            pnlIndicador.Size = new Size(4, 45);
            pnlIndicador.TabIndex = 6;
            //
            // pnlConteudo
            //
            pnlConteudo.BackColor = Color.FromArgb(240, 242, 245);
            pnlConteudo.Dock = DockStyle.Fill;
            pnlConteudo.Location = new Point(200, 30);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Size = new Size(900, 678);
            pnlConteudo.TabIndex = 1;
            //
            // FormPrincipal
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 730);
            Controls.Add(pnlConteudo);
            Controls.Add(pnlMenu);
            Controls.Add(statusPrincipal);
            Controls.Add(menuPrincipal);
            MainMenuStrip = menuPrincipal;
            MinimumSize = new Size(1000, 700);
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HSTechService";
            FormClosing += FormPrincipal_FormClosing;
            FormClosed += FormPrincipal_FormClosed;
            Load += FormPrincipal_Load;
            menuPrincipal.ResumeLayout(false);
            menuPrincipal.PerformLayout();
            statusPrincipal.ResumeLayout(false);
            statusPrincipal.PerformLayout();
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private MenuStrip menuPrincipal;
        private ToolStripMenuItem miArquivo;
        private ToolStripMenuItem miNovaOS;
        private ToolStripMenuItem miNovoCliente;
        private ToolStripSeparator sepArquivo1;
        private ToolStripMenuItem miBackup;
        private ToolStripMenuItem miRestaurar;
        private ToolStripMenuItem miAbrirPasta;
        private ToolStripSeparator sepArquivo2;
        private ToolStripMenuItem miDadosLoja;
        private ToolStripMenuItem miAlterarSenha;
        private ToolStripMenuItem miNovaChave;
        private ToolStripSeparator sepArquivo3;
        private ToolStripMenuItem miSair;
        private ToolStripMenuItem miClientes;
        private ToolStripMenuItem miGerenciarClientes;
        private ToolStripMenuItem miOrdens;
        private ToolStripMenuItem miTodasOS;
        private ToolStripSeparator sepOrdens;
        private ToolStripMenuItem miAguardando;
        private ToolStripMenuItem miEmAnalise;
        private ToolStripMenuItem miAguardandoPeca;
        private ToolStripMenuItem miProntas;
        private ToolStripMenuItem miEntregues;
        private ToolStripMenuItem miRelatorios;
        private ToolStripMenuItem miRelatorioMensal;
        private ToolStripMenuItem miExibir;
        private ToolStripMenuItem miPainel;
        private ToolStripMenuItem miAjuda;
        private ToolStripMenuItem miSobre;
        private StatusStrip statusPrincipal;
        private ToolStripStatusLabel tslUsuario;
        private ToolStripStatusLabel tslBanco;
        private ToolStripStatusLabel tslEspaco;
        private ToolStripStatusLabel tslRelogio;
        private System.Windows.Forms.Timer timerRelogio;
        private SaveFileDialog dlgBackup;
        private OpenFileDialog dlgRestaurar;
        private Panel pnlMenu;
        private Label lblMarca;
        private Button btnHome;
        private Button btnClientes;
        private Button btnNovaOS;
        private Button btnListaOS;
        private Button btnRelatorios;
        private Button btnSair;
        private Panel pnlIndicador;
        private Panel pnlConteudo;
    }
}