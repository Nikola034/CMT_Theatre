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
using System.Text.RegularExpressions;

namespace Client
{
    public partial class FormDodajIzmeniGledaoca : Form
    {
        List<Gledalac> gledaoci = Pomocna.Proxy.SviGledaoci();
        bool izmena = false;
        int index = -1;
        Jezici jezik;
        public FormDodajIzmeniGledaoca(bool izmena = false, int index = -1, Jezici jezik = Jezici.SRBL)
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
                        this.Text = "Izmena gledaoca";
                        break;
                    case Jezici.SRBC:
                        this.Text = "Измена гледаоца";
                        break;
                    case Jezici.UK:
                        this.Text = "Edit watcher";
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
                        this.Text = "Dodavanje gledaoca";
                        break;
                    case Jezici.SRBC:
                        this.Text = "Додавање гледаоца";
                        break;
                    case Jezici.UK:
                        this.Text = "Add watcher";
                        break;
                    default:
                        break;
                }
            }
        }

        public string Ime
        {
            get => textBoxIme.Text;
        }

        public string Prezime
        {
            get => textBoxPrezime.Text;
        }

        public string Email
        {
            get => textBoxEmail.Text;
        }

        private void buttonPotvrdi_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Ime) && !String.IsNullOrEmpty(Prezime) && !String.IsNullOrEmpty(Email))
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(Email);
                if (!match.Success)
                {
                    switch (jezik)
                    {
                        case Jezici.SRBL:
                            MessageBox.Show("Mejl nije ispravno unet!");
                            break;
                        case Jezici.SRBC:
                            MessageBox.Show("Мејл није исправно унет!");
                            break;
                        case Jezici.UK:
                            MessageBox.Show("The Email adress you entered is not correct!");
                            break;
                        default:
                            break;
                    }
                    return;
                }

                if (DaLiPostojiMejl(Email))
                {
                    if (!izmena)
                    {
                        switch (jezik)
                        {
                            case Jezici.SRBL:
                                MessageBox.Show("Gledalac sa unetim mejlom već postoji!");
                                break;
                            case Jezici.SRBC:
                                MessageBox.Show("Гледалац са унетим мејлом већ постоји!");
                                break;
                            case Jezici.UK:
                                MessageBox.Show("The watcher with entered email already exists!");
                                break;
                            default:
                                break;
                        }
                        return;
                    }
                }


                if (izmena)
                {
                    int id = Pomocna.Proxy.SviGledaoci()[index].Id;
                    Gledalac zaIzmenu = new Gledalac(id, Email, Ime, Prezime);

                    if (DaLiPostojiMejl(zaIzmenu.Email, id))
                    {
                        switch (jezik)
                        {
                            case Jezici.SRBL:
                                MessageBox.Show("Gledalac sa unetim mejlom već postoji!");
                                break;
                            case Jezici.SRBC:
                                MessageBox.Show("Гледалац са унетим мејлом већ постоји!");
                                break;
                            case Jezici.UK:
                                MessageBox.Show("The watcher with entered email already exists!");
                                break;
                            default:
                                break;
                        }
                        return;
                    }

                    if (Pomocna.Proxy.IzmeniGledaoca(zaIzmenu))
                    {
                        switch (jezik)
                        {
                            case Jezici.SRBL:
                                MessageBox.Show("Gledalac je uspešno izmenjen!");
                                break;
                            case Jezici.SRBC:
                                MessageBox.Show("Гледалац је успешно измењен!");
                                break;
                            case Jezici.UK:
                                MessageBox.Show("The watcher edited successfully!");
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
                                MessageBox.Show("Došlo je do greške pri izmeni gledaoca!");
                                break;
                            case Jezici.SRBC:
                                MessageBox.Show("Дошло је до грешке при измени гледаоца!");
                                break;
                            case Jezici.UK:
                                MessageBox.Show("An error occurred while editing the user!");
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    Gledalac novi = new Gledalac(Email, Ime, Prezime);

                    gledaoci.Add(novi);

                    if (Pomocna.Proxy.DodajGledaoca(novi))
                    {

                        switch (jezik)
                        {
                            case Jezici.SRBL:
                                MessageBox.Show("Gledalac je uspešno dodat!");
                                break;
                            case Jezici.SRBC:
                                MessageBox.Show("Гледалац је успешно додат!");
                                break;
                            case Jezici.UK:
                                MessageBox.Show("The watcher added successfully!");
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
                                MessageBox.Show("Došlo je do greške pri dodavanju gledaoca!");
                                break;
                            case Jezici.SRBC:
                                MessageBox.Show("Дошло је до грешке при додавању гледаоца!");
                                break;
                            case Jezici.UK:
                                MessageBox.Show("An error occurred while adding the user!");
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
                        MessageBox.Show("Please fill in all the required fields.");
                        break;
                    default:
                        break;
                }
                return;
            }
        }

        private bool DaLiPostojiMejl(string email, int id = 0)
        {
            foreach(Gledalac x in gledaoci)
            {
                if(id == x.Id)
                {
                    continue;
                }
                if(x.Email == email)
                {
                    return true;
                }
            }
            return false;
        }

        private void PopuniZaIzmenu()
        {
            Gledalac izmena = Pomocna.Proxy.SviGledaoci()[index];

            textBoxIme.Text = izmena.Ime;
            textBoxPrezime.Text = izmena.Prezime;
            textBoxEmail.Text = izmena.Email;
        }

        private void Clear()
        {
            textBoxIme.Clear();
            textBoxPrezime.Clear();
            textBoxEmail.Clear();
        }

        private void FormDodajIzmeniGledaoca_Load(object sender, EventArgs e)
        {
            switch (jezik)
            {
                case Jezici.SRBL:
                    label1.Text = "Ime:";
                    label2.Text = "Prezime:";
                    label3.Text = "E-mail:";
                    buttonPotvrdi.Text = "Potvrdi";
                    break;
                case Jezici.SRBC:
                    label1.Text = "Име:";
                    label2.Text = "Презиме:";
                    label3.Text = "Мејл:";
                    buttonPotvrdi.Text = "Потврди";
                    break;
                case Jezici.UK:
                    label1.Text = "Name:";
                    label2.Text = "Surname:";
                    label3.Text = "E-mail:";
                    buttonPotvrdi.Text = "Submit";
                    break;
                default:
                    break;
            }
        }
    }
}
