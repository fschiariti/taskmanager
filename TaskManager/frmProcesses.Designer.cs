
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
            this.dgvProcesses.Size = new System.Drawing.Size(833, 397);
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
            // frmProcesses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 450);
            this.Controls.Add(this.btnRefreshAsync);
            this.Controls.Add(this.dgvProcesses);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task Manager";
            this.MaximumSizeChanged += new System.EventHandler(this.frmProcesses_Resize);
            this.Load += new System.EventHandler(this.frmProcesses_Load);
            this.Resize += new System.EventHandler(this.frmProcesses_Resize);
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
    }
}

