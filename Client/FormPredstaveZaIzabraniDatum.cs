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
    public partial class FormPredstaveZaIzabraniDatum : Form
    {
        Jezici jezik;
        public FormPredstaveZaIzabraniDatum(Jezici jezik = Jezici.SRBL)
        {
            this.jezik = jezik;
            InitializeComponent();
            CenterToScreen();
        }

        private void dateTimePicker1_Validated(object sender, EventArgs e)
        {
            List<Predstava> predstave = Pomocna.Proxy.PredstaveZaIzabraniDatum(dateTimePicker1.Value);

            dataGridView1.DataSource = predstave.ToList();

            if (predstave.Count == 0)
            {
                switch (jezik)
                {
                    case Jezici.SRBL:
                        MessageBox.Show("Nema predstava zakazanih za taj datum!");
                        break;
                    case Jezici.SRBC:
                        MessageBox.Show("Нема представа заказаних за тај датум!");
                        break;
                    case Jezici.UK:
                        MessageBox.Show("There are no shows scheduled for this date!");
                        break;
                    default:
                        break;
                }
            }
        }

        private void FormPredstaveZaIzabraniDatum_Load(object sender, EventArgs e)
        {
            switch (jezik)
            {
                case Jezici.SRBL:
                    this.Text = "Predstave za izabrani datum";
                    label1.Text = "Datum održavanja:";
                    buttonPrikazi.Text = "Prikaži";
                    break;
                case Jezici.SRBC:
                    this.Text = "Представе за изабрани датум";
                    label1.Text = "Датум одржавања:";
                    buttonPrikazi.Text = "Прикажи";
                    break;
                case Jezici.UK:
                    this.Text = "Shows performed on selected date";
                    label1.Text = "Date:";
                    buttonPrikazi.Text = "Update grid";
                    break;
                default:
                    break;
            }
        }
    }
}
