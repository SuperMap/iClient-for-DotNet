using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SuperMap.Connector.Utility;

namespace gmap.demo.winform
{
    public partial class QueryResultForm : Form
    {
        public QueryResultForm()
        {
            InitializeComponent();
        }

        private QueryResult _queryResult = null;
        public QueryResult QueryResult
        {
            get { return _queryResult; }
            set
            {
                this._queryResult = value;
                if (value != null && _queryResult.Recordsets.Length > 0 &&
                    _queryResult.Recordsets[0] != null)
                {
                    this.dataGridView1.DataSource = _queryResult.Recordsets[0].ToDataTable();
                    this.dataGridView1.AllowUserToAddRows = false;
                    this.dataGridView1.ClearSelection();
                }
            }
        }
    }
}
