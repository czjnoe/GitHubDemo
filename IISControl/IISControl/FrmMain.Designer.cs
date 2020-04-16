namespace IISControl
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStation = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnRecycle = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvIssPools = new System.Windows.Forms.DataGridView();
            this.PoolName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Identity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcessCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvIp = new System.Windows.Forms.DataGridView();
            this.IPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssPools)).BeginInit();
            this.panel3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIp)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnStation);
            this.panel1.Controls.Add(this.btnLoad);
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnRecycle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(859, 58);
            this.panel1.TabIndex = 1;
            // 
            // btnStation
            // 
            this.btnStation.AutoSize = true;
            this.btnStation.Location = new System.Drawing.Point(239, 16);
            this.btnStation.Name = "btnStation";
            this.btnStation.Size = new System.Drawing.Size(98, 29);
            this.btnStation.TabIndex = 6;
            this.btnStation.Text = "加载站点";
            this.btnStation.UseVisualStyleBackColor = true;
            this.btnStation.Click += new System.EventHandler(this.btnStation_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(16, 16);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 29);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "加载";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(723, 15);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(100, 29);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(601, 15);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 29);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "重启";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnRecycle
            // 
            this.btnRecycle.Location = new System.Drawing.Point(477, 15);
            this.btnRecycle.Margin = new System.Windows.Forms.Padding(4);
            this.btnRecycle.Name = "btnRecycle";
            this.btnRecycle.Size = new System.Drawing.Size(100, 29);
            this.btnRecycle.TabIndex = 2;
            this.btnRecycle.Text = "回收";
            this.btnRecycle.UseVisualStyleBackColor = true;
            this.btnRecycle.Click += new System.EventHandler(this.btnRecycle_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 58);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(859, 417);
            this.panel2.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvIssPools);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(239, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(620, 417);
            this.panel4.TabIndex = 2;
            // 
            // dgvIssPools
            // 
            this.dgvIssPools.AllowUserToResizeRows = false;
            this.dgvIssPools.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIssPools.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PoolName,
            this.Status,
            this.Identity,
            this.NetVersion,
            this.ProcessCount});
            this.dgvIssPools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIssPools.Location = new System.Drawing.Point(0, 0);
            this.dgvIssPools.Margin = new System.Windows.Forms.Padding(4);
            this.dgvIssPools.Name = "dgvIssPools";
            this.dgvIssPools.RowTemplate.Height = 23;
            this.dgvIssPools.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIssPools.Size = new System.Drawing.Size(620, 417);
            this.dgvIssPools.TabIndex = 0;
            this.dgvIssPools.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIssPools_CellClick);
            this.dgvIssPools.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIssPools_CellDoubleClick);
            // 
            // PoolName
            // 
            this.PoolName.DataPropertyName = "Name";
            this.PoolName.HeaderText = "名称";
            this.PoolName.Name = "PoolName";
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "状态";
            this.Status.Name = "Status";
            // 
            // Identity
            // 
            this.Identity.DataPropertyName = "Identity";
            this.Identity.HeaderText = "标识";
            this.Identity.Name = "Identity";
            // 
            // NetVersion
            // 
            this.NetVersion.DataPropertyName = "NetVersion";
            this.NetVersion.HeaderText = "NET CLR";
            this.NetVersion.Name = "NetVersion";
            // 
            // ProcessCount
            // 
            this.ProcessCount.DataPropertyName = "ProcessCount";
            this.ProcessCount.HeaderText = "应用程序";
            this.ProcessCount.Name = "ProcessCount";
            // 
            // panel3
            // 
            this.panel3.ContextMenuStrip = this.contextMenuStrip1;
            this.panel3.Controls.Add(this.dgvIp);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(239, 417);
            this.panel3.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(109, 28);
            this.contextMenuStrip1.Text = "添加";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(108, 24);
            this.toolStripMenuItem1.Text = "添加";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // dgvIp
            // 
            this.dgvIp.AllowUserToAddRows = false;
            this.dgvIp.AllowUserToDeleteRows = false;
            this.dgvIp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IPAddress,
            this.BZ});
            this.dgvIp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIp.Location = new System.Drawing.Point(0, 0);
            this.dgvIp.Margin = new System.Windows.Forms.Padding(4);
            this.dgvIp.MultiSelect = false;
            this.dgvIp.Name = "dgvIp";
            this.dgvIp.RowHeadersVisible = false;
            this.dgvIp.RowTemplate.Height = 23;
            this.dgvIp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIp.Size = new System.Drawing.Size(239, 417);
            this.dgvIp.TabIndex = 0;
            this.dgvIp.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIp_CellClick);
            this.dgvIp.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIp_CellDoubleClick);
            this.dgvIp.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIp_CellEndEdit);
            this.dgvIp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvIp_MouseClick);
            // 
            // IPAddress
            // 
            this.IPAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IPAddress.DataPropertyName = "IPAddress";
            this.IPAddress.HeaderText = "IP";
            this.IPAddress.Name = "IPAddress";
            // 
            // BZ
            // 
            this.BZ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BZ.DataPropertyName = "BZ";
            this.BZ.HeaderText = "备注";
            this.BZ.Name = "BZ";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 475);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMain";
            this.Text = "程序池操作";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssPools)).EndInit();
            this.panel3.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvIssPools;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnRecycle;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvIp;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PoolName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Identity;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessCount;
        private System.Windows.Forms.Button btnStation;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn BZ;
    }
}

