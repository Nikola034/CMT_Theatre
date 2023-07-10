
namespace Client
{
    partial class FormDodajIzmeniKartu
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxDatumOdrzavanja = new System.Windows.Forms.ComboBox();
            this.buttonPotvrdi = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxIDGledaoca = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxIDScene = new System.Windows.Forms.ComboBox();
            this.comboBoxIDPredstave = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxBrojSedista = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.35897F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.64103F));
            this.tableLayoutPanel1.Controls.Add(this.comboBoxDatumOdrzavanja, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonPotvrdi, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxIDGledaoca, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxIDScene, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxIDPredstave, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxBrojSedista, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(390, 289);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // comboBoxDatumOdrzavanja
            // 
            this.comboBoxDatumOdrzavanja.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxDatumOdrzavanja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDatumOdrzavanja.FormattingEnabled = true;
            this.comboBoxDatumOdrzavanja.Location = new System.Drawing.Point(175, 205);
            this.comboBoxDatumOdrzavanja.Name = "comboBoxDatumOdrzavanja";
            this.comboBoxDatumOdrzavanja.Size = new System.Drawing.Size(147, 21);
            this.comboBoxDatumOdrzavanja.TabIndex = 30;
            // 
            // buttonPotvrdi
            // 
            this.buttonPotvrdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.buttonPotvrdi.Location = new System.Drawing.Point(175, 243);
            this.buttonPotvrdi.Name = "buttonPotvrdi";
            this.buttonPotvrdi.Size = new System.Drawing.Size(96, 30);
            this.buttonPotvrdi.TabIndex = 21;
            this.buttonPotvrdi.Text = "Potvrdi";
            this.buttonPotvrdi.UseVisualStyleBackColor = true;
            this.buttonPotvrdi.Click += new System.EventHandler(this.buttonPotvrdi_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label5.Location = new System.Drawing.Point(11, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 20);
            this.label5.TabIndex = 25;
            this.label5.Text = "Datum održavanja:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label4.Location = new System.Drawing.Point(34, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 20);
            this.label4.TabIndex = 24;
            this.label4.Text = "ID gledaoca:";
            // 
            // comboBoxIDGledaoca
            // 
            this.comboBoxIDGledaoca.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxIDGledaoca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIDGledaoca.FormattingEnabled = true;
            this.comboBoxIDGledaoca.Location = new System.Drawing.Point(175, 157);
            this.comboBoxIDGledaoca.Name = "comboBoxIDGledaoca";
            this.comboBoxIDGledaoca.Size = new System.Drawing.Size(147, 21);
            this.comboBoxIDGledaoca.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label3.Location = new System.Drawing.Point(45, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "ID scene:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(34, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Broj sedišta:";
            // 
            // comboBoxIDScene
            // 
            this.comboBoxIDScene.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxIDScene.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIDScene.FormattingEnabled = true;
            this.comboBoxIDScene.Location = new System.Drawing.Point(175, 109);
            this.comboBoxIDScene.Name = "comboBoxIDScene";
            this.comboBoxIDScene.Size = new System.Drawing.Size(147, 21);
            this.comboBoxIDScene.TabIndex = 28;
            this.comboBoxIDScene.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // comboBoxIDPredstave
            // 
            this.comboBoxIDPredstave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxIDPredstave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIDPredstave.FormattingEnabled = true;
            this.comboBoxIDPredstave.Location = new System.Drawing.Point(175, 61);
            this.comboBoxIDPredstave.Name = "comboBoxIDPredstave";
            this.comboBoxIDPredstave.Size = new System.Drawing.Size(147, 21);
            this.comboBoxIDPredstave.TabIndex = 27;
            this.comboBoxIDPredstave.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.Location = new System.Drawing.Point(31, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "ID predstave:";
            // 
            // comboBoxBrojSedista
            // 
            this.comboBoxBrojSedista.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxBrojSedista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBrojSedista.FormattingEnabled = true;
            this.comboBoxBrojSedista.Location = new System.Drawing.Point(175, 13);
            this.comboBoxBrojSedista.Name = "comboBoxBrojSedista";
            this.comboBoxBrojSedista.Size = new System.Drawing.Size(147, 21);
            this.comboBoxBrojSedista.TabIndex = 31;
            // 
            // FormDodajIzmeniKartu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 289);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormDodajIzmeniKartu";
            this.Text = "FormDodajKartu";
            this.Load += new System.EventHandler(this.FormDodajIzmeniKartu_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonPotvrdi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxIDGledaoca;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxIDScene;
        private System.Windows.Forms.ComboBox comboBoxIDPredstave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxDatumOdrzavanja;
        private System.Windows.Forms.ComboBox comboBoxBrojSedista;
    }
}