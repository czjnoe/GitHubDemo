namespace AutoPulishWebOrDb
{
    partial class FrmDataGridView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.dgv_config = new Sunny.UI.UIDataGridView();
            this.uiPanel2 = new Sunny.UI.UIPanel();
            this.btnSave = new Sunny.UI.UIButton();
            this.key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_config)).BeginInit();
            this.uiPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.dgv_config);
            this.uiPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel1.Location = new System.Drawing.Point(0, 35);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(800, 377);
            this.uiPanel1.TabIndex = 0;
            this.uiPanel1.Text = null;
            // 
            // dgv_config
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.dgv_config.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_config.BackgroundColor = System.Drawing.Color.White;
            this.dgv_config.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_config.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_config.ColumnHeadersHeight = 32;
            this.dgv_config.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_config.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.key,
            this.value});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_config.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_config.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_config.EnableHeadersVisualStyles = false;
            this.dgv_config.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.dgv_config.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dgv_config.Location = new System.Drawing.Point(0, 0);
            this.dgv_config.Name = "dgv_config";
            this.dgv_config.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgv_config.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_config.RowTemplate.Height = 29;
            this.dgv_config.SelectedIndex = -1;
            this.dgv_config.ShowGridLine = true;
            this.dgv_config.Size = new System.Drawing.Size(800, 377);
            this.dgv_config.TabIndex = 1;
            this.dgv_config.TagString = null;
            // 
            // uiPanel2
            // 
            this.uiPanel2.Controls.Add(this.btnSave);
            this.uiPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel2.Location = new System.Drawing.Point(0, 412);
            this.uiPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel2.Name = "uiPanel2";
            this.uiPanel2.Size = new System.Drawing.Size(800, 68);
            this.uiPanel2.TabIndex = 1;
            this.uiPanel2.Text = null;
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnSave.Location = new System.Drawing.Point(329, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // key
            // 
            this.key.DataPropertyName = "key";
            this.key.FillWeight = 152.2843F;
            this.key.HeaderText = "key";
            this.key.Name = "key";
            this.key.ReadOnly = true;
            this.key.Width = 150;
            // 
            // value
            // 
            this.value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.value.DataPropertyName = "value";
            this.value.FillWeight = 47.71573F;
            this.value.HeaderText = "value";
            this.value.Name = "value";
            // 
            // FrmDataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.uiPanel2);
            this.Controls.Add(this.uiPanel1);
            this.Name = "FrmDataGridView";
            this.Text = "修改";
            this.Load += new System.EventHandler(this.FrmDataGridView_Load);
            this.uiPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_config)).EndInit();
            this.uiPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UIDataGridView dgv_config;
        private Sunny.UI.UIPanel uiPanel2;
        private Sunny.UI.UIButton btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn key;
        private System.Windows.Forms.DataGridViewTextBoxColumn value;
    }
}