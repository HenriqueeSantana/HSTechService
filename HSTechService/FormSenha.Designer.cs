namespace HSTechService
{
    partial class FormSenha
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
            lblTitulo = new Label();
            lblDescricao = new Label();
            lblCampoUm = new Label();
            txtCampoUm = new TextBox();
            lblNova = new Label();
            txtNova = new TextBox();
            lblConfirmar = new Label();
            txtConfirmar = new TextBox();
            lblAviso = new Label();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(30, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Alterar senha";
            //
            // lblDescricao
            //
            lblDescricao.ForeColor = Color.FromArgb(107, 114, 128);
            lblDescricao.Location = new Point(32, 60);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(336, 40);
            lblDescricao.TabIndex = 1;
            //
            // lblCampoUm
            //
            lblCampoUm.AutoSize = true;
            lblCampoUm.Location = new Point(32, 108);
            lblCampoUm.Name = "lblCampoUm";
            lblCampoUm.TabIndex = 2;
            lblCampoUm.Text = "Senha atual";
            //
            // txtCampoUm
            //
            txtCampoUm.Location = new Point(32, 128);
            txtCampoUm.Name = "txtCampoUm";
            txtCampoUm.Size = new Size(336, 23);
            txtCampoUm.TabIndex = 0;
            txtCampoUm.UseSystemPasswordChar = true;
            //
            // lblNova
            //
            lblNova.AutoSize = true;
            lblNova.Location = new Point(32, 165);
            lblNova.Name = "lblNova";
            lblNova.TabIndex = 4;
            lblNova.Text = "Nova senha";
            //
            // txtNova
            //
            txtNova.Location = new Point(32, 185);
            txtNova.Name = "txtNova";
            txtNova.Size = new Size(336, 23);
            txtNova.TabIndex = 1;
            txtNova.UseSystemPasswordChar = true;
            //
            // lblConfirmar
            //
            lblConfirmar.AutoSize = true;
            lblConfirmar.Location = new Point(32, 222);
            lblConfirmar.Name = "lblConfirmar";
            lblConfirmar.TabIndex = 6;
            lblConfirmar.Text = "Confirmar nova senha";
            //
            // txtConfirmar
            //
            txtConfirmar.Location = new Point(32, 242);
            txtConfirmar.Name = "txtConfirmar";
            txtConfirmar.Size = new Size(336, 23);
            txtConfirmar.TabIndex = 2;
            txtConfirmar.UseSystemPasswordChar = true;
            //
            // lblAviso
            //
            lblAviso.ForeColor = Color.FromArgb(220, 38, 38);
            lblAviso.Location = new Point(32, 278);
            lblAviso.Name = "lblAviso";
            lblAviso.Size = new Size(336, 34);
            lblAviso.TabIndex = 8;
            //
            // btnConfirmar
            //
            btnConfirmar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnConfirmar.Location = new Point(32, 322);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(165, 38);
            btnConfirmar.TabIndex = 3;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            //
            // btnCancelar
            //
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(203, 322);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(165, 38);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            //
            // FormSenha
            //
            AcceptButton = btnConfirmar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(400, 385);
            Controls.Add(lblTitulo);
            Controls.Add(lblDescricao);
            Controls.Add(lblCampoUm);
            Controls.Add(txtCampoUm);
            Controls.Add(lblNova);
            Controls.Add(txtNova);
            Controls.Add(lblConfirmar);
            Controls.Add(txtConfirmar);
            Controls.Add(lblAviso);
            Controls.Add(btnConfirmar);
            Controls.Add(btnCancelar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormSenha";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Alterar senha";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitulo;
        private Label lblDescricao;
        private Label lblCampoUm;
        private TextBox txtCampoUm;
        private Label lblNova;
        private TextBox txtNova;
        private Label lblConfirmar;
        private TextBox txtConfirmar;
        private Label lblAviso;
        private Button btnConfirmar;
        private Button btnCancelar;
    }
}