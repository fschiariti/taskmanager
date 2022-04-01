using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManager.Controller;
using TaskManager.ViewModel;


namespace TaskManager
{
    public partial class frmProcesses : Form
    {
        #region definitions

        private ProcessInformationViewModel p = new ProcessInformationViewModel();
        private List<ProcessesInformation> l = new List<ProcessesInformation>();
        private BindingSource bs = new BindingSource();

        public frmProcesses()
        {
            InitializeComponent();

            bckWorker.DoWork += bckWorker_DoWork;
            bckWorker.ProgressChanged += bckWorker_ProgressChanged;
        }


        #endregion

        #region methods

        private async Task<int> LoadDataAsync()
        {
            bckWorker.WorkerReportsProgress = true;
            bckWorker.RunWorkerAsync();
            l = await p.GetProcessesAsync();
            DataBind();
            return l.Count();
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


        #endregion

        #region events

        private async void frmProcesses_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async void btnRefreshAsync_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private void bckWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            for (int i = 0; i < 50; i++)
            {
                System.Threading.Thread.Sleep(1000);
                bckWorker.ReportProgress(i * 2);
            }
        }

        private void bckWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            pBar.Value = e.ProgressPercentage;
        }

        #endregion
    }
}
