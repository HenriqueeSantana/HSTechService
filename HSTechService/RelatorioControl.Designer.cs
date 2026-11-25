namespace HSTechService
{
    partial class RelatorioControl
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
            DataGridViewCellStyle estiloValor = new DataGridViewCellStyle();
            DataGridViewCellStyle estiloQtd = new DataGridViewCellStyle();
            lblTitulo = new Label();
            lblPeriodo = new Label();
            dtpMes = new DateTimePicker();
            btnImprimir = new Button();
            tlpCards = new TableLayoutPanel();
            pnlCardAbertas = new Panel();
            lblAbertasTitulo = new Label();
            lblAbertasValor = new Label();
            pnlCardEntregues = new Panel();
            lblEntreguesTitulo = new Label();
            lblEntreguesValor = new Label();
            pnlCardFaturamento = new Panel();
            lblFaturamentoTitulo = new Label();
            lblFaturamentoValor = new Label();
            pnlCardTicket = new Panel();
            lblTicketTitulo = new Label();
            lblTicketValor = new Label();
            grpStatus = new GroupBox();
            dgvStatus = new DataGridView();
            colSituacao = new DataGridViewTextBoxColumn();
            colQuantidade = new DataGridViewTextBoxColumn();
            grpEntregues = new GroupBox();
            dgvEntregues = new DataGridView();
            colEId = new DataGridViewTextBoxColumn();
            colENumero = new DataGridViewTextBoxColumn();
            colEData = new DataGridViewTextBoxColumn();
            colECliente = new DataGridViewTextBoxColumn();
            colEEquip = new DataGridViewTextBoxColumn();
            colEValor = new DataGridViewTextBoxColumn();
            lblTotalEntregues = new Label();
            tlpCards.SuspendLayout();
            pnlCardAbertas.SuspendLayout();
            pnlCardEntregues.SuspendLayout();
            pnlCardFaturamento.SuspendLayout();
            pnlCardTicket.SuspendLayout();
            grpStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStatus).BeginInit();
            grpEntregues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEntregues).BeginInit();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(18, 14);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Relatório mensal";
            //
            // lblPeriodo
            //
            lblPeriodo.AutoSize = true;
            lblPeriodo.Location = new Point(20, 62);
            lblPeriodo.Name = "lblPeriodo";
            lblPeriodo.TabIndex = 1;
            lblPeriodo.Text = "Período (use as setas para mudar o mês)";
            //
            // dtpMes
            //
            dtpMes.CustomFormat = "MMMM 'de' yyyy";
            dtpMes.Format = DateTimePickerFormat.Custom;
            dtpMes.Location = new Point(20, 84);
            dtpMes.Name = "dtpMes";
            dtpMes.ShowUpDown = true;
            dtpMes.Size = new Size(240, 23);
            dtpMes.TabIndex = 0;
            dtpMes.ValueChanged += dtpMes_ValueChanged;
            //
            // btnImprimir
            //
            btnImprimir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnImprimir.Enabled = false;
            btnImprimir.Location = new Point(700, 76);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(180, 34);
            btnImprimir.TabIndex = 1;
            btnImprimir.Text = "Imprimir relatório";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            //
            // tlpCards
            //
            tlpCards.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tlpCards.ColumnCount = 4;
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpCards.Controls.Add(pnlCardAbertas, 0, 0);
            tlpCards.Controls.Add(pnlCardEntregues, 1, 0);
            tlpCards.Controls.Add(pnlCardFaturamento, 2, 0);
            tlpCards.Controls.Add(pnlCardTicket, 3, 0);
            tlpCards.Location = new Point(20, 125);
            tlpCards.Name = "tlpCards";
            tlpCards.RowCount = 1;
            tlpCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpCards.Size = new Size(860, 92);
            tlpCards.TabIndex = 2;
            //
            // pnlCardAbertas
            //
            pnlCardAbertas.BackColor = Color.FromArgb(37, 99, 235);
            pnlCardAbertas.Controls.Add(lblAbertasTitulo);
            pnlCardAbertas.Controls.Add(lblAbertasValor);
            pnlCardAbertas.Dock = DockStyle.Fill;
            pnlCardAbertas.Margin = new Padding(0, 0, 10, 0);
            pnlCardAbertas.Name = "pnlCardAbertas";
            pnlCardAbertas.TabIndex = 0;
            //
            // lblAbertasTitulo
            //
            lblAbertasTitulo.AutoSize = true;
            lblAbertasTitulo.Font = new Font("Segoe UI", 9.5F);
            lblAbertasTitulo.ForeColor = Color.White;
            lblAbertasTitulo.Location = new Point(14, 12);
            lblAbertasTitulo.Name = "lblAbertasTitulo";
            lblAbertasTitulo.TabIndex = 0;
            lblAbertasTitulo.Text = "OS abertas no mês";
            //
            // lblAbertasValor
            //
            lblAbertasValor.AutoSize = true;
            lblAbertasValor.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblAbertasValor.ForeColor = Color.White;
            lblAbertasValor.Location = new Point(12, 36);
            lblAbertasValor.Name = "lblAbertasValor";
            lblAbertasValor.TabIndex = 1;
            lblAbertasValor.Text = "0";
            //
            // pnlCardEntregues
            //
            pnlCardEntregues.BackColor = Color.FromArgb(22, 163, 74);
            pnlCardEntregues.Controls.Add(lblEntreguesTitulo);
            pnlCardEntregues.Controls.Add(lblEntreguesValor);
            pnlCardEntregues.Dock = DockStyle.Fill;
            pnlCardEntregues.Margin = new Padding(0, 0, 10, 0);
            pnlCardEntregues.Name = "pnlCardEntregues";
            pnlCardEntregues.TabIndex = 1;
            //
            // lblEntreguesTitulo
            //
            lblEntreguesTitulo.AutoSize = true;
            lblEntreguesTitulo.Font = new Font("Segoe UI", 9.5F);
            lblEntreguesTitulo.ForeColor = Color.White;
            lblEntreguesTitulo.Location = new Point(14, 12);
            lblEntreguesTitulo.Name = "lblEntreguesTitulo";
            lblEntreguesTitulo.TabIndex = 0;
            lblEntreguesTitulo.Text = "OS entregues no mês";
            //
            // lblEntreguesValor
            //
            lblEntreguesValor.AutoSize = true;
            lblEntreguesValor.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblEntreguesValor.ForeColor = Color.White;
            lblEntreguesValor.Location = new Point(12, 36);
            lblEntreguesValor.Name = "lblEntreguesValor";
            lblEntreguesValor.TabIndex = 1;
            lblEntreguesValor.Text = "0";
            //
            // pnlCardFaturamento
            //
            pnlCardFaturamento.BackColor = Color.FromArgb(10, 25, 47);
            pnlCardFaturamento.Controls.Add(lblFaturamentoTitulo);
            pnlCardFaturamento.Controls.Add(lblFaturamentoValor);
            pnlCardFaturamento.Dock = DockStyle.Fill;
            pnlCardFaturamento.Margin = new Padding(0, 0, 10, 0);
            pnlCardFaturamento.Name = "pnlCardFaturamento";
            pnlCardFaturamento.TabIndex = 2;
            //
            // lblFaturamentoTitulo
            //
            lblFaturamentoTitulo.AutoSize = true;
            lblFaturamentoTitulo.Font = new Font("Segoe UI", 9.5F);
            lblFaturamentoTitulo.ForeColor = Color.White;
            lblFaturamentoTitulo.Location = new Point(14, 12);
            lblFaturamentoTitulo.Name = "lblFaturamentoTitulo";
            lblFaturamentoTitulo.TabIndex = 0;
            lblFaturamentoTitulo.Text = "Faturamento (entregues)";
            //
            // lblFaturamentoValor
            //
            lblFaturamentoValor.AutoSize = true;
            lblFaturamentoValor.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblFaturamentoValor.ForeColor = Color.White;
            lblFaturamentoValor.Location = new Point(12, 36);
            lblFaturamentoValor.Name = "lblFaturamentoValor";
            lblFaturamentoValor.TabIndex = 1;
            lblFaturamentoValor.Text = "0";
            //
            // pnlCardTicket
            //
            pnlCardTicket.BackColor = Color.FromArgb(234, 88, 12);
            pnlCardTicket.Controls.Add(lblTicketTitulo);
            pnlCardTicket.Controls.Add(lblTicketValor);
            pnlCardTicket.Dock = DockStyle.Fill;
            pnlCardTicket.Margin = new Padding(0, 0, 10, 0);
            pnlCardTicket.Name = "pnlCardTicket";
            pnlCardTicket.TabIndex = 3;
            //
            // lblTicketTitulo
            //
            lblTicketTitulo.AutoSize = true;
            lblTicketTitulo.Font = new Font("Segoe UI", 9.5F);
            lblTicketTitulo.ForeColor = Color.White;
            lblTicketTitulo.Location = new Point(14, 12);
            lblTicketTitulo.Name = "lblTicketTitulo";
            lblTicketTitulo.TabIndex = 0;
            lblTicketTitulo.Text = "Valor médio por OS";
            //
            // lblTicketValor
            //
            lblTicketValor.AutoSize = true;
            lblTicketValor.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTicketValor.ForeColor = Color.White;
            lblTicketValor.Location = new Point(12, 36);
            lblTicketValor.Name = "lblTicketValor";
            lblTicketValor.TabIndex = 1;
            lblTicketValor.Text = "0";
            //
            // grpStatus
            //
            grpStatus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grpStatus.Controls.Add(dgvStatus);
            grpStatus.Location = new Point(20, 232);
            grpStatus.Name = "grpStatus";
            grpStatus.Size = new Size(300, 318);
            grpStatus.TabIndex = 3;
            grpStatus.TabStop = false;
            grpStatus.Text = "OS abertas no mês, por situação atual";
            //
            // dgvStatus
            //
            dgvStatus.AllowUserToAddRows = false;
            dgvStatus.AllowUserToDeleteRows = false;
            dgvStatus.AllowUserToResizeRows = false;
            dgvStatus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvStatus.AutoGenerateColumns = false;
            dgvStatus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStatus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStatus.Columns.AddRange(new DataGridViewColumn[] { colSituacao, colQuantidade });
            dgvStatus.Location = new Point(12, 24);
            dgvStatus.MultiSelect = false;
            dgvStatus.Name = "dgvStatus";
            dgvStatus.ReadOnly = true;
            dgvStatus.RowHeadersVisible = false;
            dgvStatus.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStatus.Size = new Size(276, 282);
            dgvStatus.TabIndex = 0;
            //
            // colSituacao
            //
            colSituacao.DataPropertyName = "Situacao";
            colSituacao.FillWeight = 140F;
            colSituacao.HeaderText = "Situação";
            colSituacao.Name = "colSituacao";
            colSituacao.ReadOnly = true;
            //
            // colQuantidade
            //
            estiloQtd.Alignment = DataGridViewContentAlignment.MiddleRight;
            colQuantidade.DataPropertyName = "Quantidade";
            colQuantidade.DefaultCellStyle = estiloQtd;
            colQuantidade.FillWeight = 60F;
            colQuantidade.HeaderText = "Qtd.";
            colQuantidade.Name = "colQuantidade";
            colQuantidade.ReadOnly = true;
            //
            // grpEntregues
            //
            grpEntregues.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpEntregues.Controls.Add(dgvEntregues);
            grpEntregues.Controls.Add(lblTotalEntregues);
            grpEntregues.Location = new Point(332, 232);
            grpEntregues.Name = "grpEntregues";
            grpEntregues.Size = new Size(548, 318);
            grpEntregues.TabIndex = 4;
            grpEntregues.TabStop = false;
            grpEntregues.Text = "OS entregues no mês";
            //
            // dgvEntregues
            //
            dgvEntregues.AllowUserToAddRows = false;
            dgvEntregues.AllowUserToDeleteRows = false;
            dgvEntregues.AllowUserToResizeRows = false;
            dgvEntregues.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEntregues.AutoGenerateColumns = false;
            dgvEntregues.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEntregues.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEntregues.Columns.AddRange(new DataGridViewColumn[] { colEId, colENumero, colEData, colECliente, colEEquip, colEValor });
            dgvEntregues.Location = new Point(12, 24);
            dgvEntregues.MultiSelect = false;
            dgvEntregues.Name = "dgvEntregues";
            dgvEntregues.ReadOnly = true;
            dgvEntregues.RowHeadersVisible = false;
            dgvEntregues.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEntregues.Size = new Size(524, 250);
            dgvEntregues.TabIndex = 0;
            //
            // colEId
            //
            colEId.DataPropertyName = "Id";
            colEId.HeaderText = "Id";
            colEId.Name = "colEId";
            colEId.ReadOnly = true;
            colEId.Visible = false;
            //
            // colENumero
            //
            colENumero.DataPropertyName = "Numero";
            colENumero.FillWeight = 55F;
            colENumero.HeaderText = "OS";
            colENumero.Name = "colENumero";
            colENumero.ReadOnly = true;
            //
            // colEData
            //
            colEData.DataPropertyName = "DataEntregaFormatada";
            colEData.FillWeight = 100F;
            colEData.HeaderText = "Entrega";
            colEData.Name = "colEData";
            colEData.ReadOnly = true;
            //
            // colECliente
            //
            colECliente.DataPropertyName = "ClienteNome";
            colECliente.FillWeight = 120F;
            colECliente.HeaderText = "Cliente";
            colECliente.Name = "colECliente";
            colECliente.ReadOnly = true;
            //
            // colEEquip
            //
            colEEquip.DataPropertyName = "EquipamentoResumo";
            colEEquip.FillWeight = 130F;
            colEEquip.HeaderText = "Equipamento";
            colEEquip.Name = "colEEquip";
            colEEquip.ReadOnly = true;
            //
            // colEValor
            //
            estiloValor.Alignment = DataGridViewContentAlignment.MiddleRight;
            estiloValor.Format = "C2";
            colEValor.DataPropertyName = "Valor";
            colEValor.DefaultCellStyle = estiloValor;
            colEValor.FillWeight = 80F;
            colEValor.HeaderText = "Valor";
            colEValor.Name = "colEValor";
            colEValor.ReadOnly = true;
            //
            // lblTotalEntregues
            //
            lblTotalEntregues.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblTotalEntregues.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblTotalEntregues.Location = new Point(12, 284);
            lblTotalEntregues.Name = "lblTotalEntregues";
            lblTotalEntregues.Size = new Size(524, 24);
            lblTotalEntregues.TabIndex = 1;
            lblTotalEntregues.TextAlign = ContentAlignment.MiddleRight;
            //
            // RelatorioControl
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(lblTitulo);
            Controls.Add(lblPeriodo);
            Controls.Add(dtpMes);
            Controls.Add(btnImprimir);
            Controls.Add(tlpCards);
            Controls.Add(grpStatus);
            Controls.Add(grpEntregues);
            Name = "RelatorioControl";
            Size = new Size(900, 570);
            Load += RelatorioControl_Load;
            tlpCards.ResumeLayout(false);
            pnlCardAbertas.ResumeLayout(false);
            pnlCardAbertas.PerformLayout();
            pnlCardEntregues.ResumeLayout(false);
            pnlCardEntregues.PerformLayout();
            pnlCardFaturamento.ResumeLayout(false);
            pnlCardFaturamento.PerformLayout();
            pnlCardTicket.ResumeLayout(false);
            pnlCardTicket.PerformLayout();
            grpStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStatus).EndInit();
            grpEntregues.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEntregues).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitulo;
        private Label lblPeriodo;
        private DateTimePicker dtpMes;
        private Button btnImprimir;
        private TableLayoutPanel tlpCards;
        private Panel pnlCardAbertas;
        private Label lblAbertasTitulo;
        private Label lblAbertasValor;
        private Panel pnlCardEntregues;
        private Label lblEntreguesTitulo;
        private Label lblEntreguesValor;
        private Panel pnlCardFaturamento;
        private Label lblFaturamentoTitulo;
        private Label lblFaturamentoValor;
        private Panel pnlCardTicket;
        private Label lblTicketTitulo;
        private Label lblTicketValor;
        private GroupBox grpStatus;
        private DataGridView dgvStatus;
        private DataGridViewTextBoxColumn colSituacao;
        private DataGridViewTextBoxColumn colQuantidade;
        private GroupBox grpEntregues;
        private DataGridView dgvEntregues;
        private DataGridViewTextBoxColumn colEId;
        private DataGridViewTextBoxColumn colENumero;
        private DataGridViewTextBoxColumn colEData;
        private DataGridViewTextBoxColumn colECliente;
        private DataGridViewTextBoxColumn colEEquip;
        private DataGridViewTextBoxColumn colEValor;
        private Label lblTotalEntregues;
    }
}