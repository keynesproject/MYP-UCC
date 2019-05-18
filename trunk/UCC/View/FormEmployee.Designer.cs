namespace FDA.View
{
    partial class FormEmployee
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEmployee));
            this.pdgEmployees = new TextMessage.View.Components.PageDataGridView();
            this.SuspendLayout();
            // 
            // pdgEmployees
            // 
            this.pdgEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdgEmployees.Location = new System.Drawing.Point(0, 0);
            this.pdgEmployees.Margin = new System.Windows.Forms.Padding(0);
            this.pdgEmployees.Name = "pdgEmployees";
            this.pdgEmployees.Size = new System.Drawing.Size(784, 562);
            this.pdgEmployees.TabIndex = 0;
            // 
            // FormEmployee
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.pdgEmployees);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "員工資料";
            this.ResumeLayout(false);

        }

        #endregion

        private TextMessage.View.Components.PageDataGridView pdgEmployees;
    }
}