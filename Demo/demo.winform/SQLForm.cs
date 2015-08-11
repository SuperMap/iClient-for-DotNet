using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SuperMap.Connector;
using SuperMap.Connector.Utility;
using SuperMap.Connector.Control.Forms;

namespace demo.winform
{
    public partial class SQLForm : Form
    {
        private MainForm m_mainForm;
        private Map _map = null;
        private string _mapUrl = string.Empty;
        private string _mapName = string.Empty;
        private MapParameter defaultMapParameter;
        private bool m_queryFieldFocus;//当txtQueryField获得焦点时为true
        private bool m_queryConditionFocus;//当txtQueryCondition获得焦点时为true
        private List<string> m_listField;  //查询字段数组
        private PublicResultForm publicResultForm = null;
        private MapControl _mapControl = null;

        public SQLForm(string mapUrl, string mapName, MapControl mapControl)
        {
            InitializeComponent();
            this._mapName = mapName;
            this._mapUrl = mapUrl;

            _map = new Map(_mapUrl);
            defaultMapParameter = _map.GetDefaultMapParameter(mapName);
            _mapControl = mapControl;
            publicResultForm = new PublicResultForm();
            publicResultForm.Name = "QueryBySql";
            publicResultForm.Text = "SQL查询结果";
            publicResultForm.MapControl = mapControl;
            InitializeSQL();

        }
        /// <summary>
        /// 初始化窗体
        /// </summary>
        private void InitializeSQL()
        {
            treeDataSet.Nodes.Clear();
            List<Layer> layers = null;
            if (defaultMapParameter != null)
            {
                layers = defaultMapParameter.Layers;
                treeDataSet.Nodes.Add(this._mapName);
                for (int i = 0; i < layers.Count; i++)
                {
                    //if(layers[i].Queryable){

                    treeDataSet.Nodes[0].Nodes.Add(layers[i].Name);
                    treeDataSet.Nodes[0].Nodes[i].Tag = "Field";

                    //}
                }
            }
            ////初始化时展开treeDataSet和lstFields
            treeDataSet.Nodes[0].Expand();
            lstFields.Items.Clear();
            lstFields.Columns[0].ListView.Items.Add("*");
            lstFields.Columns[0].ListView.Items[0].SubItems.Add("All");

            //m_dataSet = m_map.GetDatasetInfo(m_workspace.Datasources[0], m_workspace.Datasources[0].Datasets[0]);

            QueryParameterSet queryParameterSet = new QueryParameterSet();
            queryParameterSet.ExpectCount = 1;
            queryParameterSet.QueryOption = QueryOption.ATTRIBUTE;
            queryParameterSet.QueryParams = new QueryParameter[1];
            queryParameterSet.QueryParams[0] = new QueryParameter();
            queryParameterSet.QueryParams[0].Name = layers[0].Name;
            queryParameterSet.ReturnContent = true;
            QueryResult queryResult = _map.QueryBySQL(_mapName, queryParameterSet);
            for (int i = 0; i < queryResult.Recordsets[0].Fields.Length; i++)
            {

                lstFields.Columns[0].ListView.Items.Add(queryResult.Recordsets[0].Fields[i]);
                lstFields.Columns[0].ListView.Items[i + 1].SubItems.Add(queryResult.Recordsets[0].FieldTypes[i].ToString());
            }
            m_queryFieldFocus = true;
        }

        private void SQLForm_Load(object sender, EventArgs e)
        {
            InitializeSQL();
        }
        /// <summary>
        /// 选择查询字段
        /// </summary>
        private void treeDataSet_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            lstFields.Items.Clear();
            if ((string)e.Node.Tag == "Field")
            {
                lstFields.Items.Clear();
                lstFields.Columns[0].ListView.Items.Add("*");
                lstFields.Columns[0].ListView.Items[0].SubItems.Add("All");

                //m_dataSet = m_map.GetDatasetInfo(m_workspace.Datasources[0], m_workspace.Datasources[0].Datasets[0]);

                QueryParameterSet queryParameterSet = new QueryParameterSet();
                queryParameterSet.ExpectCount = 1;
                queryParameterSet.QueryOption = QueryOption.ATTRIBUTE;
                queryParameterSet.QueryParams = new QueryParameter[1];
                queryParameterSet.QueryParams[0] = new QueryParameter();
                queryParameterSet.QueryParams[0].Name = e.Node.Text;
                queryParameterSet.ReturnContent = true;
                QueryResult queryResult = _map.QueryBySQL(_mapName, queryParameterSet);
                if (queryResult != null && queryResult.Recordsets != null)
                {
                    for (int i = 0; i < queryResult.Recordsets[0].Fields.Length; i++)
                    {

                        lstFields.Columns[0].ListView.Items.Add(queryResult.Recordsets[0].Fields[i]);
                        lstFields.Columns[0].ListView.Items[i + 1].SubItems.Add(queryResult.Recordsets[0].FieldTypes[i].ToString());
                    }
                }
            }
            txtQuerySentence.Text = "Select * from " + e.Node.Text;

        }

        /// <summary>
        /// 选择需要查询的字段
        /// </summary>
        private void lstFields_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (m_queryFieldFocus)
            {
                if (e.IsSelected)
                {
                    if (string.IsNullOrEmpty(txtQueryField.Text))
                    {
                        txtQueryField.SelectedText = e.Item.Text;
                    }
                    else
                    {
                        txtQueryField.SelectedText = "," + e.Item.Text;
                    }
                }
            }
            else if (m_queryConditionFocus)
            {
                if (e.IsSelected)
                {
                    txtQueryCondition.SelectedText = e.Item.Text;
                }
            }

        }

        /// <summary>
        /// 清除查询语句
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtQueryCondition.Text = string.Empty;
            txtQueryField.Text = string.Empty;
            txtQuerySentence.Text = string.Empty;
            m_listField = null;
        }

        /// <summary>
        /// 关闭窗体，取消操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtQueryField_MouseClick(object sender, MouseEventArgs e)
        {
            m_queryFieldFocus = true;
            m_queryConditionFocus = false;
        }

        private void txtQueryCondition_MouseClick(object sender, MouseEventArgs e)
        {
            m_queryConditionFocus = true;
            m_queryFieldFocus = false;
        }

        ///<summary>
        ///将需要查询的字段添加到 list数组中
        ///</summary>
        private List<string> QueryFieldsCount(List<string> list)
        {
            bool isAll = false;
            list = new List<string>();
            if (txtQueryField.Text.Equals("")) return null;
            string[] fieldstrings = txtQueryField.Text.Split(',');//根据","判别需查询的字段数，并加入数组
            foreach (string fields in fieldstrings)
            {

                if (fields == "*")
                {
                    isAll = true; //查询字段里有"*"将查询所有的属性字段
                }
            }
            if (isAll)
            {
                return null;
            }
            else
            {
                for (int i = 0; i < fieldstrings.Length; i++)
                {
                    list.Add(fieldstrings[i]);
                }
            }
            return list;
        }

        /// <summary>
        /// 进行SQL查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {

            try
            {
                m_listField = QueryFieldsCount(m_listField);

                QueryParameterSet queryParameterSet = new QueryParameterSet();
                if (rdoAttribute.Checked)
                {
                    queryParameterSet.QueryOption = QueryOption.ATTRIBUTE;
                }
                else
                {
                    queryParameterSet.QueryOption = QueryOption.ATTRIBUTEANDGEOMETRY;
                }
                queryParameterSet.QueryParams = new QueryParameter[1];
                queryParameterSet.QueryParams[0] = new QueryParameter();
                queryParameterSet.QueryParams[0].Name = treeDataSet.SelectedNode.Text;
                if (m_listField != null)
                    queryParameterSet.QueryParams[0].Fields = m_listField.ToArray();
                queryParameterSet.QueryParams[0].AttributeFilter = txtQueryCondition.Text;
                queryParameterSet.ReturnContent = true;

                queryParameterSet.ExpectCount = Convert.ToInt32(sqlExpectCount.Text);

                QueryResult m_resultSet = _map.QueryBySQL(_mapName, queryParameterSet);

                if (m_resultSet.Recordsets == null)//查询结果为空时提示
                {
                    MessageBox.Show("结果为空", "警告", MessageBoxButtons.OK);
                }
                else
                {
                    //if (publicResultForm != null)
                    //    publicResultForm.Close();
                    publicResultForm.QueryResult = m_resultSet;
                    publicResultForm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 当条件语句改变时，查询语句动态改变
        /// </summary>
        private void txtQueryCondition_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtQueryCondition.Text))
            {
                txtQuerySentence.Text = "Select " + txtQueryField.Text + " from " + treeDataSet.SelectedNode.Text;
            }
            else
            {
                txtQuerySentence.Text = "Select " + txtQueryField.Text + " from " + treeDataSet.SelectedNode.Text + " where " + txtQueryCondition.Text;
            }
        }

        /// <summary>
        /// 当查询字段改变时，查询语句动态改变
        /// </summary>
        private void txtQueryField_TextChanged(object sender, EventArgs e)
        {
            //默认全字段查询
            if (string.IsNullOrEmpty((txtQueryField.Text.Trim())))
            {
                txtQuerySentence.Text = "Select * from " + treeDataSet.SelectedNode.Text;
            }
            else
            {
                txtQuerySentence.Text = "Select " + txtQueryField.Text + " from " + treeDataSet.SelectedNode.Text;
            }
        }

    }
}
