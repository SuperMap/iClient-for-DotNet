using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SuperMap.Connector.Utility;

namespace gmap.demo.winform
{
    public partial class PublicResultForm : Form
    {
        private List<QueryResult> m_listRecordSet;
        private QueryResult m_resultSet;
        private Recordset m_recordSet;
        private Feature m_record;
        private IMainForm imainForm;
        private MainForm m_mainForm;
        private TreeNode eNode;
        private Dictionary<string, MapImage> m_resultImage = new Dictionary<string, MapImage>();
        private ImageList imageList = new ImageList();

        public PublicResultForm(QueryResult resultSet, MainForm owner)
        {
            InitializeComponent();
            FormsConn fc = new FormsConn(resultSet);
            imainForm = (IMainForm)fc;
            m_mainForm = owner;
        }

        private void PublicResultForm_Load(object sender, EventArgs e)
        {
            ShowResultSet(imainForm.resultSet());
            ShowNodeMessage(0);
            eNode = this.TreeFrame.Nodes[0];
        }

        private void TreeFrame_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            eNode = e.Node;
            ShowNodeMessage(e.Node.Index);
        }

        /// <summary>
        /// 显示结果信息
        /// </summary>
        /// <param name="resultsetValue">数据信息</param>
        public void ShowResultSet(QueryResult resultsetValue)
        {
            m_listRecordSet = new List<QueryResult>();
            this.TreeFrame.ImageList = imageList;
            if (resultsetValue != null && resultsetValue.Recordsets != null && resultsetValue.Recordsets != null)
            {
                for (int i = 0; i < resultsetValue.Recordsets.Length; i++)
                {
                    this.TreeFrame.Nodes.Add(resultsetValue.Recordsets[i].DatasetName);
                    //this.TreeFrame.Nodes[i].ImageIndex = GetLayerTypeImage(ds.Type);
                    this.TreeFrame.Nodes[i].SelectedImageIndex = 0;
                    m_listRecordSet.Add(resultsetValue);
                }
            }
            this.Show();
        }

        private void TreeFrame_KeyUp(object sender, KeyEventArgs e)
        {
            //TreeNode eNode = TreeFrame.SelectedNode;
            eNode = TreeFrame.SelectedNode;
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.Right:
                case Keys.Up:
                case Keys.Down:
                    if (eNode != null)
                    {
                        ShowNodeMessage(eNode.Index);
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// DataFrame上鼠标点击操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void DataFrame_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int index = this.DataFrame.SelectedRows[0].Index;
                string layerName;
                layerName = eNode.Text;
                ShowSelectedRecord(layerName, index);
            }
            catch
            {
                return;
            }
        }

        #region 自定义接口
        private interface IMainForm
        {
            QueryResult resultSet();
        }

        private class FormsConn : IMainForm
        {
            QueryResult resultSet;
            public FormsConn(QueryResult rs)
            {
                resultSet = rs;
            }
            QueryResult IMainForm.resultSet()
            {
                return resultSet;
            }
        }
        #endregion 自定义接口

        #region 自定义方法

        /// <summary>
        /// 显示子信息
        /// </summary>
        /// <param name="strNodeTag">子标示</param>
        /// <param name="index">索引号</param>
        /// <param name="parantIndex">父索引号</param>
        /// <param name="layerName">数据集名称</param>
        private void ShowNodeMessage(int index)
        {
            this.TreeFrame.SelectedNode = this.TreeFrame.Nodes[index];
            m_recordSet = new Recordset();
            m_resultSet = new QueryResult();
            m_resultSet = m_listRecordSet[index];
            if (m_resultSet != null && m_resultSet.Recordsets != null)
            {
                if (m_resultSet.Recordsets != null)
                {
                    m_recordSet = m_resultSet.Recordsets[index];
                    DataFrame.DataSource = m_recordSet.ToDataTable();
                    DataFrame.AllowUserToAddRows = false;
                    DataFrame.ClearSelection();
                }
            }
        }

        /// <summary>
        /// 显示所选记录
        /// </summary>
        /// <param name="layerName">数据集名称</param>
        /// <param name="index">结果集索引</param>
        private void ShowSelectedRecord(string layerName, int index)
        {
            ////DataFrame.Rows[index].Selected = true;
            ////当选择某条记录时，将其居中显示
            //m_record = m_recordSet.Features[index];
            ////关键字使用数据集名+SmID号使其保证唯一
            //string strkey = layerName + "-" + m_record.FieldValues[0];
            //if (!m_resultImage.ContainsKey(strkey))
            //{
            //    QueryParam queryParam = new QueryParam();
            //    QueryLayer queryLayer = new QueryLayer();
            //    queryLayer.Name = layerName;
            //    queryLayer.WhereClause = "SmID=" + m_record.FieldValues[0];
            //    queryParam.Layers = new QueryLayer[1];
            //    queryParam.Layers[0] = queryLayer;
            //    queryParam.Highlight.HighlightResult = true;
            //    m_webLibInWinForm.m_map.QueryBySql(queryParam);
            //    m_webLibInWinForm.m_image = m_webLibInWinForm.m_map.ViewByScale(m_record.Center, m_webLibInWinForm.m_image.ReturnMapParam.MapScale);
            //    m_resultImage[strkey] = m_webLibInWinForm.m_image;
            //}
            //m_webLibInWinForm.RefreshStatus(m_resultImage[strkey]);
        }

        #endregion 自定义方法

    }

}
