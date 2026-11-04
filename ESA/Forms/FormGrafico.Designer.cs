namespace ESA.Forms
{
    partial class FormGrafico
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
            SuspendLayout();
            //
            // FormGrafico
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(704, 441);
            DoubleBuffered = true;
            Name = "FormGrafico";
            ResizeRedraw = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Evolução";
            ResumeLayout(false);
        }

        #endregion
    }
}
