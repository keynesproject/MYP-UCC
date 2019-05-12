namespace FDA.View
{
    partial class FormDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDatabase));
            this.tlpSetting = new System.Windows.Forms.TableLayoutPanel();
            this.lblServer = new System.Windows.Forms.Label();
            this.lblDbName = new System.Windows.Forms.Label();
            this.lblDbID = new System.Windows.Forms.Label();
            this.lblDbPW = new System.Windows.Forms.Label();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.tbDbName = new System.Windows.Forms.TextBox();
            this.tblblDbID = new System.Windows.Forms.TextBox();
            this.tbDbPW = new System.Windows.Forms.TextBox();
            this.tlpButton = new System.Windows.Forms.TableLayoutPanel();
            this.btnConnectTest = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.tlpSetting.SuspendLayout();
            this.tlpButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpSetting
            // 
            this.tlpSetting.ColumnCount = 4;
            this.tlpSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tlpSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tlpSetting.Controls.Add(this.lblServer, 1, 1);
            this.tlpSetting.Controls.Add(this.lblDbName, 1, 2);
            this.tlpSetting.Controls.Add(this.lblDbID, 1, 3);
            this.tlpSetting.Controls.Add(this.lblDbPW, 1, 4);
            this.tlpSetting.Controls.Add(this.tbServer, 2, 1);
            this.tlpSetting.Controls.Add(this.tbDbName, 2, 2);
            this.tlpSetting.Controls.Add(this.tblblDbID, 2, 3);
            this.tlpSetting.Controls.Add(this.tbDbPW, 2, 4);
            this.tlpSetting.Controls.Add(this.tlpButton, 2, 5);
            this.tlpSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSetting.Location = new System.Drawing.Point(0, 0);
            this.tlpSetting.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tlpSetting.Name = "tlpSetting";
            this.tlpSetting.RowCount = 6;
            this.tlpSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tlpSetting.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpSetting.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpSetting.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpSetting.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSetting.Size = new System.Drawing.Size(415, 228);
            this.tlpSetting.TabIndex = 0;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblServer.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.lblServer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblServer.Location = new System.Drawing.Point(15, 12);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(79, 33);
            this.lblServer.TabIndex = 0;
            this.lblServer.Text = "SQL Server";
            this.lblServer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDbName
            // 
            this.lblDbName.AutoSize = true;
            this.lblDbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDbName.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.lblDbName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDbName.Location = new System.Drawing.Point(15, 45);
            this.lblDbName.Name = "lblDbName";
            this.lblDbName.Size = new System.Drawing.Size(79, 33);
            this.lblDbName.TabIndex = 1;
            this.lblDbName.Text = "資料庫";
            this.lblDbName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDbID
            // 
            this.lblDbID.AutoSize = true;
            this.lblDbID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDbID.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.lblDbID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDbID.Location = new System.Drawing.Point(15, 78);
            this.lblDbID.Name = "lblDbID";
            this.lblDbID.Size = new System.Drawing.Size(79, 33);
            this.lblDbID.TabIndex = 2;
            this.lblDbID.Text = "登入名稱";
            this.lblDbID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDbPW
            // 
            this.lblDbPW.AutoSize = true;
            this.lblDbPW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDbPW.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.lblDbPW.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDbPW.Location = new System.Drawing.Point(15, 111);
            this.lblDbPW.Name = "lblDbPW";
            this.lblDbPW.Size = new System.Drawing.Size(79, 33);
            this.lblDbPW.TabIndex = 3;
            this.lblDbPW.Text = "密碼";
            this.lblDbPW.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbServer
            // 
            this.tbServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbServer.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.tbServer.Location = new System.Drawing.Point(100, 16);
            this.tbServer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbServer.MaxLength = 128;
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(300, 25);
            this.tbServer.TabIndex = 0;
            this.tbServer.Click += new System.EventHandler(this.Control_Enter);
            this.tbServer.Enter += new System.EventHandler(this.Control_Enter);
            this.tbServer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NextControl);
            // 
            // tbDbName
            // 
            this.tbDbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDbName.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.tbDbName.Location = new System.Drawing.Point(100, 49);
            this.tbDbName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbDbName.MaxLength = 128;
            this.tbDbName.Name = "tbDbName";
            this.tbDbName.Size = new System.Drawing.Size(300, 25);
            this.tbDbName.TabIndex = 4;
            this.tbDbName.Click += new System.EventHandler(this.Control_Enter);
            this.tbDbName.Enter += new System.EventHandler(this.Control_Enter);
            this.tbDbName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NextControl);
            // 
            // tblblDbID
            // 
            this.tblblDbID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblblDbID.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.tblblDbID.Location = new System.Drawing.Point(100, 82);
            this.tblblDbID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tblblDbID.MaxLength = 128;
            this.tblblDbID.Name = "tblblDbID";
            this.tblblDbID.Size = new System.Drawing.Size(300, 25);
            this.tblblDbID.TabIndex = 5;
            this.tblblDbID.Click += new System.EventHandler(this.Control_Enter);
            this.tblblDbID.Enter += new System.EventHandler(this.Control_Enter);
            this.tblblDbID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NextControl);
            // 
            // tbDbPW
            // 
            this.tbDbPW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDbPW.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.tbDbPW.Location = new System.Drawing.Point(100, 115);
            this.tbDbPW.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbDbPW.MaxLength = 128;
            this.tbDbPW.Name = "tbDbPW";
            this.tbDbPW.PasswordChar = '*';
            this.tbDbPW.Size = new System.Drawing.Size(300, 25);
            this.tbDbPW.TabIndex = 6;
            this.tbDbPW.Click += new System.EventHandler(this.Control_Enter);
            this.tbDbPW.Enter += new System.EventHandler(this.Control_Enter);
            this.tbDbPW.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NextControl);
            // 
            // tlpButton
            // 
            this.tlpButton.ColumnCount = 3;
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpButton.Controls.Add(this.btnConnectTest, 0, 0);
            this.tlpButton.Controls.Add(this.btnSave, 1, 0);
            this.tlpButton.Controls.Add(this.btnExit, 2, 0);
            this.tlpButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButton.Location = new System.Drawing.Point(100, 148);
            this.tlpButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tlpButton.Name = "tlpButton";
            this.tlpButton.RowCount = 1;
            this.tlpButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButton.Size = new System.Drawing.Size(300, 76);
            this.tlpButton.TabIndex = 7;
            // 
            // btnConnectTest
            // 
            this.btnConnectTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConnectTest.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.btnConnectTest.Location = new System.Drawing.Point(12, 12);
            this.btnConnectTest.Margin = new System.Windows.Forms.Padding(12);
            this.btnConnectTest.Name = "btnConnectTest";
            this.btnConnectTest.Size = new System.Drawing.Size(76, 52);
            this.btnConnectTest.TabIndex = 2;
            this.btnConnectTest.Text = "連接測試";
            this.btnConnectTest.UseVisualStyleBackColor = true;
            this.btnConnectTest.Click += new System.EventHandler(this.BtnConnectTest_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.btnSave.Location = new System.Drawing.Point(112, 12);
            this.btnSave.Margin = new System.Windows.Forms.Padding(12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 52);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "儲存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.btnExit.Location = new System.Drawing.Point(212, 12);
            this.btnExit.Margin = new System.Windows.Forms.Padding(12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(76, 52);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "取消";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // FormDatabase
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(415, 228);
            this.Controls.Add(this.tlpSetting);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "資料庫設定";
            this.Load += new System.EventHandler(this.FormDatabase_Load);
            this.tlpSetting.ResumeLayout(false);
            this.tlpSetting.PerformLayout();
            this.tlpButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpSetting;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label lblDbName;
        private System.Windows.Forms.Label lblDbID;
        private System.Windows.Forms.Label lblDbPW;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.TextBox tbDbName;
        private System.Windows.Forms.TextBox tblblDbID;
        private System.Windows.Forms.TextBox tbDbPW;
        private System.Windows.Forms.TableLayoutPanel tlpButton;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnConnectTest;
    }
}