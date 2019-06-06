using FDA.Model.DataAccessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FDA.View
{
    public partial class FormEmployee : Form
    {
        /// <summary>
        /// 顯示資料的Data Gride View
        /// </summary>
        private DataGridView m_dgvEmployees;

        public FormEmployee()
        {
            InitializeComponent();

            m_dgvEmployees = pdgEmployees.DataList;
                        
            m_dgvEmployees.RowHeadersVisible = false;
            m_dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            m_dgvEmployees.AllowUserToAddRows = false;
            m_dgvEmployees.AllowUserToDeleteRows = false;
            m_dgvEmployees.MultiSelect = false;
            m_dgvEmployees.ReadOnly = true;
            m_dgvEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            m_dgvEmployees.TabStop = false;

            cbMonitor.DataBindings.Add("Checked", Properties.Settings.Default, "MonitorFingerPrint");
        }

        /// <summary>
        /// 更新資料
        /// </summary>
        public void ReLoad()
        {
            //當視窗有顯示及啟動即時監視功能時才更新資料;//
            if(    this.Visible ==true 
                && Properties.Settings.Default.MonitorFingerPrint == true)
            LoadEmployees();
        }

        private void PdgEmployees_ChangePage(int Page)
        {
            this.LoadEmployees(Page);
        }

        private void LoadEmployees(int LoadPage = 1)
        {
            //暫停顯示Scroll BAR，待資料整理完再一次顯示;//
            m_dgvEmployees.ScrollBars = ScrollBars.None;

            //取得員工的總筆數後計算總頁數;//
            int EmployeesNum = DaoMSSQL.Instance.GetEmployeesNum();
            int TotalPage = EmployeesNum % pdgEmployees.DisplayDataNumPerPage == 0 ? EmployeesNum / pdgEmployees.DisplayDataNumPerPage : ((EmployeesNum / pdgEmployees.DisplayDataNumPerPage) + 1);
            TotalPage = TotalPage == 0 ? 1 : TotalPage;
            pdgEmployees.SetTotalPage(TotalPage);

            if (LoadPage <= 0)
                LoadPage = 1;
            else if (LoadPage >= TotalPage)
                LoadPage = TotalPage;

            //設定資料;//
            int FromNo = (pdgEmployees.DisplayDataNumPerPage * (LoadPage - 1));
            int EndNo = pdgEmployees.DisplayDataNumPerPage * LoadPage;
            pdgEmployees.BindingData(DaoMSSQL.Instance.GetEmployees(FromNo, EndNo), LoadPage);

            //最後一個欄位設定為FILL;//
            m_dgvEmployees.Columns[m_dgvEmployees.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            if (m_dgvEmployees.Columns.Contains("建立時間"))
            {
                m_dgvEmployees.Columns["建立時間"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";
            }

            lblInfo.Text = string.Format("● 每頁顯示 500 筆員工資訊, 共有 {0} 筆員工資訊", EmployeesNum);

            m_dgvEmployees.ScrollBars = ScrollBars.Both;
        }

        private void CbMonitor_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.MonitorFingerPrint = cbMonitor.Checked;
            Properties.Settings.Default.Save();
        }

        private void FormEmployee_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void FormEmployee_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
                LoadEmployees();
        }
    }
}
