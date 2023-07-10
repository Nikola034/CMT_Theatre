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
    public partial class FormLogin : Form
    {
        List<Korisnik> korisnici = Korisnik.SviKorisnici();
        public FormLogin()
        {
            InitializeComponent();
            CenterToScreen();
        }

        public string User { get; set; }

        private void buttonPotvrdi_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(textBoxKorisnickoIme.Text) && !String.IsNullOrEmpty(textBoxLozinka.Text))
            {
                if (Provera(textBoxKorisnickoIme.Text, textBoxLozinka.Text))
                {
                    User = textBoxKorisnickoIme.Text;
                    MessageBox.Show("Uspesno ste se ulogovali!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ne postoji korisnik sa ovakvim podacima!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Sva polja moraju biti popunjena!");
                return;
            }
        }

        private bool Provera(string korisnickoIme, string lozinka)
        {
            foreach(Korisnik k in korisnici)
            {
                if(k.KorisnickoIme == korisnickoIme && k.Lozinka == lozinka)
                {
                    return true;
                }
            }
            return false;
        }

        private void labelRegister_Click(object sender, EventArgs e)
        {
            FormRegister register = new FormRegister();
            register.ShowDialog();
            User = register.User;
            if (String.IsNullOrEmpty(User))
            {
                return;
            }
            this.Close();
        }
    }
}
