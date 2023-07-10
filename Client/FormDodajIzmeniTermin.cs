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
    public partial class FormDodajIzmeniTermin : Form
    {
        List<Termin> termini = Pomocna.Proxy.SviTermini();
        bool izmena = false;
        int index = -1;
        Jezici jezik;
        public FormDodajIzmeniTermin(bool izmena = false, int index = -1, Jezici jezik = Jezici.SRBL)
        {
            this.jezik = jezik;
            InitializeComponent();
            CenterToScreen();
            NapuniComboBoxove();
            this.izmena = izmena;
            this.index = index;
            if (izmena)
            {
                switch (jezik)
                {
                    case Jezici.SRBL:
                        this.Text = "Izmena termina";
                        break;
                    case Jezici.SRBC:
                        this.Text = "Измена термина";
                        break;
                    case Jezici.UK:
                        this.Text = "Edit appointment";
                        break;
                    default:
                        break;
                }
                PopuniZaIzmenu();
            }
            else
            {
                switch (jezik)
                {
                    case Jezici.SRBL:
                        this.Text = "Dodavanje termina";
                        break;
                    case Jezici.SRBC:
                        this.Text = "Додавање термина";
                        break;
                    case Jezici.UK:
                        this.Text = "Add appointment";
                        break;
                    default:
                        break;
                }
            }
            OdrediId();
        }

        public int IDPredstave
        {
            get;
            set;
        }

        public int IDScene
        {
            get;
            set;
        }

        public DateTime DatumOdrzavanja
        {
            get => dateTimePicker1.Value;
        }

        public TimeSpan Vreme_odrzavanja
        {
            get;
            set;
        }

        private void buttonPotvrdi_Click(object sender, EventArgs e)
        {
            try
            {
                OdrediId();
                int id_predstave = IDPredstave;
                int id_scene = IDScene;
                DateTime datumOdrzavanja = dateTimePicker1.Value;

                string vreme = maskedTextBoxVremeOdrzavanja.Text;

                if (vreme.Length < 5 || Char.IsWhiteSpace(vreme[0]) || Char.IsWhiteSpace(vreme[1]) ||
                    Char.IsWhiteSpace(vreme[3]) || Char.IsWhiteSpace(vreme[4]))
                {
                    switch (jezik)
                    {
                        case Jezici.SRBL:
                            MessageBox.Show("Vreme mora biti uneto u formatu HH:MM!");
                            break;
                        case Jezici.SRBC:
                            MessageBox.Show("Време мора бити унето у формату ЧЧ:ММ!");
                            break;
                        case Jezici.UK:
                            MessageBox.Show("The time must be entered in HH:MM format!");
                            break;
                        default:
                            break;
                    }
                    return;
                }
                else
                {
                    if(!TimeSpan.TryParse(maskedTextBoxVremeOdrzavanja.Text, out TimeSpan x))
                    {
                        switch (jezik)
                        {
                            case Jezici.SRBL:
                                MessageBox.Show("Vreme nije ispravno uneto!");
                                break;
                            case Jezici.SRBC:
                                MessageBox.Show("Време није исправно унето!");
                                break;
                            case Jezici.UK:
                                MessageBox.Show("The time you entered is not correct!"); 
                                break;
                            default:
                                break;
                        }
                        return;
                    }
                    else
                    {
                        Vreme_odrzavanja = x;
                    }
                }

                if (izmena)
                {
                    Termin izmena = new Termin(id_predstave, id_scene, datumOdrzavanja, 0, Vreme_odrzavanja);

                    if (DaLiPostojiTermin(izmena, index))
                    {
                        switch (jezik)
                        {
                            case Jezici.SRBL:
                                MessageBox.Show("Termin sa unetim podacima već postoji!");
                                break;
                            case Jezici.SRBC:
                                MessageBox.Show("Термин са унетим подацима већ постоји!");
                                break;
                            case Jezici.UK:
                                MessageBox.Show("The appointment with entered properties already exists!");
                                break;
                            default:
                                break;
                        }
                        return;
                    }

                    if (Pomocna.Proxy.IzmeniTermin(izmena, Pomocna.Proxy.SviTermini()[index]))
                    {
                        switch (jezik)
                        {
                            case Jezici.SRBL:
                                MessageBox.Show("Termin je uspešno izmenjen!");
                                break;
                            case Jezici.SRBC:
                                MessageBox.Show("Термин је успешно измењен!");
                                break;
                            case Jezici.UK:
                                MessageBox.Show("The appointment edited successfully!");
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        switch (jezik)
                        {
                            case Jezici.SRBL:
                                MessageBox.Show("Došlo je do greške pri izmeni termina!");
                                break;
                            case Jezici.SRBC:
                                MessageBox.Show("Дошло је до грешке при измени термина!");
                                break;
                            case Jezici.UK:
                                MessageBox.Show("An error occurred while editing the appointment!");
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    Termin novi = new Termin(id_predstave, id_scene, datumOdrzavanja, 0, Vreme_odrzavanja);

                    if (DaLiPostojiTermin(novi))
                    {
                        switch (jezik)
                        {
                            case Jezici.SRBL:
                                MessageBox.Show("Termin sa unetim podacima već postoji!");
                                break;
                            case Jezici.SRBC:
                                MessageBox.Show("Термин са унетим подацима већ постоји!");
                                break;
                            case Jezici.UK:
                                MessageBox.Show("The appointment with entered properties already exists!");
                                break;
                            default:
                                break;
                        }
                        return;
                    }

                    termini.Add(novi);

                    if (Pomocna.Proxy.DodajTermin(novi))
                    {
                        switch (jezik)
                        {
                            case Jezici.SRBL:
                                MessageBox.Show("Termin je uspešno dodat!");
                                break;
                            case Jezici.SRBC:
                                MessageBox.Show("Термин је успешно додат!");
                                break;
                            case Jezici.UK:
                                MessageBox.Show("The appointment added successfully!");
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        switch (jezik)
                        {
                            case Jezici.SRBL:
                                MessageBox.Show("Došlo je do greške pri dodavanju termina!");
                                break;
                            case Jezici.SRBC:
                                MessageBox.Show("Дошло је до грешке при додавању термина!");
                                break;
                            case Jezici.UK:
                                MessageBox.Show("An error occurred while adding the appointment!");
                                break;
                            default:
                                break;
                        }
                    }
                }
                Clear();
                this.Close();
            }
            catch (Exception ex)
            {
                switch (jezik)
                {
                    case Jezici.SRBL:
                        MessageBox.Show("Neispravan unos!");
                        break;
                    case Jezici.SRBC:
                        MessageBox.Show("Неисправан унос!");
                        break;
                    case Jezici.UK:
                        MessageBox.Show("Incorrect input!");
                        break;
                    default:
                        break;
                }
            }
        }

        private void NapuniComboBoxove()
        {
            foreach(Predstava p in Pomocna.Proxy.SvePredstave())
            {
                comboBoxIDPredstave.Items.Add(p.Id + " - " + p.Naziv);
            }
            foreach(Scena s in Pomocna.Proxy.SveScene())
            {
                comboBoxIDScene.Items.Add(s.Id + " - " + s.Naziv);
            }

            comboBoxIDPredstave.SelectedIndex = 0;
            comboBoxIDScene.SelectedIndex = 0;
        }

        private void OdrediId()
        {
            string[] words = comboBoxIDPredstave.SelectedItem.ToString().Split('-', ' ');
            IDPredstave = int.Parse(words[0]);
            words = comboBoxIDScene.SelectedItem.ToString().Split('-', ' ');
            IDScene = int.Parse(words[0]);
        }

        private bool DaLiPostojiTermin(Termin novi, int index = -1)
        {
            List<Termin> pom = Pomocna.Proxy.SviTermini();

            for (int i = 0; i < pom.Count; i++) 
            {
                if(i == index)
                {
                    continue;
                }
                else
                {
                    if (pom[i].Id_predstave == novi.Id_predstave && pom[i].Id_scene == novi.Id_scene &&
                    pom[i].DatumOdrzavanja.Year == novi.DatumOdrzavanja.Year &&
                    pom[i].DatumOdrzavanja.Month == novi.DatumOdrzavanja.Month && pom[i].DatumOdrzavanja.Day == novi.DatumOdrzavanja.Day)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void PopuniZaIzmenu()
        {
            Termin izmena = Pomocna.Proxy.SviTermini()[index];

            foreach(Predstava p in Pomocna.Proxy.SvePredstave())
            {
                if (p.Id == izmena.Id_predstave)
                {
                    comboBoxIDPredstave.SelectedItem = izmena.Id_predstave + " - " + p.Naziv;
                }
            }
            foreach(Scena s in Pomocna.Proxy.SveScene())
            {
                if(s.Id == izmena.Id_scene)
                {
                    comboBoxIDScene.SelectedItem = izmena.Id_scene + " - " + s.Naziv;
                }
            }
            dateTimePicker1.Value = izmena.DatumOdrzavanja;
            maskedTextBoxVremeOdrzavanja.Text = izmena.Vreme_odrzavanja.ToString();
        }

        private void Clear()
        {
            comboBoxIDPredstave.SelectedIndex = 0;
            comboBoxIDScene.SelectedIndex = 0;
            dateTimePicker1.Value = DateTime.Now;
            maskedTextBoxVremeOdrzavanja.Clear();
        }

        private void FormDodajIzmeniTermin_Load(object sender, EventArgs e)
        {
            switch (jezik)
            {
                case Jezici.SRBL:
                    label8.Text = "ID predstave:";
                    label4.Text = "ID scene:";
                    label6.Text = "Datum održavanja:";
                    label7.Text = "Vreme(HH:MM):";
                    buttonPotvrdi.Text = "Potvrdi";
                    break;
                case Jezici.SRBC:
                    label8.Text = "ИД представе:";
                    label4.Text = "ИД сцене:";
                    label6.Text = "Датум одржавања:";
                    label7.Text = "Време(ЧЧ:ММ):";
                    buttonPotvrdi.Text = "Потврди";
                    break;
                case Jezici.UK:
                    label8.Text = "Show ID:";
                    label4.Text = "Stage ID:";
                    label6.Text = "Date:";
                    label7.Text = "Time(HH:MM):";
                    buttonPotvrdi.Text = "Submit";
                    break;
                default:
                    break;
            }
        }
    }
}
