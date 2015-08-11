namespace gmap.demo.winform
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel4 = new System.Windows.Forms.Panel();
            this.mapControl1 = new gmap.demo.winform.MapControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.splitter1 = new BSE.Windows.Forms.Splitter();
            this.panelMenu = new BSE.Windows.Forms.Panel();
            this.xPanderPanelList1 = new BSE.Windows.Forms.XPanderPanelList();
            this.xPanderPanelMain = new BSE.Windows.Forms.XPanderPanel();
            this.xPanderPanel1 = new BSE.Windows.Forms.XPanderPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbnLayerNames = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.attributeFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataSet1 = new System.Data.DataSet();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbPan = new System.Windows.Forms.ToolStripButton();
            this.tsbZoomIn = new System.Windows.Forms.ToolStripButton();
            this.tsbZoomOut = new System.Windows.Forms.ToolStripButton();
            this.tsbMeasureDistance = new System.Windows.Forms.ToolStripButton();
            this.tsbMeasureArea = new System.Windows.Forms.ToolStripButton();
            this.tsbDropdownbtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbPolygonQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbPointQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbRectQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbtnQuerySetting = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbtnClearhighlight = new System.Windows.Forms.ToolStripButton();
            this.panel4.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.xPanderPanelList1.SuspendLayout();
            this.xPanderPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.mapControl1);
            this.panel4.Controls.Add(this.toolStrip1);
            this.panel4.Controls.Add(this.splitter1);
            this.panel4.Controls.Add(this.panelMenu);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(958, 518);
            this.panel4.TabIndex = 44;
            // 
            // mapControl1
            // 
            this.mapControl1.Bearing = 0F;
            this.mapControl1.CanDragMap = true;
            this.mapControl1.CurrentAction = null;
            this.mapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapControl1.GrayScaleMode = false;
            this.mapControl1.LevelsKeepInMemmory = 5;
            this.mapControl1.Location = new System.Drawing.Point(0, 29);
            this.mapControl1.MarkersEnabled = true;
            this.mapControl1.MaxZoom = 2;
            this.mapControl1.MinZoom = 2;
            this.mapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.mapControl1.Name = "mapControl1";
            this.mapControl1.NegativeMode = false;
            this.mapControl1.PolygonsEnabled = true;
            this.mapControl1.RetryLoadTile = 0;
            this.mapControl1.RoutesEnabled = true;
            this.mapControl1.ShowTileGridLines = false;
            this.mapControl1.Size = new System.Drawing.Size(728, 489);
            this.mapControl1.TabIndex = 45;
            this.mapControl1.Zoom = 0D;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOpen,
            this.toolStripSeparator1,
            this.tsbPan,
            this.tsbZoomIn,
            this.tsbZoomOut,
            this.toolStripSeparator2,
            this.tsbMeasureDistance,
            this.tsbMeasureArea,
            this.toolStripSeparator3,
            this.tsbDropdownbtn,
            this.toolStripSeparator4,
            this.tsbtnClearhighlight});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(728, 29);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 44;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 29);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 29);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 29);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Transparent;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(728, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(2);
            this.splitter1.MinExtra = 390;
            this.splitter1.MinSize = 390;
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(2, 518);
            this.splitter1.TabIndex = 42;
            this.splitter1.TabStop = false;
            // 
            // panelMenu
            // 
            this.panelMenu.AssociatedSplitter = null;
            this.panelMenu.BackColor = System.Drawing.Color.Transparent;
            this.panelMenu.CaptionFont = new System.Drawing.Font("微软雅黑", 11.75F, System.Drawing.FontStyle.Bold);
            this.panelMenu.CaptionHeight = 27;
            this.panelMenu.Controls.Add(this.xPanderPanelList1);
            this.panelMenu.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.panelMenu.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.panelMenu.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.panelMenu.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.panelMenu.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.panelMenu.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.panelMenu.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.panelMenu.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.panelMenu.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.panelMenu.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.panelMenu.CustomColors.ContentGradientBegin = System.Drawing.SystemColors.ButtonFace;
            this.panelMenu.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.panelMenu.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelMenu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelMenu.Image = null;
            this.panelMenu.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.panelMenu.Location = new System.Drawing.Point(730, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(2);
            this.panelMenu.MinimumSize = new System.Drawing.Size(27, 27);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.panelMenu.Size = new System.Drawing.Size(228, 518);
            this.panelMenu.TabIndex = 40;
            this.panelMenu.Text = "Menu";
            this.panelMenu.ToolTipTextCloseIcon = null;
            this.panelMenu.ToolTipTextExpandIconPanelCollapsed = "maximize";
            this.panelMenu.ToolTipTextExpandIconPanelExpanded = "minimize";
            this.panelMenu.Visible = false;
            // 
            // xPanderPanelList1
            // 
            this.xPanderPanelList1.BackColor = System.Drawing.Color.Transparent;
            this.xPanderPanelList1.CaptionStyle = BSE.Windows.Forms.CaptionStyle.Flat;
            this.xPanderPanelList1.Controls.Add(this.xPanderPanelMain);
            this.xPanderPanelList1.Controls.Add(this.xPanderPanel1);
            this.xPanderPanelList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanderPanelList1.GradientBackground = System.Drawing.Color.Empty;
            this.xPanderPanelList1.Location = new System.Drawing.Point(0, 28);
            this.xPanderPanelList1.Margin = new System.Windows.Forms.Padding(2);
            this.xPanderPanelList1.Name = "xPanderPanelList1";
            this.xPanderPanelList1.PanelColors = null;
            this.xPanderPanelList1.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.xPanderPanelList1.ShowCloseIcon = true;
            this.xPanderPanelList1.ShowExpandIcon = true;
            this.xPanderPanelList1.Size = new System.Drawing.Size(228, 489);
            this.xPanderPanelList1.TabIndex = 1;
            this.xPanderPanelList1.Text = "xPanderPanelList1";
            // 
            // xPanderPanelMain
            // 
            this.xPanderPanelMain.CaptionFont = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Bold);
            this.xPanderPanelMain.Cursor = System.Windows.Forms.Cursors.Cross;
            this.xPanderPanelMain.CustomColors.BackColor = System.Drawing.SystemColors.Control;
            this.xPanderPanelMain.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.xPanderPanelMain.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.Empty;
            this.xPanderPanelMain.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.Empty;
            this.xPanderPanelMain.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.Empty;
            this.xPanderPanelMain.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanelMain.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanelMain.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanelMain.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.xPanderPanelMain.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanelMain.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanelMain.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanelMain.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanelMain.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanelMain.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanelMain.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanelMain.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanelMain.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanelMain.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanelMain.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanelMain.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.xPanderPanelMain.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanderPanelMain.Image = null;
            this.xPanderPanelMain.IsClosable = false;
            this.xPanderPanelMain.Margin = new System.Windows.Forms.Padding(2);
            this.xPanderPanelMain.Name = "xPanderPanelMain";
            this.xPanderPanelMain.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.xPanderPanelMain.Size = new System.Drawing.Size(228, 25);
            this.xPanderPanelMain.TabIndex = 0;
            this.xPanderPanelMain.Text = "map";
            this.xPanderPanelMain.ToolTipTextCloseIcon = null;
            this.xPanderPanelMain.ToolTipTextExpandIconPanelCollapsed = null;
            this.xPanderPanelMain.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // xPanderPanel1
            // 
            this.xPanderPanel1.CaptionFont = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Bold);
            this.xPanderPanel1.Controls.Add(this.groupBox2);
            this.xPanderPanel1.Controls.Add(this.groupBox1);
            this.xPanderPanel1.CustomColors.BackColor = System.Drawing.SystemColors.Control;
            this.xPanderPanel1.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.xPanderPanel1.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.Empty;
            this.xPanderPanel1.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.Empty;
            this.xPanderPanel1.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.Empty;
            this.xPanderPanel1.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel1.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel1.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanel1.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.xPanderPanel1.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanel1.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel1.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel1.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel1.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel1.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel1.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel1.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel1.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel1.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanel1.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanel1.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.xPanderPanel1.Expand = true;
            this.xPanderPanel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel1.Image = null;
            this.xPanderPanel1.IsClosable = false;
            this.xPanderPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.xPanderPanel1.Name = "xPanderPanel1";
            this.xPanderPanel1.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.xPanderPanel1.Size = new System.Drawing.Size(228, 464);
            this.xPanderPanel1.TabIndex = 3;
            this.xPanderPanel1.Text = "查询";
            this.xPanderPanel1.ToolTipTextCloseIcon = null;
            this.xPanderPanel1.ToolTipTextExpandIconPanelCollapsed = null;
            this.xPanderPanel1.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(1, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(226, 288);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询结果";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(220, 268);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbnLayerNames);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.attributeFilter);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(1, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 151);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "sql查询";
            // 
            // cbnLayerNames
            // 
            this.cbnLayerNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbnLayerNames.FormattingEnabled = true;
            this.cbnLayerNames.Location = new System.Drawing.Point(15, 86);
            this.cbnLayerNames.Name = "cbnLayerNames";
            this.cbnLayerNames.Size = new System.Drawing.Size(190, 20);
            this.cbnLayerNames.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "待查询图层:";
            // 
            // attributeFilter
            // 
            this.attributeFilter.Location = new System.Drawing.Point(109, 21);
            this.attributeFilter.Name = "attributeFilter";
            this.attributeFilter.Size = new System.Drawing.Size(96, 21);
            this.attributeFilter.TabIndex = 1;
            this.attributeFilter.Text = "SMID > 0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "属性过滤条件:";
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // tsbOpen
            // 
            this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpen.Image")));
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(48, 26);
            this.tsbOpen.Text = "初始化";
            // 
            // tsbPan
            // 
            this.tsbPan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPan.Image = global::gmap.demo.winform.Properties.Resources.btn_06_off;
            this.tsbPan.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbPan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPan.Name = "tsbPan";
            this.tsbPan.Size = new System.Drawing.Size(28, 26);
            this.tsbPan.Text = "平移";
            this.tsbPan.Click += new System.EventHandler(this.tsbPan_Click);
            // 
            // tsbZoomIn
            // 
            this.tsbZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbZoomIn.Image = global::gmap.demo.winform.Properties.Resources.btn_02_off;
            this.tsbZoomIn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZoomIn.Name = "tsbZoomIn";
            this.tsbZoomIn.Size = new System.Drawing.Size(28, 26);
            this.tsbZoomIn.Text = "放大";
            this.tsbZoomIn.Click += new System.EventHandler(this.tsbZoomIn_Click);
            // 
            // tsbZoomOut
            // 
            this.tsbZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbZoomOut.Image = global::gmap.demo.winform.Properties.Resources.btn_03_off;
            this.tsbZoomOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZoomOut.Name = "tsbZoomOut";
            this.tsbZoomOut.Size = new System.Drawing.Size(28, 26);
            this.tsbZoomOut.Text = "缩小";
            this.tsbZoomOut.Click += new System.EventHandler(this.tsbZoomOut_Click);
            // 
            // tsbMeasureDistance
            // 
            this.tsbMeasureDistance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMeasureDistance.Image = global::gmap.demo.winform.Properties.Resources.btn_15_off;
            this.tsbMeasureDistance.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbMeasureDistance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMeasureDistance.Name = "tsbMeasureDistance";
            this.tsbMeasureDistance.Size = new System.Drawing.Size(28, 26);
            this.tsbMeasureDistance.Text = "距离量算";
            this.tsbMeasureDistance.Click += new System.EventHandler(this.tsbMeasureDistance_Click);
            // 
            // tsbMeasureArea
            // 
            this.tsbMeasureArea.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMeasureArea.Image = global::gmap.demo.winform.Properties.Resources.btn_16_off;
            this.tsbMeasureArea.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbMeasureArea.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMeasureArea.Name = "tsbMeasureArea";
            this.tsbMeasureArea.Size = new System.Drawing.Size(28, 26);
            this.tsbMeasureArea.Text = "面积量算";
            this.tsbMeasureArea.Click += new System.EventHandler(this.tsbMeasureArea_Click);
            // 
            // tsbDropdownbtn
            // 
            this.tsbDropdownbtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPolygonQuery,
            this.tsbPointQuery,
            this.tsbRectQuery,
            this.sQLQuery,
            this.tsbtnQuerySetting});
            this.tsbDropdownbtn.Image = global::gmap.demo.winform.Properties.Resources.Select;
            this.tsbDropdownbtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDropdownbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDropdownbtn.Name = "tsbDropdownbtn";
            this.tsbDropdownbtn.Size = new System.Drawing.Size(61, 26);
            this.tsbDropdownbtn.Text = "查询";
            // 
            // tsbPolygonQuery
            // 
            this.tsbPolygonQuery.Image = global::gmap.demo.winform.Properties.Resources.btn_17_off;
            this.tsbPolygonQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbPolygonQuery.Name = "tsbPolygonQuery";
            this.tsbPolygonQuery.Size = new System.Drawing.Size(160, 28);
            this.tsbPolygonQuery.Text = "多边形查询";
            this.tsbPolygonQuery.Click += new System.EventHandler(this.tsbQueryByPolygon_Click);
            // 
            // tsbPointQuery
            // 
            this.tsbPointQuery.Image = global::gmap.demo.winform.Properties.Resources.btn_13_off;
            this.tsbPointQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbPointQuery.Name = "tsbPointQuery";
            this.tsbPointQuery.Size = new System.Drawing.Size(160, 28);
            this.tsbPointQuery.Text = "点选查询";
            this.tsbPointQuery.Click += new System.EventHandler(this.tsbPointQuery_Click);
            // 
            // tsbRectQuery
            // 
            this.tsbRectQuery.Image = global::gmap.demo.winform.Properties.Resources.btn_14_off;
            this.tsbRectQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbRectQuery.Name = "tsbRectQuery";
            this.tsbRectQuery.Size = new System.Drawing.Size(160, 28);
            this.tsbRectQuery.Text = "拉框查询";
            this.tsbRectQuery.Click += new System.EventHandler(this.tsbRectQuery_Click);
            // 
            // sQLQuery
            // 
            this.sQLQuery.Image = global::gmap.demo.winform.Properties.Resources.SQL_form;
            this.sQLQuery.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.sQLQuery.Name = "sQLQuery";
            this.sQLQuery.Size = new System.Drawing.Size(160, 28);
            this.sQLQuery.Text = "SQL查询";
            this.sQLQuery.Click += new System.EventHandler(this.sQLQuery_Click);
            // 
            // tsbtnQuerySetting
            // 
            this.tsbtnQuerySetting.Name = "tsbtnQuerySetting";
            this.tsbtnQuerySetting.Size = new System.Drawing.Size(160, 28);
            this.tsbtnQuerySetting.Text = "查询设置";
            // 
            // tsbtnClearhighlight
            // 
            this.tsbtnClearhighlight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnClearhighlight.Image = global::gmap.demo.winform.Properties.Resources.btn_11_off;
            this.tsbtnClearhighlight.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnClearhighlight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnClearhighlight.Name = "tsbtnClearhighlight";
            this.tsbtnClearhighlight.Size = new System.Drawing.Size(28, 26);
            this.tsbtnClearhighlight.Text = "清除高亮";
            this.tsbtnClearhighlight.Click += new System.EventHandler(this.tsbtnClearhighlight_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(958, 518);
            this.Controls.Add(this.panel4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DemoForm";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.xPanderPanelList1.ResumeLayout(false);
            this.xPanderPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private BSE.Windows.Forms.Panel panelMenu;
        private BSE.Windows.Forms.Splitter splitter1;
        private BSE.Windows.Forms.XPanderPanelList xPanderPanelList1;
        private BSE.Windows.Forms.XPanderPanel xPanderPanelMain;
        private BSE.Windows.Forms.XPanderPanel xPanderPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox attributeFilter;
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private MapControl mapControl1;
        private System.Windows.Forms.ToolStripButton tsbPan;
        private System.Windows.Forms.ToolStripButton tsbZoomIn;
        private System.Windows.Forms.ToolStripButton tsbZoomOut;
        private System.Windows.Forms.ToolStripButton tsbMeasureArea;
        private System.Windows.Forms.ToolStripButton tsbMeasureDistance;
        private System.Windows.Forms.ComboBox cbnLayerNames;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripDropDownButton tsbDropdownbtn;
        private System.Windows.Forms.ToolStripMenuItem tsbPolygonQuery;
        private System.Windows.Forms.ToolStripMenuItem tsbPointQuery;
        private System.Windows.Forms.ToolStripMenuItem tsbRectQuery;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsbtnQuerySetting;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbtnClearhighlight;
        private System.Windows.Forms.ToolStripMenuItem sQLQuery;

    }
}

