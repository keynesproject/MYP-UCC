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

            m_dgvEmployees.ScrollBars = ScrollBars.Both;
        }
    }
}
