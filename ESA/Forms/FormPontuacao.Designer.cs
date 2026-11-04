namespace ESA.Forms
{
    partial class FormPontuacao
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
            lblAluno = new Label();
            cmbAluno = new ComboBox();
            lblNota = new Label();
            txtNota = new TextBox();
            btnRegistrar = new Button();
            btnAlterar = new Button();
            btnExcluir = new Button();
            lblHistorico = new Label();
            dgvHistorico = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvHistorico).BeginInit();
            SuspendLayout();
            //
            // lblAluno
            //
            lblAluno.AutoSize = true;
            lblAluno.Location = new Point(20, 20);
            lblAluno.Name = "lblAluno";
            lblAluno.Size = new Size(40, 15);
            lblAluno.TabIndex = 0;
            lblAluno.Text = "Aluno:";
            //
            // cmbAluno
            //
            cmbAluno.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAluno.FormattingEnabled = true;
            cmbAluno.Location = new Point(20, 40);
            cmbAluno.Name = "cmbAluno";
            cmbAluno.Size = new Size(300, 23);
            cmbAluno.TabIndex = 1;
            cmbAluno.SelectedIndexChanged += cmbAluno_SelectedIndexChanged;
            //
            // lblNota
            //
            lblNota.AutoSize = true;
            lblNota.Location = new Point(20, 78);
            lblNota.Name = "lblNota";
            lblNota.Size = new Size(190, 15);
            lblNota.TabIndex = 2;
            lblNota.Text = "Pontuação da peça (0,0 a 100,0):";
            //
            // txtNota
            //
            txtNota.Location = new Point(20, 100);
            txtNota.Name = "txtNota";
            txtNota.Size = new Size(120, 23);
            txtNota.TabIndex = 3;
            //
            // btnRegistrar
            //
            btnRegistrar.Location = new Point(160, 95);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(110, 30);
            btnRegistrar.TabIndex = 4;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            //
            // btnAlterar
            //
            btnAlterar.Location = new Point(280, 95);
            btnAlterar.Name = "btnAlterar";
            btnAlterar.Size = new Size(140, 30);
            btnAlterar.TabIndex = 5;
            btnAlterar.Text = "Alterar selecionada";
            btnAlterar.UseVisualStyleBackColor = true;
            btnAlterar.Click += btnAlterar_Click;
            //
            // btnExcluir
            //
            btnExcluir.Location = new Point(430, 95);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(130, 30);
            btnExcluir.TabIndex = 6;
            btnExcluir.Text = "Excluir selecionada";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            //
            // lblHistorico
            //
            lblHistorico.AutoSize = true;
            lblHistorico.Location = new Point(20, 165);
            lblHistorico.Name = "lblHistorico";
            lblHistorico.Size = new Size(111, 15);
            lblHistorico.TabIndex = 7;
            lblHistorico.Text = "Histórico do aluno:";
            //
            // dgvHistorico
            //
            dgvHistorico.AllowUserToAddRows = false;
            dgvHistorico.AllowUserToDeleteRows = false;
            dgvHistorico.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorico.BackgroundColor = SystemColors.Window;
            dgvHistorico.MultiSelect = false;
            dgvHistorico.ReadOnly = true;
            dgvHistorico.RowHeadersVisible = false;
            dgvHistorico.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorico.Location = new Point(20, 190);
            dgvHistorico.Name = "dgvHistorico";
            dgvHistorico.Size = new Size(540, 220);
            dgvHistorico.TabIndex = 8;
            //
            // FormPontuacao
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 451);
            Controls.Add(lblAluno);
            Controls.Add(cmbAluno);
            Controls.Add(lblNota);
            Controls.Add(txtNota);
            Controls.Add(btnRegistrar);
            Controls.Add(btnAlterar);
            Controls.Add(btnExcluir);
            Controls.Add(lblHistorico);
            Controls.Add(dgvHistorico);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormPontuacao";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Registrar pontuação de peça";
            Load += FormPontuacao_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHistorico).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAluno;
        private ComboBox cmbAluno;
        private Label lblNota;
        private TextBox txtNota;
        private Button btnRegistrar;
        private Button btnAlterar;
        private Button btnExcluir;
        private Label lblHistorico;
        private DataGridView dgvHistorico;
    }
}
