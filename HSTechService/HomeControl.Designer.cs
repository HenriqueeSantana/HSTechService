namespace HSTechService
{
    partial class HomeControl
    {
        private System.ComponentModel.IContainer? components = null;

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
            lblBemVindo = new Label();
            lblInfo = new Label();
            pnlCardClientes = new Panel();
            pnlFaixaClientes = new Panel();
            lblNumClientes = new Label();
            lblRotClientes = new Label();
            pnlCardAbertas = new Panel();
            pnlFaixaAbertas = new Panel();
            lblNumAbertas = new Label();
            lblRotAbertas = new Label();
            pnlCardProntas = new Panel();
            pnlFaixaProntas = new Panel();
            lblNumProntas = new Label();
            lblRotProntas = new Label();
            pnlCardEntregues = new Panel();
            pnlFaixaEntregues = new Panel();
            lblNumEntregues = new Label();
            lblRotEntregues = new Label();
            pnlRelogio = new Panel();
            pnlFaixaRelogio = new Panel();
            lblRelogioTitulo = new Label();
            lblHora = new Label();
            lblDiaSemana = new Label();
            lblDataCompleta = new Label();
            pnlCalendario = new Panel();
            pnlFaixaCalendario = new Panel();
            lblCalTitulo = new Label();
            calendario = new MonthCalendar();
            lblDiaInfo = new Label();
            timerRelogio = new System.Windows.Forms.Timer(components);
            pnlCardClientes.SuspendLayout();
            pnlCardAbertas.SuspendLayout();
            pnlCardProntas.SuspendLayout();
            pnlCardEntregues.SuspendLayout();
            pnlRelogio.SuspendLayout();
            pnlCalendario.SuspendLayout();
            SuspendLayout();
            //
            // lblBemVindo
            //
            lblBemVindo.AutoSize = true;
            lblBemVindo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblBemVindo.Location = new Point(30, 28);
            lblBemVindo.Name = "lblBemVindo";
            lblBemVindo.TabIndex = 0;
            lblBemVindo.Text = "Painel";
            //
            // lblInfo
            //
            lblInfo.AutoSize = true;
            lblInfo.ForeColor = Color.FromArgb(107, 114, 128);
            lblInfo.Location = new Point(33, 78);
            lblInfo.Name = "lblInfo";
            lblInfo.TabIndex = 1;
            lblInfo.Text = "Resumo da assistência técnica.";
            //
            // pnlCardClientes
            //
            pnlCardClientes.BackColor = Color.White;
            pnlCardClientes.Controls.Add(pnlFaixaClientes);
            pnlCardClientes.Controls.Add(lblNumClientes);
            pnlCardClientes.Controls.Add(lblRotClientes);
            pnlCardClientes.Location = new Point(30, 115);
            pnlCardClientes.Name = "pnlCardClientes";
            pnlCardClientes.Size = new Size(195, 110);
            pnlCardClientes.TabIndex = 2;
            //
            // pnlFaixaClientes
            //
            pnlFaixaClientes.BackColor = Color.FromArgb(37, 99, 235);
            pnlFaixaClientes.Dock = DockStyle.Top;
            pnlFaixaClientes.Name = "pnlFaixaClientes";
            pnlFaixaClientes.Size = new Size(195, 5);
            pnlFaixaClientes.TabIndex = 0;
            //
            // lblNumClientes
            //
            lblNumClientes.AutoSize = true;
            lblNumClientes.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblNumClientes.ForeColor = Color.FromArgb(37, 99, 235);
            lblNumClientes.Location = new Point(14, 22);
            lblNumClientes.Name = "lblNumClientes";
            lblNumClientes.TabIndex = 1;
            lblNumClientes.Text = "0";
            //
            // lblRotClientes
            //
            lblRotClientes.AutoSize = true;
            lblRotClientes.ForeColor = Color.FromArgb(107, 114, 128);
            lblRotClientes.Location = new Point(18, 76);
            lblRotClientes.Name = "lblRotClientes";
            lblRotClientes.TabIndex = 2;
            lblRotClientes.Text = "Clientes cadastrados";
            //
            // pnlCardAbertas
            //
            pnlCardAbertas.BackColor = Color.White;
            pnlCardAbertas.Controls.Add(pnlFaixaAbertas);
            pnlCardAbertas.Controls.Add(lblNumAbertas);
            pnlCardAbertas.Controls.Add(lblRotAbertas);
            pnlCardAbertas.Location = new Point(245, 115);
            pnlCardAbertas.Name = "pnlCardAbertas";
            pnlCardAbertas.Size = new Size(195, 110);
            pnlCardAbertas.TabIndex = 3;
            //
            // pnlFaixaAbertas
            //
            pnlFaixaAbertas.BackColor = Color.FromArgb(234, 88, 12);
            pnlFaixaAbertas.Dock = DockStyle.Top;
            pnlFaixaAbertas.Name = "pnlFaixaAbertas";
            pnlFaixaAbertas.Size = new Size(195, 5);
            pnlFaixaAbertas.TabIndex = 0;
            //
            // lblNumAbertas
            //
            lblNumAbertas.AutoSize = true;
            lblNumAbertas.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblNumAbertas.ForeColor = Color.FromArgb(234, 88, 12);
            lblNumAbertas.Location = new Point(14, 22);
            lblNumAbertas.Name = "lblNumAbertas";
            lblNumAbertas.TabIndex = 1;
            lblNumAbertas.Text = "0";
            //
            // lblRotAbertas
            //
            lblRotAbertas.AutoSize = true;
            lblRotAbertas.ForeColor = Color.FromArgb(107, 114, 128);
            lblRotAbertas.Location = new Point(18, 76);
            lblRotAbertas.Name = "lblRotAbertas";
            lblRotAbertas.TabIndex = 2;
            lblRotAbertas.Text = "OS em aberto";
            //
            // pnlCardProntas
            //
            pnlCardProntas.BackColor = Color.White;
            pnlCardProntas.Controls.Add(pnlFaixaProntas);
            pnlCardProntas.Controls.Add(lblNumProntas);
            pnlCardProntas.Controls.Add(lblRotProntas);
            pnlCardProntas.Location = new Point(460, 115);
            pnlCardProntas.Name = "pnlCardProntas";
            pnlCardProntas.Size = new Size(195, 110);
            pnlCardProntas.TabIndex = 4;
            //
            // pnlFaixaProntas
            //
            pnlFaixaProntas.BackColor = Color.FromArgb(22, 163, 74);
            pnlFaixaProntas.Dock = DockStyle.Top;
            pnlFaixaProntas.Name = "pnlFaixaProntas";
            pnlFaixaProntas.Size = new Size(195, 5);
            pnlFaixaProntas.TabIndex = 0;
            //
            // lblNumProntas
            //
            lblNumProntas.AutoSize = true;
            lblNumProntas.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblNumProntas.ForeColor = Color.FromArgb(22, 163, 74);
            lblNumProntas.Location = new Point(14, 22);
            lblNumProntas.Name = "lblNumProntas";
            lblNumProntas.TabIndex = 1;
            lblNumProntas.Text = "0";
            //
            // lblRotProntas
            //
            lblRotProntas.AutoSize = true;
            lblRotProntas.ForeColor = Color.FromArgb(107, 114, 128);
            lblRotProntas.Location = new Point(18, 76);
            lblRotProntas.Name = "lblRotProntas";
            lblRotProntas.TabIndex = 2;
            lblRotProntas.Text = "Prontas para retirada";
            //
            // pnlCardEntregues
            //
            pnlCardEntregues.BackColor = Color.White;
            pnlCardEntregues.Controls.Add(pnlFaixaEntregues);
            pnlCardEntregues.Controls.Add(lblNumEntregues);
            pnlCardEntregues.Controls.Add(lblRotEntregues);
            pnlCardEntregues.Location = new Point(675, 115);
            pnlCardEntregues.Name = "pnlCardEntregues";
            pnlCardEntregues.Size = new Size(195, 110);
            pnlCardEntregues.TabIndex = 5;
            //
            // pnlFaixaEntregues
            //
            pnlFaixaEntregues.BackColor = Color.FromArgb(107, 114, 128);
            pnlFaixaEntregues.Dock = DockStyle.Top;
            pnlFaixaEntregues.Name = "pnlFaixaEntregues";
            pnlFaixaEntregues.Size = new Size(195, 5);
            pnlFaixaEntregues.TabIndex = 0;
            //
            // lblNumEntregues
            //
            lblNumEntregues.AutoSize = true;
            lblNumEntregues.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblNumEntregues.ForeColor = Color.FromArgb(107, 114, 128);
            lblNumEntregues.Location = new Point(14, 22);
            lblNumEntregues.Name = "lblNumEntregues";
            lblNumEntregues.TabIndex = 1;
            lblNumEntregues.Text = "0";
            //
            // lblRotEntregues
            //
            lblRotEntregues.AutoSize = true;
            lblRotEntregues.ForeColor = Color.FromArgb(107, 114, 128);
            lblRotEntregues.Location = new Point(18, 76);
            lblRotEntregues.Name = "lblRotEntregues";
            lblRotEntregues.TabIndex = 2;
            lblRotEntregues.Text = "OS entregues";
            //
            // pnlRelogio
            //
            pnlRelogio.BackColor = Color.White;
            pnlRelogio.Controls.Add(pnlFaixaRelogio);
            pnlRelogio.Controls.Add(lblRelogioTitulo);
            pnlRelogio.Controls.Add(lblHora);
            pnlRelogio.Controls.Add(lblDiaSemana);
            pnlRelogio.Controls.Add(lblDataCompleta);
            pnlRelogio.Location = new Point(30, 250);
            pnlRelogio.Name = "pnlRelogio";
            pnlRelogio.Size = new Size(410, 260);
            pnlRelogio.TabIndex = 6;
            //
            // pnlFaixaRelogio
            //
            pnlFaixaRelogio.BackColor = Color.FromArgb(37, 99, 235);
            pnlFaixaRelogio.Dock = DockStyle.Top;
            pnlFaixaRelogio.Name = "pnlFaixaRelogio";
            pnlFaixaRelogio.Size = new Size(410, 5);
            pnlFaixaRelogio.TabIndex = 0;
            //
            // lblRelogioTitulo
            //
            lblRelogioTitulo.AutoSize = true;
            lblRelogioTitulo.ForeColor = Color.FromArgb(107, 114, 128);
            lblRelogioTitulo.Location = new Point(18, 20);
            lblRelogioTitulo.Name = "lblRelogioTitulo";
            lblRelogioTitulo.TabIndex = 1;
            lblRelogioTitulo.Text = "Horário";
            //
            // lblHora
            //
            lblHora.AutoSize = true;
            lblHora.Font = new Font("Segoe UI", 44F, FontStyle.Bold);
            lblHora.ForeColor = Color.FromArgb(10, 25, 47);
            lblHora.Location = new Point(12, 52);
            lblHora.Name = "lblHora";
            lblHora.TabIndex = 2;
            lblHora.Text = "00:00:00";
            //
            // lblDiaSemana
            //
            lblDiaSemana.AutoSize = true;
            lblDiaSemana.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblDiaSemana.ForeColor = Color.FromArgb(37, 99, 235);
            lblDiaSemana.Location = new Point(18, 150);
            lblDiaSemana.Name = "lblDiaSemana";
            lblDiaSemana.TabIndex = 3;
            lblDiaSemana.Text = "Dia";
            //
            // lblDataCompleta
            //
            lblDataCompleta.AutoSize = true;
            lblDataCompleta.Font = new Font("Segoe UI", 12F);
            lblDataCompleta.ForeColor = Color.FromArgb(107, 114, 128);
            lblDataCompleta.Location = new Point(20, 192);
            lblDataCompleta.Name = "lblDataCompleta";
            lblDataCompleta.TabIndex = 4;
            lblDataCompleta.Text = "Data";
            //
            // pnlCalendario
            //
            pnlCalendario.BackColor = Color.White;
            pnlCalendario.Controls.Add(pnlFaixaCalendario);
            pnlCalendario.Controls.Add(lblCalTitulo);
            pnlCalendario.Controls.Add(calendario);
            pnlCalendario.Controls.Add(lblDiaInfo);
            pnlCalendario.Location = new Point(460, 250);
            pnlCalendario.Name = "pnlCalendario";
            pnlCalendario.Size = new Size(410, 260);
            pnlCalendario.TabIndex = 7;
            //
            // pnlFaixaCalendario
            //
            pnlFaixaCalendario.BackColor = Color.FromArgb(10, 25, 47);
            pnlFaixaCalendario.Dock = DockStyle.Top;
            pnlFaixaCalendario.Name = "pnlFaixaCalendario";
            pnlFaixaCalendario.Size = new Size(410, 5);
            pnlFaixaCalendario.TabIndex = 0;
            //
            // lblCalTitulo
            //
            lblCalTitulo.AutoSize = true;
            lblCalTitulo.ForeColor = Color.FromArgb(107, 114, 128);
            lblCalTitulo.Location = new Point(18, 16);
            lblCalTitulo.Name = "lblCalTitulo";
            lblCalTitulo.TabIndex = 1;
            lblCalTitulo.Text = "Calendário (dias em negrito têm OS abertas)";
            //
            // calendario
            //
            calendario.Location = new Point(18, 42);
            calendario.MaxSelectionCount = 1;
            calendario.Name = "calendario";
            calendario.TabIndex = 2;
            calendario.TitleBackColor = Color.FromArgb(10, 25, 47);
            calendario.TitleForeColor = Color.White;
            calendario.TrailingForeColor = Color.FromArgb(156, 163, 175);
            calendario.DateSelected += calendario_DateSelected;
            //
            // lblDiaInfo
            //
            lblDiaInfo.AutoSize = true;
            lblDiaInfo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDiaInfo.ForeColor = Color.FromArgb(10, 25, 47);
            lblDiaInfo.Location = new Point(18, 222);
            lblDiaInfo.Name = "lblDiaInfo";
            lblDiaInfo.TabIndex = 3;
            lblDiaInfo.Text = "Selecione um dia.";
            //
            // timerRelogio
            //
            timerRelogio.Enabled = true;
            timerRelogio.Interval = 1000;
            timerRelogio.Tick += timerRelogio_Tick;
            //
            // HomeControl
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(lblBemVindo);
            Controls.Add(lblInfo);
            Controls.Add(pnlCardClientes);
            Controls.Add(pnlCardAbertas);
            Controls.Add(pnlCardProntas);
            Controls.Add(pnlCardEntregues);
            Controls.Add(pnlRelogio);
            Controls.Add(pnlCalendario);
            Name = "HomeControl";
            Size = new Size(900, 680);
            Load += HomeControl_Load;
            pnlCardClientes.ResumeLayout(false);
            pnlCardClientes.PerformLayout();
            pnlCardAbertas.ResumeLayout(false);
            pnlCardAbertas.PerformLayout();
            pnlCardProntas.ResumeLayout(false);
            pnlCardProntas.PerformLayout();
            pnlCardEntregues.ResumeLayout(false);
            pnlCardEntregues.PerformLayout();
            pnlRelogio.ResumeLayout(false);
            pnlRelogio.PerformLayout();
            pnlCalendario.ResumeLayout(false);
            pnlCalendario.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblBemVindo;
        private Label lblInfo;
        private Panel pnlCardClientes;
        private Panel pnlFaixaClientes;
        private Label lblNumClientes;
        private Label lblRotClientes;
        private Panel pnlCardAbertas;
        private Panel pnlFaixaAbertas;
        private Label lblNumAbertas;
        private Label lblRotAbertas;
        private Panel pnlCardProntas;
        private Panel pnlFaixaProntas;
        private Label lblNumProntas;
        private Label lblRotProntas;
        private Panel pnlCardEntregues;
        private Panel pnlFaixaEntregues;
        private Label lblNumEntregues;
        private Label lblRotEntregues;
        private Panel pnlRelogio;
        private Panel pnlFaixaRelogio;
        private Label lblRelogioTitulo;
        private Label lblHora;
        private Label lblDiaSemana;
        private Label lblDataCompleta;
        private Panel pnlCalendario;
        private Panel pnlFaixaCalendario;
        private Label lblCalTitulo;
        private MonthCalendar calendario;
        private Label lblDiaInfo;
        private System.Windows.Forms.Timer timerRelogio;
    }
}