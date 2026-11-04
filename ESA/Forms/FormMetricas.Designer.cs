namespace ESA.Forms
{
    partial class FormMetricas
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
            dgvPontuacoes = new DataGridView();
            lblMedia = new Label();
            lblMaior = new Label();
            lblMenor = new Label();
            lblQtd = new Label();
            btnGrafico = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPontuacoes).BeginInit();
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
            // dgvPontuacoes
            //
            dgvPontuacoes.AllowUserToAddRows = false;
            dgvPontuacoes.AllowUserToDeleteRows = false;
            dgvPontuacoes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPontuacoes.BackgroundColor = SystemColors.Window;
            dgvPontuacoes.MultiSelect = false;
            dgvPontuacoes.ReadOnly = true;
            dgvPontuacoes.RowHeadersVisible = false;
            dgvPontuacoes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPontuacoes.Location = new Point(20, 90);
            dgvPontuacoes.Name = "dgvPontuacoes";
            dgvPontuacoes.Size = new Size(360, 280);
            dgvPontuacoes.TabIndex = 2;
            //
            // lblMedia
            //
            lblMedia.AutoSize = true;
            lblMedia.Font = new Font("Segoe UI", 11F);
            lblMedia.Location = new Point(410, 100);
            lblMedia.Name = "lblMedia";
            lblMedia.Size = new Size(0, 20);
            lblMedia.TabIndex = 3;
            //
            // lblMaior
            //
            lblMaior.AutoSize = true;
            lblMaior.Font = new Font("Segoe UI", 11F);
            lblMaior.Location = new Point(410, 140);
            lblMaior.Name = "lblMaior";
            lblMaior.Size = new Size(0, 20);
            lblMaior.TabIndex = 4;
            //
            // lblMenor
            //
            lblMenor.AutoSize = true;
            lblMenor.Font = new Font("Segoe UI", 11F);
            lblMenor.Location = new Point(410, 180);
            lblMenor.Name = "lblMenor";
            lblMenor.Size = new Size(0, 20);
            lblMenor.TabIndex = 5;
            //
            // lblQtd
            //
            lblQtd.AutoSize = true;
            lblQtd.Font = new Font("Segoe UI", 11F);
            lblQtd.Location = new Point(410, 220);
            lblQtd.Name = "lblQtd";
            lblQtd.Size = new Size(0, 20);
            lblQtd.TabIndex = 6;
            //
            // btnGrafico
            //
            btnGrafico.Location = new Point(410, 290);
            btnGrafico.Name = "btnGrafico";
            btnGrafico.Size = new Size(170, 30);
            btnGrafico.TabIndex = 7;
            btnGrafico.Text = "Gráfico de evolução";
            btnGrafico.UseVisualStyleBackColor = true;
            btnGrafico.Click += btnGrafico_Click;
            //
            // FormMetricas
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 431);
            Controls.Add(lblAluno);
            Controls.Add(cmbAluno);
            Controls.Add(dgvPontuacoes);
            Controls.Add(lblMedia);
            Controls.Add(lblMaior);
            Controls.Add(lblMenor);
            Controls.Add(lblQtd);
            Controls.Add(btnGrafico);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormMetricas";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Métricas de desempenho";
            Load += FormMetricas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPontuacoes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAluno;
        private ComboBox cmbAluno;
        private DataGridView dgvPontuacoes;
        private Label lblMedia;
        private Label lblMaior;
        private Label lblMenor;
        private Label lblQtd;
        private Button btnGrafico;
    }
}
