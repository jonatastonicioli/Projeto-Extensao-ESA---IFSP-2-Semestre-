namespace ESA.Forms
{
    partial class FormAlunos
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
            btnCadastrar = new Button();
            btnAtualizar = new Button();
            btnRemover = new Button();
            dgvAlunos = new DataGridView();
            lblTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAlunos).BeginInit();
            SuspendLayout();
            //
            // lblNome
            //
            lblNome.AutoSize = true;
            lblNome.Location = new Point(20, 20);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(90, 15);
            lblNome.TabIndex = 0;
            lblNome.Text = "Nome completo:";
            //
            // txtNome
            //
            txtNome.Location = new Point(20, 40);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(300, 23);
            txtNome.TabIndex = 1;
            //
            // btnCadastrar
            //
            btnCadastrar.Location = new Point(20, 75);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(110, 30);
            btnCadastrar.TabIndex = 2;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += btnCadastrar_Click;
            //
            // btnAtualizar
            //
            btnAtualizar.Location = new Point(140, 75);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(120, 30);
            btnAtualizar.TabIndex = 3;
            btnAtualizar.Text = "Atualizar nome";
            btnAtualizar.UseVisualStyleBackColor = true;
            btnAtualizar.Click += btnAtualizar_Click;
            //
            // btnRemover
            //
            btnRemover.Location = new Point(270, 75);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(110, 30);
            btnRemover.TabIndex = 4;
            btnRemover.Text = "Remover";
            btnRemover.UseVisualStyleBackColor = true;
            btnRemover.Click += btnRemover_Click;
            //
            // dgvAlunos
            //
            dgvAlunos.AllowUserToAddRows = false;
            dgvAlunos.AllowUserToDeleteRows = false;
            dgvAlunos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAlunos.BackgroundColor = SystemColors.Window;
            dgvAlunos.MultiSelect = false;
            dgvAlunos.ReadOnly = true;
            dgvAlunos.RowHeadersVisible = false;
            dgvAlunos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAlunos.Location = new Point(20, 120);
            dgvAlunos.Name = "dgvAlunos";
            dgvAlunos.Size = new Size(540, 280);
            dgvAlunos.TabIndex = 5;
            dgvAlunos.SelectionChanged += dgvAlunos_SelectionChanged;
            //
            // lblTotal
            //
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(20, 405);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(0, 15);
            lblTotal.TabIndex = 6;
            //
            // FormAlunos
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 441);
            Controls.Add(lblNome);
            Controls.Add(txtNome);
            Controls.Add(btnCadastrar);
            Controls.Add(btnAtualizar);
            Controls.Add(btnRemover);
            Controls.Add(dgvAlunos);
            Controls.Add(lblTotal);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormAlunos";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Alunos";
            Load += FormAlunos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAlunos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNome;
        private TextBox txtNome;
        private Button btnCadastrar;
        private Button btnAtualizar;
        private Button btnRemover;
        private DataGridView dgvAlunos;
        private Label lblTotal;
    }
}
