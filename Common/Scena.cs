using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Common
{
    [DataContract]
    public class Scena
    {
        int id;
        string naziv;
        int kapacitet;

        public Scena()
        {
            Id = -1;
            Naziv = "";
            Kapacitet = -1;
        }

        public Scena(string naziv, int kapacitet)
        {
            Id = -1;
            Naziv = naziv;
            Kapacitet = kapacitet;
        }

        public Scena(int id, string naziv, int kapacitet)
        {
            Id = id;
            Naziv = naziv;
            Kapacitet = kapacitet;
        }

        [DataMember]
        public int Id { get => id; set => id = value; }
        [DataMember]
        public string Naziv { get => naziv; set => naziv = value; }
        [DataMember]
        public int Kapacitet { get => kapacitet; set => kapacitet = value; }

        public override string ToString()
        {
            return id + " " + naziv + " " + kapacitet;
        }
    }
}
