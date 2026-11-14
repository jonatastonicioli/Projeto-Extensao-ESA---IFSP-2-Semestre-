#nullable enable
namespace ESA.Forms
{
    partial class FormRanking
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
            lblModalidade = new Label();
            cmbModalidade = new ComboBox();
            lblEdicao = new Label();
            cmbEdicao = new ComboBox();
            btnGerar = new Button();
            dgvRanking = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvRanking).BeginInit();
            SuspendLayout();
            //
            // lblModalidade
            //
            lblModalidade.AutoSize = true;
            lblModalidade.Location = new Point(20, 15);
            lblModalidade.Name = "lblModalidade";
            lblModalidade.Size = new Size(60, 15);
            lblModalidade.TabIndex = 0;
            lblModalidade.Text = "Modalidade:";
            //
            // cmbModalidade
            //
            cmbModalidade.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModalidade.FormattingEnabled = true;
            cmbModalidade.Location = new Point(20, 35);
            cmbModalidade.Name = "cmbModalidade";
            cmbModalidade.Size = new Size(250, 23);
            cmbModalidade.TabIndex = 1;
            //
            // lblEdicao
            //
            lblEdicao.AutoSize = true;
            lblEdicao.Location = new Point(290, 15);
            lblEdicao.Name = "lblEdicao";
            lblEdicao.Size = new Size(60, 15);
            lblEdicao.TabIndex = 2;
            lblEdicao.Text = "Edição:";
            //
            // cmbEdicao
            //
            cmbEdicao.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEdicao.FormattingEnabled = true;
            cmbEdicao.Location = new Point(290, 35);
            cmbEdicao.Name = "cmbEdicao";
            cmbEdicao.Size = new Size(200, 23);
            cmbEdicao.TabIndex = 3;
            //
            // btnGerar
            //
            btnGerar.UseVisualStyleBackColor = true;
            btnGerar.Location = new Point(510, 32);
            btnGerar.Name = "btnGerar";
            btnGerar.Size = new Size(130, 30);
            btnGerar.TabIndex = 4;
            btnGerar.Text = "Gerar ranking";
            btnGerar.Click += btnGerar_Click;
            //
            // dgvRanking
            //
            dgvRanking.AllowUserToAddRows = false;
            dgvRanking.AllowUserToDeleteRows = false;
            dgvRanking.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRanking.BackgroundColor = SystemColors.Window;
            dgvRanking.MultiSelect = false;
            dgvRanking.ReadOnly = true;
            dgvRanking.RowHeadersVisible = false;
            dgvRanking.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRanking.Location = new Point(20, 80);
            dgvRanking.Name = "dgvRanking";
            dgvRanking.Size = new Size(680, 340);
            dgvRanking.TabIndex = 5;
            //
            // FormRanking
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 440);
            Controls.Add(lblModalidade);
            Controls.Add(cmbModalidade);
            Controls.Add(lblEdicao);
            Controls.Add(cmbEdicao);
            Controls.Add(btnGerar);
            Controls.Add(dgvRanking);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormRanking";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Ranking";
            Load += FormRanking_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRanking).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblModalidade;
        private ComboBox cmbModalidade;
        private Label lblEdicao;
        private ComboBox cmbEdicao;
        private Button btnGerar;
        private DataGridView dgvRanking;
    }
}
