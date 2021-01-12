
namespace ExpanderTestApp
{
    partial class TestForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.outerSplitter = new System.Windows.Forms.SplitContainer();
            this.innerSplitter = new System.Windows.Forms.SplitContainer();
            this.btUpperRefresh = new System.Windows.Forms.Button();
            this.pgUpper = new System.Windows.Forms.PropertyGrid();
            this.upperExpander = new WindowsFormsExpander.Expander();
            this.btLowerRefresh = new System.Windows.Forms.Button();
            this.pgLower = new System.Windows.Forms.PropertyGrid();
            this.lowerExpander = new WindowsFormsExpander.Expander();
            ((System.ComponentModel.ISupportInitialize)(this.outerSplitter)).BeginInit();
            this.outerSplitter.Panel1.SuspendLayout();
            this.outerSplitter.Panel2.SuspendLayout();
            this.outerSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.innerSplitter)).BeginInit();
            this.innerSplitter.Panel1.SuspendLayout();
            this.innerSplitter.Panel2.SuspendLayout();
            this.innerSplitter.SuspendLayout();
            this.SuspendLayout();
            // 
            // outerSplitter
            // 
            this.outerSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outerSplitter.Location = new System.Drawing.Point(0, 0);
            this.outerSplitter.Name = "outerSplitter";
            // 
            // outerSplitter.Panel1
            // 
            this.outerSplitter.Panel1.Controls.Add(this.innerSplitter);
            // 
            // outerSplitter.Panel2
            // 
            this.outerSplitter.Panel2.Controls.Add(this.lowerExpander);
            this.outerSplitter.Panel2.Controls.Add(this.upperExpander);
            this.outerSplitter.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.outerSplitter.Size = new System.Drawing.Size(528, 413);
            this.outerSplitter.SplitterDistance = 221;
            this.outerSplitter.TabIndex = 0;
            // 
            // innerSplitter
            // 
            this.innerSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.innerSplitter.Location = new System.Drawing.Point(0, 0);
            this.innerSplitter.Name = "innerSplitter";
            this.innerSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // innerSplitter.Panel1
            // 
            this.innerSplitter.Panel1.Controls.Add(this.btUpperRefresh);
            this.innerSplitter.Panel1.Controls.Add(this.pgUpper);
            // 
            // innerSplitter.Panel2
            // 
            this.innerSplitter.Panel2.Controls.Add(this.btLowerRefresh);
            this.innerSplitter.Panel2.Controls.Add(this.pgLower);
            this.innerSplitter.Size = new System.Drawing.Size(221, 413);
            this.innerSplitter.SplitterDistance = 213;
            this.innerSplitter.TabIndex = 0;
            // 
            // btUpperRefresh
            // 
            this.btUpperRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btUpperRefresh.Location = new System.Drawing.Point(3, 186);
            this.btUpperRefresh.Name = "btUpperRefresh";
            this.btUpperRefresh.Size = new System.Drawing.Size(75, 23);
            this.btUpperRefresh.TabIndex = 1;
            this.btUpperRefresh.Text = "Refresh";
            this.btUpperRefresh.UseVisualStyleBackColor = true;
            this.btUpperRefresh.Click += new System.EventHandler(this.btUpperRefresh_Click);
            // 
            // pgUpper
            // 
            this.pgUpper.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgUpper.Location = new System.Drawing.Point(3, 5);
            this.pgUpper.Name = "pgUpper";
            this.pgUpper.SelectedObject = this.upperExpander;
            this.pgUpper.Size = new System.Drawing.Size(215, 177);
            this.pgUpper.TabIndex = 0;
            // 
            // upperExpander
            // 
            this.upperExpander.Dock = System.Windows.Forms.DockStyle.Top;
            this.upperExpander.Location = new System.Drawing.Point(5, 5);
            this.upperExpander.Name = "upperExpander";
            this.upperExpander.Size = new System.Drawing.Size(293, 168);
            this.upperExpander.TabIndex = 0;
            this.upperExpander.Text = "Upper expander";
            // 
            // btLowerRefresh
            // 
            this.btLowerRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btLowerRefresh.Location = new System.Drawing.Point(3, 170);
            this.btLowerRefresh.Name = "btLowerRefresh";
            this.btLowerRefresh.Size = new System.Drawing.Size(75, 23);
            this.btLowerRefresh.TabIndex = 2;
            this.btLowerRefresh.Text = "Refresh";
            this.btLowerRefresh.UseVisualStyleBackColor = true;
            this.btLowerRefresh.Click += new System.EventHandler(this.btLowerRefresh_Click);
            // 
            // pgLower
            // 
            this.pgLower.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgLower.Location = new System.Drawing.Point(3, -2);
            this.pgLower.Name = "pgLower";
            this.pgLower.SelectedObject = this.lowerExpander;
            this.pgLower.Size = new System.Drawing.Size(215, 166);
            this.pgLower.TabIndex = 1;
            // 
            // lowerExpander
            // 
            this.lowerExpander.Dock = System.Windows.Forms.DockStyle.Top;
            this.lowerExpander.Location = new System.Drawing.Point(5, 173);
            this.lowerExpander.Name = "lowerExpander";
            this.lowerExpander.Size = new System.Drawing.Size(293, 177);
            this.lowerExpander.TabIndex = 1;
            this.lowerExpander.Text = "Lower expander";
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 413);
            this.Controls.Add(this.outerSplitter);
            this.Name = "TestForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expander control test form";
            this.outerSplitter.Panel1.ResumeLayout(false);
            this.outerSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.outerSplitter)).EndInit();
            this.outerSplitter.ResumeLayout(false);
            this.innerSplitter.Panel1.ResumeLayout(false);
            this.innerSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.innerSplitter)).EndInit();
            this.innerSplitter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer outerSplitter;
        private System.Windows.Forms.SplitContainer innerSplitter;
        private System.Windows.Forms.PropertyGrid pgUpper;
        private System.Windows.Forms.PropertyGrid pgLower;
        private WindowsFormsExpander.Expander upperExpander;
        private WindowsFormsExpander.Expander lowerExpander;
        private System.Windows.Forms.Button btUpperRefresh;
        private System.Windows.Forms.Button btLowerRefresh;
    }
}

