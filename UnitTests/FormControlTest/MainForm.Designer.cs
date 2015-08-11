namespace FormMapControlTest
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mapControl1 = new SuperMap.Connector.Control.Forms.MapControl();
            this.btnTestGraphicsLayer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mapControl1
            // 
            this.mapControl1.Center = ((SuperMap.Connector.Utility.Point2D)(resources.GetObject("mapControl1.Center")));
            this.mapControl1.CurrentAction = null;
            this.mapControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.mapControl1.Location = new System.Drawing.Point(0, 0);
            this.mapControl1.MapLayer = null;
            this.mapControl1.MouseWheelZoomType = SuperMap.Connector.Control.Utility.MouseWheelZoomType.MousePositionAndCenter;
            this.mapControl1.Name = "mapControl1";
            this.mapControl1.Size = new System.Drawing.Size(524, 418);
            this.mapControl1.TabIndex = 0;
            this.mapControl1.Zoom = 0;
            // 
            // btnTestGraphicsLayer
            // 
            this.btnTestGraphicsLayer.Location = new System.Drawing.Point(530, 12);
            this.btnTestGraphicsLayer.Name = "btnTestGraphicsLayer";
            this.btnTestGraphicsLayer.Size = new System.Drawing.Size(75, 23);
            this.btnTestGraphicsLayer.TabIndex = 1;
            this.btnTestGraphicsLayer.Text = "增加Marker";
            this.btnTestGraphicsLayer.UseVisualStyleBackColor = true;
            this.btnTestGraphicsLayer.Click += new System.EventHandler(this.btnTestGraphicsLayer_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 418);
            this.Controls.Add(this.btnTestGraphicsLayer);
            this.Controls.Add(this.mapControl1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SuperMap.Connector.Control.Forms.MapControl mapControl1;
        private System.Windows.Forms.Button btnTestGraphicsLayer;
    }
}