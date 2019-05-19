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
    public partial class FormAttendance : Form
    {
        /// <summary>
        /// 顯示資料的Data Gride View
        /// </summary>
        private DataGridView m_dgvAttendance;
        public FormAttendance()
        {
            InitializeComponent();

            m_dgvAttendance = pdgAttendance.DataList;

            m_dgvAttendance.RowHeadersVisible = false;
            m_dgvAttendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            m_dgvAttendance.AllowUserToAddRows = false;
            m_dgvAttendance.AllowUserToDeleteRows = false;
            m_dgvAttendance.MultiSelect = false;
            m_dgvAttendance.ReadOnly = true;
            m_dgvAttendance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            m_dgvAttendance.TabStop = false;

            LoadAttendance();
        }

        private void PdgAttendance_ChangePage(int Page)
        {
            this.LoadAttendance(Page);
        }
        private void LoadAttendance(int LoadPage = 1)
        {
            //暫停顯示Scroll BAR，待資料整理完再一次顯示;//
            m_dgvAttendance.ScrollBars = ScrollBars.None;

            //取得員工的總筆數後計算總頁數;//
            int EmployeesNum = DaoMSSQL.Instance.GetAttNum();
            int TotalPage = EmployeesNum % pdgAttendance.DisplayDataNumPerPage == 0 ? EmployeesNum / pdgAttendance.DisplayDataNumPerPage : ((EmployeesNum / pdgAttendance.DisplayDataNumPerPage) + 1);
            pdgAttendance.SetTotalPage(TotalPage);

            if (LoadPage <= 0)
                LoadPage = 1;
            else if (LoadPage >= TotalPage)
                LoadPage = TotalPage;

            //設定資料;//
            int FromNo = (pdgAttendance.DisplayDataNumPerPage * (LoadPage - 1));
            int EndNo = pdgAttendance.DisplayDataNumPerPage * LoadPage;
            pdgAttendance.BindingData(DaoMSSQL.Instance.GetAtt(FromNo, EndNo), LoadPage);

            //最後一個欄位設定為FILL;//
            m_dgvAttendance.Columns[m_dgvAttendance.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            m_dgvAttendance.ScrollBars = ScrollBars.Both;
        }
    }
}
