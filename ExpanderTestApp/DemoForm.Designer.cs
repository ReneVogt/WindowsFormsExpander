
namespace ExpanderTestApp
{
    partial class DemoForm
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
            this.expander2 = new WindowsFormsExpander.Expander();
            this.propertyGrid2 = new System.Windows.Forms.PropertyGrid();
            this.expander1 = new WindowsFormsExpander.Expander();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.expander2.SuspendLayout();
            this.expander1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // expander2
            // 
            this.expander2.Controls.Add(this.propertyGrid2);
            this.expander2.Dock = System.Windows.Forms.DockStyle.Top;
            this.expander2.ExpandedHeight = 113;
            this.expander2.Location = new System.Drawing.Point(3, 116);
            this.expander2.Margin = new System.Windows.Forms.Padding(0);
            this.expander2.Name = "expander2";
            this.expander2.Padding = new System.Windows.Forms.Padding(0);
            this.expander2.Size = new System.Drawing.Size(270, 113);
            this.expander2.TabIndex = 1;
            this.expander2.Text = "Address";
            // 
            // propertyGrid2
            // 
            this.propertyGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid2.HelpVisible = false;
            this.propertyGrid2.Location = new System.Drawing.Point(0, 24);
            this.propertyGrid2.Name = "propertyGrid2";
            this.propertyGrid2.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propertyGrid2.Size = new System.Drawing.Size(270, 89);
            this.propertyGrid2.TabIndex = 1;
            this.propertyGrid2.ToolbarVisible = false;
            // 
            // expander1
            // 
            this.expander1.Controls.Add(this.propertyGrid1);
            this.expander1.Dock = System.Windows.Forms.DockStyle.Top;
            this.expander1.ExpandedHeight = 100;
            this.expander1.Location = new System.Drawing.Point(3, 16);
            this.expander1.Margin = new System.Windows.Forms.Padding(0);
            this.expander1.Name = "expander1";
            this.expander1.Padding = new System.Windows.Forms.Padding(0);
            this.expander1.Size = new System.Drawing.Size(270, 100);
            this.expander1.TabIndex = 0;
            this.expander1.Text = "Person";
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.HelpVisible = false;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 24);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propertyGrid1.Size = new System.Drawing.Size(270, 76);
            this.propertyGrid1.TabIndex = 0;
            this.propertyGrid1.ToolbarVisible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.expander2);
            this.groupBox1.Controls.Add(this.expander1);
            this.groupBox1.Location = new System.Drawing.Point(54, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 253);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Personal information";
            // 
            // DemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(384, 339);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 0);
            this.Name = "DemoForm";
            this.ShowIcon = false;
            this.Text = "DemoForm";
            this.expander2.ResumeLayout(false);
            this.expander1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WindowsFormsExpander.Expander expander1;
        private WindowsFormsExpander.Expander expander2;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.PropertyGrid propertyGrid2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}