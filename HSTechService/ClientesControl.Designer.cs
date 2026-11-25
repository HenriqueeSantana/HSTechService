namespace HSTechService
{
    partial class ClientesControl
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
            grpDados = new GroupBox();
            lblNome = new Label();
            txtNome = new TextBox();
            lblCpfCnpj = new Label();
            txtCpfCnpj = new TextBox();
            lblTelefone = new Label();
            txtTelefone = new TextBox();
            lblWhatsApp = new Label();
            txtWhatsApp = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblCidade = new Label();
            txtCidade = new TextBox();
            lblEndereco = new Label();
            txtEndereco = new TextBox();
            lblNumero = new Label();
            txtNumero = new TextBox();
            lblBairro = new Label();
            txtBairro = new TextBox();
            btnNovo = new Button();
            btnSalvar = new Button();
            btnExcluir = new Button();
            lblBusca = new Label();
            txtBusca = new TextBox();
            dgvClientes = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colNome = new DataGridViewTextBoxColumn();
            colCpfCnpj = new DataGridViewTextBoxColumn();
            colTelefone = new DataGridViewTextBoxColumn();
            colWhatsApp = new DataGridViewTextBoxColumn();
            colCidade = new DataGridViewTextBoxColumn();
            grpDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            //
            // grpDados
            //
            grpDados.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpDados.Controls.Add(lblNome);
            grpDados.Controls.Add(txtNome);
            grpDados.Controls.Add(lblCpfCnpj);
            grpDados.Controls.Add(txtCpfCnpj);
            grpDados.Controls.Add(lblTelefone);
            grpDados.Controls.Add(txtTelefone);
            grpDados.Controls.Add(lblWhatsApp);
            grpDados.Controls.Add(txtWhatsApp);
            grpDados.Controls.Add(lblEmail);
            grpDados.Controls.Add(txtEmail);
            grpDados.Controls.Add(lblCidade);
            grpDados.Controls.Add(txtCidade);
            grpDados.Controls.Add(lblEndereco);
            grpDados.Controls.Add(txtEndereco);
            grpDados.Controls.Add(lblNumero);
            grpDados.Controls.Add(txtNumero);
            grpDados.Controls.Add(lblBairro);
            grpDados.Controls.Add(txtBairro);
            grpDados.Location = new Point(12, 12);
            grpDados.Name = "grpDados";
            grpDados.Size = new Size(876, 195);
            grpDados.TabIndex = 0;
            grpDados.TabStop = false;
            grpDados.Text = "Dados do cliente";
            //
            // lblNome
            //
            lblNome.AutoSize = true;
            lblNome.Location = new Point(15, 25);
            lblNome.Name = "lblNome";
            lblNome.TabIndex = 0;
            lblNome.Text = "Nome completo";
            //
            // txtNome
            //
            txtNome.Location = new Point(15, 45);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(400, 23);
            txtNome.TabIndex = 1;
            //
            // lblCpfCnpj
            //
            lblCpfCnpj.AutoSize = true;
            lblCpfCnpj.Location = new Point(430, 25);
            lblCpfCnpj.Name = "lblCpfCnpj";
            lblCpfCnpj.TabIndex = 2;
            lblCpfCnpj.Text = "CPF/CNPJ";
            //
            // txtCpfCnpj
            //
            txtCpfCnpj.Location = new Point(430, 45);
            txtCpfCnpj.Name = "txtCpfCnpj";
            txtCpfCnpj.Size = new Size(200, 23);
            txtCpfCnpj.TabIndex = 3;
            //
            // lblTelefone
            //
            lblTelefone.AutoSize = true;
            lblTelefone.Location = new Point(645, 25);
            lblTelefone.Name = "lblTelefone";
            lblTelefone.TabIndex = 4;
            lblTelefone.Text = "Telefone";
            //
            // txtTelefone
            //
            txtTelefone.Location = new Point(645, 45);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(215, 23);
            txtTelefone.TabIndex = 5;
            //
            // lblWhatsApp
            //
            lblWhatsApp.AutoSize = true;
            lblWhatsApp.Location = new Point(15, 80);
            lblWhatsApp.Name = "lblWhatsApp";
            lblWhatsApp.TabIndex = 6;
            lblWhatsApp.Text = "WhatsApp";
            //
            // txtWhatsApp
            //
            txtWhatsApp.Location = new Point(15, 100);
            txtWhatsApp.Name = "txtWhatsApp";
            txtWhatsApp.Size = new Size(190, 23);
            txtWhatsApp.TabIndex = 7;
            //
            // lblEmail
            //
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(220, 80);
            lblEmail.Name = "lblEmail";
            lblEmail.TabIndex = 8;
            lblEmail.Text = "E-mail";
            //
            // txtEmail
            //
            txtEmail.Location = new Point(220, 100);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(410, 23);
            txtEmail.TabIndex = 9;
            //
            // lblCidade
            //
            lblCidade.AutoSize = true;
            lblCidade.Location = new Point(645, 80);
            lblCidade.Name = "lblCidade";
            lblCidade.TabIndex = 10;
            lblCidade.Text = "Cidade";
            //
            // txtCidade
            //
            txtCidade.Location = new Point(645, 100);
            txtCidade.Name = "txtCidade";
            txtCidade.Size = new Size(215, 23);
            txtCidade.TabIndex = 11;
            //
            // lblEndereco
            //
            lblEndereco.AutoSize = true;
            lblEndereco.Location = new Point(15, 135);
            lblEndereco.Name = "lblEndereco";
            lblEndereco.TabIndex = 12;
            lblEndereco.Text = "Endereço (rua)";
            //
            // txtEndereco
            //
            txtEndereco.Location = new Point(15, 155);
            txtEndereco.Name = "txtEndereco";
            txtEndereco.Size = new Size(400, 23);
            txtEndereco.TabIndex = 13;
            //
            // lblNumero
            //
            lblNumero.AutoSize = true;
            lblNumero.Location = new Point(430, 135);
            lblNumero.Name = "lblNumero";
            lblNumero.TabIndex = 14;
            lblNumero.Text = "Número";
            //
            // txtNumero
            //
            txtNumero.Location = new Point(430, 155);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(100, 23);
            txtNumero.TabIndex = 15;
            //
            // lblBairro
            //
            lblBairro.AutoSize = true;
            lblBairro.Location = new Point(545, 135);
            lblBairro.Name = "lblBairro";
            lblBairro.TabIndex = 16;
            lblBairro.Text = "Bairro";
            //
            // txtBairro
            //
            txtBairro.Location = new Point(545, 155);
            txtBairro.Name = "txtBairro";
            txtBairro.Size = new Size(315, 23);
            txtBairro.TabIndex = 17;
            //
            // btnNovo
            //
            btnNovo.Location = new Point(12, 219);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(100, 32);
            btnNovo.TabIndex = 1;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            //
            // btnSalvar
            //
            btnSalvar.Location = new Point(122, 219);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(100, 32);
            btnSalvar.TabIndex = 2;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            //
            // btnExcluir
            //
            btnExcluir.Location = new Point(232, 219);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(100, 32);
            btnExcluir.TabIndex = 3;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            //
            // lblBusca
            //
            lblBusca.AutoSize = true;
            lblBusca.Location = new Point(12, 270);
            lblBusca.Name = "lblBusca";
            lblBusca.TabIndex = 4;
            lblBusca.Text = "Buscar:";
            //
            // txtBusca
            //
            txtBusca.Location = new Point(65, 266);
            txtBusca.Name = "txtBusca";
            txtBusca.PlaceholderText = "Nome, CPF/CNPJ ou telefone";
            txtBusca.Size = new Size(400, 23);
            txtBusca.TabIndex = 5;
            txtBusca.TextChanged += txtBusca_TextChanged;
            //
            // dgvClientes
            //
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.AllowUserToResizeRows = false;
            dgvClientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.BackgroundColor = Color.White;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Columns.AddRange(new DataGridViewColumn[] { colId, colNome, colCpfCnpj, colTelefone, colWhatsApp, colCidade });
            dgvClientes.Location = new Point(12, 297);
            dgvClientes.MultiSelect = false;
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.Size = new Size(876, 371);
            dgvClientes.TabIndex = 6;
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
            colNome.FillWeight = 160F;
            colNome.HeaderText = "Nome";
            colNome.Name = "colNome";
            colNome.ReadOnly = true;
            //
            // colCpfCnpj
            //
            colCpfCnpj.DataPropertyName = "CpfCnpj";
            colCpfCnpj.HeaderText = "CPF/CNPJ";
            colCpfCnpj.Name = "colCpfCnpj";
            colCpfCnpj.ReadOnly = true;
            //
            // colTelefone
            //
            colTelefone.DataPropertyName = "Telefone";
            colTelefone.HeaderText = "Telefone";
            colTelefone.Name = "colTelefone";
            colTelefone.ReadOnly = true;
            //
            // colWhatsApp
            //
            colWhatsApp.DataPropertyName = "WhatsApp";
            colWhatsApp.HeaderText = "WhatsApp";
            colWhatsApp.Name = "colWhatsApp";
            colWhatsApp.ReadOnly = true;
            //
            // colCidade
            //
            colCidade.DataPropertyName = "Cidade";
            colCidade.HeaderText = "Cidade";
            colCidade.Name = "colCidade";
            colCidade.ReadOnly = true;
            //
            // ClientesControl
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(grpDados);
            Controls.Add(btnNovo);
            Controls.Add(btnSalvar);
            Controls.Add(btnExcluir);
            Controls.Add(lblBusca);
            Controls.Add(txtBusca);
            Controls.Add(dgvClientes);
            Name = "ClientesControl";
            Size = new Size(900, 680);
            Load += ClientesControl_Load;
            grpDados.ResumeLayout(false);
            grpDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private GroupBox grpDados;
        private Label lblNome;
        private TextBox txtNome;
        private Label lblCpfCnpj;
        private TextBox txtCpfCnpj;
        private Label lblTelefone;
        private TextBox txtTelefone;
        private Label lblWhatsApp;
        private TextBox txtWhatsApp;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblCidade;
        private TextBox txtCidade;
        private Label lblEndereco;
        private TextBox txtEndereco;
        private Label lblNumero;
        private TextBox txtNumero;
        private Label lblBairro;
        private TextBox txtBairro;
        private Button btnNovo;
        private Button btnSalvar;
        private Button btnExcluir;
        private Label lblBusca;
        private TextBox txtBusca;
        private DataGridView dgvClientes;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNome;
        private DataGridViewTextBoxColumn colCpfCnpj;
        private DataGridViewTextBoxColumn colTelefone;
        private DataGridViewTextBoxColumn colWhatsApp;
        private DataGridViewTextBoxColumn colCidade;
    }
}