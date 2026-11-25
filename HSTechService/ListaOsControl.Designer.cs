namespace HSTechService
{
    partial class ListaOsControl
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
            lblTitulo = new Label();
            lblFiltroStatus = new Label();
            cmbFiltroStatus = new ComboBox();
            lblBusca = new Label();
            txtBusca = new TextBox();
            lblTotal = new Label();
            dgvOs = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colNumero = new DataGridViewTextBoxColumn();
            colData = new DataGridViewTextBoxColumn();
            colCliente = new DataGridViewTextBoxColumn();
            colEquipamento = new DataGridViewTextBoxColumn();
            colDefeito = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colValor = new DataGridViewTextBoxColumn();
            grpDetalhes = new GroupBox();
            lblResumo = new Label();
            txtResumo = new TextBox();
            lblStatusOs = new Label();
            cmbStatusOs = new ComboBox();
            lblValor = new Label();
            txtValor = new TextBox();
            lblLaudo = new Label();
            txtLaudo = new TextBox();
            btnSalvar = new Button();
            btnExcluir = new Button();
            btnImprimir = new Button();
            lblItens = new Label();
            txtItem = new TextBox();
            nudQtd = new NumericUpDown();
            btnAddItem = new Button();
            lstItens = new ListBox();
            btnRemoverItem = new Button();
            btnWhatsApp = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvOs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudQtd).BeginInit();
            grpDetalhes.SuspendLayout();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(18, 14);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Ordens de serviço";
            //
            // lblFiltroStatus
            //
            lblFiltroStatus.AutoSize = true;
            lblFiltroStatus.Location = new Point(20, 64);
            lblFiltroStatus.Name = "lblFiltroStatus";
            lblFiltroStatus.TabIndex = 1;
            lblFiltroStatus.Text = "Status:";
            //
            // cmbFiltroStatus
            //
            cmbFiltroStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroStatus.FormattingEnabled = true;
            cmbFiltroStatus.Items.AddRange(new object[] { "Todos", "Aguardando", "Em análise", "Aguardando peça", "Pronto", "Entregue" });
            cmbFiltroStatus.Location = new Point(70, 60);
            cmbFiltroStatus.Name = "cmbFiltroStatus";
            cmbFiltroStatus.Size = new Size(170, 23);
            cmbFiltroStatus.TabIndex = 0;
            cmbFiltroStatus.SelectedIndexChanged += cmbFiltroStatus_SelectedIndexChanged;
            //
            // lblBusca
            //
            lblBusca.AutoSize = true;
            lblBusca.Location = new Point(262, 64);
            lblBusca.Name = "lblBusca";
            lblBusca.TabIndex = 3;
            lblBusca.Text = "Buscar:";
            //
            // txtBusca
            //
            txtBusca.Location = new Point(316, 60);
            txtBusca.Name = "txtBusca";
            txtBusca.PlaceholderText = "Nº da OS, cliente, marca, modelo, série ou defeito";
            txtBusca.Size = new Size(400, 23);
            txtBusca.TabIndex = 1;
            txtBusca.TextChanged += txtBusca_TextChanged;
            //
            // lblTotal
            //
            lblTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotal.ForeColor = Color.FromArgb(107, 114, 128);
            lblTotal.Location = new Point(780, 64);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(100, 18);
            lblTotal.TabIndex = 5;
            lblTotal.Text = "0 OS";
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            //
            // dgvOs
            //
            dgvOs.AllowUserToAddRows = false;
            dgvOs.AllowUserToDeleteRows = false;
            dgvOs.AllowUserToResizeRows = false;
            dgvOs.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvOs.AutoGenerateColumns = false;
            dgvOs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOs.Columns.AddRange(new DataGridViewColumn[] { colId, colNumero, colData, colCliente, colEquipamento, colDefeito, colStatus, colValor });
            dgvOs.Location = new Point(20, 95);
            dgvOs.MultiSelect = false;
            dgvOs.Name = "dgvOs";
            dgvOs.ReadOnly = true;
            dgvOs.RowHeadersVisible = false;
            dgvOs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOs.Size = new Size(860, 225);
            dgvOs.TabIndex = 2;
            dgvOs.CellClick += dgvOs_CellClick;
            dgvOs.CellFormatting += dgvOs_CellFormatting;
            //
            // colId
            //
            colId.DataPropertyName = "Id";
            colId.HeaderText = "Id";
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            //
            // colNumero
            //
            colNumero.DataPropertyName = "Numero";
            colNumero.FillWeight = 55F;
            colNumero.HeaderText = "OS";
            colNumero.Name = "colNumero";
            colNumero.ReadOnly = true;
            //
            // colData
            //
            colData.DataPropertyName = "DataEntradaFormatada";
            colData.FillWeight = 90F;
            colData.HeaderText = "Entrada";
            colData.Name = "colData";
            colData.ReadOnly = true;
            //
            // colCliente
            //
            colCliente.DataPropertyName = "ClienteNome";
            colCliente.FillWeight = 140F;
            colCliente.HeaderText = "Cliente";
            colCliente.Name = "colCliente";
            colCliente.ReadOnly = true;
            //
            // colEquipamento
            //
            colEquipamento.DataPropertyName = "EquipamentoResumo";
            colEquipamento.FillWeight = 140F;
            colEquipamento.HeaderText = "Equipamento";
            colEquipamento.Name = "colEquipamento";
            colEquipamento.ReadOnly = true;
            //
            // colDefeito
            //
            colDefeito.DataPropertyName = "DefeitoRelatado";
            colDefeito.FillWeight = 190F;
            colDefeito.HeaderText = "Defeito";
            colDefeito.Name = "colDefeito";
            colDefeito.ReadOnly = true;
            //
            // colStatus
            //
            colStatus.DataPropertyName = "Status";
            colStatus.FillWeight = 95F;
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            //
            // colValor
            //
            estiloValor.Alignment = DataGridViewContentAlignment.MiddleRight;
            estiloValor.Format = "C2";
            colValor.DataPropertyName = "Valor";
            colValor.DefaultCellStyle = estiloValor;
            colValor.FillWeight = 75F;
            colValor.HeaderText = "Valor";
            colValor.Name = "colValor";
            colValor.ReadOnly = true;
            //
            // grpDetalhes
            //
            grpDetalhes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpDetalhes.Controls.Add(lblResumo);
            grpDetalhes.Controls.Add(txtResumo);
            grpDetalhes.Controls.Add(lblStatusOs);
            grpDetalhes.Controls.Add(cmbStatusOs);
            grpDetalhes.Controls.Add(lblValor);
            grpDetalhes.Controls.Add(txtValor);
            grpDetalhes.Controls.Add(lblLaudo);
            grpDetalhes.Controls.Add(txtLaudo);
            grpDetalhes.Controls.Add(btnSalvar);
            grpDetalhes.Controls.Add(btnExcluir);
            grpDetalhes.Controls.Add(btnImprimir);
            grpDetalhes.Controls.Add(lblItens);
            grpDetalhes.Controls.Add(txtItem);
            grpDetalhes.Controls.Add(nudQtd);
            grpDetalhes.Controls.Add(btnAddItem);
            grpDetalhes.Controls.Add(lstItens);
            grpDetalhes.Controls.Add(btnRemoverItem);
            grpDetalhes.Controls.Add(btnWhatsApp);
            grpDetalhes.Location = new Point(20, 332);
            grpDetalhes.Name = "grpDetalhes";
            grpDetalhes.Size = new Size(860, 410);
            grpDetalhes.TabIndex = 3;
            grpDetalhes.TabStop = false;
            grpDetalhes.Text = "Detalhes da OS";
            //
            // lblResumo
            //
            lblResumo.AutoSize = true;
            lblResumo.Location = new Point(15, 22);
            lblResumo.Name = "lblResumo";
            lblResumo.TabIndex = 0;
            lblResumo.Text = "Resumo do atendimento";
            //
            // txtResumo
            //
            txtResumo.Location = new Point(15, 42);
            txtResumo.Multiline = true;
            txtResumo.Name = "txtResumo";
            txtResumo.ReadOnly = true;
            txtResumo.ScrollBars = ScrollBars.Vertical;
            txtResumo.Size = new Size(400, 305);
            txtResumo.TabIndex = 6;
            txtResumo.TabStop = false;
            //
            // lblStatusOs
            //
            lblStatusOs.AutoSize = true;
            lblStatusOs.Location = new Point(435, 22);
            lblStatusOs.Name = "lblStatusOs";
            lblStatusOs.TabIndex = 2;
            lblStatusOs.Text = "Status da OS";
            //
            // cmbStatusOs
            //
            cmbStatusOs.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatusOs.Enabled = false;
            cmbStatusOs.FormattingEnabled = true;
            cmbStatusOs.Items.AddRange(new object[] { "Aguardando", "Em análise", "Aguardando peça", "Pronto", "Entregue" });
            cmbStatusOs.Location = new Point(435, 42);
            cmbStatusOs.Name = "cmbStatusOs";
            cmbStatusOs.Size = new Size(190, 23);
            cmbStatusOs.TabIndex = 4;
            //
            // lblValor
            //
            lblValor.AutoSize = true;
            lblValor.Location = new Point(645, 22);
            lblValor.Name = "lblValor";
            lblValor.TabIndex = 4;
            lblValor.Text = "Valor (R$)";
            //
            // txtValor
            //
            txtValor.Enabled = false;
            txtValor.Location = new Point(645, 42);
            txtValor.Name = "txtValor";
            txtValor.PlaceholderText = "0,00";
            txtValor.Size = new Size(200, 23);
            txtValor.TabIndex = 5;
            //
            // lblLaudo
            //
            lblLaudo.AutoSize = true;
            lblLaudo.Location = new Point(435, 80);
            lblLaudo.Name = "lblLaudo";
            lblLaudo.TabIndex = 6;
            lblLaudo.Text = "Laudo técnico (o que foi encontrado e feito)";
            //
            // txtLaudo
            //
            txtLaudo.Enabled = false;
            txtLaudo.Location = new Point(435, 100);
            txtLaudo.Multiline = true;
            txtLaudo.Name = "txtLaudo";
            txtLaudo.ScrollBars = ScrollBars.Vertical;
            txtLaudo.Size = new Size(410, 70);
            txtLaudo.TabIndex = 6;
            //
            // btnSalvar
            //
            btnSalvar.Enabled = false;
            btnSalvar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSalvar.Location = new Point(435, 357);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(160, 40);
            btnSalvar.TabIndex = 7;
            btnSalvar.Text = "Salvar alterações";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            //
            // btnExcluir
            //
            btnExcluir.Enabled = false;
            btnExcluir.Location = new Point(605, 357);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(120, 40);
            btnExcluir.TabIndex = 8;
            btnExcluir.Text = "Excluir OS";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            //
            // btnImprimir
            //
            btnImprimir.Enabled = false;
            btnImprimir.Location = new Point(735, 357);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(110, 40);
            btnImprimir.TabIndex = 9;
            btnImprimir.Text = "Imprimir OS";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            //
            // lblItens
            //
            lblItens.AutoSize = true;
            lblItens.Location = new Point(435, 180);
            lblItens.Name = "lblItens";
            lblItens.TabIndex = 10;
            lblItens.Text = "Serviços e peças (o que foi feito e trocado)";
            //
            // txtItem
            //
            txtItem.Enabled = false;
            txtItem.Location = new Point(435, 200);
            txtItem.MaxLength = 100;
            txtItem.Name = "txtItem";
            txtItem.PlaceholderText = "Ex.: Formatação, SSD 240 GB";
            txtItem.Size = new Size(270, 23);
            txtItem.TabIndex = 11;
            txtItem.KeyDown += txtItem_KeyDown;
            //
            // nudQtd
            //
            nudQtd.Enabled = false;
            nudQtd.Location = new Point(713, 200);
            nudQtd.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            nudQtd.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudQtd.Name = "nudQtd";
            nudQtd.Size = new Size(55, 23);
            nudQtd.TabIndex = 12;
            nudQtd.TextAlign = HorizontalAlignment.Center;
            nudQtd.Value = new decimal(new int[] { 1, 0, 0, 0 });
            //
            // btnAddItem
            //
            btnAddItem.Enabled = false;
            btnAddItem.Location = new Point(776, 198);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(69, 27);
            btnAddItem.TabIndex = 13;
            btnAddItem.Text = "Adicionar";
            btnAddItem.UseVisualStyleBackColor = true;
            btnAddItem.Click += btnAddItem_Click;
            //
            // lstItens
            //
            lstItens.Enabled = false;
            lstItens.FormattingEnabled = true;
            lstItens.Location = new Point(435, 230);
            lstItens.Name = "lstItens";
            lstItens.Size = new Size(410, 79);
            lstItens.TabIndex = 14;
            lstItens.SelectedIndexChanged += lstItens_SelectedIndexChanged;
            //
            // btnRemoverItem
            //
            btnRemoverItem.Enabled = false;
            btnRemoverItem.Location = new Point(435, 316);
            btnRemoverItem.Name = "btnRemoverItem";
            btnRemoverItem.Size = new Size(190, 28);
            btnRemoverItem.TabIndex = 15;
            btnRemoverItem.Text = "Remover item selecionado";
            btnRemoverItem.UseVisualStyleBackColor = true;
            btnRemoverItem.Click += btnRemoverItem_Click;
            //
            // btnWhatsApp
            //
            btnWhatsApp.Enabled = false;
            btnWhatsApp.Location = new Point(15, 357);
            btnWhatsApp.Name = "btnWhatsApp";
            btnWhatsApp.Size = new Size(400, 40);
            btnWhatsApp.TabIndex = 16;
            btnWhatsApp.Text = "Avisar cliente no WhatsApp";
            btnWhatsApp.UseVisualStyleBackColor = true;
            btnWhatsApp.Click += btnWhatsApp_Click;
            //
            // ListaOsControl
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(lblTitulo);
            Controls.Add(lblFiltroStatus);
            Controls.Add(cmbFiltroStatus);
            Controls.Add(lblBusca);
            Controls.Add(txtBusca);
            Controls.Add(lblTotal);
            Controls.Add(dgvOs);
            Controls.Add(grpDetalhes);
            Name = "ListaOsControl";
            Size = new Size(900, 762);
            Load += ListaOsControl_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOs).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudQtd).EndInit();
            grpDetalhes.ResumeLayout(false);
            grpDetalhes.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitulo;
        private Label lblFiltroStatus;
        private ComboBox cmbFiltroStatus;
        private Label lblBusca;
        private TextBox txtBusca;
        private Label lblTotal;
        private DataGridView dgvOs;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNumero;
        private DataGridViewTextBoxColumn colData;
        private DataGridViewTextBoxColumn colCliente;
        private DataGridViewTextBoxColumn colEquipamento;
        private DataGridViewTextBoxColumn colDefeito;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colValor;
        private GroupBox grpDetalhes;
        private Label lblResumo;
        private TextBox txtResumo;
        private Label lblStatusOs;
        private ComboBox cmbStatusOs;
        private Label lblValor;
        private TextBox txtValor;
        private Label lblLaudo;
        private TextBox txtLaudo;
        private Button btnSalvar;
        private Button btnExcluir;
        private Button btnImprimir;
        private Label lblItens;
        private TextBox txtItem;
        private NumericUpDown nudQtd;
        private Button btnAddItem;
        private ListBox lstItens;
        private Button btnRemoverItem;
        private Button btnWhatsApp;
    }
}