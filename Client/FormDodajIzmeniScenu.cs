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
    public partial class FormDodajIzmeniScenu : Form
    {
        List<Scena> scene = Pomocna.Proxy.SveScene();
        bool izmena = false;
        int index = -1;
        Jezici jezik;
        public FormDodajIzmeniScenu(bool izmena = false, int index = -1, Jezici jezik = Jezici.SRBL)
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
                        this.Text = "Izmena scene";
                        break;
                    case Jezici.SRBC:
                        this.Text = "Измена сцене";
                        break;
                    case Jezici.UK:
                        this.Text = "Edit stage";
                        break;
                    default:
                        break;
                }
                textBoxKapacitet.Enabled = false;
                PopuniZaIzmenu();
            }
            else
            {
                textBoxKapacitet.Enabled = true;
                switch (jezik)
                {
                    case Jezici.SRBL:
                        this.Text = "Dodavanje scene";
                        break;
                    case Jezici.SRBC:
                        this.Text = "Додавање сцене";
                        break;
                    case Jezici.UK:
                        this.Text = "Add stage";
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

        public string Kapacitet
        {
            get => textBoxKapacitet.Text;
        }

        private void buttonPotvrdi_Click_1(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Naziv) || !String.IsNullOrEmpty(Kapacitet))
            {
                if (!int.TryParse(Kapacitet, out int x) || x <= 0)
                {
                    switch (jezik)
                    {
                        case Jezici.SRBL:
                            MessageBox.Show("Kapacitet scene mora biti prirodan broj!");
                            break;
                        case Jezici.SRBC:
                            MessageBox.Show("Капацитет сцене мора бити природан број!");
                            break;
                        case Jezici.UK:
                            MessageBox.Show("The capacity of the stage must be natural number!");
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
                                MessageBox.Show("Scena sa unetim nazivom već postoji!");
                                break;
                            case Jezici.SRBC:
                                MessageBox.Show("Сцена са унетим називом већ постоји!");
                                break;
                            case Jezici.UK:
                                MessageBox.Show("The stage with entered name already exists!");
                                break;
                            default:
                                break;
                        }
                        return;
                    }
                }

                if (izmena)
                {
                    int id = Pomocna.Proxy.SveScene()[index].Id;
                    Scena zaIzmenu = new Scena(id, Naziv, int.Parse(Kapacitet));

                    if (DaLiPostojiNaziv(zaIzmenu.Naziv, id))
                    {
                        switch (jezik)
                        {
                            case Jezici.SRBL:
                                MessageBox.Show("Scena sa unetim nazivom već postoji!");
                                break;
                            case Jezici.SRBC:
                                MessageBox.Show("Сцена са унетим називом већ постоји!");
                                break;
                            case Jezici.UK:
                                MessageBox.Show("The stage with entered name already exists!");
                                break;
                            default:
                                break;
                        }
                        return;
                    }

                    if (Pomocna.Proxy.IzmeniScenu(zaIzmenu))
                    {
                        switch (jezik)
                        {
                            case Jezici.SRBL:
                                MessageBox.Show("Scena je uspešno izmenjena!");
                                break;
                            case Jezici.SRBC:
                                MessageBox.Show("Сцена је успешно измењена!");
                                break;
                            case Jezici.UK:
                                MessageBox.Show("The stage edited successfully!");
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
                                MessageBox.Show("Doslo je do greske pri izmeni scene!");
                                break;
                            case Jezici.SRBC:
                                MessageBox.Show("Дошло је до грешке при измени сцене!"); ;
                                break;
                            case Jezici.UK:
                                MessageBox.Show("An error occurred while editing the stage!");
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    Scena nova = new Scena(Naziv, int.Parse(Kapacitet));

                    scene.Add(nova);

                    if (Pomocna.Proxy.DodajScenu(nova))
                    {
                        switch (jezik)
                        {
                            case Jezici.SRBL:
                                MessageBox.Show("Scena je uspešno dodata!");
                                break;
                            case Jezici.SRBC:
                                MessageBox.Show("Сцена је успешно додата!");
                                break;
                            case Jezici.UK:
                                MessageBox.Show("The stage added successfully!");
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Doslo je do greske dodavanju scene!");
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
                        MessageBox.Show("Sva polja moraju biti uneta!");
                        break;
                    case Jezici.SRBC:
                        MessageBox.Show("Сва поља морају бити унета!");
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
            Scena izmena = Pomocna.Proxy.SveScene()[index];

            textBoxNaziv.Text = izmena.Naziv;
            textBoxKapacitet.Text = izmena.Kapacitet.ToString();
        }

        private bool DaLiPostojiNaziv(string naziv, int id = 0)
        {
            foreach (Scena s in scene)
            {
                if(id == s.Id)
                {
                    continue;
                }
                if (s.Naziv == naziv)
                {
                    return true;
                }
            }
            return false;
        }

        private void Clear()
        {
            textBoxNaziv.Clear();
            textBoxKapacitet.Clear();
        }

        private void FormDodajIzmeniScenu_Load(object sender, EventArgs e)
        {
            switch (jezik)
            {
                case Jezici.SRBL:
                    label4.Text = "Naziv:";
                    label3.Text = "Kapacitet:";
                    buttonPotvrdi.Text = "Potvrdi";
                    break;
                case Jezici.SRBC:
                    label4.Text = "Назив:";
                    label3.Text = "Капацитет:";
                    buttonPotvrdi.Text = "Потврди";
                    break;
                case Jezici.UK:
                    label4.Text = "Name:";
                    label3.Text = "Capacity:";
                    buttonPotvrdi.Text = "Submit";
                    break;
                default:
                    break;
            }
        }
    }
}
