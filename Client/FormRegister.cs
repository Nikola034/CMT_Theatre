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
    public partial class FormRegister : Form
    {
        List<Korisnik> korisnici = Korisnik.SviKorisnici();
        public FormRegister()
        {
            InitializeComponent();
            CenterToScreen();
        }

        public string User { get; set; }

        private void buttonPotvrdi_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxIme.Text) && !String.IsNullOrEmpty(textBoxPrezime.Text) &&
                !String.IsNullOrEmpty(textBoxKorisnickoIme.Text) && !String.IsNullOrEmpty(textBoxLozinka.Text))
            {
                string ime = textBoxIme.Text;
                string prezime = textBoxPrezime.Text;
                string korisnickoIme = textBoxKorisnickoIme.Text;
                string lozinka = textBoxLozinka.Text;

                if (DaLiSadrziKorisnickoIme(korisnickoIme))
                {
                    MessageBox.Show("Vec postoji korisnik sa unetim korisnickim imenom!");
                    return;
                }

                Korisnik novi = new Korisnik(ime, prezime, korisnickoIme, lozinka);

                korisnici.Add(novi);

                Korisnik.SacuvajKorisnike(korisnici);

                User = novi.KorisnickoIme;

                MessageBox.Show("Uspesno ste se registrovali!");

                this.Close();
            }
        }

        private bool DaLiSadrziKorisnickoIme(string korisnickoIme)
        {
            foreach(Korisnik k in korisnici)
            {
                if(k.KorisnickoIme == korisnickoIme)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
