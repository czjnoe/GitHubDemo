using IISControl.Model;
using IISControl.Util;
using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static IISControl.Util.Enums;

namespace IISControl
{
    public partial class FrmSatation : Form
    {
        private Dictionary<string, string> dic = new Dictionary<string, string>();
        public FrmSatation()
        {
            InitializeComponent();
        }
        private string ip = "";
        private string poolNmae = "";
        List<StationDetail> stationList = null;


        public FrmSatation(string _ip)
        {
            InitializeComponent();
            dic = EnumUtil.GetEnumDic<Status>();
            ip = _ip;
            stationList = InitStations(ip);
            this.dgvStation.DataSource = stationList;
        }
        string path = "IIS://{0}/W3SVC";
        public void Init()
        {
            List<StationDetail> list = new List<StationDetail>();
            DirectoryEntry pools = new DirectoryEntry(string.Format(path, ip));
            foreach (DirectoryEntry item in pools.Children)
            {
                if (item.SchemaClassName == "IIsWebServer")
                {
                    DirectoryEntry poolChild = new DirectoryEntry(string.Format(path+"/" + item.Name + "/ROOT", ip));
                    foreach (DirectoryEntry item1 in poolChild.Children)//程序池中子站点
                    {
                        if (item1.Properties["AppPoolId"].Value.ToString() == poolNmae)
                        {
                            StationDetail StationDetail = new StationDetail();
                            StationDetail.StationName = item.Properties["ServerComment"].Value.ToString();
                            list.Add(StationDetail);
                        }
                    }
                }
            }
            this.dgvStation.DataSource = list;
        }

        /// <summary>
        /// 初始化站点
        /// </summary>
        /// <param name="_ip"></param>
        /// <returns></returns>
        public List<StationDetail> InitStations(string _ip)
        {
            List<StationDetail> list = new List<StationDetail>();
            try
            {
                ServerManager server = ServerManager.OpenRemote(_ip);
                foreach (Site site in server.Sites)
                {
                    StationDetail StationDetail = new StationDetail
                    {
                        StationName = site.Name,
                        Status = dic[((int)site.State).ToString()],
                        Site = site
                    };
                    list.Add(StationDetail);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return list;
        }

        private StationDetail curentStation = null;
        private void dgvStation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            curentStation = (StationDetail)dgvStation.Rows[e.RowIndex].DataBoundItem;
        }
        /// <summary>
        /// 启动站点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (curentStation != null)
                curentStation.Site.Start();
            RefreshSource();
        }
        /// <summary>
        /// 站点停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (curentStation != null)
                curentStation.Site.Stop();
            RefreshSource();
        }

        /// <summary>
        /// 刷新源
        /// </summary>
        public void RefreshSource()
        {
            this.dgvStation.DataSource = InitStations(ip);
        }
    }


}
