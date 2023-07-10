using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;

namespace Common
{
    [DataContract]
    public class Korisnik
    {
        string ime;
        string prezime;
        string korisnickoIme;
        string lozinka;
        public Korisnik()
        {
            Ime = "";
            Prezime = "";
            KorisnickoIme = "";
            Lozinka = "";
        }
        public Korisnik(string ime, string prezime, string korisnickoIme, string lozinka)
        {
            Ime = ime;
            Prezime = prezime;
            KorisnickoIme = korisnickoIme;
            Lozinka = lozinka;
        }

        [DataMember]
        public string Ime { get => ime; set => ime = value; }
        [DataMember]
        public string Prezime { get => prezime; set => prezime = value; }
        [DataMember]
        public string KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }
        [DataMember]
        public string Lozinka { get => lozinka; set => lozinka = value; }

        public override string ToString()
        {
            return Ime + " " + Prezime + " " + KorisnickoIme + " " + Lozinka;
        }

        public static List<Korisnik> SviKorisnici()
        {
            List<Korisnik> returnLista = new List<Korisnik>();

            using (StreamReader sr = new StreamReader("Korisnici.txt"))
            {
                string line = "";

                while((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(' ');

                    Korisnik korisnik = new Korisnik();

                    korisnik.Ime = words[0];
                    korisnik.Prezime = words[1];
                    korisnik.KorisnickoIme = words[2];
                    korisnik.Lozinka = words[3];

                    returnLista.Add(korisnik);
                }

                return returnLista;
            }
        }

        public static void SacuvajKorisnike(List<Korisnik> korisnici)
        {
            using(StreamWriter sw = new StreamWriter("Korisnici.txt"))
            {
                foreach(Korisnik k in korisnici)
                {
                    sw.WriteLine(k);
                }
            }
        }
    }
}
