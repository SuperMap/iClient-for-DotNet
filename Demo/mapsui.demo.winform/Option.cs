using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mapsui.demo.winform
{
    public partial class Option : Form
    {
        public Option()
        {
            InitializeComponent();
            
        }

        public string URL
        {
            get { return this.textBox1.Text; }
        }
    }
}
