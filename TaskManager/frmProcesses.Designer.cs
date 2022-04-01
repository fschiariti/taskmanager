
namespace TaskManager
{
    partial class frmProcesses
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dgvProcesses = new System.Windows.Forms.DataGridView();
            this.btnRefreshAsync = new System.Windows.Forms.Button();
            this.bckWorker = new System.ComponentModel.BackgroundWorker();
            this.pBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesses)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProcesses
            // 
            this.dgvProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProcesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcesses.Location = new System.Drawing.Point(12, 12);
            this.dgvProcesses.Name = "dgvProcesses";
            this.dgvProcesses.RowTemplate.Height = 25;
            this.dgvProcesses.Size = new System.Drawing.Size(776, 397);
            this.dgvProcesses.TabIndex = 0;
            // 
            // btnRefreshAsync
            // 
            this.btnRefreshAsync.Location = new System.Drawing.Point(12, 414);
            this.btnRefreshAsync.Name = "btnRefreshAsync";
            this.btnRefreshAsync.Size = new System.Drawing.Size(121, 23);
            this.btnRefreshAsync.TabIndex = 4;
            this.btnRefreshAsync.Text = "Refresh";
            this.btnRefreshAsync.UseVisualStyleBackColor = true;
            this.btnRefreshAsync.Click += new System.EventHandler(this.btnRefreshAsync_Click);
            // 
            // bckWorker
            // 
            this.bckWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bckWorker_DoWork);
            this.bckWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bckWorker_ProgressChanged);
            // 
            // pBar
            // 
            this.pBar.Location = new System.Drawing.Point(139, 414);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(649, 23);
            this.pBar.TabIndex = 5;
            // 
            // frmProcesses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pBar);
            this.Controls.Add(this.btnRefreshAsync);
            this.Controls.Add(this.dgvProcesses);
            this.Text = "Task Manager";
            this.Load += new System.EventHandler(this.frmProcesses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridView dgvProcesses;
        private System.Windows.Forms.DataGridViewTextBoxColumn pid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn exeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn owner;
        private System.Windows.Forms.Button btnRefreshAsync;
        private System.ComponentModel.BackgroundWorker bckWorker;
        private System.Windows.Forms.ProgressBar pBar;
    }
}

