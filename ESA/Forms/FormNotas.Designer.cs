#nullable enable
namespace ESA.Forms
{
    partial class FormNotas
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
            lblInscricao = new Label();
            cmbInscricao = new ComboBox();
            lblAvaliador = new Label();
            cmbAvaliador = new ComboBox();
            lblNota = new Label();
            txtNota = new TextBox();
            btnLancar = new Button();
            btnRemover = new Button();
            lblMedia = new Label();
            dgvNotas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvNotas).BeginInit();
            SuspendLayout();
            //
            // lblInscricao
            //
            lblInscricao.AutoSize = true;
            lblInscricao.Location = new Point(20, 15);
            lblInscricao.Name = "lblInscricao";
            lblInscricao.Size = new Size(60, 15);
            lblInscricao.TabIndex = 0;
            lblInscricao.Text = "Inscrição (competidor | modalidade | edição):";
            //
            // cmbInscricao
            //
            cmbInscricao.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbInscricao.FormattingEnabled = true;
            cmbInscricao.Location = new Point(20, 35);
            cmbInscricao.Name = "cmbInscricao";
            cmbInscricao.Size = new Size(720, 23);
            cmbInscricao.TabIndex = 1;
            cmbInscricao.SelectedIndexChanged += cmbInscricao_SelectedIndexChanged;
            //
            // lblAvaliador
            //
            lblAvaliador.AutoSize = true;
            lblAvaliador.Location = new Point(20, 70);
            lblAvaliador.Name = "lblAvaliador";
            lblAvaliador.Size = new Size(60, 15);
            lblAvaliador.TabIndex = 2;
            lblAvaliador.Text = "Avaliador:";
            //
            // cmbAvaliador
            //
            cmbAvaliador.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAvaliador.FormattingEnabled = true;
            cmbAvaliador.Location = new Point(20, 90);
            cmbAvaliador.Name = "cmbAvaliador";
            cmbAvaliador.Size = new Size(330, 23);
            cmbAvaliador.TabIndex = 3;
            //
            // lblNota
            //
            lblNota.AutoSize = true;
            lblNota.Location = new Point(370, 70);
            lblNota.Name = "lblNota";
            lblNota.Size = new Size(60, 15);
            lblNota.TabIndex = 4;
            lblNota.Text = "Nota (0 a 100):";
            //
            // txtNota
            //
            txtNota.Location = new Point(370, 90);
            txtNota.Name = "txtNota";
            txtNota.Size = new Size(130, 23);
            txtNota.TabIndex = 5;
            //
            // btnLancar
            //
            btnLancar.UseVisualStyleBackColor = true;
            btnLancar.Location = new Point(20, 130);
            btnLancar.Name = "btnLancar";
            btnLancar.Size = new Size(130, 30);
            btnLancar.TabIndex = 6;
            btnLancar.Text = "Lançar nota";
            btnLancar.Click += btnLancar_Click;
            //
            // btnRemover
            //
            btnRemover.UseVisualStyleBackColor = true;
            btnRemover.Location = new Point(160, 130);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(170, 30);
            btnRemover.TabIndex = 7;
            btnRemover.Text = "Remover selecionada";
            btnRemover.Click += btnRemover_Click;
            //
            // lblMedia
            //
            lblMedia.AutoSize = true;
            lblMedia.Font = new Font("Segoe UI", 10F);
            lblMedia.Location = new Point(360, 138);
            lblMedia.Name = "lblMedia";
            lblMedia.Size = new Size(60, 15);
            lblMedia.TabIndex = 8;
            lblMedia.Text = "";
            //
            // dgvNotas
            //
            dgvNotas.AllowUserToAddRows = false;
            dgvNotas.AllowUserToDeleteRows = false;
            dgvNotas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNotas.BackgroundColor = SystemColors.Window;
            dgvNotas.MultiSelect = false;
            dgvNotas.ReadOnly = true;
            dgvNotas.RowHeadersVisible = false;
            dgvNotas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNotas.Location = new Point(20, 175);
            dgvNotas.Name = "dgvNotas";
            dgvNotas.Size = new Size(720, 320);
            dgvNotas.TabIndex = 9;
            //
            // FormNotas
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 520);
            Controls.Add(lblInscricao);
            Controls.Add(cmbInscricao);
            Controls.Add(lblAvaliador);
            Controls.Add(cmbAvaliador);
            Controls.Add(lblNota);
            Controls.Add(txtNota);
            Controls.Add(btnLancar);
            Controls.Add(btnRemover);
            Controls.Add(lblMedia);
            Controls.Add(dgvNotas);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormNotas";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Lançar notas";
            Load += FormNotas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvNotas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblInscricao;
        private ComboBox cmbInscricao;
        private Label lblAvaliador;
        private ComboBox cmbAvaliador;
        private Label lblNota;
        private TextBox txtNota;
        private Button btnLancar;
        private Button btnRemover;
        private Label lblMedia;
        private DataGridView dgvNotas;
    }
}
