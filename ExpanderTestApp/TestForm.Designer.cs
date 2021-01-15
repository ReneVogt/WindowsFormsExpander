
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
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.expander = new WindowsFormsExpander.Expander();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.outerSplitter)).BeginInit();
            this.outerSplitter.Panel1.SuspendLayout();
            this.outerSplitter.Panel2.SuspendLayout();
            this.outerSplitter.SuspendLayout();
            this.expander.SuspendLayout();
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
            this.outerSplitter.Panel1.Controls.Add(this.propertyGrid);
            // 
            // outerSplitter.Panel2
            // 
            this.outerSplitter.Panel2.Controls.Add(this.expander);
            this.outerSplitter.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.outerSplitter.Size = new System.Drawing.Size(528, 633);
            this.outerSplitter.SplitterDistance = 221;
            this.outerSplitter.TabIndex = 0;
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(221, 633);
            this.propertyGrid.TabIndex = 0;
            // 
            // expander
            // 
            this.expander.Controls.Add(this.label1);
            this.expander.Controls.Add(this.button1);
            this.expander.ExpandedHeight = 227;
            this.expander.Location = new System.Drawing.Point(6, 32);
            this.expander.Name = "expander";
            this.expander.Size = new System.Drawing.Size(198, 227);
            this.expander.TabIndex = 0;
            this.expander.Text = "Expander";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(81, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 112);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 633);
            this.Controls.Add(this.outerSplitter);
            this.Name = "TestForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expander control test form";
            this.outerSplitter.Panel1.ResumeLayout(false);
            this.outerSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.outerSplitter)).EndInit();
            this.outerSplitter.ResumeLayout(false);
            this.expander.ResumeLayout(false);
            this.expander.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer outerSplitter;
        private WindowsFormsExpander.Expander expander;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}

