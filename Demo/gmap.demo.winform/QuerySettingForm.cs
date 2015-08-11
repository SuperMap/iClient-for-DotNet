using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SuperMap.Connector;
using SuperMap.Connector.Utility;

namespace gmap.demo.winform
{
    public partial class QuerySettingForm : Form
    {
        private string _mapUrl = string.Empty;
        private string _mapName = string.Empty;
        public QuerySettingForm(string mapUrl, string mapName)
        {
            InitializeComponent();

            this._mapName = mapName;
            this._mapUrl = mapUrl;

            Map map = new Map(_mapUrl);
            MapParameter defaultMapParameter = map.GetDefaultMapParameter(mapName);
            InitLayer(defaultMapParameter);
        }

        private void InitLayer(MapParameter mapParameter)
        {
            this.clbLayers.Items.Clear();
            Map map = new Map(_mapUrl);
            if (mapParameter != null)
            {
                for (int i = 0; i < mapParameter.Layers.Count; i++)
                {
                    this.clbLayers.Items.Add(new LayerItem(mapParameter.Layers[i].Name, mapParameter.Layers[i].Caption));
                }
            }
        }

        class LayerItem
        {
            private string _name = string.Empty;
            private string _caption = string.Empty;
            public LayerItem(string name, string caption)
            {
                this._name = name;
                this._caption = caption;
            }

            public string Name
            {
                get { return this._name; }
            }

            public string Caption
            {
                get { return this._caption; }
            }

            public override string ToString()
            {
                return this.Name;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int exceptionCount = 20;
            try
            {
                int.TryParse(this.tbExceptionCount.Text, out exceptionCount);
            }
            catch { exceptionCount = 20; }
            finally
            {
                QuerySetting.ExceptionCount = exceptionCount;
            }

            if (this.radioButton1.Checked)
                QuerySetting.QueryOption = QueryOption.GEOMETRY;
            else if (this.radioButton2.Checked)
                QuerySetting.QueryOption = QueryOption.ATTRIBUTE;
            else if (this.radioButton3.Checked)
                QuerySetting.QueryOption = QueryOption.ATTRIBUTEANDGEOMETRY;
            else QuerySetting.QueryOption = QueryOption.ATTRIBUTEANDGEOMETRY;

            QuerySetting.LayerNames = new List<string>();
            // if(this.clbLayers.CheckedItems.Count==0)

            for (int i = 0; i < this.clbLayers.CheckedItems.Count; i++)
            {
                QuerySetting.LayerNames.Add((this.clbLayers.CheckedItems[i] as LayerItem).Name);
            }
        }

        private void cbnSelAll_CheckedChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < this.clbLayers.Items.Count; i++)
            {
                this.clbLayers.SetItemChecked(i, this.cbnSelAll.Checked);
            }

        }
    }
}
