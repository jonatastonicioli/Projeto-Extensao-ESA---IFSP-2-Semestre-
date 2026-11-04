namespace ESA.Forms
{
    partial class FormPrincipal
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
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            btnAlunos = new Button();
            btnPontuacao = new Button();
            btnMetricas = new Button();
            btnRanking = new Button();
            btnRelatorio = new Button();
            btnSair = new Button();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(0, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(404, 35);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "ESA - Evaluation System Analyzer";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblSubtitulo
            //
            lblSubtitulo.Location = new Point(0, 50);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(404, 22);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "SENAI Roberto Mange - Usinagem CNC";
            lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;
            //
            // btnAlunos
            //
            btnAlunos.Location = new Point(40, 90);
            btnAlunos.Name = "btnAlunos";
            btnAlunos.Size = new Size(330, 38);
            btnAlunos.TabIndex = 2;
            btnAlunos.Text = "Alunos (cadastrar / listar / editar / remover)";
            btnAlunos.UseVisualStyleBackColor = true;
            btnAlunos.Click += btnAlunos_Click;
            //
            // btnPontuacao
            //
            btnPontuacao.Location = new Point(40, 140);
            btnPontuacao.Name = "btnPontuacao";
            btnPontuacao.Size = new Size(330, 38);
            btnPontuacao.TabIndex = 3;
            btnPontuacao.Text = "Registrar pontuação de peça";
            btnPontuacao.UseVisualStyleBackColor = true;
            btnPontuacao.Click += btnPontuacao_Click;
            //
            // btnMetricas
            //
            btnMetricas.Location = new Point(40, 190);
            btnMetricas.Name = "btnMetricas";
            btnMetricas.Size = new Size(330, 38);
            btnMetricas.TabIndex = 4;
            btnMetricas.Text = "Métricas e histórico de um aluno";
            btnMetricas.UseVisualStyleBackColor = true;
            btnMetricas.Click += btnMetricas_Click;
            //
            // btnRanking
            //
            btnRanking.Location = new Point(40, 240);
            btnRanking.Name = "btnRanking";
            btnRanking.Size = new Size(330, 38);
            btnRanking.TabIndex = 5;
            btnRanking.Text = "Ranking geral";
            btnRanking.UseVisualStyleBackColor = true;
            btnRanking.Click += btnRanking_Click;
            //
            // btnRelatorio
            //
            btnRelatorio.Location = new Point(40, 290);
            btnRelatorio.Name = "btnRelatorio";
            btnRelatorio.Size = new Size(330, 38);
            btnRelatorio.TabIndex = 6;
            btnRelatorio.Text = "Relatório consolidado";
            btnRelatorio.UseVisualStyleBackColor = true;
            btnRelatorio.Click += btnRelatorio_Click;
            //
            // btnSair
            //
            btnSair.Location = new Point(40, 355);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(330, 38);
            btnSair.TabIndex = 7;
            btnSair.Text = "Sair";
            btnSair.UseVisualStyleBackColor = true;
            btnSair.Click += btnSair_Click;
            //
            // FormPrincipal
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 431);
            Controls.Add(lblTitulo);
            Controls.Add(lblSubtitulo);
            Controls.Add(btnAlunos);
            Controls.Add(btnPontuacao);
            Controls.Add(btnMetricas);
            Controls.Add(btnRanking);
            Controls.Add(btnRelatorio);
            Controls.Add(btnSair);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ESA - Evaluation System Analyzer";
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitulo;
        private Label lblSubtitulo;
        private Button btnAlunos;
        private Button btnPontuacao;
        private Button btnMetricas;
        private Button btnRanking;
        private Button btnRelatorio;
        private Button btnSair;
    }
}
