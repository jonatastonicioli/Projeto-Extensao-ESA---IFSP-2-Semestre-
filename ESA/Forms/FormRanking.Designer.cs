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
            dgvRanking = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvRanking).BeginInit();
            SuspendLayout();
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
            dgvRanking.Location = new Point(20, 20);
            dgvRanking.Name = "dgvRanking";
            dgvRanking.Size = new Size(640, 340);
            dgvRanking.TabIndex = 0;
            //
            // FormRanking
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 401);
            Controls.Add(dgvRanking);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormRanking";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Ranking geral";
            Load += FormRanking_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRanking).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvRanking;
    }
}
