
namespace Client
{
    partial class FormPomoc
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labelPomoc = new System.Windows.Forms.Label();
            this.richTextBoxPomoc = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.splitContainer1.Panel1.Controls.Add(this.labelPomoc);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBoxPomoc);
            this.splitContainer1.Size = new System.Drawing.Size(841, 563);
            this.splitContainer1.SplitterDistance = 73;
            this.splitContainer1.TabIndex = 2;
            // 
            // labelPomoc
            // 
            this.labelPomoc.AutoSize = true;
            this.labelPomoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.labelPomoc.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelPomoc.Location = new System.Drawing.Point(380, 24);
            this.labelPomoc.Name = "labelPomoc";
            this.labelPomoc.Size = new System.Drawing.Size(70, 24);
            this.labelPomoc.TabIndex = 0;
            this.labelPomoc.Text = "Pomoć";
            // 
            // richTextBoxPomoc
            // 
            this.richTextBoxPomoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(61)))), ((int)(((byte)(79)))));
            this.richTextBoxPomoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxPomoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.richTextBoxPomoc.ForeColor = System.Drawing.Color.Gainsboro;
            this.richTextBoxPomoc.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxPomoc.Name = "richTextBoxPomoc";
            this.richTextBoxPomoc.Size = new System.Drawing.Size(841, 486);
            this.richTextBoxPomoc.TabIndex = 0;
            this.richTextBoxPomoc.Text = "";
            // 
            // FormPomoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 563);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormPomoc";
            this.Text = "Pomoć";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label labelPomoc;
        private System.Windows.Forms.RichTextBox richTextBoxPomoc;
    }
}