using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SuperMap.Connector.Utility;
using SuperMap.Connector.Control.Forms;

namespace demo.winform
{
    public partial class PublicResultForm : Form
    {
        private GraphicsLayer _graphicsLayer = null; //= new GraphicsLayer("high", "high");
        public PublicResultForm()
        {
            InitializeComponent();
        }

        private MapControl _mapControl = null;
        public MapControl MapControl
        {
            set
            {
                this._mapControl = value;
                _graphicsLayer = new GraphicsLayer(this.Name, this.Name);
                this._mapControl.GraphicsLayers.Add(_graphicsLayer);
            }
        }

        private QueryResult _queryResult = null;
        public QueryResult QueryResult
        {
            set
            {
                _queryResult = value;
                this.TreeFrame.Nodes.Clear();
                if (this._queryResult != null)
                {
                    for (int i = 0; i < this._queryResult.Recordsets.Length; i++)
                    {
                        Recordset rs = this._queryResult.Recordsets[i];
                        TreeNode node = new TreeNode(rs.DatasetName);
                        this.TreeFrame.Nodes.Add(node);
                        node.Tag = rs;
                    }
                    _graphicsLayer.Markers.Clear();
                    _graphicsLayer.Polygons.Clear();
                    _graphicsLayer.Lines.Clear();
                    this.dataGridView1.Columns.Clear();
                    this.dataGridView1.Rows.Clear();
                    if (this.TreeFrame.Nodes.Count > 0)
                    {
                        ShowDataTable(this._queryResult.Recordsets[0]);
                    }
                }
            }
        }

        public PublicResultForm(QueryResult resultSet, MainForm owner)
        {
            InitializeComponent();
        }

        private void PublicResultForm_Load(object sender, EventArgs e)
        {

        }

        private void TreeFrame_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Recordset rs = e.Node.Tag as Recordset;
            ShowDataTable(rs);
        }

        public void ShowDataTable(Recordset rs)
        {
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Columns.Clear();

            for (int i = 0; i < rs.Fields.Length; i++)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.Name = rs.FieldCaptions[i];
                dataGridView1.Columns.Add(column);
            }
            this.dataGridView1.Rows.Clear();
            for (int i = 0; i < rs.Features.Length; i++)
            {
                int index = this.dataGridView1.Rows.Add(rs.Features[i].FieldValues);
                DataGridViewRow row = this.dataGridView1.Rows[index];
                row.Tag = rs.Features[i].Geometry;
            }
        }

        private void PublicResultForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_graphicsLayer == null) return;
            _graphicsLayer.Markers.Clear();
            _graphicsLayer.Polygons.Clear();
            _graphicsLayer.Lines.Clear();
            Geometry geometry = this.dataGridView1.Rows[e.RowIndex].Tag as Geometry;
            if (geometry != null)
            {
                switch (geometry.Type)
                {
                    case GeometryType.POINT:
                        Marker marker = new Marker(e.RowIndex.ToString(), new Point2D(geometry.Points[0].X, geometry.Points[0].Y),
                             MarkerType.Red_Dot, null);
                        _graphicsLayer.Markers.Add(marker);
                        break;
                    case GeometryType.LINE:
                        Line line = new Line(e.RowIndex.ToString(), new List<Point2D>(geometry.Points), 4.5, System.Drawing.Color.FromArgb(125, 0, 0, 255));
                        _graphicsLayer.Lines.Add(line);
                        break;
                    case GeometryType.REGION:
                        Polygon polygon = new Polygon(e.RowIndex.ToString(), new List<Point2D>(geometry.Points), System.Drawing.Color.FromArgb(125, 0, 255, 0), System.Drawing.Color.FromArgb(50, 0, 0, 255),
                            4.5);
                        _graphicsLayer.Polygons.Add(polygon);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
