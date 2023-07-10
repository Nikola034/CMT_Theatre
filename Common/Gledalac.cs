using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Common
{
    [DataContract]
    public class Gledalac
    {
        int id;
        string email;
        string ime;
        string prezime;

        public Gledalac()
        {
            Id = -1;
            Email = "";
            Ime = "";
            Prezime = "";
        }

        public Gledalac(string email, string ime, string prezime)
        {
            Id = -1;
            Email = email;
            Ime = ime;
            Prezime = prezime;
        }

        public Gledalac(int id, string email, string ime, string prezime)
        {
            Id = id;
            Email = email;
            Ime = ime;
            Prezime = prezime;
        }

        [DataMember]
        public int Id { get => id; set => id = value; }
        [DataMember]
        public string Email { get => email; set => email = value; }
        [DataMember]
        public string Ime { get => ime; set => ime = value; }
        [DataMember]
        public string Prezime { get => prezime; set => prezime = value; }

        public override string ToString()
        {
            return id + " " + email + " " + ime + " " + prezime;
        }
    }
}
