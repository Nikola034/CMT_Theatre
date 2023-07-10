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
using System.ServiceModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Client
{
    public enum Tabele { Gledalac, Predstava, Karta, Scena, Termin }
    public enum Jezici { SRBC, SRBL, UK}

    public partial class Form1 : Form
    {
        List<string> parametri = new List<string>();
        Tabele vazecaTabela;
        Jezici jezik = Jezici.SRBL;
        bool uspesnoLogovanje = true;

        public Form1()
        {
            PokreniServer();
            FormLogin login = new FormLogin();
            login.ShowDialog();
            if (String.IsNullOrEmpty(login.User))
            {
                uspesnoLogovanje = false;
                Application.Exit();
            }
            InitializeComponent();
            CenterToScreen();
            if (String.IsNullOrEmpty(login.User))
            {
                Environment.Exit(1);
            }
        }

        private void toolStripButtonDodaj_Click(object sender, EventArgs e)
        {
            switch (vazecaTabela)
            {
                case Tabele.Gledalac:
                    try
                    {
                        FormDodajIzmeniGledaoca dodajGledaoca = new FormDodajIzmeniGledaoca(false, -1, jezik);
                        dodajGledaoca.ShowDialog();
                    }
                    catch (FaultException<string> ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    Refresh(vazecaTabela);
                    break;
                case Tabele.Predstava:
                    try
                    {
                        FormDodajIzmeniPredstavu dodajPredstavu = new FormDodajIzmeniPredstavu(false, -1, jezik);
                        dodajPredstavu.ShowDialog();
                    }
                    catch (FaultException<string> ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    Refresh(vazecaTabela);
                    break;
                case Tabele.Karta:
                    try
                    {
                        FormDodajIzmeniKartu dodajKartu = new FormDodajIzmeniKartu(false, -1, jezik);
                        dodajKartu.ShowDialog();
                    }
                    catch (FaultException<string> ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    Refresh(vazecaTabela);
                    break;
                case Tabele.Scena:
                    try
                    {
                        FormDodajIzmeniScenu dodajScenu = new FormDodajIzmeniScenu(false, -1, jezik);
                        dodajScenu.ShowDialog();
                    }
                    catch (FaultException<string> ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    Refresh(vazecaTabela);
                    break;
                case Tabele.Termin:
                    try
                    {
                        FormDodajIzmeniTermin dodajTermin = new FormDodajIzmeniTermin(false, -1, jezik);
                        dodajTermin.ShowDialog();
                    }
                    catch (FaultException<string> ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    Refresh(vazecaTabela);
                    break;
                default:
                    break;
            }
        }

        private void PokreniServer()
        {
            Process.Start("E:\\Poslovni folder\\Programiranje C# 3\\CMT\\CMT Projekat 2021\\CMT Projekat 2021\\Server\\bin\\Debug\\Server.exe");
        }
        private void toolStripButtonIzmeni_Click(object sender, EventArgs e)
        {
            switch (vazecaTabela)
            {
                case Tabele.Gledalac:
                    try
                    {
                        FormDodajIzmeniGledaoca izmeniGledaoca = new FormDodajIzmeniGledaoca(true, dataGridView1.SelectedRows[0].Index, jezik);
                        izmeniGledaoca.ShowDialog();
                    }
                    catch (FaultException<string> ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    catch (Exception ex)
                    {
                        switch (jezik)
                        {
                            case Jezici.SRBL:
                                MessageBox.Show("Niste selektovali red!");
                                break;
                            case Jezici.SRBC:
                                MessageBox.Show("Нисте селектовали ред!");
                                break;
                            case Jezici.UK:
                                MessageBox.Show("You did not select a row!");
                                break;
                            default:
                                break;
                        }
                        return;
                    }
                    Refresh(vazecaTabela);
                    break;
                case Tabele.Predstava:
                    try
                    {
                        FormDodajIzmeniPredstavu izmeniPredstavu = new FormDodajIzmeniPredstavu(true, dataGridView1.SelectedRows[0].Index, jezik);
                        izmeniPredstavu.ShowDialog();
                    }
                    catch (FaultException<string> ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    catch (Exception ex)
                    {
                        switch (jezik)
                        {
                            case Jezici.SRBL:
                                MessageBox.Show("Niste selektovali red!");
                                break;
                            case Jezici.SRBC:
                                MessageBox.Show("Нисте селектовали ред!");
                                break;
                            case Jezici.UK:
                                MessageBox.Show("You did not select a row!");
                                break;
                            default:
                                break;
                        }
                        return;
                    }
                    Refresh(vazecaTabela);
                    break;
                case Tabele.Karta:
                    try
                    {
                        FormDodajIzmeniKartu izmeniKartu = new FormDodajIzmeniKartu(true, dataGridView1.SelectedRows[0].Index, jezik);
                        izmeniKartu.ShowDialog();
                    }
                    catch (FaultException<string> ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    catch (Exception ex)
                    {
                        switch (jezik)
                        {
                            case Jezici.SRBL:
                                MessageBox.Show("Niste selektovali red!");
                                break;
                            case Jezici.SRBC:
                                MessageBox.Show("Нисте селектовали ред!");
                                break;
                            case Jezici.UK:
                                MessageBox.Show("You did not select a row!");
                                break;
                            default:
                                break;
                        }
                        return;
                    }
                    Refresh(vazecaTabela);
                    break;
                case Tabele.Scena:
                    try
                    {
                        FormDodajIzmeniScenu izmeniScenu = new FormDodajIzmeniScenu(true, dataGridView1.SelectedRows[0].Index, jezik);
                        izmeniScenu.ShowDialog();
                    }
                    catch (FaultException<string> ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    catch (Exception ex)
                    {
                        switch (jezik)
                        {
                            case Jezici.SRBL:
                                MessageBox.Show("Niste selektovali red!");
                                break;
                            case Jezici.SRBC:
                                MessageBox.Show("Нисте селектовали ред!");
                                break;
                            case Jezici.UK:
                                MessageBox.Show("You did not select a row!");
                                break;
                            default:
                                break;
                        }
                        return;
                    }
                    Refresh(vazecaTabela);
                    break;
                case Tabele.Termin:
                    try
                    {
                        FormDodajIzmeniTermin izmeniTermin = new FormDodajIzmeniTermin(true, dataGridView1.SelectedRows[0].Index, jezik);
                        izmeniTermin.ShowDialog();
                    }
                    catch (FaultException<string> ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    catch (Exception ex)
                    {
                        switch (jezik)
                        {
                            case Jezici.SRBL:
                                MessageBox.Show("Niste selektovali red!");
                                break;
                            case Jezici.SRBC:
                                MessageBox.Show("Нисте селектовали ред!");
                                break;
                            case Jezici.UK:
                                MessageBox.Show("You did not select a row!");
                                break;
                            default:
                                break;
                        }
                        return;
                    }
                    Refresh(vazecaTabela);
                    break;
                default:
                    break;
            }
        }

        private void toolStripButtonBrisi_Click(object sender, EventArgs e)
        {
            int id = -1;
            try
            {
                id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            }
            catch (Exception ex)
            {
                switch (jezik)
                {
                    case Jezici.SRBL:
                        MessageBox.Show("Niste selektovali red!");
                        break;
                    case Jezici.SRBC:
                        MessageBox.Show("Нисте селектовали ред!");
                        break;
                    case Jezici.UK:
                        MessageBox.Show("You did not select a row!");
                        break;
                    default:
                        break;
                }
                return;
            }

            switch (vazecaTabela)
            {
                case Tabele.Gledalac:
                    try
                    {
                        string text = "", naslov = "";

                        switch (jezik)
                        {
                            case Jezici.SRBL:
                                text = "Da li ste sigurni da zelite da obrišete gledaoca?\n" +
                            "Sve karte koje je posedovao ce biti obrisane.";
                                naslov = "Potvrda";
                                break;
                            case Jezici.SRBC:
                                text = "Да ли сте сигурни да желите да обришете гледаоца?\n" +
                            "Све карте које је поседовао ће бити обрисане.";
                                naslov = "Потврда";
                                break;
                            case Jezici.UK:
                                text = "Are you sure you want to delete the watcher?\n" +
                            "All of the user's tickets will also be deleted.";
                                naslov = "Assurance";
                                break;
                            default:
                                break;
                        }

                        if (MessageBox.Show(text, naslov, MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }

                        if (Pomocna.Proxy.ObrisiGledaoca(id))
                        {
                            switch (jezik)
                            {
                                case Jezici.SRBL:
                                    MessageBox.Show("Gledalac je uspešno obrisan!");
                                    break;
                                case Jezici.SRBC:
                                    MessageBox.Show("Гледалац је успешно обрисан!");
                                    break;
                                case Jezici.UK:
                                    MessageBox.Show("The user deleted successfully!");
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
                                    MessageBox.Show("Došlo je do greške pri brisanju gledaoca!");
                                    break;
                                case Jezici.SRBC:
                                    MessageBox.Show("Дошло је до грешке при брисању гледаоца!");
                                    break;
                                case Jezici.UK:
                                    MessageBox.Show("An error occurred while deleting the watcher!");
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    catch (FaultException<string> ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    Refresh(vazecaTabela);
                    break;
                case Tabele.Predstava:
                    try
                    {
                        string text = "", naslov = "";

                        switch (jezik)
                        {
                            case Jezici.SRBL:
                                text = "Da li ste sigurni da zelite da obrišete predstavu?\n" +
                            "Svi termini i karte koje sadrže izabranu predstavu će biti obrisani.";
                                naslov = "Potvrda";
                                break;
                            case Jezici.SRBC:
                                text = "Да ли сте сигурни да желите да обришете представу?\n" +
                            "Сви термини и карте које садрже изабрану представу ће бити обрисани.";
                                naslov = "Потврда";
                                break;
                            case Jezici.UK:
                                text = "Are you sure you want to delete the show?\n" +
                            "All of the tickets which contains selected show will also be deleted.";
                                naslov = "Assurance";
                                break;
                            default:
                                break;
                        }

                        if (MessageBox.Show(text, naslov, MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) 
                        {
                            return;
                        }

                        if (Pomocna.Proxy.ObrisiPredstavu(id))
                        {
                            switch (jezik)
                            {
                                case Jezici.SRBL:
                                    MessageBox.Show("Predstava je uspešno obrisana!");
                                    break;
                                case Jezici.SRBC:
                                    MessageBox.Show("Представа је успешно обрисана!");
                                    break;
                                case Jezici.UK:
                                    MessageBox.Show("The show deleted successfully!");
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
                                    MessageBox.Show("Došlo je do greške pri brisanju predstave!");
                                    break;
                                case Jezici.SRBC:
                                    MessageBox.Show("Дошло је до грешке при брисању представе!");
                                    break;
                                case Jezici.UK:
                                    MessageBox.Show("An error occurred while deleting the show!");
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    catch (FaultException<string> ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    Refresh(vazecaTabela);
                    break;
                case Tabele.Karta:
                    try
                    {
                        string text = "", naslov = "";

                        switch (jezik)
                        {
                            case Jezici.SRBL:
                                text = "Da li ste sigurni da zelite da obrišete kartu?";
                                naslov = "Potvrda";
                                break;
                            case Jezici.SRBC:
                                text = "Да ли сте сигурни да желите да обришете карту?";
                                naslov = "Потврда";
                                break;
                            case Jezici.UK:
                                text = "Are you sure you want to delete the ticket?";
                                naslov = "Assurance";
                                break;
                            default:
                                break;
                        }

                        if (MessageBox.Show(text, naslov, MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }

                        if (Pomocna.Proxy.ObrisiKartu(id))
                        {
                            switch (jezik)
                            {
                                case Jezici.SRBL:
                                    MessageBox.Show("Karta je uspešno obrisana!");
                                    break;
                                case Jezici.SRBC:
                                    MessageBox.Show("Карта је успешно обрисана!");
                                    break;
                                case Jezici.UK:
                                    MessageBox.Show("The ticket deleted successfully!");
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
                                    MessageBox.Show("Došlo je do greške pri brisanju karte!");
                                    break;
                                case Jezici.SRBC:
                                    MessageBox.Show("Дошло је до грешке при брисању карте!");
                                    break;
                                case Jezici.UK:
                                    MessageBox.Show("An error occurred while deleting the ticket!");
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    catch (FaultException<string> ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    Refresh(vazecaTabela);
                    break;
                case Tabele.Scena:
                    try
                    {
                        string text = "", naslov = "";

                        switch (jezik)
                        {
                            case Jezici.SRBL:
                                text = "Da li ste sigurni da želite da obrišete scenu?\n" +
                            "Sve karte i termini koji sadrže datu scenu ce biti obrisani.";
                                naslov = "Potvrda";
                                break;
                            case Jezici.SRBC:
                                text = "Да ли сте сигурни да желите да обришете сцену?\n" +
                            "Све карте и термини који садрже дату сцену ће бити обрисани.";
                                naslov = "Потврда";
                                break;
                            case Jezici.UK:
                                text = "Are you sure you want to delete the stage?\n" +
                            "All of the cards and appointments which contains selected stage will also be deleted.";
                                naslov = "Assurance";
                                break;
                            default:
                                break;
                        }

                        if (MessageBox.Show(text, naslov, MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }

                        if (Pomocna.Proxy.ObrisiScenu(id))
                        {
                            switch (jezik)
                            {
                                case Jezici.SRBL:
                                    MessageBox.Show("Scena je uspešno obrisana!");
                                    break;
                                case Jezici.SRBC:
                                    MessageBox.Show("Сцена је успешно обрисана!");
                                    break;
                                case Jezici.UK:
                                    MessageBox.Show("The stage deleted successfully!");
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
                                    MessageBox.Show("Došlo je do greške pri brisanju scene!");
                                    break;
                                case Jezici.SRBC:
                                    MessageBox.Show("Дошло је до грешке при брисању сцене!");
                                    break;
                                case Jezici.UK:
                                    MessageBox.Show("An error occurred while deleting the stage!");
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    catch (FaultException<string> ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    Refresh(vazecaTabela);
                    break;
                case Tabele.Termin:
                    try
                    {
                        int id_predstave = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                        int id_scene = (int)dataGridView1.SelectedRows[0].Cells[1].Value;
                        DateTime datum_odrzavanja = (DateTime)dataGridView1.SelectedRows[0].Cells[2].Value;
                        int broj_prodatih_karata = (int)dataGridView1.SelectedRows[0].Cells[3].Value;
                        TimeSpan vreme_odrzavanja = (TimeSpan)dataGridView1.SelectedRows[0].Cells[4].Value;

                        Termin brisanje = new Termin(id_predstave, id_scene, datum_odrzavanja, broj_prodatih_karata, vreme_odrzavanja);

                        string text = "", naslov = "";

                        switch (jezik)
                        {
                            case Jezici.SRBL:
                                text = "Da li ste sigurni da želite da obrišete termin?\n" +
                            "Sve karte kupljene za ovaj termin će biti obrisane.";
                                naslov = "Potvrda";
                                break;
                            case Jezici.SRBC:
                                text = "Да ли сте сигурни да желите да обришете термин?\n" +
                            "Све карте купљене за овај термин ће бити обрисане.";
                                naslov = "Потврда";
                                break;
                            case Jezici.UK:
                                text = "Are you sure you want to delete the appointment?\n" +
                            "All of the cards which contains selected appointment will also be deleted.";
                                naslov = "Assurance";
                                break;
                            default:
                                break;
                        }

                        if (MessageBox.Show(text, naslov, MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }

                        if (Pomocna.Proxy.ObrisiTermin(brisanje))
                        {
                            switch (jezik)
                            {
                                case Jezici.SRBL:
                                    MessageBox.Show("Termin je uspešno obrisan!");
                                    break;
                                case Jezici.SRBC:
                                    MessageBox.Show("Термин је успешно обрисан!");
                                    break;
                                case Jezici.UK:
                                    MessageBox.Show("The appointment deleted successfully!");
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
                                    MessageBox.Show("Došlo je do greške pri brisanju termina!");
                                    break;
                                case Jezici.SRBC:
                                    MessageBox.Show("Дошло је до грешке при брисању термина!");
                                    break;
                                case Jezici.UK:
                                    MessageBox.Show("An error occurred while deleting the appointment!");
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    catch (FaultException<string> ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    Refresh(vazecaTabela);
                    break;
                default:
                    break;
            }
        }
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Refresh(vazecaTabela);
        }

        private void Refresh(Tabele tabela)
        {
            parametri.Clear();

            foreach(Control c in panelTabeleSubmenu.Controls)
            {
                c.BackColor = Color.FromArgb(51, 61, 79);
            }

            switch (tabela)
            {
                case Tabele.Gledalac:
                    dataGridView1.DataSource = Pomocna.Proxy.SviGledaoci().ToList();
                    parametri.Add("Ime");
                    parametri.Add("Prezime");
                    parametri.Add("E-mail");
                    buttonGledaoci.BackColor = Color.FromArgb(61, 73, 94);
                    break;
                case Tabele.Predstava:
                    dataGridView1.DataSource = Pomocna.Proxy.SvePredstave().ToList();
                    parametri.Add("Naziv");
                    parametri.Add("Trajanje");
                    buttonPredstave.BackColor = Color.FromArgb(61, 73, 94);
                    break;
                case Tabele.Karta:
                    dataGridView1.DataSource = Pomocna.Proxy.SveKarte().ToList();
                    parametri.Add("Broj sedista");
                    parametri.Add("ID predstave");
                    parametri.Add("ID scene");
                    parametri.Add("ID gledaoca");
                    parametri.Add("Datum odrzavanja");
                    buttonKarte.BackColor = Color.FromArgb(61, 73, 94);
                    break;
                case Tabele.Scena:
                    dataGridView1.DataSource = Pomocna.Proxy.SveScene().ToList();
                    parametri.Add("Naziv");
                    parametri.Add("Kapacitet");
                    buttonScene.BackColor = Color.FromArgb(61, 73, 94);
                    break;
                case Tabele.Termin:
                    dataGridView1.DataSource = Pomocna.Proxy.SviTermini().ToList();
                    parametri.Add("ID predstave");
                    parametri.Add("ID scene");
                    parametri.Add("Datum odrzavanja");
                    parametri.Add("Broj prodatih karata");
                    parametri.Add("Vreme odrzavanja");
                    buttonTermini.BackColor = Color.FromArgb(61, 73, 94);
                    break;
                default:
                    break;
            }

            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
            toolStripComboBox2.DataSource = parametri.ToList();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (uspesnoLogovanje)
            {
                string text = "";
                string naslov = "";

                switch (jezik)
                {
                    case Jezici.SRBL:
                        text = "Da li zaista želite da zaustavite program!";
                        naslov = "Potvrdi izlaz";
                        break;
                    case Jezici.SRBC:
                        text = "Да ли заиста желите да зауставите програм!";
                        naslov = "Потврди излаз";
                        break;
                    case Jezici.UK:
                        text = "Are you sure you want to close the program?";
                        naslov = "Assurance";
                        break;
                    default:
                        break;
                }

                if (MessageBox.Show(text, naslov, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("Server");

            processes[0].Kill();
        }

        private void toolStripTextBoxPretraga_TextChanged(object sender, EventArgs e)
        {
            Pretraga();
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            toolStripTextBoxPretraga.Visible = false;
            toolStripTextBoxPretraga.Enabled = false;
            toolStripTextBoxPretraga.Clear();
            toolStripComboBox2.Visible = false;
            toolStripComboBox2.Enabled = false;
        }

        private void prikazPredstavaZaIzabraniDatumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPredstaveZaIzabraniDatum predstaveZaIzabraniDatum = new FormPredstaveZaIzabraniDatum(jezik);
            predstaveZaIzabraniDatum.ShowDialog();
        }

        private void prikazPredstavaKojeJeKorisnikGledaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPredstaveGledaoca predstaveGledaoca = new FormPredstaveGledaoca(jezik);
            predstaveGledaoca.ShowDialog();
        }

        private void prikazPredstavaKojeTrajuManjeIliViseOdOdredjeneMinutazeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTrajanjePredstave trajanjePredstave = new FormTrajanjePredstave(jezik);
            trajanjePredstave.ShowDialog();
        }

        private void pomocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPomoc pomoc = new FormPomoc(jezik);
            pomoc.ShowDialog();
        }

        private void oAplikacijiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOAplikaciji oAplikaciji = new FormOAplikaciji(jezik);
            oAplikaciji.ShowDialog();
        }

        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pretraga();
        }

        private void Pretraga()
        {

            string parametar = "";
            string pretraga = toolStripTextBoxPretraga.Text;

            switch (vazecaTabela)
            {
                case Tabele.Gledalac:

                    switch ((string)toolStripComboBox2.SelectedItem)
                    {
                        case "Ime":
                            parametar = "ime";
                            break;
                        case "Prezime":
                            parametar = "prezime";
                            break;
                        case "E-mail":
                            parametar = "email";
                            break;
                        default:
                            break;
                    }

                    List<Gledalac> gledaoci = Pomocna.Proxy.PretragaGledalaca(pretraga, parametar);
                    dataGridView1.DataSource = gledaoci.ToList();

                    break;

                case Tabele.Predstava:

                    switch ((string)toolStripComboBox2.SelectedItem)
                    {
                        case "Naziv":
                            parametar = "naziv_predstave";
                            break;
                        case "Trajanje":
                            parametar = "trajanje";
                            break;
                        default:
                            break;
                    }

                    List<Predstava> predstave = Pomocna.Proxy.PretragaPredstava(pretraga, parametar);
                    dataGridView1.DataSource = predstave.ToList();

                    break;

                case Tabele.Karta:

                    switch ((string)toolStripComboBox2.SelectedItem)
                    {
                        case "Broj sedista":
                            parametar = "broj_sedista";
                            break;
                        case "ID predstave":
                            parametar = "id_predstave";
                            break;
                        case "ID scene":
                            parametar = "id_scene";
                            break;
                        case "ID gledaoca":
                            parametar = "id_gledaoca";
                            break;
                        case "Datum odrzavanja":
                            parametar = "datum_odrzavanja";
                            break;
                        default:
                            break;
                    }

                    List<Karta> karte = Pomocna.Proxy.PretragaKarata(pretraga, parametar);
                    dataGridView1.DataSource = karte.ToList();

                    break;

                case Tabele.Scena:

                    switch ((string)toolStripComboBox2.SelectedItem)
                    {
                        case "Naziv":
                            parametar = "naziv_scene";
                            break;
                        case "Kapacitet":
                            parametar = "kapacitet";
                            break;
                        default:
                            break;
                    }

                    List<Scena> scene = Pomocna.Proxy.PretragaScena(pretraga, parametar);
                    dataGridView1.DataSource = scene.ToList();

                    break;

                case Tabele.Termin:

                    switch ((string)toolStripComboBox2.SelectedItem)
                    {
                        case "ID predstave":
                            parametar = "id_predstave";
                            break;
                        case "ID scene":
                            parametar = "id_scene";
                            break;
                        case "Datum odrzavanja":
                            parametar = "datum_odrzavanja";
                            break;
                        case "Broj prodatih karata":
                            parametar = "broj_prodatih_karata";
                            break;
                        case "Vreme odrzavanja":
                            parametar = "vreme_odrzavanja";
                            break;
                        default:
                            break;
                    }

                    List<Termin> termini = Pomocna.Proxy.PretragaTermina(pretraga, parametar);
                    dataGridView1.DataSource = termini.ToList();

                    break;

                default:
                    break;
            }
        }

        private void buttonTabele_Click(object sender, EventArgs e)
        {
            if (!panelTabeleSubmenu.Visible)
            {
                panelTabeleSubmenu.Visible = true;
            }
            else
            {
                panelTabeleSubmenu.Visible = false;
            }
        }

        private void buttonPodesavanja_Click(object sender, EventArgs e)
        {
            if (!panelPodesavanjaSubmenu.Visible)
            {
                panelPodesavanjaSubmenu.Visible = true;
            }
            else
            {
                panelPodesavanjaSubmenu.Visible = false;
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = String.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            Bitmap x = (Bitmap)buttonPodesavanja.Image;
            Bitmap y = (Bitmap)buttonTabele.Image;
            x.MakeTransparent();
            y.MakeTransparent();

            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;

            Bitmap a = (Bitmap)toolStripButtonDodaj.Image;
            a.MakeTransparent();

            Bitmap b = (Bitmap)toolStripButtonIzmeni.Image;
            b.MakeTransparent();

            Bitmap c = (Bitmap)toolStripButtonBrisi.Image;
            c.MakeTransparent();

            Bitmap d = (Bitmap)buttonPretraga.Image;
            d.MakeTransparent();
        }

        private void buttonIzborTabele_Click(object sender, EventArgs e)
        {
            panelTools.Visible = true;
            buttonPretraga.Visible = true;
            Button btn = sender as Button;
            switch (btn.Name)
            {
                case "buttonGledaoci":
                    vazecaTabela = Tabele.Gledalac;
                    break;
                case "buttonPredstave":
                    vazecaTabela = Tabele.Predstava;
                    break;
                case "buttonKarte":
                    vazecaTabela = Tabele.Karta;
                    break;
                case "buttonScene":
                    vazecaTabela = Tabele.Scena;
                    break;
                case "buttonTermini":
                    vazecaTabela = Tabele.Termin;
                    break;
                default:
                    break;
            }

            Refresh(vazecaTabela);
        }

        private void buttonJezik_Click(object sender, EventArgs e)
        {
            FormJezik formJezik = new FormJezik();
            formJezik.ShowDialog();
            jezik = formJezik.Jezik;
            OsveziJezik();
        }

        private void OsveziJezik()
        {

            switch (jezik)
            {
                case Jezici.SRBL:
                    labelPozoriste.Text = "P O Z O R I Š T E";
                    buttonTabele.Text = "  Tabele";
                    buttonPodesavanja.Text = " Podešavanja";
                    buttonGledaoci.Text = "Gledaoci";
                    buttonPredstave.Text = "Predstave";
                    buttonKarte.Text = "Karte";
                    buttonScene.Text = "Scene";
                    buttonTermini.Text = "Termini";
                    buttonJezik.Text = "Jezik";
                    buttonOaplikaciji.Text = "O aplikaciji";
                    buttonPomoc.Text = "Pomoć";
                    labelDodatneOpcije.Text = "DODATNE OPCIJE";
                    labelDodatneOpcije.Padding = new Padding(40, 1, 0, 0);
                    panelLogo.Padding = new Padding(25, 25, 0, 0);
                    break;
                case Jezici.SRBC:
                    labelPozoriste.Text = "П О З О Р И Ш Т Е";
                    buttonTabele.Text = "  Табеле";
                    buttonPodesavanja.Text = " Подешавања";
                    buttonGledaoci.Text = "Гледаоци";
                    buttonPredstave.Text = "Представе";
                    buttonKarte.Text = "Карте";
                    buttonScene.Text = "Сцене";
                    buttonTermini.Text = "Термини";
                    buttonJezik.Text = "Језик";
                    buttonOaplikaciji.Text = "O апликацији";
                    buttonPomoc.Text = "Помоћ";
                    labelDodatneOpcije.Text = "ДОДАТНЕ ОПЦИЈЕ";
                    labelDodatneOpcije.Padding = new Padding(37, 1, 0, 0);
                    panelLogo.Padding = new Padding(15, 25, 0, 0);
                    break;
                case Jezici.UK:
                    labelPozoriste.Text = "T H E A T E R";
                    buttonTabele.Text = "  Tables";
                    buttonPodesavanja.Text = " Settings";
                    buttonGledaoci.Text = "Watchers";
                    buttonPredstave.Text = "Shows";
                    buttonKarte.Text = "Tickets";
                    buttonScene.Text = "Stages";
                    buttonTermini.Text = "Appointments";
                    buttonJezik.Text = "Language";
                    buttonOaplikaciji.Text = "About";
                    buttonPomoc.Text = "Help";
                    labelDodatneOpcije.Text = "ADDITIONAL FEATURES";
                    labelDodatneOpcije.Padding = new Padding(20, 1, 0, 0);
                    panelLogo.Padding = new Padding(40, 25, 0, 0);
                    break;
                default:
                    break;
            }
        }

        private void buttonPretraga_Click(object sender, EventArgs e)
        {
            if (!panelAlatiZaPretragu.Visible)
            {
                panelAlatiZaPretragu.Visible = true;
            }
            else
            {
                panelAlatiZaPretragu.Visible = false;
            }

            if (!panelDodatneOpcije.Visible)
            {
                panelDodatneOpcije.Visible = true;
            }
            else
            {
                panelDodatneOpcije.Visible = false;
            }
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonMaximize_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
