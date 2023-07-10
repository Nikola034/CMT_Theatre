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
    public partial class FormDodajIzmeniPredstavu : Form
    {
        List<Predstava> predstave = Pomocna.Proxy.SvePredstave();
        bool izmena = false;
        int index = -1;
        Jezici jezik;
        public FormDodajIzmeniPredstavu(bool izmena = false, int index = -1, Jezici jezik = Jezici.SRBL)
        {
            this.jezik = jezik;
            InitializeComponent();
            CenterToScreen();
            this.izmena = izmena;
            this.index = index;
            if (izmena)
            {
                switch (jezik)
                {
                    case Jezici.SRBL:
                        this.Text = "Izmena predstave";
                        break;
                    case Jezici.SRBC:
                        this.Text = "Измена представе";
                        break;
                    case Jezici.UK:
                        this.Text = "Edit show";
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
                        this.Text = "Dodavanje predstave";
                        break;
                    case Jezici.SRBC:
                        this.Text = "Додавање представе";
                        break;
                    case Jezici.UK:
                        this.Text = "Add show";
                        break;
                    default:
                        break;
                }
            }
        }

        public string Naziv
        {
            get => textBoxNaziv.Text;
        }

        public string Trajanje
        {
            get => textBoxTrajanje.Text;
        }
        private void buttonPotvrdi_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(Naziv) && !String.IsNullOrEmpty(Trajanje))
            {
                if(!int.TryParse(Trajanje, out int x) || x <= 0)
                {
                    switch (jezik)
                    {
                        case Jezici.SRBL:
                            MessageBox.Show("Trajanje predstave nije pravilno uneto!");
                            break;
                        case Jezici.SRBC:
                            MessageBox.Show("Трајање представе није правилно унето!");
                            break;
                        case Jezici.UK:
                            MessageBox.Show("The duration of the show you entered is not correct!");
                            break;
                        default:
                            break;
                    }
                    return;
                }

                if (DaLiPostojiNaziv(Naziv))
                {
                    if (!izmena)
                    {
                        switch (jezik)
                        {
                            case Jezici.SRBL:
                                MessageBox.Show("Predstava sa unetim nazivom već postoji!");
                                break;
                            case Jezici.SRBC:
                                MessageBox.Show("Представа са унетим називом већ постоји!");
                                break;
                            case Jezici.UK:
                                MessageBox.Show("The show with entered title already exists!");
                                break;
                            default:
                                break;
                        }
                        return;
                    }
                }

                if (izmena)
                {
                    int id = Pomocna.Proxy.SvePredstave()[index].Id;
                    Predstava zaIzmenu = new Predstava(id, Naziv, int.Parse(Trajanje));

                    if (DaLiPostojiNaziv(zaIzmenu.Naziv, id))
                    {
                        switch (jezik)
                        {
                            case Jezici.SRBL:
                                MessageBox.Show("Predstava sa unetim nazivom već postoji!");
                                break;
                            case Jezici.SRBC:
                                MessageBox.Show("Представа са унетим називом већ постоји!");
                                break;
                            case Jezici.UK:
                                MessageBox.Show("The show with entered title already exists!");
                                break;
                            default:
                                break;
                        }
                        return;
                    }

                    if (Pomocna.Proxy.IzmeniPredstavu(zaIzmenu))
                    {
                        switch (jezik)
                        {
                            case Jezici.SRBL:
                                MessageBox.Show("Predstava je uspešno izmenjena!");
                                break;
                            case Jezici.SRBC:
                                MessageBox.Show("Представа је успешно измењена!");
                                break;
                            case Jezici.UK:
                                MessageBox.Show("The show edited successfully!");
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
                                MessageBox.Show("Došlo je do greške pri izmeni predstave!");
                                break;
                            case Jezici.SRBC:
                                MessageBox.Show("Дошло је до грешке при измени представе!");
                                break;
                            case Jezici.UK:
                                MessageBox.Show("An error occurred while editing the show!");
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    Predstava nova = new Predstava(Naziv, x);

                    predstave.Add(nova);

                    if (Pomocna.Proxy.DodajPredstavu(nova))
                    {
                        switch (jezik)
                        {
                            case Jezici.SRBL:
                                MessageBox.Show("Predstava je uspešno dodata!");
                                break;
                            case Jezici.SRBC:
                                MessageBox.Show("Представа је успешно додата!");
                                break;
                            case Jezici.UK:
                                MessageBox.Show("The show added successfully!");
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
                                MessageBox.Show("Došlo je do greške pri dodavanju predstave!");
                                break;
                            case Jezici.SRBC:
                                MessageBox.Show("Дошло је до грешке при додавању представе!");
                                break;
                            case Jezici.UK:
                                MessageBox.Show("An error occurred while adding the show!");
                                break;
                            default:
                                break;
                        }
                    }
                }
                Clear();
                this.Close();
            }
            else
            {
                switch (jezik)
                {
                    case Jezici.SRBL:
                        MessageBox.Show("Sva polja moraju biti popunjena!");
                        break;
                    case Jezici.SRBC:
                        MessageBox.Show("Сва поља морају бити попуњена!");
                        break;
                    case Jezici.UK:
                        MessageBox.Show("All the fields must be filled up!");
                        break;
                    default:
                        break;
                }
                return;
            }
        }

        private void PopuniZaIzmenu()
        {
            Predstava izmena = Pomocna.Proxy.SvePredstave()[index];

            textBoxNaziv.Text = izmena.Naziv;
            textBoxTrajanje.Text = izmena.Trajanje.ToString();
        }

        private bool DaLiPostojiNaziv(string naziv, int id = 0)
        {
            foreach (Predstava p in predstave)
            {
                if (p.Naziv == naziv)
                {
                    if(id == p.Id)
                    {
                        continue;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void Clear()
        {
            textBoxNaziv.Clear();
            textBoxTrajanje.Clear();
        }

        private void FormDodajIzmeniPredstavu_Load(object sender, EventArgs e)
        {
            switch (jezik)
            {
                case Jezici.SRBL:
                    label4.Text = "Naziv:";
                    label3.Text = "Trajanje:";
                    button1.Text = "Potvrdi";
                    break;
                case Jezici.SRBC:
                    label4.Text = "Назив:";
                    label3.Text = "Трајање:";
                    button1.Text = "Потврди";
                    break;
                case Jezici.UK:
                    label4.Text = "Title:";
                    label3.Text = "Duration:";
                    button1.Text = "Submit";
                    break;
                default:
                    break;
            }
        }
    }
}
