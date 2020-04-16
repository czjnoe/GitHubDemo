using IISControl.Model;
using IISControl.Util;
using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using static IISControl.Util.Enums;

namespace IISControl
{
    public partial class FrmMain : Form
    {
        private Dictionary<string, string> dic = new Dictionary<string, string>();
        public FrmMain()
        {
            InitializeComponent();
            dic = EnumUtil.GetEnumDic<Status>();
            InitIp();
        }

        string path = "IIS://{0}/W3SVC/AppPools";
        string ip = string.Empty;
        public void InitPools(string _ip)
        {
            try
            {
                ServerManager server = ServerManager.OpenRemote(_ip);
                var pools = server.ApplicationPools;
                List<IssPool> list = new List<IssPool>();
                foreach (ApplicationPool pool in pools)
                {
                    IssPool IssPool = new IssPool();

                    int appCount = 0;
                    foreach (Site site in server.Sites)
                    {
                        foreach (Microsoft.Web.Administration.Application application in site.Applications)
                        {
                            if (application.ApplicationPoolName == pool.Name)
                            {
                                appCount++;
                                //IssPool.StationList.Add(new StationDetail
                                //{
                                //    StationName = site.Name,
                                //    Status = dic[((int)pool.State).ToString()]
                                //});
                            }
                        }
                    }
                    IssPool.ProcessCount = appCount;
                    IssPool.Name = pool.Name;

                    IssPool.Status = dic[((int)pool.State).ToString()];
                    IssPool.NetVersion = pool.ManagedRuntimeVersion;
                    IssPool.Identity = pool.ProcessModel.IdentityType.ToString();
                    list.Add(IssPool);
                }

                //DirectoryEntry pools = new DirectoryEntry(string.Format(path, this.tbIp.Text));
                //foreach (DirectoryEntry item in pools.Children)
                //{
                //    IssPool IssPool = new IssPool();
                //    IssPool.Name = item.Name;
                //    if (item.Properties["AppPoolState"].Value.ToString() == "2")
                //        IssPool.Status = "已启动";
                //    else if (item.Properties["AppPoolState"].Value.ToString() == "4")
                //        IssPool.Status = "已停止";
                //    IssPool.NetVersion = item.Properties["ManagedRuntimeVersion"].Value.ToString();
                //    //IssPool.Identity = pool.ProcessModel.IdentityType.ToString();
                //    object[] apps = item.Invoke("EnumAppsInPool", null) as object[];//站点数量
                //    IssPool.ProcessCount = apps.Count();
                //    list.Add(IssPool);
                //}
                dgvIssPools.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private string XMLPath = AppDomain.CurrentDomain.BaseDirectory + "IP.xml";
        public void InitIp()
        {

            if (File.Exists(XMLPath))
            {
                var list = ReadXml();
                this.dgvIp.DataSource = list;
            }
            else
            {

            }
        }

        public void saveXml(List<IpModel> list)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<IpModel>));
            Stream stream = new FileStream(XMLPath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            xs.Serialize(stream, list);
            stream.Close();
        }

        public List<IpModel> ReadXml()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<IpModel>));
            Stream stream = new FileStream(XMLPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var list = (List<IpModel>)xs.Deserialize(stream);
            stream.Close();
            return list;
        }

        /// <summary>
        /// 反序列化xml文本
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlStr"></param>
        /// <returns></returns>
        public T XmlDeserialize<T>(string xmlStr) where T : new()
        {
            xmlStr = xmlStr.Trim();
            xmlStr = xmlStr.Replace(" ", "");//去除空格
            XmlSerializer xml = new XmlSerializer(typeof(T));
            //StreamReader sr = null;
            StringReader sr = null;
            {
                //var bytes = System.Text.Encoding.Default.GetBytes(xmlStr);
                //MemoryStream mStream = new MemoryStream(bytes);
                //sr = new StreamReader(mStream);
            }
            {
                sr = new StringReader(xmlStr);
            }
            var t = (T)xml.Deserialize(sr);
            return t;
        }
        private void dgvIssPools_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //IssPool IssPool = (IssPool)dgvIssPools.Rows[e.RowIndex].DataBoundItem;
            //FrmSatation dialog = new FrmSatation(IssPool.StationList);
            //dialog.ShowDialog();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            InitPools(ip);
        }

        /// <summary>
        /// 程序池启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            foreach (IssPool item in GetSelectList())
            {
                ServerManager server = ServerManager.OpenRemote(ip);
                var pools2 = server.ApplicationPools;
                foreach (var pool in pools2)
                {
                    if (pool.Name == item.Name)
                    {
                        pool.Start();
                    }
                }
            }
            InitPools(ip);
        }

        /// <summary>
        /// 程序池回收
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecycle_Click(object sender, EventArgs e)
        {
            foreach (IssPool item in GetSelectList())
            {
                ServerManager server = ServerManager.OpenRemote(ip);
                var pools2 = server.ApplicationPools;
                foreach (var pool in pools2)
                {
                    if (pool.Name == item.Name)
                    {
                        pool.Recycle();
                    }
                }
            }
            InitPools(ip);
        }

        /// <summary>
        /// 程序池停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            foreach (IssPool item in GetSelectList())
            {
                ServerManager server = ServerManager.OpenRemote(ip);
                var pools2 = server.ApplicationPools;
                foreach (var pool in pools2)
                {
                    if (pool.Name == item.Name)
                    {
                        ObjectState Status = pool.Stop();
                    }
                }
            }
            InitPools(ip);
        }

        private IssPool currentIssPool = null;
        private void dgvIssPools_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentIssPool = (IssPool)dgvIssPools.Rows[e.RowIndex].DataBoundItem;
        }

        /// <summary>
        /// 获取选中程序池
        /// </summary>
        /// <returns></returns>
        public List<IssPool> GetSelectList()
        {
            List<IssPool> list = new List<IssPool>();
            foreach (DataGridViewRow row in dgvIssPools.SelectedRows)
            {
                IssPool IssPool = (IssPool)row.DataBoundItem;
                list.Add(IssPool);
            }
            return list;
        }

        private void dgvIp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// 编辑结束触发时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvIp_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            List<IpModel> list = new List<IpModel>();
            foreach (DataGridViewRow row in dgvIp.Rows)
            {
                if (row.Cells["IPAddress"].Value != null)
                {
                    if (!string.IsNullOrWhiteSpace(row.Cells["IPAddress"].Value.ToString()))
                    {
                        IpModel IpModel = new IpModel();
                        IpModel.IPAddress = row.Cells["IPAddress"].Value.ToString();
                        IpModel.BZ = row.Cells["BZ"].Value == null ? "" : row.Cells["BZ"].Value.ToString();
                        list.Add(IpModel);
                    }
                }
            }
            dgvIp.EndEdit();
            saveXml(list);
            //InitIp();
        }

        /// <summary>
        /// 右键弹窗事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            List<IpModel> list = new List<IpModel>();
            if (this.dgvIp.DataSource != null)
                list = ((List<IpModel>)this.dgvIp.DataSource);
            list.Add(new IpModel());
            this.dgvIp.DataSource = null;
            this.dgvIp.DataSource = list;
        }
        /// <summary>
        /// dataGridView右键弹窗
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvIp_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
            }
        }

        DataGridViewRow currentRow = null;
        private void dgvIp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvIp.SelectedRows != null)
            {
                if (dgvIp.SelectedRows.Count > 0)
                {
                    currentRow = dgvIp.SelectedRows[0];
                    ip = currentRow.Cells["IPAddress"].Value == null ? "" : currentRow.Cells["IPAddress"].Value.ToString();
                }
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            dgvIp.ClearSelection();
        }
        /// <summary>
        /// 加载站点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStation_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ip))
            {
                MessageBox.Show("没有选择IP");
                return;
            }
            FrmSatation dialog = new FrmSatation(ip);
            dialog.ShowDialog();
        }
    }
}
