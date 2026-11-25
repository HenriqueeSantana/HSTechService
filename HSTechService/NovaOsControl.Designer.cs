namespace HSTechService
{
    partial class NovaOsControl
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
            DataGridViewCellStyle estiloValorHist = new DataGridViewCellStyle();
            lblTitulo = new Label();
            grpCliente = new GroupBox();
            lblBuscaCliente = new Label();
            txtBuscaCliente = new TextBox();
            btnNovoCliente = new Button();
            dgvClientes = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colNome = new DataGridViewTextBoxColumn();
            colCpfCnpj = new DataGridViewTextBoxColumn();
            colTelefone = new DataGridViewTextBoxColumn();
            colEndereco = new DataGridViewTextBoxColumn();
            colCidade = new DataGridViewTextBoxColumn();
            pnlSelecionado = new Panel();
            lblSelecionado = new Label();
            grpHistorico = new GroupBox();
            lblHistorico = new Label();
            dgvHistorico = new DataGridView();
            colHId = new DataGridViewTextBoxColumn();
            colHNumero = new DataGridViewTextBoxColumn();
            colHData = new DataGridViewTextBoxColumn();
            colHEquip = new DataGridViewTextBoxColumn();
            colHDefeito = new DataGridViewTextBoxColumn();
            colHStatus = new DataGridViewTextBoxColumn();
            colHValor = new DataGridViewTextBoxColumn();
            btnUsarEquip = new Button();
            grpEquip = new GroupBox();
            lblTipo = new Label();
            cmbTipo = new ComboBox();
            lblMarca = new Label();
            txtMarca = new TextBox();
            lblModelo = new Label();
            txtModelo = new TextBox();
            lblSerie = new Label();
            txtSerie = new TextBox();
            lblSenha = new Label();
            txtSenha = new TextBox();
            lblProcessador = new Label();
            txtProcessador = new TextBox();
            lblMemoria = new Label();
            txtMemoria = new TextBox();
            lblArmazenamento = new Label();
            txtArmazenamento = new TextBox();
            lblAcessorios = new Label();
            txtAcessorios = new TextBox();
            lblObs = new Label();
            txtObs = new TextBox();
            grpDefeito = new GroupBox();
            lblMarque = new Label();
            clbDefeitos = new CheckedListBox();
            lblDetalhes = new Label();
            txtDefeito = new TextBox();
            btnSalvar = new Button();
            btnLimpar = new Button();
            grpCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            pnlSelecionado.SuspendLayout();
            grpHistorico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorico).BeginInit();
            grpEquip.SuspendLayout();
            grpDefeito.SuspendLayout();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(18, 14);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Nova ordem de serviço";
            //
            // grpCliente
            //
            grpCliente.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpCliente.Controls.Add(lblBuscaCliente);
            grpCliente.Controls.Add(txtBuscaCliente);
            grpCliente.Controls.Add(btnNovoCliente);
            grpCliente.Controls.Add(dgvClientes);
            grpCliente.Controls.Add(pnlSelecionado);
            grpCliente.Location = new Point(20, 55);
            grpCliente.Name = "grpCliente";
            grpCliente.Size = new Size(860, 228);
            grpCliente.TabIndex = 1;
            grpCliente.TabStop = false;
            grpCliente.Text = "1. Cliente";
            //
            // lblBuscaCliente
            //
            lblBuscaCliente.AutoSize = true;
            lblBuscaCliente.Location = new Point(15, 25);
            lblBuscaCliente.Name = "lblBuscaCliente";
            lblBuscaCliente.TabIndex = 0;
            lblBuscaCliente.Text = "Buscar cliente (nome, CPF/CNPJ ou telefone)";
            //
            // txtBuscaCliente
            //
            txtBuscaCliente.Location = new Point(15, 45);
            txtBuscaCliente.Name = "txtBuscaCliente";
            txtBuscaCliente.PlaceholderText = "Digite para filtrar a lista";
            txtBuscaCliente.Size = new Size(400, 23);
            txtBuscaCliente.TabIndex = 0;
            txtBuscaCliente.TextChanged += txtBuscaCliente_TextChanged;
            //
            // btnNovoCliente
            //
            btnNovoCliente.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNovoCliente.Location = new Point(665, 42);
            btnNovoCliente.Name = "btnNovoCliente";
            btnNovoCliente.Size = new Size(180, 30);
            btnNovoCliente.TabIndex = 1;
            btnNovoCliente.Text = "Cadastrar novo cliente";
            btnNovoCliente.UseVisualStyleBackColor = true;
            btnNovoCliente.Click += btnNovoCliente_Click;
            //
            // dgvClientes
            //
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.AllowUserToResizeRows = false;
            dgvClientes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Columns.AddRange(new DataGridViewColumn[] { colId, colNome, colCpfCnpj, colTelefone, colEndereco, colCidade });
            dgvClientes.Location = new Point(15, 78);
            dgvClientes.MultiSelect = false;
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.Size = new Size(830, 98);
            dgvClientes.TabIndex = 2;
            dgvClientes.CellClick += dgvClientes_CellClick;
            //
            // colId
            //
            colId.DataPropertyName = "Id";
            colId.HeaderText = "Id";
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            //
            // colNome
            //
            colNome.DataPropertyName = "Nome";
            colNome.FillWeight = 150F;
            colNome.HeaderText = "Nome";
            colNome.Name = "colNome";
            colNome.ReadOnly = true;
            //
            // colCpfCnpj
            //
            colCpfCnpj.DataPropertyName = "CpfCnpj";
            colCpfCnpj.FillWeight = 90F;
            colCpfCnpj.HeaderText = "CPF/CNPJ";
            colCpfCnpj.Name = "colCpfCnpj";
            colCpfCnpj.ReadOnly = true;
            //
            // colTelefone
            //
            colTelefone.DataPropertyName = "Telefone";
            colTelefone.FillWeight = 90F;
            colTelefone.HeaderText = "Telefone";
            colTelefone.Name = "colTelefone";
            colTelefone.ReadOnly = true;
            //
            // colEndereco
            //
            colEndereco.DataPropertyName = "EnderecoCompleto";
            colEndereco.FillWeight = 190F;
            colEndereco.HeaderText = "Endereço";
            colEndereco.Name = "colEndereco";
            colEndereco.ReadOnly = true;
            //
            // colCidade
            //
            colCidade.DataPropertyName = "Cidade";
            colCidade.FillWeight = 90F;
            colCidade.HeaderText = "Cidade";
            colCidade.Name = "colCidade";
            colCidade.ReadOnly = true;
            //
            // pnlSelecionado
            //
            pnlSelecionado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSelecionado.BackColor = Color.FromArgb(219, 234, 254);
            pnlSelecionado.Controls.Add(lblSelecionado);
            pnlSelecionado.Location = new Point(15, 184);
            pnlSelecionado.Name = "pnlSelecionado";
            pnlSelecionado.Size = new Size(830, 32);
            pnlSelecionado.TabIndex = 3;
            //
            // lblSelecionado
            //
            lblSelecionado.AutoEllipsis = true;
            lblSelecionado.Dock = DockStyle.Fill;
            lblSelecionado.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSelecionado.ForeColor = Color.FromArgb(10, 25, 47);
            lblSelecionado.Name = "lblSelecionado";
            lblSelecionado.Padding = new Padding(10, 0, 0, 0);
            lblSelecionado.Size = new Size(830, 32);
            lblSelecionado.TabIndex = 0;
            lblSelecionado.Text = "Nenhum cliente selecionado.";
            lblSelecionado.TextAlign = ContentAlignment.MiddleLeft;
            //
            // grpHistorico
            //
            grpHistorico.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpHistorico.Controls.Add(lblHistorico);
            grpHistorico.Controls.Add(dgvHistorico);
            grpHistorico.Controls.Add(btnUsarEquip);
            grpHistorico.Location = new Point(20, 293);
            grpHistorico.Name = "grpHistorico";
            grpHistorico.Size = new Size(860, 196);
            grpHistorico.TabIndex = 2;
            grpHistorico.TabStop = false;
            grpHistorico.Text = "Histórico do cliente";
            //
            // lblHistorico
            //
            lblHistorico.AutoSize = true;
            lblHistorico.Location = new Point(15, 22);
            lblHistorico.Name = "lblHistorico";
            lblHistorico.TabIndex = 0;
            lblHistorico.Text = "Selecione um cliente para ver as OS anteriores.";
            //
            // dgvHistorico
            //
            dgvHistorico.AllowUserToAddRows = false;
            dgvHistorico.AllowUserToDeleteRows = false;
            dgvHistorico.AllowUserToResizeRows = false;
            dgvHistorico.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvHistorico.AutoGenerateColumns = false;
            dgvHistorico.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorico.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorico.Columns.AddRange(new DataGridViewColumn[] { colHId, colHNumero, colHData, colHEquip, colHDefeito, colHStatus, colHValor });
            dgvHistorico.Location = new Point(15, 44);
            dgvHistorico.MultiSelect = false;
            dgvHistorico.Name = "dgvHistorico";
            dgvHistorico.ReadOnly = true;
            dgvHistorico.RowHeadersVisible = false;
            dgvHistorico.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorico.Size = new Size(830, 110);
            dgvHistorico.TabIndex = 1;
            dgvHistorico.CellFormatting += dgvHistorico_CellFormatting;
            dgvHistorico.SelectionChanged += dgvHistorico_SelectionChanged;
            //
            // colHId
            //
            colHId.DataPropertyName = "Id";
            colHId.HeaderText = "Id";
            colHId.Name = "colHId";
            colHId.ReadOnly = true;
            colHId.Visible = false;
            //
            // colHNumero
            //
            colHNumero.DataPropertyName = "Numero";
            colHNumero.FillWeight = 55F;
            colHNumero.HeaderText = "OS";
            colHNumero.Name = "colHNumero";
            colHNumero.ReadOnly = true;
            //
            // colHData
            //
            colHData.DataPropertyName = "DataEntradaFormatada";
            colHData.FillWeight = 95F;
            colHData.HeaderText = "Entrada";
            colHData.Name = "colHData";
            colHData.ReadOnly = true;
            //
            // colHEquip
            //
            colHEquip.DataPropertyName = "EquipamentoResumo";
            colHEquip.FillWeight = 130F;
            colHEquip.HeaderText = "Equipamento";
            colHEquip.Name = "colHEquip";
            colHEquip.ReadOnly = true;
            //
            // colHDefeito
            //
            colHDefeito.DataPropertyName = "DefeitoRelatado";
            colHDefeito.FillWeight = 190F;
            colHDefeito.HeaderText = "Defeito relatado";
            colHDefeito.Name = "colHDefeito";
            colHDefeito.ReadOnly = true;
            //
            // colHStatus
            //
            colHStatus.DataPropertyName = "Status";
            colHStatus.FillWeight = 90F;
            colHStatus.HeaderText = "Status";
            colHStatus.Name = "colHStatus";
            colHStatus.ReadOnly = true;
            //
            // colHValor
            //
            estiloValorHist.Alignment = DataGridViewContentAlignment.MiddleRight;
            estiloValorHist.Format = "C2";
            colHValor.DataPropertyName = "Valor";
            colHValor.DefaultCellStyle = estiloValorHist;
            colHValor.FillWeight = 70F;
            colHValor.HeaderText = "Valor";
            colHValor.Name = "colHValor";
            colHValor.ReadOnly = true;
            //
            // btnUsarEquip
            //
            btnUsarEquip.Enabled = false;
            btnUsarEquip.Location = new Point(15, 160);
            btnUsarEquip.Name = "btnUsarEquip";
            btnUsarEquip.Size = new Size(300, 28);
            btnUsarEquip.TabIndex = 2;
            btnUsarEquip.Text = "Usar o equipamento da OS selecionada";
            btnUsarEquip.UseVisualStyleBackColor = true;
            btnUsarEquip.Click += btnUsarEquip_Click;
            //
            // grpEquip
            //
            grpEquip.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpEquip.Controls.Add(lblTipo);
            grpEquip.Controls.Add(cmbTipo);
            grpEquip.Controls.Add(lblMarca);
            grpEquip.Controls.Add(txtMarca);
            grpEquip.Controls.Add(lblModelo);
            grpEquip.Controls.Add(txtModelo);
            grpEquip.Controls.Add(lblSerie);
            grpEquip.Controls.Add(txtSerie);
            grpEquip.Controls.Add(lblSenha);
            grpEquip.Controls.Add(txtSenha);
            grpEquip.Controls.Add(lblProcessador);
            grpEquip.Controls.Add(txtProcessador);
            grpEquip.Controls.Add(lblMemoria);
            grpEquip.Controls.Add(txtMemoria);
            grpEquip.Controls.Add(lblArmazenamento);
            grpEquip.Controls.Add(txtArmazenamento);
            grpEquip.Controls.Add(lblAcessorios);
            grpEquip.Controls.Add(txtAcessorios);
            grpEquip.Controls.Add(lblObs);
            grpEquip.Controls.Add(txtObs);
            grpEquip.Location = new Point(20, 499);
            grpEquip.Name = "grpEquip";
            grpEquip.Size = new Size(860, 275);
            grpEquip.TabIndex = 3;
            grpEquip.TabStop = false;
            grpEquip.Text = "2. Equipamento";
            //
            // lblTipo
            //
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(15, 25);
            lblTipo.Name = "lblTipo";
            lblTipo.TabIndex = 0;
            lblTipo.Text = "Tipo";
            //
            // cmbTipo
            //
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Items.AddRange(new object[] { "Notebook", "Desktop", "All-in-One", "Outro" });
            cmbTipo.Location = new Point(15, 45);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(140, 23);
            cmbTipo.TabIndex = 0;
            //
            // lblMarca
            //
            lblMarca.AutoSize = true;
            lblMarca.Location = new Point(170, 25);
            lblMarca.Name = "lblMarca";
            lblMarca.TabIndex = 2;
            lblMarca.Text = "Marca";
            //
            // txtMarca
            //
            txtMarca.Location = new Point(170, 45);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(170, 23);
            txtMarca.TabIndex = 1;
            //
            // lblModelo
            //
            lblModelo.AutoSize = true;
            lblModelo.Location = new Point(355, 25);
            lblModelo.Name = "lblModelo";
            lblModelo.TabIndex = 4;
            lblModelo.Text = "Modelo";
            //
            // txtModelo
            //
            txtModelo.Location = new Point(355, 45);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(250, 23);
            txtModelo.TabIndex = 2;
            //
            // lblSerie
            //
            lblSerie.AutoSize = true;
            lblSerie.Location = new Point(620, 25);
            lblSerie.Name = "lblSerie";
            lblSerie.TabIndex = 6;
            lblSerie.Text = "Nº de série";
            //
            // txtSerie
            //
            txtSerie.Location = new Point(620, 45);
            txtSerie.Name = "txtSerie";
            txtSerie.Size = new Size(225, 23);
            txtSerie.TabIndex = 3;
            //
            // lblSenha
            //
            lblSenha.AutoSize = true;
            lblSenha.Location = new Point(15, 80);
            lblSenha.Name = "lblSenha";
            lblSenha.TabIndex = 8;
            lblSenha.Text = "Senha do equip.";
            //
            // txtSenha
            //
            txtSenha.Location = new Point(15, 100);
            txtSenha.Name = "txtSenha";
            txtSenha.PlaceholderText = "Se tiver";
            txtSenha.Size = new Size(140, 23);
            txtSenha.TabIndex = 4;
            //
            // lblProcessador
            //
            lblProcessador.AutoSize = true;
            lblProcessador.Location = new Point(170, 80);
            lblProcessador.Name = "lblProcessador";
            lblProcessador.TabIndex = 10;
            lblProcessador.Text = "Processador";
            //
            // txtProcessador
            //
            txtProcessador.Location = new Point(170, 100);
            txtProcessador.Name = "txtProcessador";
            txtProcessador.PlaceholderText = "Ex.: Intel i5 8250U";
            txtProcessador.Size = new Size(170, 23);
            txtProcessador.TabIndex = 5;
            //
            // lblMemoria
            //
            lblMemoria.AutoSize = true;
            lblMemoria.Location = new Point(355, 80);
            lblMemoria.Name = "lblMemoria";
            lblMemoria.TabIndex = 12;
            lblMemoria.Text = "Memória RAM";
            //
            // txtMemoria
            //
            txtMemoria.Location = new Point(355, 100);
            txtMemoria.Name = "txtMemoria";
            txtMemoria.PlaceholderText = "Ex.: 1 pente de 8 GB DDR4";
            txtMemoria.Size = new Size(250, 23);
            txtMemoria.TabIndex = 6;
            //
            // lblArmazenamento
            //
            lblArmazenamento.AutoSize = true;
            lblArmazenamento.Location = new Point(620, 80);
            lblArmazenamento.Name = "lblArmazenamento";
            lblArmazenamento.TabIndex = 14;
            lblArmazenamento.Text = "Armazenamento";
            //
            // txtArmazenamento
            //
            txtArmazenamento.Location = new Point(620, 100);
            txtArmazenamento.Name = "txtArmazenamento";
            txtArmazenamento.PlaceholderText = "Ex.: SSD 240 GB";
            txtArmazenamento.Size = new Size(225, 23);
            txtArmazenamento.TabIndex = 7;
            //
            // lblAcessorios
            //
            lblAcessorios.AutoSize = true;
            lblAcessorios.Location = new Point(15, 135);
            lblAcessorios.Name = "lblAcessorios";
            lblAcessorios.TabIndex = 16;
            lblAcessorios.Text = "Acessórios deixados";
            //
            // txtAcessorios
            //
            txtAcessorios.Location = new Point(15, 155);
            txtAcessorios.Name = "txtAcessorios";
            txtAcessorios.PlaceholderText = "Ex.: carregador, bolsa";
            txtAcessorios.Size = new Size(830, 23);
            txtAcessorios.TabIndex = 8;
            //
            // lblObs
            //
            lblObs.AutoSize = true;
            lblObs.Location = new Point(15, 190);
            lblObs.Name = "lblObs";
            lblObs.TabIndex = 18;
            lblObs.Text = "Observações (o que tem no equipamento, estado físico)";
            //
            // txtObs
            //
            txtObs.Location = new Point(15, 210);
            txtObs.Multiline = true;
            txtObs.Name = "txtObs";
            txtObs.ScrollBars = ScrollBars.Vertical;
            txtObs.Size = new Size(830, 50);
            txtObs.TabIndex = 9;
            //
            // grpDefeito
            //
            grpDefeito.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpDefeito.Controls.Add(lblMarque);
            grpDefeito.Controls.Add(clbDefeitos);
            grpDefeito.Controls.Add(lblDetalhes);
            grpDefeito.Controls.Add(txtDefeito);
            grpDefeito.Location = new Point(20, 784);
            grpDefeito.Name = "grpDefeito";
            grpDefeito.Size = new Size(860, 215);
            grpDefeito.TabIndex = 4;
            grpDefeito.TabStop = false;
            grpDefeito.Text = "3. Defeito relatado";
            //
            // lblMarque
            //
            lblMarque.AutoSize = true;
            lblMarque.Location = new Point(15, 22);
            lblMarque.Name = "lblMarque";
            lblMarque.TabIndex = 0;
            lblMarque.Text = "Marque o que se aplica";
            //
            // clbDefeitos
            //
            clbDefeitos.CheckOnClick = true;
            clbDefeitos.ColumnWidth = 400;
            clbDefeitos.FormattingEnabled = true;
            clbDefeitos.Items.AddRange(new object[] {
                "Não liga",
                "Não dá vídeo",
                "Não carrega a bateria",
                "Desliga sozinho / superaquecimento",
                "Lento / travando",
                "Tela quebrada ou com falha",
                "Teclado ou touchpad com defeito",
                "Não reconhece o HD/SSD",
                "Não inicia o Windows",
                "Barulho / ventoinha",
                "Formatação ou limpeza",
                "Outro (descrever abaixo)" });
            clbDefeitos.Location = new Point(15, 42);
            clbDefeitos.MultiColumn = true;
            clbDefeitos.Name = "clbDefeitos";
            clbDefeitos.Size = new Size(830, 106);
            clbDefeitos.TabIndex = 10;
            //
            // lblDetalhes
            //
            lblDetalhes.AutoSize = true;
            lblDetalhes.Location = new Point(15, 155);
            lblDetalhes.Name = "lblDetalhes";
            lblDetalhes.TabIndex = 2;
            lblDetalhes.Text = "Detalhes do defeito (opcional)";
            //
            // txtDefeito
            //
            txtDefeito.Location = new Point(15, 175);
            txtDefeito.Name = "txtDefeito";
            txtDefeito.Size = new Size(830, 23);
            txtDefeito.TabIndex = 11;
            //
            // btnSalvar
            //
            btnSalvar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSalvar.Location = new Point(20, 1014);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(150, 40);
            btnSalvar.TabIndex = 5;
            btnSalvar.Text = "Abrir OS";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            //
            // btnLimpar
            //
            btnLimpar.Location = new Point(180, 1014);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(120, 40);
            btnLimpar.TabIndex = 6;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Click += btnLimpar_Click;
            //
            // NovaOsControl
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(lblTitulo);
            Controls.Add(grpCliente);
            Controls.Add(grpHistorico);
            Controls.Add(grpEquip);
            Controls.Add(grpDefeito);
            Controls.Add(btnSalvar);
            Controls.Add(btnLimpar);
            Name = "NovaOsControl";
            Size = new Size(900, 1076);
            Load += NovaOsControl_Load;
            grpCliente.ResumeLayout(false);
            grpCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            pnlSelecionado.ResumeLayout(false);
            grpHistorico.ResumeLayout(false);
            grpHistorico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorico).EndInit();
            grpEquip.ResumeLayout(false);
            grpEquip.PerformLayout();
            grpDefeito.ResumeLayout(false);
            grpDefeito.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitulo;
        private GroupBox grpCliente;
        private Label lblBuscaCliente;
        private TextBox txtBuscaCliente;
        private Button btnNovoCliente;
        private DataGridView dgvClientes;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNome;
        private DataGridViewTextBoxColumn colCpfCnpj;
        private DataGridViewTextBoxColumn colTelefone;
        private DataGridViewTextBoxColumn colEndereco;
        private DataGridViewTextBoxColumn colCidade;
        private Panel pnlSelecionado;
        private Label lblSelecionado;
        private GroupBox grpHistorico;
        private Label lblHistorico;
        private DataGridView dgvHistorico;
        private DataGridViewTextBoxColumn colHId;
        private DataGridViewTextBoxColumn colHNumero;
        private DataGridViewTextBoxColumn colHData;
        private DataGridViewTextBoxColumn colHEquip;
        private DataGridViewTextBoxColumn colHDefeito;
        private DataGridViewTextBoxColumn colHStatus;
        private DataGridViewTextBoxColumn colHValor;
        private Button btnUsarEquip;
        private GroupBox grpEquip;
        private Label lblTipo;
        private ComboBox cmbTipo;
        private Label lblMarca;
        private TextBox txtMarca;
        private Label lblModelo;
        private TextBox txtModelo;
        private Label lblSerie;
        private TextBox txtSerie;
        private Label lblSenha;
        private TextBox txtSenha;
        private Label lblProcessador;
        private TextBox txtProcessador;
        private Label lblMemoria;
        private TextBox txtMemoria;
        private Label lblArmazenamento;
        private TextBox txtArmazenamento;
        private Label lblAcessorios;
        private TextBox txtAcessorios;
        private Label lblObs;
        private TextBox txtObs;
        private GroupBox grpDefeito;
        private Label lblMarque;
        private CheckedListBox clbDefeitos;
        private Label lblDetalhes;
        private TextBox txtDefeito;
        private Button btnSalvar;
        private Button btnLimpar;
    }
}