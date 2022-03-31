using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class frmProcesses : Form
    {
        public frmProcesses()
        {
            InitializeComponent();
        }

        private List<ProcessesInformation> l = new List<ProcessesInformation>();
        private BindingSource bs = new BindingSource();

        private void LoadData()
        {
            ProcessesInformation p = new ProcessesInformation();
            l = p.GetProcesses();
            DataBind();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmProcesses_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void DataBind()
        {
            dgvProcesses.Columns.Clear();

            DataGridViewColumn pid = new DataGridViewTextBoxColumn();
            pid.Width = 50;
            pid.DataPropertyName = "pId";
            pid.Name = "Id";
            dgvProcesses.Columns.Add(pid);

            DataGridViewColumn name = new DataGridViewTextBoxColumn();
            name.Width = 300;
            name.DataPropertyName = "name";
            name.Name = "Process name";
            dgvProcesses.Columns.Add(name);

            DataGridViewColumn exeName = new DataGridViewTextBoxColumn();
            exeName.Width = 300;
            exeName.DataPropertyName = "exeName";
            exeName.Name = "Process executable name";
            dgvProcesses.Columns.Add(exeName);

            DataGridViewColumn owner = new DataGridViewTextBoxColumn();
            owner.Width = 200;
            owner.DataPropertyName = "owner";
            owner.Name = "Owner";
            dgvProcesses.Columns.Add(owner);

            bs.DataSource = l.Select(m => new { m.pid, m.name, m.exeName, m.owner }).OrderBy(m => m.pid).ToList();
            dgvProcesses.DataSource = bs.DataSource;

        }

    }
}


