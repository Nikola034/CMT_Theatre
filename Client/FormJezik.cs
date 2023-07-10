using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class FormJezik : Form
    {
        public FormJezik(Jezici jezik = Jezici.SRBC)
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void FormJezik_Load(object sender, EventArgs e)
        {
            this.Text = String.Empty;
            this.ControlBox = false;
        }

        public Jezici Jezik { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            switch (btn.Name)
            {
                case "button1":
                    Jezik = Jezici.SRBC;
                    break;
                case "button2":
                    Jezik = Jezici.SRBL;
                    break;
                case "button3":
                    Jezik = Jezici.UK;
                    break;
            }

            this.Close();
        }
    }
}
