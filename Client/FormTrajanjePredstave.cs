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
    public partial class FormTrajanjePredstave : Form
    {
        char znak = '<';
        Jezici jezik;
        public FormTrajanjePredstave(Jezici jezik = Jezici.SRBL)
        {
            this.jezik = jezik;
            InitializeComponent();
            CenterToScreen();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(maskedTextBox1.Text))
                {
                    NadjiPredstave(int.Parse(maskedTextBox1.Text));
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
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
                MessageBox.Show("Neispravan unos trajanja!");
                return;
            }
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(maskedTextBox1.Text))
                {
                    NadjiPredstave(int.Parse(maskedTextBox1.Text));
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                switch (jezik)
                {
                    case Jezici.SRBL:
                        MessageBox.Show("Neispravan unos trajanja!");
                        break;
                    case Jezici.SRBC:
                        MessageBox.Show("Неисправан унос трајања!");
                        break;
                    case Jezici.UK:
                        MessageBox.Show("The duration you entered is not correct!");
                        break;
                    default:
                        break;
                }
                return;
            }
        }

        private void NadjiPredstave(int trajanje)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                znak = '<';
            }
            else
            {
                znak = '>';
            }

            List<Predstava> predstave = Pomocna.Proxy.PredstavePoTrajanju(trajanje, znak);

            dataGridView1.DataSource = predstave.ToList();

            if (predstave.Count == 0)
            {
                switch (jezik)
                {
                    case Jezici.SRBL:
                        MessageBox.Show("Nema predstava koje ispunjavaju zadati uslov!");
                        break;
                    case Jezici.SRBC:
                        MessageBox.Show("Нема представа које испуњавају задати услов!");
                        break;
                    case Jezici.UK:
                        MessageBox.Show("There are no shows that satisfy the given condition!");
                        break;
                    default:
                        break;
                }
            }
        }

        private void FormTrajanjePredstave_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            List<string> elementi = new List<string>();

            switch (jezik)
            {
                case Jezici.SRBL:
                    this.Text = "Predstave po trajanju";
                    label1.Text = "Predstave koje traju";
                    label2.Text = "od";
                    elementi.Add("manje");
                    elementi.Add("više");
                    buttonPrikazi.Text = "Prikaži";
                    break;
                case Jezici.SRBC:
                    this.Text = "Представе по трајању";
                    label1.Text = "Представе које трају";
                    label2.Text = "од";
                    label1.Left = 0;
                    label3.Text = "мин.";
                    elementi.Add("мање");
                    elementi.Add("више");
                    buttonPrikazi.Text = "Прикажи";
                    break;
                case Jezici.UK:
                    this.Text = "Shows by duration";
                    label1.Text = "The shows that last";
                    label2.Text = "than";
                    comboBox1.Width = 82;
                    elementi.Add("shorter");
                    elementi.Add("longer");
                    buttonPrikazi.Text = "Update grid";
                    break;
                default:
                    break;
            }

            comboBox1.DataSource = elementi.ToList();
        }
    }
}
