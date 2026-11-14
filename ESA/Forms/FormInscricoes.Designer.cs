#nullable enable
namespace ESA.Forms
{
    partial class FormInscricoes
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
            lblCompetidor = new Label();
            cmbCompetidor = new ComboBox();
            lblModalidade = new Label();
            cmbModalidade = new ComboBox();
            lblEdicao = new Label();
            cmbEdicao = new ComboBox();
            btnInscrever = new Button();
            btnRemover = new Button();
            dgvInscricoes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvInscricoes).BeginInit();
            SuspendLayout();
            //
            // lblCompetidor
            //
            lblCompetidor.AutoSize = true;
            lblCompetidor.Location = new Point(20, 15);
            lblCompetidor.Name = "lblCompetidor";
            lblCompetidor.Size = new Size(60, 15);
            lblCompetidor.TabIndex = 0;
            lblCompetidor.Text = "Competidor:";
            //
            // cmbCompetidor
            //
            cmbCompetidor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCompetidor.FormattingEnabled = true;
            cmbCompetidor.Location = new Point(20, 35);
            cmbCompetidor.Name = "cmbCompetidor";
            cmbCompetidor.Size = new Size(250, 23);
            cmbCompetidor.TabIndex = 1;
            //
            // lblModalidade
            //
            lblModalidade.AutoSize = true;
            lblModalidade.Location = new Point(290, 15);
            lblModalidade.Name = "lblModalidade";
            lblModalidade.Size = new Size(60, 15);
            lblModalidade.TabIndex = 2;
            lblModalidade.Text = "Modalidade:";
            //
            // cmbModalidade
            //
            cmbModalidade.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModalidade.FormattingEnabled = true;
            cmbModalidade.Location = new Point(290, 35);
            cmbModalidade.Name = "cmbModalidade";
            cmbModalidade.Size = new Size(200, 23);
            cmbModalidade.TabIndex = 3;
            //
            // lblEdicao
            //
            lblEdicao.AutoSize = true;
            lblEdicao.Location = new Point(510, 15);
            lblEdicao.Name = "lblEdicao";
            lblEdicao.Size = new Size(60, 15);
            lblEdicao.TabIndex = 4;
            lblEdicao.Text = "Edição:";
            //
            // cmbEdicao
            //
            cmbEdicao.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEdicao.FormattingEnabled = true;
            cmbEdicao.Location = new Point(510, 35);
            cmbEdicao.Name = "cmbEdicao";
            cmbEdicao.Size = new Size(200, 23);
            cmbEdicao.TabIndex = 5;
            //
            // btnInscrever
            //
            btnInscrever.UseVisualStyleBackColor = true;
            btnInscrever.Location = new Point(20, 75);
            btnInscrever.Name = "btnInscrever";
            btnInscrever.Size = new Size(120, 30);
            btnInscrever.TabIndex = 6;
            btnInscrever.Text = "Inscrever";
            btnInscrever.Click += btnInscrever_Click;
            //
            // btnRemover
            //
            btnRemover.UseVisualStyleBackColor = true;
            btnRemover.Location = new Point(160, 75);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(150, 30);
            btnRemover.TabIndex = 7;
            btnRemover.Text = "Remover inscrição";
            btnRemover.Click += btnRemover_Click;
            //
            // dgvInscricoes
            //
            dgvInscricoes.AllowUserToAddRows = false;
            dgvInscricoes.AllowUserToDeleteRows = false;
            dgvInscricoes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInscricoes.BackgroundColor = SystemColors.Window;
            dgvInscricoes.MultiSelect = false;
            dgvInscricoes.ReadOnly = true;
            dgvInscricoes.RowHeadersVisible = false;
            dgvInscricoes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInscricoes.Location = new Point(20, 125);
            dgvInscricoes.Name = "dgvInscricoes";
            dgvInscricoes.Size = new Size(720, 340);
            dgvInscricoes.TabIndex = 8;
            //
            // FormInscricoes
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 490);
            Controls.Add(lblCompetidor);
            Controls.Add(cmbCompetidor);
            Controls.Add(lblModalidade);
            Controls.Add(cmbModalidade);
            Controls.Add(lblEdicao);
            Controls.Add(cmbEdicao);
            Controls.Add(btnInscrever);
            Controls.Add(btnRemover);
            Controls.Add(dgvInscricoes);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormInscricoes";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Inscrições";
            Load += FormInscricoes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvInscricoes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCompetidor;
        private ComboBox cmbCompetidor;
        private Label lblModalidade;
        private ComboBox cmbModalidade;
        private Label lblEdicao;
        private ComboBox cmbEdicao;
        private Button btnInscrever;
        private Button btnRemover;
        private DataGridView dgvInscricoes;
    }
}
