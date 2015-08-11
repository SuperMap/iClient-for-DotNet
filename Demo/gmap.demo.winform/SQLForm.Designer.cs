namespace gmap.demo.winform
{
    partial class SQLForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SQLForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstFields = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.treeDataSet = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.rdoSpacicalAndAtrrribute = new System.Windows.Forms.RadioButton();
            this.rdoAttribute = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQueryField = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtQueryCondition = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtQuerySentence = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.sqlExpectCount = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lstFields);
            this.groupBox1.Controls.Add(this.treeDataSet);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lstFields
            // 
            this.lstFields.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstFields.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("lstFields.Groups"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("lstFields.Groups1")))});
            resources.ApplyResources(this.lstFields, "lstFields");
            this.lstFields.Name = "lstFields";
            this.lstFields.UseCompatibleStateImageBehavior = false;
            this.lstFields.View = System.Windows.Forms.View.Details;
            this.lstFields.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstFields_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // treeDataSet
            // 
            resources.ApplyResources(this.treeDataSet, "treeDataSet");
            this.treeDataSet.Name = "treeDataSet";
            this.treeDataSet.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeDataSet_NodeMouseClick);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // rdoSpacicalAndAtrrribute
            // 
            resources.ApplyResources(this.rdoSpacicalAndAtrrribute, "rdoSpacicalAndAtrrribute");
            this.rdoSpacicalAndAtrrribute.Checked = true;
            this.rdoSpacicalAndAtrrribute.Name = "rdoSpacicalAndAtrrribute";
            this.rdoSpacicalAndAtrrribute.TabStop = true;
            this.rdoSpacicalAndAtrrribute.UseVisualStyleBackColor = true;
            // 
            // rdoAttribute
            // 
            resources.ApplyResources(this.rdoAttribute, "rdoAttribute");
            this.rdoAttribute.Name = "rdoAttribute";
            this.rdoAttribute.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txtQueryField
            // 
            resources.ApplyResources(this.txtQueryField, "txtQueryField");
            this.txtQueryField.Name = "txtQueryField";
            this.txtQueryField.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtQueryField_MouseClick);
            this.txtQueryField.TextChanged += new System.EventHandler(this.txtQueryField_TextChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtQueryCondition
            // 
            resources.ApplyResources(this.txtQueryCondition, "txtQueryCondition");
            this.txtQueryCondition.Name = "txtQueryCondition";
            this.txtQueryCondition.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtQueryCondition_MouseClick);
            this.txtQueryCondition.TextChanged += new System.EventHandler(this.txtQueryCondition_TextChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // txtQuerySentence
            // 
            resources.ApplyResources(this.txtQuerySentence, "txtQuerySentence");
            this.txtQuerySentence.Name = "txtQuerySentence";
            // 
            // btnQuery
            // 
            resources.ApplyResources(this.btnQuery, "btnQuery");
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnClear
            // 
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.Name = "btnClear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // sqlExpectCount
            // 
            resources.ApplyResources(this.sqlExpectCount, "sqlExpectCount");
            this.sqlExpectCount.Name = "sqlExpectCount";
            // 
            // SQLForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sqlExpectCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.txtQuerySentence);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtQueryCondition);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtQueryField);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rdoAttribute);
            this.Controls.Add(this.rdoSpacicalAndAtrrribute);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SQLForm";
            this.Load += new System.EventHandler(this.SQLForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeDataSet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdoSpacicalAndAtrrribute;
        private System.Windows.Forms.RadioButton rdoAttribute;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQueryField;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtQueryCondition;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtQuerySentence;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView lstFields;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox sqlExpectCount;
    }
}