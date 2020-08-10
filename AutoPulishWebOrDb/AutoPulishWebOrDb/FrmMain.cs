using AutoPulishWebOrDb.Dal;
using AutoPulishWebOrDb.Help;
using Microsoft.Web.Administration;
//using AutoPulishWebOrDb.Help;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoPulishWebOrDb
{
    public partial class FrmMain : UIForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }


        private void btnSqlServerOk_Click(object sender, EventArgs e)
        {

        }

        private void rbtSqlServer_Click(object sender, EventArgs e)
        {

        }

        private void rbtMysql_ValueChanged(object sender, bool value)
        {
            if (rbtMysql.Checked)
            {

            }
        }

        private void rbtOracle_ValueChanged(object sender, bool value)
        {
            if (rbtOracle.Checked)
            {

            }
        }

        private void rbtSqlServer_ValueChanged(object sender, bool value)
        {
            if (rbtSqlServer.Checked)
            {

            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.tabControl1.SelectedIndex)
            {
                case 0:
                    //InitIndex();
                    break;
                case 1:
                    InitTab1();
                    break;
            }
        }

        private void InitTab1()
        {

        }


        private BaseDal GetDal(string connString)
        {
            BaseDal dal = null;
            if (this.rbtMysql.Checked)
            {
                //dal = new MysqlDal(connString);
            }
            if (this.rbtOracle.Checked)
            {
                dal = new OracleDal(connString);
            }
            if (this.rbtSqlServer.Checked)
            {
                dal = new SqlServerDal(connString);
            }
            return dal;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (this.tbConnString.Text.IsNullOrWhiteSpace())
            {
                this.ShowWarningDialog("没有设置连接字符串");
                return;
            }
            var dal = GetDal(this.tbConnString.Text);
            var result = dal.TestConnection();
            if (!result)
            {
                UIMessageTip.ShowError("测试失败", 1000, true);
            }
            else
            {
                UIMessageTip.ShowOk("测试成功", 1000, true);
            }
        }

        private void btnDbPath_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Filter = "(*.bak)|*.bak";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.tbDbPath.Text = dialog.FileName;
            }
        }

        private void btnDbOk_Click(object sender, EventArgs e)
        {
            var connString = this.tbConnString.Text;
            var dbName = this.tbDbName.Text;
            var dbPath = this.tbDbPath.Text;
            var savePath = this.tbSavePath.Text;
            if (connString.IsNullOrWhiteSpace())
            {
                this.ShowWarningDialog("没有设置连接字符串");
                return;
            }
            if (dbName.IsNullOrWhiteSpace())
            {
                this.ShowWarningDialog("数据库名不可为空");
                return;
            }
            if (dbPath.IsNullOrWhiteSpace())
            {
                this.ShowWarningDialog("数据库文件不可为空");
                return;
            }

            if (!File.Exists(dbPath))
            {
                this.ShowWarningDialog("数据库文件不存在");
                return;
            }

            if(savePath.IsNullOrWhiteSpace())
            {
                this.ShowWarningDialog("保存目录不可为空");
                return;
            }

            if (!Directory.Exists(savePath))
            {
                this.ShowWarningDialog("保存目录不存在");
                return;
            }

            var dal = GetDal(this.tbConnString.Text);
            var dbNameIsExist = dal.IsExistDb(dbName);
            if (dbNameIsExist)
            {
                this.ShowWarningDialog($"数据库:{dbName} 已存在");
                return;
            }
            dal.RestoreDb(dbName, dbPath, savePath);
            UIMessageTip.ShowOk("创建成功", 2000, true);
        }

        private void btnSavePath_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "选择保存目录";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.tbSavePath.Text = dialog.SelectedPath;
            }
        }

        private void btnCheckPort_Click(object sender, EventArgs e)
        {
            var port = this.tbPort.Text;
            if (port.IsNullOrWhiteSpace())
            {
                UIMessageTip.ShowError("端口号为空", 1000, true);
                return;
            }

            if (!port.IsNumeric())
            {
                UIMessageTip.ShowError("端口号只能为数字", 1000, true);
                return;
            }

            if (PortHelper.PortInUse(Convert.ToInt32(port)))
            {
                this.ShowWarningDialog($"{port}端口号已被占用");
            }
            else
            {
                this.ShowSuccessTip($"端口号:{port} 未占用");
            }
        }

        private IISManagerHelp iisManager = null;
        private void FrmMain_Load(object sender, EventArgs e)
        {
            iisManager = new IISManagerHelp();
        }

        private void btnPoolNameUse_Click(object sender, EventArgs e)
        {
            var poolName = this.tbPoolName.Text;
            if (poolName.IsNullOrWhiteSpace())
            {
                UIMessageTip.ShowError("程序池名为空", 1000, true);
                return;
            }

            if (iisManager.IsExistPoolName(poolName))
            {
                this.ShowWarningDialog($"名称:{poolName}已被使用");
            }
            else
            {
                this.ShowSuccessTip($"名称:{poolName} 未使用");
            }
        }

        private void btnSiteUse_Click(object sender, EventArgs e)
        {
            var siteName = this.tbSiteName.Text;
            if (siteName.IsNullOrWhiteSpace())
            {
                UIMessageTip.ShowError("应用名为空", 1000, true);
                return;
            }

            if (iisManager.IsExistSiteName(siteName))
            {
                this.ShowWarningDialog($"应用名:{siteName} 已被使用");
            }
            else
            {
                this.ShowSuccessTip($"应用名:{siteName} 未使用");
            }
        }

        private void btnSiteOK_Click(object sender, EventArgs e)
        {
            if (!this.iisManager.IsInstallIIS())
            {
                this.ShowWarningDialog("服务器尚未安装IIS服务模块");
                return;
            }
            if (IISHelp.GetIISVersion() < 0)
            {
                this.ShowWarningDialog("没有安装 IIS 环境");
                return;
            }
            if (!NetFrameWorkHelp.IsExistNet40())
            {
                this.ShowWarningDialog("没有 NET4.0 环境");
                return;
            }

            Dictionary<string, string> mimeDic = new Dictionary<string, string>();
            mimeDic.Add(".woff2", "application/x-font-woff");
            mimeDic.Add(".woff", "application/x-font-woff");
            //IISHelp.AddMIMEType(mimeDic);

            var siteName = this.tbSiteName.Text;
            if (siteName.IsNullOrWhiteSpace())
            {
                this.ShowWarningDialog("应用名为空");
                return;
            }
            if (iisManager.IsExistSiteName(siteName))
            {
                this.ShowWarningDialog($"应用名:{siteName} 已被使用");
                return;
            }


            var poolName = this.tbPoolName.Text;
            if (poolName.IsNullOrWhiteSpace())
            {
                this.ShowWarningDialog("程序池名为空");
                return;
            }
            if (iisManager.IsExistPoolName(poolName))
            {
                this.ShowWarningDialog($"名称:{poolName}已被使用");
                return;
            }

            var port = this.tbPort.Text;
            if (port.IsNullOrWhiteSpace())
            {
                this.ShowWarningDialog("端口号为空");
                return;
            }
            if (!port.IsNumeric())
            {
                this.ShowWarningDialog("端口号只能为数字");
                return;
            }
            if (PortHelper.PortInUse(Convert.ToInt32(port)))
            {
                this.ShowWarningDialog($"{port}端口号已被占用");
                return;
            }


            var sitePath = this.tbSitePath.Text;
            if (sitePath.IsNullOrWhiteSpace())
            {
                this.ShowWarningDialog("应用路径不可为空");
                return;
            }
            if (!Directory.Exists(sitePath))
            {
                this.ShowWarningDialog("应用路径不存在");
                return;
            }

           

            var result=iisManager.CreateWebSite(siteName, poolName, sitePath, Convert.ToInt32(port), mimeDic, GetPoolMode());
            if (result)
            {
                UIMessageTip.ShowOk("发布成功", 2000, true);
            }
            else
            {
                this.ShowWarningDialog("发布失败");
            }
        }

        private ManagedPipelineMode GetPoolMode()
        {
            if (this.rbtIntegrated.Checked)
            {
                return (ManagedPipelineMode)0;
            }
            else
            {
                return (ManagedPipelineMode)1;
            }
        }

        private void btnSitePath_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "选择应用目录";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.tbSitePath.Text = dialog.SelectedPath;
            }
        }
    }
}
