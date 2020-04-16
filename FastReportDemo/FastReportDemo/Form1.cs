using FastReport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            try
            {
               
                var frxPath = $"{AppDomain.CurrentDomain.BaseDirectory}\\Frx\\fastReportDemo.frx";
                if (!System.IO.File.Exists(frxPath))
                {
                    MessageBox.Show("打印文件不存在");
                    return;
                }
                DataSet ds = new DataSet();
                DataTable dt = new DataTable("用户");
                dt.Columns.Add("姓名", typeof(String));
                dt.Columns.Add("密码", typeof(String));
                DataRow row = dt.NewRow();
                row["姓名"] = "陈兆杰";
                row["密码"] = "123456";
                dt.Rows.Add(row);

                row = dt.NewRow();
                row["姓名"] = "辅导辅导";
                row["密码"] = "123456";
                dt.Rows.Add(row);
                ds.Tables.Add(dt);
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("currentDate", DateTime.Now);

                report.Load(frxPath);
                report.RegisterData(ds);
                foreach (var key in dic.Keys)
                {
                    report.SetParameterValue(key, dic[key]);//设置参数
                }
                report.Show();
                report.Dispose();
            }
            catch(Exception ex)
            {
                report.Dispose();
            }
        }
        public class User
        {
            public string Name { get; set; }
            public int Pwd { get; set; }
        }
    }
}
