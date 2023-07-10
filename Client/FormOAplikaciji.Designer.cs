
namespace Client
{
    partial class FormOAplikaciji
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
            this.labelOaplikaciji = new System.Windows.Forms.Label();
            this.richTextBoxOaplikaciji = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.splitContainer1.Panel1.Controls.Add(this.labelOaplikaciji);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBoxOaplikaciji);
            this.splitContainer1.Size = new System.Drawing.Size(670, 466);
            this.splitContainer1.SplitterDistance = 46;
            this.splitContainer1.TabIndex = 1;
            // 
            // labelOaplikaciji
            // 
            this.labelOaplikaciji.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelOaplikaciji.AutoSize = true;
            this.labelOaplikaciji.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOaplikaciji.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelOaplikaciji.Location = new System.Drawing.Point(248, 13);
            this.labelOaplikaciji.Name = "labelOaplikaciji";
            this.labelOaplikaciji.Size = new System.Drawing.Size(178, 25);
            this.labelOaplikaciji.TabIndex = 0;
            this.labelOaplikaciji.Text = "O autoru i aplikaciji";
            // 
            // richTextBoxOaplikaciji
            // 
            this.richTextBoxOaplikaciji.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(61)))), ((int)(((byte)(79)))));
            this.richTextBoxOaplikaciji.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxOaplikaciji.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.richTextBoxOaplikaciji.ForeColor = System.Drawing.Color.Gainsboro;
            this.richTextBoxOaplikaciji.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxOaplikaciji.Name = "richTextBoxOaplikaciji";
            this.richTextBoxOaplikaciji.ReadOnly = true;
            this.richTextBoxOaplikaciji.Size = new System.Drawing.Size(670, 416);
            this.richTextBoxOaplikaciji.TabIndex = 0;
            this.richTextBoxOaplikaciji.Text = "";
            // 
            // FormOAplikaciji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 466);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormOAplikaciji";
            this.Text = "O autoru i aplikaciji";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label labelOaplikaciji;
        private System.Windows.Forms.RichTextBox richTextBoxOaplikaciji;
    }
}