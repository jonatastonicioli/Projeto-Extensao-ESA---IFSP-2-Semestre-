namespace ESA.Forms
{
    partial class FormRelatorio
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
            txtRelatorio = new TextBox();
            btnExportar = new Button();
            SuspendLayout();
            //
            // txtRelatorio
            //
            txtRelatorio.BackColor = Color.White;
            txtRelatorio.Font = new Font("Consolas", 9.5F);
            txtRelatorio.Location = new Point(20, 20);
            txtRelatorio.Multiline = true;
            txtRelatorio.Name = "txtRelatorio";
            txtRelatorio.ReadOnly = true;
            txtRelatorio.ScrollBars = ScrollBars.Vertical;
            txtRelatorio.Size = new Size(640, 340);
            txtRelatorio.TabIndex = 0;
            //
            // btnExportar
            //
            btnExportar.Location = new Point(20, 370);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(140, 30);
            btnExportar.TabIndex = 1;
            btnExportar.Text = "Exportar .txt";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            //
            // FormRelatorio
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 411);
            Controls.Add(txtRelatorio);
            Controls.Add(btnExportar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormRelatorio";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Relatório consolidado";
            Load += FormRelatorio_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtRelatorio;
        private Button btnExportar;
    }
}
