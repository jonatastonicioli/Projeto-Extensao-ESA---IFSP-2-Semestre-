#nullable enable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            btnCompetidores = new Button();
            btnInscricoes = new Button();
            btnNotas = new Button();
            btnRanking = new Button();
            btnSair = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(1, 110);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(424, 35);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "ESA - Evaluation System Analyzer";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.Location = new Point(1, 145);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(424, 22);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "SENAI Roberto Mange - Usinagem CNC";
            lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCompetidores
            // 
            btnCompetidores.Location = new Point(48, 185);
            btnCompetidores.Name = "btnCompetidores";
            btnCompetidores.Size = new Size(330, 38);
            btnCompetidores.TabIndex = 2;
            btnCompetidores.Text = "Competidores";
            btnCompetidores.UseVisualStyleBackColor = true;
            btnCompetidores.Click += btnCompetidores_Click;
            // 
            // btnInscricoes
            // 
            btnInscricoes.Location = new Point(48, 233);
            btnInscricoes.Name = "btnInscricoes";
            btnInscricoes.Size = new Size(330, 38);
            btnInscricoes.TabIndex = 3;
            btnInscricoes.Text = "Inscrições";
            btnInscricoes.UseVisualStyleBackColor = true;
            btnInscricoes.Click += btnInscricoes_Click;
            // 
            // btnNotas
            // 
            btnNotas.Location = new Point(48, 281);
            btnNotas.Name = "btnNotas";
            btnNotas.Size = new Size(330, 38);
            btnNotas.TabIndex = 4;
            btnNotas.Text = "Lançar notas";
            btnNotas.UseVisualStyleBackColor = true;
            btnNotas.Click += btnNotas_Click;
            // 
            // btnRanking
            // 
            btnRanking.Location = new Point(48, 329);
            btnRanking.Name = "btnRanking";
            btnRanking.Size = new Size(330, 38);
            btnRanking.TabIndex = 5;
            btnRanking.Text = "Ranking";
            btnRanking.UseVisualStyleBackColor = true;
            btnRanking.Click += btnRanking_Click;
            // 
            // btnSair
            // 
            btnSair.Location = new Point(48, 392);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(330, 38);
            btnSair.TabIndex = 6;
            btnSair.Text = "Sair";
            btnSair.UseVisualStyleBackColor = true;
            btnSair.Click += btnSair_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(163, 39);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(112, 78);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.SENAI_São_Paulo_logo1;
            pictureBox2.Location = new Point(12, 1);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(127, 65);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.IFSP___logo;
            pictureBox3.Location = new Point(302, 1);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(157, 74);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 9;
            pictureBox3.TabStop = false;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 440);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(lblTitulo);
            Controls.Add(lblSubtitulo);
            Controls.Add(btnCompetidores);
            Controls.Add(btnInscricoes);
            Controls.Add(btnNotas);
            Controls.Add(btnRanking);
            Controls.Add(btnSair);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ESA - Evaluation System Analyzer";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitulo;
        private Label lblSubtitulo;
        private Button btnCompetidores;
        private Button btnInscricoes;
        private Button btnNotas;
        private Button btnRanking;
        private Button btnSair;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
    }
}
