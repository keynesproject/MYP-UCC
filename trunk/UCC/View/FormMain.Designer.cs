namespace FDA
{
    partial class FormMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsmiMainSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOption = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSeparatorSetting01 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiMYP = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSeparatorSetting02 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.temiMainHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnDatabase = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiDbSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiConnectDb = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDisconnectDb = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnStartLoadDevice = new System.Windows.Forms.ToolStripButton();
            this.tsBtnStopLoadDevice = new System.Windows.Forms.ToolStripButton();
            this.tsBtnUpdateData = new System.Windows.Forms.ToolStripButton();
            this.tsSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnEnableDevice = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDisableDevice = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tsSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnAddDevice = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRemoveDevice = new System.Windows.Forms.ToolStripButton();
            this.tsSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnExit = new System.Windows.Forms.ToolStripButton();
            this.ssStatus = new System.Windows.Forms.StatusStrip();
            this.tsslTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvDevice = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();            
            this.msMain.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevice)).BeginInit();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Location = new System.Drawing.Point(0, 0);
            msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.tsmiMainSetting,
                this.temiMainHelp
            });
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.msMain.Size = new System.Drawing.Size(794, 24);
            this.msMain.TabIndex = 0;
            this.msMain.Text = "menuStrip1";
            // 
            // tsmiMainSetting
            // 
            this.tsmiMainSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOption,
            this.tsmiDatabase,
            this.tsSeparatorSetting01,
            this.tsmiMYP,
            this.tsSeparatorSetting02,
            this.tsmiExit});
            this.tsmiMainSetting.Name = "tsmiMainSetting";
            this.tsmiMainSetting.Size = new System.Drawing.Size(44, 20);
            this.tsmiMainSetting.Text = "設定";
            // 
            // tsmiOption
            // 
            this.tsmiOption.Name = "tsmiOption";
            this.tsmiOption.Size = new System.Drawing.Size(153, 22);
            this.tsmiOption.Text = "功能設定(&S)";
            // 
            // tsmiDatabase
            // 
            this.tsmiDatabase.Name = "tsmiDatabase";
            this.tsmiDatabase.Size = new System.Drawing.Size(153, 22);
            this.tsmiDatabase.Text = "資料庫設定(&D)";
            this.tsmiDatabase.Click += new System.EventHandler(this.TsmiDatabase_Click);
            // 
            // tsSeparatorSetting01
            // 
            this.tsSeparatorSetting01.Name = "tsSeparatorSetting01";
            this.tsSeparatorSetting01.Size = new System.Drawing.Size(150, 6);
            // 
            // tsmiMYP
            // 
            this.tsmiMYP.Name = "tsmiMYP";
            this.tsmiMYP.Size = new System.Drawing.Size(153, 22);
            this.tsmiMYP.Text = "MYP設定(&O)";
            this.tsmiMYP.Click += new System.EventHandler(this.TsmiMYP_Click);
            // 
            // tsSeparatorSetting02
            // 
            this.tsSeparatorSetting02.Name = "tsSeparatorSetting02";
            this.tsSeparatorSetting02.Size = new System.Drawing.Size(150, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(153, 22);
            this.tsmiExit.Text = "結束(&X)";
            this.tsmiExit.Click += new System.EventHandler(this.TsmiExit_Click);
            // 
            // temiMainHelp
            // 
            this.temiMainHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAbout});
            this.temiMainHelp.Name = "temiMainHelp";
            this.temiMainHelp.Size = new System.Drawing.Size(44, 20);
            this.temiMainHelp.Text = "說明";
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(100, 22);
            this.tsmiAbout.Text = "關於";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.tsBtnDatabase,
                this.tsSeparator1,
                this.tsBtnStartLoadDevice,
                this.tsBtnStopLoadDevice,
                this.tsBtnUpdateData,
                this.tsSeparator2,
                this.tsBtnEnableDevice,
                this.tsBtnDisableDevice,
                this.toolStripButton2,
                this.tsSeparator3,
                this.tsBtnAddDevice,
                this.tsBtnRemoveDevice,
                this.tsSeparator4,
                this.tsBtnExit
            });
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(794, 53);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnDatabase
            // 
            tsBtnDatabase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                tsmiDbSetting,
                tsmiConnectDb,
                tsmiDisconnectDb
            });
            this.tsBtnDatabase.Image = global::FDA.Properties.Resources.IconDatabase;
            this.tsBtnDatabase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDatabase.Name = "tsBtnDatabase";
            this.tsBtnDatabase.Size = new System.Drawing.Size(57, 50);
            this.tsBtnDatabase.Text = "資料庫";
            this.tsBtnDatabase.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsmiDbSetting
            // 
            this.tsmiDbSetting.Name = "tsmiDbSetting";
            this.tsmiDbSetting.Size = new System.Drawing.Size(180, 22);
            this.tsmiDbSetting.Text = "資料庫設定";
            this.tsmiDbSetting.Click += new System.EventHandler(this.TsmiDbSetting_Click);
            // 
            // tsmiConnectDb
            // 
            this.tsmiConnectDb.Name = "tsmiConnectDb";
            this.tsmiConnectDb.Size = new System.Drawing.Size(180, 22);
            this.tsmiConnectDb.Text = "連接資料庫";
            this.tsmiConnectDb.Click += new System.EventHandler(this.TsmiConnectDb_Click);
            // 
            // tsmiDisconnectDb
            // 
            this.tsmiDisconnectDb.Enabled = false;
            this.tsmiDisconnectDb.Name = "tsmiDisconnectDb";
            this.tsmiDisconnectDb.Size = new System.Drawing.Size(180, 22);
            this.tsmiDisconnectDb.Text = "斷開開資料庫";
            this.tsmiDisconnectDb.Click += new System.EventHandler(this.TsmiDisconnectDb_Click);
            // 
            // tsSeparator1
            // 
            this.tsSeparator1.Name = "tsSeparator1";
            this.tsSeparator1.Size = new System.Drawing.Size(6, 53);
            // 
            // tsBtnStartLoadDevice
            // 
            this.tsBtnStartLoadDevice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsBtnStartLoadDevice.Image = global::FDA.Properties.Resources.IconDownload;
            this.tsBtnStartLoadDevice.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsBtnStartLoadDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnStartLoadDevice.Name = "tsBtnStartLoadDevice";
            this.tsBtnStartLoadDevice.Size = new System.Drawing.Size(60, 50);
            this.tsBtnStartLoadDevice.Text = "定時讀取";
            this.tsBtnStartLoadDevice.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsBtnStartLoadDevice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsBtnStopLoadDevice
            // 
            this.tsBtnStopLoadDevice.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnStopLoadDevice.Image")));
            this.tsBtnStopLoadDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnStopLoadDevice.Name = "tsBtnStopLoadDevice";
            this.tsBtnStopLoadDevice.Size = new System.Drawing.Size(60, 50);
            this.tsBtnStopLoadDevice.Text = "停止讀取";
            this.tsBtnStopLoadDevice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsBtnUpdateData
            // 
            this.tsBtnUpdateData.Image = global::FDA.Properties.Resources.IconRefresh;
            this.tsBtnUpdateData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnUpdateData.Name = "tsBtnUpdateData";
            this.tsBtnUpdateData.Size = new System.Drawing.Size(60, 50);
            this.tsBtnUpdateData.Text = "立即更新";
            this.tsBtnUpdateData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsSeparator2
            // 
            this.tsSeparator2.Name = "tsSeparator2";
            this.tsSeparator2.Size = new System.Drawing.Size(6, 53);
            // 
            // tsBtnEnableDevice
            // 
            this.tsBtnEnableDevice.Image = global::FDA.Properties.Resources.IconEnableDevice;
            this.tsBtnEnableDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnEnableDevice.Name = "tsBtnEnableDevice";
            this.tsBtnEnableDevice.Size = new System.Drawing.Size(60, 50);
            this.tsBtnEnableDevice.Text = "啟用設備";
            this.tsBtnEnableDevice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsBtnDisableDevice
            // 
            this.tsBtnDisableDevice.Image = global::FDA.Properties.Resources.IconDisableDevice;
            this.tsBtnDisableDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDisableDevice.Name = "tsBtnDisableDevice";
            this.tsBtnDisableDevice.Size = new System.Drawing.Size(60, 50);
            this.tsBtnDisableDevice.Text = "停用設備";
            this.tsBtnDisableDevice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::FDA.Properties.Resources.IconClearDeviceData;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(60, 50);
            this.toolStripButton2.Text = "刪除出勤";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsSeparator3
            // 
            this.tsSeparator3.Name = "tsSeparator3";
            this.tsSeparator3.Size = new System.Drawing.Size(6, 53);
            // 
            // tsBtnAddDevice
            // 
            this.tsBtnAddDevice.Image = global::FDA.Properties.Resources.IconAddDevice;
            this.tsBtnAddDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAddDevice.Name = "tsBtnAddDevice";
            this.tsBtnAddDevice.Size = new System.Drawing.Size(60, 50);
            this.tsBtnAddDevice.Text = "新增設備";
            this.tsBtnAddDevice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsBtnAddDevice.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TsBtnAddDevice_MouseUp);
            // 
            // tsBtnRemoveDevice
            // 
            this.tsBtnRemoveDevice.Image = global::FDA.Properties.Resources.IconRemoveDevice;
            this.tsBtnRemoveDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRemoveDevice.Name = "tsBtnRemoveDevice";
            this.tsBtnRemoveDevice.Size = new System.Drawing.Size(60, 50);
            this.tsBtnRemoveDevice.Text = "移除設備";
            this.tsBtnRemoveDevice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsBtnRemoveDevice.ToolTipText = "移除設備";
            // 
            // tsSeparator4
            // 
            this.tsSeparator4.Name = "tsSeparator4";
            this.tsSeparator4.Size = new System.Drawing.Size(6, 53);
            // 
            // tsBtnExit
            // 
            this.tsBtnExit.Image = global::FDA.Properties.Resources.IconPowerOff;
            this.tsBtnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnExit.Name = "tsBtnExit";
            this.tsBtnExit.Size = new System.Drawing.Size(60, 50);
            this.tsBtnExit.Text = "退出系統";
            this.tsBtnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsBtnExit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TsBtnExit_MouseUp);
            // 
            // ssStatus
            // 
            this.ssStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslTime
            });
            this.ssStatus.Location = new System.Drawing.Point(0, 407);
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.ssStatus.Size = new System.Drawing.Size(794, 22);
            this.ssStatus.TabIndex = 2;
            this.ssStatus.Text = "statusStrip1";
            // 
            // tsslTime
            // 
            this.tsslTime.AutoSize = false;
            this.tsslTime.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslTime.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tsslTime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsslTime.Name = "tsslTime";
            this.tsslTime.Size = new System.Drawing.Size(200, 26);
            this.tsslTime.Text = "上午 12:30:30";
            this.tsslTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvDevice
            // 
            this.dgvDevice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDevice.Location = new System.Drawing.Point(0, 77);
            this.dgvDevice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvDevice.Name = "dgvDevice";
            dataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvDevice.RowHeadersDefaultCellStyle = dataGridViewCellStyle28;
            this.dgvDevice.RowHeadersVisible = false;
            this.dgvDevice.RowTemplate.Height = 24;
            this.dgvDevice.Size = new System.Drawing.Size(794, 330);
            this.dgvDevice.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle22;
            this.Column1.HeaderText = "設備名稱";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle23;
            this.Column2.HeaderText = "連線狀態";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle24;
            this.Column3.HeaderText = "機器號";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle25;
            this.Column4.HeaderText = "IP地址";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle26;
            this.Column5.HeaderText = "埠號";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle27;
            this.Column6.HeaderText = "啟用狀態";
            this.Column6.Name = "Column6";           
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 429);
            this.Controls.Add(this.dgvDevice);
            this.Controls.Add(this.ssStatus);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.msMain);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormMain";
            this.Text = "指紋機MYP-2000資料存取系統";
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiMainSetting;
        private System.Windows.Forms.ToolStripMenuItem temiMainHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnStartLoadDevice;
        private System.Windows.Forms.ToolStripButton tsBtnStopLoadDevice;
        private System.Windows.Forms.ToolStripSeparator tsSeparator3;
        private System.Windows.Forms.ToolStripButton tsBtnAddDevice;
        private System.Windows.Forms.ToolStripMenuItem tsmiDatabase;
        private System.Windows.Forms.ToolStripSeparator tsSeparatorSetting01;
        private System.Windows.Forms.ToolStripMenuItem tsmiMYP;
        private System.Windows.Forms.ToolStripSeparator tsSeparatorSetting02;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripButton tsBtnRemoveDevice;
        private System.Windows.Forms.ToolStripSeparator tsSeparator4;
        private System.Windows.Forms.ToolStripButton tsBtnExit;
        private System.Windows.Forms.StatusStrip ssStatus;
        private System.Windows.Forms.ToolStripStatusLabel tsslTime;
        private System.Windows.Forms.DataGridView dgvDevice;
        private System.Windows.Forms.ToolStripSeparator tsSeparator1;
        private System.Windows.Forms.ToolStripSeparator tsSeparator2;
        private System.Windows.Forms.ToolStripButton tsBtnEnableDevice;
        private System.Windows.Forms.ToolStripButton tsBtnDisableDevice;
        private System.Windows.Forms.ToolStripMenuItem tsmiOption;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.ToolStripDropDownButton tsBtnDatabase;
        private System.Windows.Forms.ToolStripMenuItem tsmiDbSetting;
        private System.Windows.Forms.ToolStripMenuItem tsmiConnectDb;
        private System.Windows.Forms.ToolStripMenuItem tsmiDisconnectDb;
        private System.Windows.Forms.ToolStripButton tsBtnUpdateData;
        private System.Windows.Forms.ToolStripButton toolStripButton2;        
    }
}

