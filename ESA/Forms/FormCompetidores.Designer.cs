#nullable enable
namespace ESA.Forms
{
    partial class FormCompetidores
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblNome = new Label();
            txtNome = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblInstituicao = new Label();
            cmbInstituicao = new ComboBox();
            lblTelefone = new Label();
            txtTelefone = new TextBox();
            btnCadastrar = new Button();
            btnRemover = new Button();
            btnLimpar = new Button();
            dgvCompetidores = new DataGridView();
            lblTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCompetidores).BeginInit();
            SuspendLayout();
            //
            // lblNome
            //
            lblNome.AutoSize = true;
            lblNome.Location = new Point(20, 15);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(60, 15);
            lblNome.TabIndex = 0;
            lblNome.Text = "Nome completo:";
            //
            // txtNome
            //
            txtNome.Location = new Point(20, 35);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(300, 23);
            txtNome.TabIndex = 1;
            //
            // lblEmail
            //
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(340, 15);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(60, 15);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "E-mail:";
            //
            // txtEmail
            //
            txtEmail.Location = new Point(340, 35);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(340, 23);
            txtEmail.TabIndex = 3;
            //
            // lblInstituicao
            //
            lblInstituicao.AutoSize = true;
            lblInstituicao.Location = new Point(20, 70);
            lblInstituicao.Name = "lblInstituicao";
            lblInstituicao.Size = new Size(60, 15);
            lblInstituicao.TabIndex = 4;
            lblInstituicao.Text = "Instituição:";
            //
            // cmbInstituicao
            //
            cmbInstituicao.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbInstituicao.FormattingEnabled = true;
            cmbInstituicao.Location = new Point(20, 90);
            cmbInstituicao.Name = "cmbInstituicao";
            cmbInstituicao.Size = new Size(300, 23);
            cmbInstituicao.TabIndex = 5;
            //
            // lblTelefone
            //
            lblTelefone.AutoSize = true;
            lblTelefone.Location = new Point(340, 70);
            lblTelefone.Name = "lblTelefone";
            lblTelefone.Size = new Size(60, 15);
            lblTelefone.TabIndex = 6;
            lblTelefone.Text = "Telefone:";
            //
            // txtTelefone
            //
            txtTelefone.Location = new Point(340, 90);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(200, 23);
            txtTelefone.TabIndex = 7;
            //
            // btnCadastrar
            //
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Location = new Point(20, 130);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(110, 30);
            btnCadastrar.TabIndex = 8;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.Click += btnCadastrar_Click;
            //
            // btnRemover
            //
            btnRemover.UseVisualStyleBackColor = true;
            btnRemover.Location = new Point(140, 130);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(110, 30);
            btnRemover.TabIndex = 9;
            btnRemover.Text = "Remover";
            btnRemover.Click += btnRemover_Click;
            //
            // btnLimpar
            //
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Location = new Point(260, 130);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(120, 30);
            btnLimpar.TabIndex = 10;
            btnLimpar.Text = "Limpar campos";
            btnLimpar.Click += btnLimpar_Click;
            //
            // dgvCompetidores
            //
            dgvCompetidores.AllowUserToAddRows = false;
            dgvCompetidores.AllowUserToDeleteRows = false;
            dgvCompetidores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCompetidores.BackgroundColor = SystemColors.Window;
            dgvCompetidores.MultiSelect = false;
            dgvCompetidores.ReadOnly = true;
            dgvCompetidores.RowHeadersVisible = false;
            dgvCompetidores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCompetidores.Location = new Point(20, 175);
            dgvCompetidores.Name = "dgvCompetidores";
            dgvCompetidores.Size = new Size(680, 290);
            dgvCompetidores.TabIndex = 11;
            //
            // lblTotal
            //
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(20, 475);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(60, 15);
            lblTotal.TabIndex = 12;
            lblTotal.Text = "";
            //
            // FormCompetidores
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 520);
            Controls.Add(lblNome);
            Controls.Add(txtNome);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblInstituicao);
            Controls.Add(cmbInstituicao);
            Controls.Add(lblTelefone);
            Controls.Add(txtTelefone);
            Controls.Add(btnCadastrar);
            Controls.Add(btnRemover);
            Controls.Add(btnLimpar);
            Controls.Add(dgvCompetidores);
            Controls.Add(lblTotal);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormCompetidores";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Competidores";
            Load += FormCompetidores_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCompetidores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNome;
        private TextBox txtNome;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblInstituicao;
        private ComboBox cmbInstituicao;
        private Label lblTelefone;
        private TextBox txtTelefone;
        private Button btnCadastrar;
        private Button btnRemover;
        private Button btnLimpar;
        private DataGridView dgvCompetidores;
        private Label lblTotal;
    }
}
