using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace Client
{
    public partial class FormPredstaveGledaoca : Form
    {
        List<Gledalac> gledaoci = Pomocna.Proxy.SviGledaoci();
        Jezici jezik;
        public FormPredstaveGledaoca(Jezici jezik = Jezici.SRBL)
        {
            this.jezik = jezik;
            InitializeComponent();
            CenterToScreen();
            foreach(Gledalac g in gledaoci)
            {
                comboBox1.Items.Add(g.Id);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Predstava> predstave = Pomocna.Proxy.PredstaveGledaoca((int)comboBox1.SelectedItem);

            dataGridView1.DataSource = predstave.ToList();

            if(predstave.Count == 0)
            {
                switch (jezik)
                {
                    case Jezici.SRBL:
                        MessageBox.Show("Izabrani gledalac nema nijednu kartu!");
                        break;
                    case Jezici.SRBC:
                        MessageBox.Show("Изабрани гледалац нема ниједну карту!");
                        break;
                    case Jezici.UK:
                        MessageBox.Show("The selected user has no tickets!");
                        break;
                    default:
                        break;
                }
            }
        }

        private void FormPredstaveGledaoca_Load(object sender, EventArgs e)
        {
            switch (jezik)
            {
                case Jezici.SRBL:
                    this.Text = "Predstave gledaoca";
                    label1.Text = "ID gledaoca:";
                    break;
                case Jezici.SRBC:
                    this.Text = "Представе гледаоца";
                    label1.Text = "ИД гледаоца:"; 
                    break;
                case Jezici.UK:
                    this.Text = "User's shows";
                    label1.Text = "User ID:";
                    break;
                default:
                    break;
            }
        }
    }
}
