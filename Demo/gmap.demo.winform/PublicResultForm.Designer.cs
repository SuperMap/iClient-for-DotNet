namespace gmap.demo.winform
{
    partial class PublicResultForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PublicResultForm));
            this.DataFrame = new System.Windows.Forms.DataGridView();
            this.TreeFrame = new System.Windows.Forms.TreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.DataFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // DataFrame
            // 
            this.DataFrame.AllowDrop = true;
            this.DataFrame.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DataFrame.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DataFrame.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.DataFrame, "DataFrame");
            this.DataFrame.Name = "DataFrame";
            this.DataFrame.ReadOnly = true;
            this.DataFrame.RowTemplate.Height = 23;
            this.DataFrame.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DataFrame_MouseClick);
            // 
            // TreeFrame
            // 
            resources.ApplyResources(this.TreeFrame, "TreeFrame");
            this.TreeFrame.Name = "TreeFrame";
            this.TreeFrame.TabStop = false;
            this.TreeFrame.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TreeFrame_KeyUp);
            this.TreeFrame.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeFrame_NodeMouseClick);
            // 
            // splitter1
            // 
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // PublicResultForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.DataFrame);
            this.Controls.Add(this.TreeFrame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PublicResultForm";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.PublicResultForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataFrame)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView DataFrame;
        internal System.Windows.Forms.TreeView TreeFrame;
        private System.Windows.Forms.Splitter splitter1;

    }
}