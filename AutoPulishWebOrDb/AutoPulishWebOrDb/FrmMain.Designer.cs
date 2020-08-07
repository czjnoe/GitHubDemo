namespace AutoPulishWebOrDb
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
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.tabControl1 = new Sunny.UI.UITabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rbtClassic = new Sunny.UI.UIRadioButton();
            this.rbtIntegrated = new Sunny.UI.UIRadioButton();
            this.uiLabel10 = new Sunny.UI.UILabel();
            this.btnSiteUse = new Sunny.UI.UIButton();
            this.tbSiteName = new Sunny.UI.UITextBox();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.btnPoolNameUse = new Sunny.UI.UIButton();
            this.btnCheckPort = new Sunny.UI.UIButton();
            this.btnSiteOK = new Sunny.UI.UIButton();
            this.tbPoolName = new Sunny.UI.UITextBox();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.tbPort = new Sunny.UI.UITextBox();
            this.btnSitePath = new Sunny.UI.UIButton();
            this.tbSitePath = new Sunny.UI.UITextBox();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.uiPanel3 = new Sunny.UI.UIPanel();
            this.btnDbOk = new Sunny.UI.UIButton();
            this.panelSqlserver = new Sunny.UI.UIPanel();
            this.btnSavePath = new Sunny.UI.UIButton();
            this.tbSavePath = new Sunny.UI.UITextBox();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.btnTest = new Sunny.UI.UIButton();
            this.tbConnString = new Sunny.UI.UITextBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.tbDbName = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.btnDbPath = new Sunny.UI.UIButton();
            this.tbDbPath = new Sunny.UI.UITextBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiPanel2 = new Sunny.UI.UIPanel();
            this.rbtMysql = new Sunny.UI.UIRadioButton();
            this.rbtOracle = new Sunny.UI.UIRadioButton();
            this.rbtSqlServer = new Sunny.UI.UIRadioButton();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.uiPanel3.SuspendLayout();
            this.panelSqlserver.SuspendLayout();
            this.uiPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.tabControl1);
            this.uiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel1.Location = new System.Drawing.Point(0, 35);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(800, 445);
            this.uiPanel1.TabIndex = 0;
            this.uiPanel1.Text = null;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tabControl1.ItemSize = new System.Drawing.Size(150, 40);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 445);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rbtClassic);
            this.tabPage1.Controls.Add(this.rbtIntegrated);
            this.tabPage1.Controls.Add(this.uiLabel10);
            this.tabPage1.Controls.Add(this.btnSiteUse);
            this.tabPage1.Controls.Add(this.tbSiteName);
            this.tabPage1.Controls.Add(this.uiLabel9);
            this.tabPage1.Controls.Add(this.btnPoolNameUse);
            this.tabPage1.Controls.Add(this.btnCheckPort);
            this.tabPage1.Controls.Add(this.btnSiteOK);
            this.tabPage1.Controls.Add(this.tbPoolName);
            this.tabPage1.Controls.Add(this.uiLabel8);
            this.tabPage1.Controls.Add(this.uiLabel7);
            this.tabPage1.Controls.Add(this.tbPort);
            this.tabPage1.Controls.Add(this.btnSitePath);
            this.tabPage1.Controls.Add(this.tbSitePath);
            this.tabPage1.Controls.Add(this.uiLabel6);
            this.tabPage1.Location = new System.Drawing.Point(0, 40);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(800, 405);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "IIS部署";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rbtClassic
            // 
            this.rbtClassic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtClassic.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.rbtClassic.GroupIndex = 2;
            this.rbtClassic.Location = new System.Drawing.Point(422, 276);
            this.rbtClassic.Name = "rbtClassic";
            this.rbtClassic.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rbtClassic.Size = new System.Drawing.Size(150, 29);
            this.rbtClassic.TabIndex = 15;
            this.rbtClassic.Text = "经典模式";
            // 
            // rbtIntegrated
            // 
            this.rbtIntegrated.Checked = true;
            this.rbtIntegrated.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtIntegrated.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.rbtIntegrated.GroupIndex = 2;
            this.rbtIntegrated.Location = new System.Drawing.Point(187, 276);
            this.rbtIntegrated.Name = "rbtIntegrated";
            this.rbtIntegrated.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rbtIntegrated.Size = new System.Drawing.Size(150, 29);
            this.rbtIntegrated.TabIndex = 14;
            this.rbtIntegrated.Text = "集成模式";
            // 
            // uiLabel10
            // 
            this.uiLabel10.AutoSize = true;
            this.uiLabel10.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel10.Location = new System.Drawing.Point(45, 276);
            this.uiLabel10.Name = "uiLabel10";
            this.uiLabel10.Size = new System.Drawing.Size(97, 27);
            this.uiLabel10.TabIndex = 13;
            this.uiLabel10.Text = "托管模式:";
            this.uiLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSiteUse
            // 
            this.btnSiteUse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSiteUse.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnSiteUse.Location = new System.Drawing.Point(549, 215);
            this.btnSiteUse.Name = "btnSiteUse";
            this.btnSiteUse.Size = new System.Drawing.Size(100, 35);
            this.btnSiteUse.TabIndex = 12;
            this.btnSiteUse.Text = "是否存在";
            this.btnSiteUse.Click += new System.EventHandler(this.btnSiteUse_Click);
            // 
            // tbSiteName
            // 
            this.tbSiteName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbSiteName.FillColor = System.Drawing.Color.White;
            this.tbSiteName.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tbSiteName.Location = new System.Drawing.Point(187, 215);
            this.tbSiteName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSiteName.Maximum = 2147483647D;
            this.tbSiteName.Minimum = -2147483648D;
            this.tbSiteName.Name = "tbSiteName";
            this.tbSiteName.Padding = new System.Windows.Forms.Padding(5);
            this.tbSiteName.Size = new System.Drawing.Size(321, 34);
            this.tbSiteName.TabIndex = 11;
            // 
            // uiLabel9
            // 
            this.uiLabel9.AutoSize = true;
            this.uiLabel9.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel9.Location = new System.Drawing.Point(40, 215);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(77, 27);
            this.uiLabel9.TabIndex = 10;
            this.uiLabel9.Text = "应用名:";
            this.uiLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPoolNameUse
            // 
            this.btnPoolNameUse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPoolNameUse.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnPoolNameUse.Location = new System.Drawing.Point(549, 162);
            this.btnPoolNameUse.Name = "btnPoolNameUse";
            this.btnPoolNameUse.Size = new System.Drawing.Size(100, 35);
            this.btnPoolNameUse.TabIndex = 9;
            this.btnPoolNameUse.Text = "是否存在";
            this.btnPoolNameUse.Click += new System.EventHandler(this.btnPoolNameUse_Click);
            // 
            // btnCheckPort
            // 
            this.btnCheckPort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckPort.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnCheckPort.Location = new System.Drawing.Point(549, 97);
            this.btnCheckPort.Name = "btnCheckPort";
            this.btnCheckPort.Size = new System.Drawing.Size(100, 35);
            this.btnCheckPort.TabIndex = 8;
            this.btnCheckPort.Text = "是否占用";
            this.btnCheckPort.Click += new System.EventHandler(this.btnCheckPort_Click);
            // 
            // btnSiteOK
            // 
            this.btnSiteOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSiteOK.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnSiteOK.Location = new System.Drawing.Point(313, 335);
            this.btnSiteOK.Name = "btnSiteOK";
            this.btnSiteOK.Size = new System.Drawing.Size(100, 35);
            this.btnSiteOK.TabIndex = 7;
            this.btnSiteOK.Text = "发布";
            this.btnSiteOK.Click += new System.EventHandler(this.btnSiteOK_Click);
            // 
            // tbPoolName
            // 
            this.tbPoolName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbPoolName.FillColor = System.Drawing.Color.White;
            this.tbPoolName.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tbPoolName.Location = new System.Drawing.Point(187, 156);
            this.tbPoolName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPoolName.Maximum = 2147483647D;
            this.tbPoolName.Minimum = -2147483648D;
            this.tbPoolName.Name = "tbPoolName";
            this.tbPoolName.Padding = new System.Windows.Forms.Padding(5);
            this.tbPoolName.Size = new System.Drawing.Size(321, 34);
            this.tbPoolName.TabIndex = 6;
            // 
            // uiLabel8
            // 
            this.uiLabel8.AutoSize = true;
            this.uiLabel8.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel8.Location = new System.Drawing.Point(40, 162);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(137, 27);
            this.uiLabel8.TabIndex = 5;
            this.uiLabel8.Text = "应用程序池名:";
            this.uiLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel7
            // 
            this.uiLabel7.AutoSize = true;
            this.uiLabel7.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel7.Location = new System.Drawing.Point(40, 97);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(77, 27);
            this.uiLabel7.TabIndex = 4;
            this.uiLabel7.Text = "端口号:";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbPort
            // 
            this.tbPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbPort.FillColor = System.Drawing.Color.White;
            this.tbPort.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tbPort.Location = new System.Drawing.Point(187, 99);
            this.tbPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPort.Maximum = 2147483647D;
            this.tbPort.Minimum = -2147483648D;
            this.tbPort.Name = "tbPort";
            this.tbPort.Padding = new System.Windows.Forms.Padding(5);
            this.tbPort.Size = new System.Drawing.Size(321, 34);
            this.tbPort.TabIndex = 3;
            // 
            // btnSitePath
            // 
            this.btnSitePath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSitePath.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnSitePath.Location = new System.Drawing.Point(602, 33);
            this.btnSitePath.Name = "btnSitePath";
            this.btnSitePath.Size = new System.Drawing.Size(47, 35);
            this.btnSitePath.TabIndex = 2;
            this.btnSitePath.Text = "....";
            this.btnSitePath.Click += new System.EventHandler(this.btnSitePath_Click);
            // 
            // tbSitePath
            // 
            this.tbSitePath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbSitePath.FillColor = System.Drawing.Color.White;
            this.tbSitePath.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tbSitePath.Location = new System.Drawing.Point(187, 35);
            this.tbSitePath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSitePath.Maximum = 2147483647D;
            this.tbSitePath.Minimum = -2147483648D;
            this.tbSitePath.Name = "tbSitePath";
            this.tbSitePath.Padding = new System.Windows.Forms.Padding(5);
            this.tbSitePath.Size = new System.Drawing.Size(395, 34);
            this.tbSitePath.TabIndex = 1;
            // 
            // uiLabel6
            // 
            this.uiLabel6.AutoSize = true;
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel6.Location = new System.Drawing.Point(40, 35);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(77, 27);
            this.uiLabel6.TabIndex = 0;
            this.uiLabel6.Text = "包目录:";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.uiPanel3);
            this.tabPage2.Controls.Add(this.panelSqlserver);
            this.tabPage2.Controls.Add(this.uiPanel2);
            this.tabPage2.Location = new System.Drawing.Point(0, 40);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(800, 405);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "数据库部署";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // uiPanel3
            // 
            this.uiPanel3.Controls.Add(this.btnDbOk);
            this.uiPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel3.Location = new System.Drawing.Point(0, 346);
            this.uiPanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel3.Name = "uiPanel3";
            this.uiPanel3.Size = new System.Drawing.Size(800, 59);
            this.uiPanel3.TabIndex = 2;
            this.uiPanel3.Text = null;
            // 
            // btnDbOk
            // 
            this.btnDbOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDbOk.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnDbOk.Location = new System.Drawing.Point(306, 8);
            this.btnDbOk.Name = "btnDbOk";
            this.btnDbOk.Size = new System.Drawing.Size(100, 35);
            this.btnDbOk.TabIndex = 13;
            this.btnDbOk.Text = "OK";
            this.btnDbOk.Click += new System.EventHandler(this.btnDbOk_Click);
            // 
            // panelSqlserver
            // 
            this.panelSqlserver.Controls.Add(this.btnSavePath);
            this.panelSqlserver.Controls.Add(this.tbSavePath);
            this.panelSqlserver.Controls.Add(this.uiLabel5);
            this.panelSqlserver.Controls.Add(this.btnTest);
            this.panelSqlserver.Controls.Add(this.tbConnString);
            this.panelSqlserver.Controls.Add(this.uiLabel4);
            this.panelSqlserver.Controls.Add(this.tbDbName);
            this.panelSqlserver.Controls.Add(this.uiLabel3);
            this.panelSqlserver.Controls.Add(this.btnDbPath);
            this.panelSqlserver.Controls.Add(this.tbDbPath);
            this.panelSqlserver.Controls.Add(this.uiLabel2);
            this.panelSqlserver.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSqlserver.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.panelSqlserver.Location = new System.Drawing.Point(0, 74);
            this.panelSqlserver.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelSqlserver.Name = "panelSqlserver";
            this.panelSqlserver.Size = new System.Drawing.Size(800, 272);
            this.panelSqlserver.TabIndex = 1;
            this.panelSqlserver.Text = null;
            // 
            // btnSavePath
            // 
            this.btnSavePath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSavePath.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnSavePath.Location = new System.Drawing.Point(606, 99);
            this.btnSavePath.Name = "btnSavePath";
            this.btnSavePath.Size = new System.Drawing.Size(47, 35);
            this.btnSavePath.TabIndex = 19;
            this.btnSavePath.Text = "....";
            this.btnSavePath.Click += new System.EventHandler(this.btnSavePath_Click);
            // 
            // tbSavePath
            // 
            this.tbSavePath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbSavePath.FillColor = System.Drawing.Color.White;
            this.tbSavePath.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tbSavePath.Location = new System.Drawing.Point(160, 87);
            this.tbSavePath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSavePath.Maximum = 2147483647D;
            this.tbSavePath.Minimum = -2147483648D;
            this.tbSavePath.Name = "tbSavePath";
            this.tbSavePath.Padding = new System.Windows.Forms.Padding(5);
            this.tbSavePath.Size = new System.Drawing.Size(429, 34);
            this.tbSavePath.TabIndex = 18;
            // 
            // uiLabel5
            // 
            this.uiLabel5.AutoSize = true;
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel5.Location = new System.Drawing.Point(41, 87);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(97, 27);
            this.uiLabel5.TabIndex = 17;
            this.uiLabel5.Text = "保存目录:";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnTest
            // 
            this.btnTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTest.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnTest.Location = new System.Drawing.Point(606, 201);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(100, 35);
            this.btnTest.TabIndex = 16;
            this.btnTest.Text = "Test";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // tbConnString
            // 
            this.tbConnString.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbConnString.FillColor = System.Drawing.Color.White;
            this.tbConnString.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tbConnString.Location = new System.Drawing.Point(160, 201);
            this.tbConnString.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbConnString.Maximum = 2147483647D;
            this.tbConnString.Minimum = -2147483648D;
            this.tbConnString.Name = "tbConnString";
            this.tbConnString.Padding = new System.Windows.Forms.Padding(5);
            this.tbConnString.Size = new System.Drawing.Size(429, 34);
            this.tbConnString.TabIndex = 15;
            // 
            // uiLabel4
            // 
            this.uiLabel4.AutoSize = true;
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel4.Location = new System.Drawing.Point(41, 202);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(77, 27);
            this.uiLabel4.TabIndex = 14;
            this.uiLabel4.Text = "连接串:";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbDbName
            // 
            this.tbDbName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbDbName.FillColor = System.Drawing.Color.White;
            this.tbDbName.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tbDbName.Location = new System.Drawing.Point(160, 143);
            this.tbDbName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbDbName.Maximum = 2147483647D;
            this.tbDbName.Minimum = -2147483648D;
            this.tbDbName.Name = "tbDbName";
            this.tbDbName.Padding = new System.Windows.Forms.Padding(5);
            this.tbDbName.Size = new System.Drawing.Size(429, 34);
            this.tbDbName.TabIndex = 12;
            // 
            // uiLabel3
            // 
            this.uiLabel3.AutoSize = true;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel3.Location = new System.Drawing.Point(41, 143);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(97, 27);
            this.uiLabel3.TabIndex = 11;
            this.uiLabel3.Text = "数据库名:";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDbPath
            // 
            this.btnDbPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDbPath.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnDbPath.Location = new System.Drawing.Point(606, 30);
            this.btnDbPath.Name = "btnDbPath";
            this.btnDbPath.Size = new System.Drawing.Size(47, 35);
            this.btnDbPath.TabIndex = 10;
            this.btnDbPath.Text = "....";
            this.btnDbPath.Click += new System.EventHandler(this.btnDbPath_Click);
            // 
            // tbDbPath
            // 
            this.tbDbPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbDbPath.FillColor = System.Drawing.Color.White;
            this.tbDbPath.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tbDbPath.Location = new System.Drawing.Point(160, 31);
            this.tbDbPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbDbPath.Maximum = 2147483647D;
            this.tbDbPath.Minimum = -2147483648D;
            this.tbDbPath.Name = "tbDbPath";
            this.tbDbPath.Padding = new System.Windows.Forms.Padding(5);
            this.tbDbPath.Size = new System.Drawing.Size(429, 34);
            this.tbDbPath.TabIndex = 9;
            // 
            // uiLabel2
            // 
            this.uiLabel2.AutoSize = true;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(41, 30);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(57, 27);
            this.uiLabel2.TabIndex = 8;
            this.uiLabel2.Text = "路径:";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiPanel2
            // 
            this.uiPanel2.Controls.Add(this.rbtMysql);
            this.uiPanel2.Controls.Add(this.rbtOracle);
            this.uiPanel2.Controls.Add(this.rbtSqlServer);
            this.uiPanel2.Controls.Add(this.uiLabel1);
            this.uiPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiPanel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel2.Location = new System.Drawing.Point(0, 0);
            this.uiPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel2.Name = "uiPanel2";
            this.uiPanel2.Size = new System.Drawing.Size(800, 74);
            this.uiPanel2.TabIndex = 0;
            this.uiPanel2.Text = null;
            // 
            // rbtMysql
            // 
            this.rbtMysql.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtMysql.Enabled = false;
            this.rbtMysql.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.rbtMysql.GroupIndex = 1;
            this.rbtMysql.Location = new System.Drawing.Point(348, 24);
            this.rbtMysql.Name = "rbtMysql";
            this.rbtMysql.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rbtMysql.Size = new System.Drawing.Size(115, 29);
            this.rbtMysql.TabIndex = 7;
            this.rbtMysql.Text = "MySQL";
            this.rbtMysql.ValueChanged += new Sunny.UI.UIRadioButton.OnValueChanged(this.rbtMysql_ValueChanged);
            // 
            // rbtOracle
            // 
            this.rbtOracle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtOracle.Enabled = false;
            this.rbtOracle.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.rbtOracle.GroupIndex = 1;
            this.rbtOracle.Location = new System.Drawing.Point(469, 24);
            this.rbtOracle.Name = "rbtOracle";
            this.rbtOracle.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rbtOracle.Size = new System.Drawing.Size(108, 29);
            this.rbtOracle.TabIndex = 6;
            this.rbtOracle.Text = "Oracle";
            this.rbtOracle.ValueChanged += new Sunny.UI.UIRadioButton.OnValueChanged(this.rbtOracle_ValueChanged);
            // 
            // rbtSqlServer
            // 
            this.rbtSqlServer.Checked = true;
            this.rbtSqlServer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtSqlServer.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.rbtSqlServer.GroupIndex = 1;
            this.rbtSqlServer.Location = new System.Drawing.Point(214, 24);
            this.rbtSqlServer.Name = "rbtSqlServer";
            this.rbtSqlServer.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rbtSqlServer.Size = new System.Drawing.Size(128, 29);
            this.rbtSqlServer.TabIndex = 5;
            this.rbtSqlServer.Text = "SqlServer";
            this.rbtSqlServer.ValueChanged += new Sunny.UI.UIRadioButton.OnValueChanged(this.rbtSqlServer_ValueChanged);
            this.rbtSqlServer.Click += new System.EventHandler(this.rbtSqlServer_Click);
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(41, 24);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(132, 27);
            this.uiLabel1.TabIndex = 4;
            this.uiLabel1.Text = "数据库类型：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.uiPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.Text = "自动部署";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.uiPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.uiPanel3.ResumeLayout(false);
            this.panelSqlserver.ResumeLayout(false);
            this.panelSqlserver.PerformLayout();
            this.uiPanel2.ResumeLayout(false);
            this.uiPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UITabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Sunny.UI.UIPanel panelSqlserver;
        private Sunny.UI.UIPanel uiPanel2;
        private Sunny.UI.UIRadioButton rbtMysql;
        private Sunny.UI.UIRadioButton rbtOracle;
        private Sunny.UI.UIRadioButton rbtSqlServer;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIPanel uiPanel3;
        private Sunny.UI.UIButton btnDbOk;
        private Sunny.UI.UIButton btnTest;
        private Sunny.UI.UITextBox tbConnString;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UITextBox tbDbName;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIButton btnDbPath;
        private Sunny.UI.UITextBox tbDbPath;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIButton btnSavePath;
        private Sunny.UI.UITextBox tbSavePath;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UIButton btnSiteOK;
        private Sunny.UI.UITextBox tbPoolName;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UITextBox tbPort;
        private Sunny.UI.UIButton btnSitePath;
        private Sunny.UI.UITextBox tbSitePath;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UIButton btnSiteUse;
        private Sunny.UI.UITextBox tbSiteName;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UIButton btnPoolNameUse;
        private Sunny.UI.UIButton btnCheckPort;
        private Sunny.UI.UIRadioButton rbtClassic;
        private Sunny.UI.UIRadioButton rbtIntegrated;
        private Sunny.UI.UILabel uiLabel10;
    }
}

