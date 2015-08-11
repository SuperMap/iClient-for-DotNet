using SuperMap.Connector.Control.Forms;
using SuperMap.Connector.Control.Utility;
namespace demo.winform
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
            this.mapControl1 = new SuperMap.Connector.Control.Forms.MapControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSelect = new System.Windows.Forms.ToolStripButton();
            this.tsbPan = new System.Windows.Forms.ToolStripButton();
            this.tsbZoomIn = new System.Windows.Forms.ToolStripButton();
            this.tsbZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbMeasureDistance = new System.Windows.Forms.ToolStripButton();
            this.tsbMeasureArea = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.LayerSet = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDropdownbtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbPolygonQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbPointQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbRectQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDropdownDel = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbmarkerDel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbRectDel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbpolygonDel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDropdownAdd = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbmarkerAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbLineAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbPolygonAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.Add = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnClearhighlight = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbnLayerNames = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.attributeFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataSet1 = new System.Data.DataSet();
            this.panel4.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(958, 518);
            this.panel4.TabIndex = 44;
            // 
            // mapControl1
            // 
            this.mapControl1.Center = ((SuperMap.Connector.Utility.Point2D)(resources.GetObject("mapControl1.Center")));
            this.mapControl1.CurrentAction = null;
            this.mapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapControl1.Location = new System.Drawing.Point(0, 29);
            this.mapControl1.MapLayer = null;
            this.mapControl1.MouseWheelZoomType = SuperMap.Connector.Control.Utility.MouseWheelZoomType.MousePositionAndCenter;
            this.mapControl1.Name = "mapControl1";
            this.mapControl1.Size = new System.Drawing.Size(958, 489);
            this.mapControl1.TabIndex = 0;
            this.mapControl1.Zoom = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOpen,
            this.toolStripSeparator1,
            this.tsbSelect,
            this.tsbPan,
            this.tsbZoomIn,
            this.tsbZoomOut,
            this.toolStripSeparator2,
            this.tsbMeasureDistance,
            this.tsbMeasureArea,
            this.toolStripSeparator3,
            this.LayerSet,
            this.toolStripSeparator7,
            this.tsbDropdownbtn,
            this.toolStripSeparator4,
            this.tsbDropdownDel,
            this.toolStripSeparator5,
            this.tsbDropdownAdd,
            this.toolStripSeparator6,
            this.tsbtnClearhighlight});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(958, 29);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 44;
            this.toolStrip1.Text = "toolStrip1";
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // tsbSelect
            // 
            this.tsbSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSelect.Image = global::demo.winform.Properties.Resources.Select;
            this.tsbSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSelect.Name = "tsbSelect";
            this.tsbSelect.Size = new System.Drawing.Size(23, 26);
            this.tsbSelect.Text = "选择";
            this.tsbSelect.Click += new System.EventHandler(this.tsbSelect_Click);
            // 
            // tsbPan
            // 
            this.tsbPan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPan.Image = global::demo.winform.Properties.Resources.btn_06_off;
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
            this.tsbZoomIn.Image = global::demo.winform.Properties.Resources.btn_02_off;
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
            this.tsbZoomOut.Image = global::demo.winform.Properties.Resources.btn_03_off;
            this.tsbZoomOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZoomOut.Name = "tsbZoomOut";
            this.tsbZoomOut.Size = new System.Drawing.Size(28, 26);
            this.tsbZoomOut.Text = "缩小";
            this.tsbZoomOut.Click += new System.EventHandler(this.tsbZoomOut_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 29);
            // 
            // tsbMeasureDistance
            // 
            this.tsbMeasureDistance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMeasureDistance.Image = global::demo.winform.Properties.Resources.btn_15_off;
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
            this.tsbMeasureArea.Image = global::demo.winform.Properties.Resources.btn_16_off;
            this.tsbMeasureArea.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbMeasureArea.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMeasureArea.Name = "tsbMeasureArea";
            this.tsbMeasureArea.Size = new System.Drawing.Size(28, 26);
            this.tsbMeasureArea.Text = "面积量算";
            this.tsbMeasureArea.Click += new System.EventHandler(this.tsbMeasureArea_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 29);
            // 
            // LayerSet
            // 
            this.LayerSet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LayerSet.Image = ((System.Drawing.Image)(resources.GetObject("LayerSet.Image")));
            this.LayerSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LayerSet.Name = "LayerSet";
            this.LayerSet.Size = new System.Drawing.Size(60, 26);
            this.LayerSet.Text = "图层设置";
            this.LayerSet.Click += new System.EventHandler(this.LayerSet_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 29);
            // 
            // tsbDropdownbtn
            // 
            this.tsbDropdownbtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPolygonQuery,
            this.tsbPointQuery,
            this.tsbRectQuery,
            this.sQLQuery});
            this.tsbDropdownbtn.Image = global::demo.winform.Properties.Resources.Select;
            this.tsbDropdownbtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDropdownbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDropdownbtn.Name = "tsbDropdownbtn";
            this.tsbDropdownbtn.Size = new System.Drawing.Size(61, 26);
            this.tsbDropdownbtn.Text = "查询";
            this.tsbDropdownbtn.ToolTipText = "查询地图中各图层包含的要素信息，查询方式分两种：\r\n1.SQL查询：通过设置参数及过滤条件，拼凑成SQL语句\r\n进行查询。结果以表格的形式呈现。\r\n2.地图上圈选" +
    "区域查询：在指定图层中查找地图上所选择\r\n区域包含的元素。\r\n提供点、矩形、多边形三种选择区域的方式。\r\n查询完成后，会将结果高亮显示在地图上。\r\n";
            // 
            // tsbPolygonQuery
            // 
            this.tsbPolygonQuery.Image = global::demo.winform.Properties.Resources.btn_17_off;
            this.tsbPolygonQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbPolygonQuery.Name = "tsbPolygonQuery";
            this.tsbPolygonQuery.Size = new System.Drawing.Size(144, 28);
            this.tsbPolygonQuery.Text = "多边形查询";
            this.tsbPolygonQuery.Click += new System.EventHandler(this.tsbPolygonQuery_Click);
            // 
            // tsbPointQuery
            // 
            this.tsbPointQuery.Image = global::demo.winform.Properties.Resources.btn_13_off;
            this.tsbPointQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbPointQuery.Name = "tsbPointQuery";
            this.tsbPointQuery.Size = new System.Drawing.Size(144, 28);
            this.tsbPointQuery.Text = "点选查询";
            this.tsbPointQuery.Click += new System.EventHandler(this.tsbPointQuery_Click);
            // 
            // tsbRectQuery
            // 
            this.tsbRectQuery.Image = global::demo.winform.Properties.Resources.btn_14_off;
            this.tsbRectQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbRectQuery.Name = "tsbRectQuery";
            this.tsbRectQuery.Size = new System.Drawing.Size(144, 28);
            this.tsbRectQuery.Text = "拉框查询";
            this.tsbRectQuery.Click += new System.EventHandler(this.tsbRectQuery_Click);
            // 
            // sQLQuery
            // 
            this.sQLQuery.Image = global::demo.winform.Properties.Resources.SQL_form;
            this.sQLQuery.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.sQLQuery.Name = "sQLQuery";
            this.sQLQuery.Size = new System.Drawing.Size(144, 28);
            this.sQLQuery.Text = "SQL查询";
            this.sQLQuery.Click += new System.EventHandler(this.sQLQuery_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 29);
            // 
            // tsbDropdownDel
            // 
            this.tsbDropdownDel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbmarkerDel,
            this.tsbRectDel,
            this.tsbpolygonDel});
            this.tsbDropdownDel.Image = global::demo.winform.Properties.Resources.btn_11_off;
            this.tsbDropdownDel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDropdownDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDropdownDel.Name = "tsbDropdownDel";
            this.tsbDropdownDel.Size = new System.Drawing.Size(93, 26);
            this.tsbDropdownDel.Text = "删除要素";
            this.tsbDropdownDel.ToolTipText = "删除指定图层的数据集上所选择区域包含的元素。\r\n提供点、矩形框、多边形三种方式选择区域。\r\n选择湾区域后，待删除的元素会高亮显示在地图上，\r\n按Del键删除这些元" +
    "素，或者重新选择取消当前查询结果。";
            // 
            // tsbmarkerDel
            // 
            this.tsbmarkerDel.Image = global::demo.winform.Properties.Resources.btn_13_off;
            this.tsbmarkerDel.Name = "tsbmarkerDel";
            this.tsbmarkerDel.Size = new System.Drawing.Size(160, 22);
            this.tsbmarkerDel.Text = "点选删除";
            this.tsbmarkerDel.Click += new System.EventHandler(this.tsbmarkerDel_Click);
            // 
            // tsbRectDel
            // 
            this.tsbRectDel.Image = global::demo.winform.Properties.Resources.btn_14_off;
            this.tsbRectDel.Name = "tsbRectDel";
            this.tsbRectDel.Size = new System.Drawing.Size(160, 22);
            this.tsbRectDel.Text = "拉框圈选删除";
            this.tsbRectDel.Click += new System.EventHandler(this.tsbRectDel_Click);
            // 
            // tsbpolygonDel
            // 
            this.tsbpolygonDel.Image = global::demo.winform.Properties.Resources.btn_17_off;
            this.tsbpolygonDel.Name = "tsbpolygonDel";
            this.tsbpolygonDel.Size = new System.Drawing.Size(160, 22);
            this.tsbpolygonDel.Text = "多边形圈选删除";
            this.tsbpolygonDel.Click += new System.EventHandler(this.tsbpolygonDel_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 29);
            // 
            // tsbDropdownAdd
            // 
            this.tsbDropdownAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbDropdownAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbmarkerAdd,
            this.tsbLineAdd,
            this.tsbPolygonAdd,
            this.Add});
            this.tsbDropdownAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbDropdownAdd.Image")));
            this.tsbDropdownAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDropdownAdd.Name = "tsbDropdownAdd";
            this.tsbDropdownAdd.Size = new System.Drawing.Size(69, 26);
            this.tsbDropdownAdd.Text = "添加要素";
            this.tsbDropdownAdd.ToolTipText = "向指定图层的数据集中加入手工绘制的集合图形。\r\n可添加点、折线、多边形三种几何图形。\r\n画完需要添加的点后，点击“确定添加”按钮，就能将\r\n几何图形添加到题图数据" +
    "集中。";
            // 
            // tsbmarkerAdd
            // 
            this.tsbmarkerAdd.Name = "tsbmarkerAdd";
            this.tsbmarkerAdd.Size = new System.Drawing.Size(136, 22);
            this.tsbmarkerAdd.Text = "添加点";
            this.tsbmarkerAdd.Click += new System.EventHandler(this.tsbmarkerAdd_Click);
            // 
            // tsbLineAdd
            // 
            this.tsbLineAdd.Name = "tsbLineAdd";
            this.tsbLineAdd.Size = new System.Drawing.Size(136, 22);
            this.tsbLineAdd.Text = "添加直线";
            this.tsbLineAdd.Click += new System.EventHandler(this.tsbLineAdd_Click);
            // 
            // tsbPolygonAdd
            // 
            this.tsbPolygonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbPolygonAdd.Name = "tsbPolygonAdd";
            this.tsbPolygonAdd.Size = new System.Drawing.Size(136, 22);
            this.tsbPolygonAdd.Text = "添加多边形";
            this.tsbPolygonAdd.Click += new System.EventHandler(this.tsbPolygonAdd_Click);
            // 
            // Add
            // 
            this.Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(136, 22);
            this.Add.Text = "确定添加";
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 29);
            // 
            // tsbtnClearhighlight
            // 
            this.tsbtnClearhighlight.Image = global::demo.winform.Properties.Resources.btn_11_off;
            this.tsbtnClearhighlight.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnClearhighlight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnClearhighlight.Name = "tsbtnClearhighlight";
            this.tsbtnClearhighlight.Size = new System.Drawing.Size(84, 26);
            this.tsbtnClearhighlight.Text = "清除高亮";
            this.tsbtnClearhighlight.Click += new System.EventHandler(this.tsbtnClearhighlight_Click);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(958, 518);
            this.Controls.Add(this.panel4);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DemoForm";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        //private BSE.Windows.Forms.Panel panelMenu;
        //private BSE.Windows.Forms.Splitter splitter1;
        //private BSE.Windows.Forms.XPanderPanelList xPanderPanelList1;
        //private BSE.Windows.Forms.XPanderPanel xPanderPanelMain;
        //private BSE.Windows.Forms.XPanderPanel xPanderPanel1;
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbtnClearhighlight;
        private System.Windows.Forms.ToolStripMenuItem sQLQuery;
        private System.Windows.Forms.ToolStripButton tsbSelect;
        private System.Windows.Forms.ToolStripDropDownButton tsbDropdownDel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tsbmarkerDel;
        private System.Windows.Forms.ToolStripMenuItem tsbRectDel;
        private System.Windows.Forms.ToolStripMenuItem tsbpolygonDel;
        private System.Windows.Forms.ToolStripDropDownButton tsbDropdownAdd;
        private System.Windows.Forms.ToolStripMenuItem tsbmarkerAdd;
        private System.Windows.Forms.ToolStripMenuItem tsbLineAdd;
        private System.Windows.Forms.ToolStripMenuItem tsbPolygonAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem Add;
        private System.Windows.Forms.ToolStripButton LayerSet;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;

    }
}

