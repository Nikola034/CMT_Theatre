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
using System.Data.SqlClient;

namespace Client
{
    public partial class FormDodajIzmeniKartu : Form
    {
        List<Karta> karte = Pomocna.Proxy.SveKarte();
        int kapacitet = 0;
        bool izmena = false;
        int index = -1;
        Jezici jezik;

        public FormDodajIzmeniKartu(bool izmena = false, int index = -1, Jezici jezik = Jezici.SRBL)
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
                        this.Text = "Izmena karte";
                        break;
                    case Jezici.SRBC:
                        this.Text = "Измена карте";
                        break;
                    case Jezici.UK:
                        this.Text = "Edit ticket";
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
                        this.Text = "Dodavanje karte";
                        break;
                    case Jezici.SRBC:
                        this.Text = "Додавање карте";
                        break;
                    case Jezici.UK:
                        this.Text = "Add ticket";
                        break;
                    default:
                        break;
                }
            }
            OdrediId();
        }

        public int BrojSedista
        {
            get => (int)comboBoxBrojSedista.SelectedItem;
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

        public int IDGledaoca
        {
            get;
            set;
        }
        public DateTime DatumOdrzavanja
        {
            get => (DateTime)comboBoxDatumOdrzavanja.SelectedItem;
        }

        private void buttonPotvrdi_Click(object sender, EventArgs e)
        {
            try
            {
                string nema_termina = "";
                switch (jezik)
                {
                    case Jezici.SRBL:
                        nema_termina = "NEMA TERMINA";
                        break;
                    case Jezici.SRBC:
                        nema_termina = "НЕМА ТЕРМИНА";
                        break;
                    case Jezici.UK:
                        nema_termina = "NO APPOINTMENTS";
                        break;
                    default:
                        break;
                }

                if (comboBoxDatumOdrzavanja.SelectedItem.ToString().Equals(nema_termina))
                {
                    switch (jezik)
                    {
                        case Jezici.SRBL:
                            MessageBox.Show("Nema termina za datu predstavu na unetoj sceni!");
                            break;
                        case Jezici.SRBC:
                            MessageBox.Show("Нема термина за дату представу на унетој сцени!");
                            break;
                        case Jezici.UK:
                            MessageBox.Show("There are no appointments for the entered show on the entered stage!");
                            break;
                        default:
                            break;
                    }
                    return;
                }
                else if (!DaLiImaKarata(NadjiScenu(IDScene)))
                {
                    switch (jezik)
                    {
                        case Jezici.SRBL:
                            MessageBox.Show("Nema više karata za izabrani termin!");
                            break;
                        case Jezici.SRBC:
                            MessageBox.Show("Нема више карата за изабрани термин!");
                            break;
                        case Jezici.UK:
                            MessageBox.Show("There are no more tickets for selected appointment!");
                            break;
                        default:
                            break;
                    }
                    return;
                }

                if (izmena)
                {
                    OdrediId();
                    int id = Pomocna.Proxy.SveKarte()[index].Id;
                    Karta zaIzmenu = new Karta(id, BrojSedista, IDPredstave, IDScene, IDGledaoca, DatumOdrzavanja);

                    if (Pomocna.Proxy.IzmeniKartu(zaIzmenu))
                    {
                        switch (jezik)
                        {
                            case Jezici.SRBL:
                                MessageBox.Show("Karta je uspešno izmenjena!");
                                break;
                            case Jezici.SRBC:
                                MessageBox.Show("Карта је успешно измењена!");
                                break;
                            case Jezici.UK:
                                MessageBox.Show("The ticket edited successfully!");
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
                                MessageBox.Show("Došlo je do greške pri izmeni karte!");
                                break;
                            case Jezici.SRBC:
                                MessageBox.Show("Дошло је до грешке при измени карте!");
                                break;
                            case Jezici.UK:
                                MessageBox.Show("An error occurred while editing ticket!");
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    OdrediId();

                    Karta nova = new Karta(BrojSedista, IDPredstave, IDScene, IDGledaoca,
                    DatumOdrzavanja);

                    karte.Add(nova);

                    if (Pomocna.Proxy.DodajKartu(nova))
                    {
                        switch (jezik)
                        {
                            case Jezici.SRBL:
                                MessageBox.Show("Karta je uspešno dodata!");
                                break;
                            case Jezici.SRBC:
                                MessageBox.Show("Карта је успешно додата!");
                                break;
                            case Jezici.UK:
                                MessageBox.Show("The ticket added successfully!");
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
                                MessageBox.Show("Došlo je do greške pri dodavanju karte!");
                                break;
                            case Jezici.SRBC:
                                MessageBox.Show("Дошло је до грешке при додавању карте!");
                                break;
                            case Jezici.UK:
                                MessageBox.Show("An error occurred while adding ticket!");
                                break;
                            default:
                                break;
                        };
                    }
                }
                this.Close();
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NapuniComboBoxove()
        {
            List<Predstava> predstave = Pomocna.Proxy.SvePredstave();
            List<Scena> scene = Pomocna.Proxy.SveScene();
            List<Gledalac> gledaoci = Pomocna.Proxy.SviGledaoci();
       
            foreach (Predstava p in predstave)
            {
                comboBoxIDPredstave.Items.Add(p.Id + " - " + p.Naziv);
            }

            foreach (Scena s in scene)
            {
                comboBoxIDScene.Items.Add(s.Id + " - " + s.Naziv);
            }

            foreach (Gledalac g in gledaoci)
            {
                comboBoxIDGledaoca.Items.Add(g.Id + " - " + g.Ime + " " + g.Prezime);
            }

            comboBoxIDGledaoca.SelectedIndex = 0;
            comboBoxIDPredstave.SelectedIndex = 0;
            comboBoxIDScene.SelectedIndex = 0;

            for (int i = 1; i <= kapacitet; i++)
            {
                if (DaLiJeSedisteSlobodno(i))
                {
                    comboBoxBrojSedista.Items.Add(i);
                }
            }

            comboBoxBrojSedista.SelectedIndex = 0;
        }

        private void OdrediId()
        {
            string[] words = comboBoxIDPredstave.SelectedItem.ToString().Split('-', ' ');
            IDPredstave = int.Parse(words[0]);
            words = comboBoxIDScene.SelectedItem.ToString().Split('-', ' ');
            IDScene = int.Parse(words[0]);
            words = comboBoxIDGledaoca.SelectedItem.ToString().Split('-', ' ');
            IDGledaoca = int.Parse(words[0]);
        }

        private bool DaLiJeSedisteSlobodno(int broj_sedista)
        {
            foreach (Karta x in karte)
            {
                if (x.Id_predstave == IDPredstave && x.Id_scene == IDScene && x.Broj_sedista == broj_sedista &&
                    x.DatumOdrzavanja.Year == DatumOdrzavanja.Year && x.DatumOdrzavanja.Month == x.DatumOdrzavanja.Month &&
                    x.DatumOdrzavanja.Day == DatumOdrzavanja.Day)
                {
                    return false;
                }
            }
            return true;
        }

        private bool DaLiImaKarata(Scena s)
        {
            List<Termin> termini = Pomocna.Proxy.SviTermini();

            foreach (Termin t in termini)
            {
                if (t.Id_scene == s.Id && t.Broj_prodatih_karata == s.Kapacitet)
                {
                    return false;
                }
            }
            return true;
        }

        private Scena NadjiScenu(int id)
        {
            foreach (Scena s in Pomocna.Proxy.SveScene())
            {
                if (s.Id == id)
                {
                    return s;
                }
            }
            return new Scena();
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComboBox cb = sender as ComboBox;

                if (cb.Name == "comboBoxIDScene")
                {
                    string[] words = cb.SelectedItem.ToString().Split('-', ' ');
                    int selektovani_id_scene = int.Parse(words[0]);

                    foreach (Scena s in Pomocna.Proxy.SveScene())
                    {
                        if (s.Id == selektovani_id_scene)
                        {
                            kapacitet = s.Kapacitet;
                        }
                    }
                    IDScene = selektovani_id_scene;

                }
                else
                {
                    string[] words = cb.SelectedItem.ToString().Split('-', ' ');
                    int selektovani_id_predstave = int.Parse(words[0]);

                    IDPredstave = selektovani_id_predstave;

                }

                NapuniDatumeOdrzavanja();

                comboBoxBrojSedista.Items.Clear();

                for (int i = 1; i <= kapacitet; i++)
                {
                    if (DaLiJeSedisteSlobodno(i))
                    {
                        comboBoxBrojSedista.Items.Add(i);
                    }
                }

                comboBoxBrojSedista.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void NapuniDatumeOdrzavanja()
        {
            List<DateTime> datumi = new List<DateTime>();

            datumi = Pomocna.Proxy.DatumiTermina(IDPredstave, IDScene);

            if (datumi.Count > 0)
            {
                comboBoxDatumOdrzavanja.DataSource = datumi.ToList();
            }
            else
            {
                List<string> empty = new List<string>();
                string message = "";
                switch (jezik)
                {
                    case Jezici.SRBL:
                        message = "NEMA TERMINA";
                        break;
                    case Jezici.SRBC:
                        message = "НЕМА ТЕРМИНА";
                        break;
                    case Jezici.UK:
                        message = "NO APPOINTMENTS";
                        break;
                    default:
                        break;
                }
                empty.Add(message);
                comboBoxDatumOdrzavanja.DataSource = empty.ToList();
            }
        }

        private void PopuniZaIzmenu()
        {
            Karta izmena = Pomocna.Proxy.SveKarte()[index];

            comboBoxBrojSedista.SelectedItem = izmena.Broj_sedista;
            foreach (Predstava p in Pomocna.Proxy.SvePredstave())
            {
                if (p.Id == izmena.Id_predstave)
                {
                    comboBoxIDPredstave.SelectedItem = izmena.Id_predstave + " - " + p.Naziv;
                }
            }
            foreach (Scena s in Pomocna.Proxy.SveScene())
            {
                if (s.Id == izmena.Id_scene)
                {
                    comboBoxIDScene.SelectedItem = izmena.Id_scene + " - " + s.Naziv;
                }
            }
            foreach (Gledalac g in Pomocna.Proxy.SviGledaoci())
            {
                if (g.Id == izmena.Id_gledaoca)
                {
                    comboBoxIDGledaoca.SelectedItem = izmena.Id_gledaoca + " - " + g.Ime + " " + g.Prezime;
                }
            }
            comboBoxDatumOdrzavanja.SelectedItem = izmena.DatumOdrzavanja;
        }

        private void Clear()
        {
            comboBoxBrojSedista.SelectedIndex = 0;
            comboBoxIDGledaoca.SelectedIndex = 0;
            comboBoxIDPredstave.SelectedIndex = 0;
            comboBoxIDScene.SelectedIndex = 0;
            comboBoxDatumOdrzavanja.SelectedIndex = 0;
        }

        private void FormDodajIzmeniKartu_Load(object sender, EventArgs e)
        {
            switch (jezik)
            {
                case Jezici.SRBL:
                    label1.Text = "Broj sedišta:";
                    label2.Text = "ID predstave:";
                    label3.Text = "ID scene:";
                    label4.Text = "ID gledaoca:";
                    label5.Text = "Datum održavanja:";
                    buttonPotvrdi.Text = "Potvrdi";
                    break;
                case Jezici.SRBC:
                    label1.Text = "Број седишта:";
                    label2.Text = "ИД представе:";
                    label3.Text = "ИД сцене:";
                    label4.Text = "ИД гледаоца:";
                    label5.Text = "Датум одржавања:";
                    buttonPotvrdi.Text = "Потврди";
                    break;
                case Jezici.UK:
                    label1.Text = "Seat number:";
                    label2.Text = "Show ID:";
                    label3.Text = "Stage ID:";
                    label4.Text = "Watcher ID:";
                    label5.Text = "Date:";
                    buttonPotvrdi.Text = "Submit";
                    break;
                default:
                    break;
            }
        }
    }
}
