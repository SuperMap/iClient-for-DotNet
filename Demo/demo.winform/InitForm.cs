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

namespace demo.winform
{
    public partial class InitForm : Form
    {
        public InitForm()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                Map map = new Map(this.tbUrl.Text);
                List<string> mapNames = map.GetMapNames();
                if (mapNames != null && mapNames.Count > 0)
                {
                    this.cbnMapNames.Items.Clear();
                    foreach(string mapName in mapNames)
                    {
                        this.cbnMapNames.Items.Add(mapName);
                    }
                    this.cbnMapNames.SelectedIndex = 0;
                    this.btnOk.Enabled = true;
                }
            }
            catch (ArgumentNullException argumengNullException)
            {
                MessageBox.Show(argumengNullException.Message);
            }
            catch (ServiceException serviceException)
            {
                MessageBox.Show(serviceException.Message);
            }
        }

        public string SelectedMapName
        {
            get
            {
                return this.cbnMapNames.Text;
            }
        }

        public string MapUrl
        {
            get
            {
                return this.tbUrl.Text;
            }
        }

        private void tbUrl_TextChanged(object sender, EventArgs e)
        {
            this.btnOk.Enabled = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }
    }
}
