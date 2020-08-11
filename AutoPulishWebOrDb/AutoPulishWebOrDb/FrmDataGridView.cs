using AutoPulishWebOrDb.Help;
using AutoPulishWebOrDb.Model;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoPulishWebOrDb
{
    public partial class FrmDataGridView : UIForm
    {
        public FrmDataGridView()
        {
            InitializeComponent();
        }
        private string _configPath = string.Empty;
        public FrmDataGridView(string configPath)
        {
            InitializeComponent();
            _configPath = configPath;
        }
        public override void Init()
        {
            List<Config> list = new List<Config>();
            var dic = ConfigUtil.GetAppSettingValues(_configPath);
            foreach (string key in dic.Keys)
            {
                Config config = new Config();
                config.key = key;
                config.value = dic[key];
                list.Add(config);
            }
            this.dgv_config.DataSource = list;
        }

        private void dgv_config_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //var DataGridViewCell=this.dvg_config.Rows[e.RowIndex].Cells[e.ColumnIndex];
            this.dgv_config.BeginEdit(true);
        }

        private void FrmDataGridView_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in this.dgv_config.Rows)
                {
                    var key = row.Cells["key"].Value?.ToString();
                    var value = row.Cells["value"].Value?.ToString();
                    ConfigUtil.SetAppSettingValue(key, value, _configPath);
                }
                UIMessageTip.ShowOk("编辑成功", 2000, true);
            }
            catch (Exception ex)
            {
                this.ShowWarningDialog("编辑失败");
            }

        }
    }
}
