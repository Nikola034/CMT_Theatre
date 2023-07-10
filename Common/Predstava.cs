using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Common
{
    [DataContract]
    public class Predstava
    {
        int id;
        string naziv;
        int trajanje;

        public Predstava()
        {
            Id = -1;
            Naziv = "";
            Trajanje = -1;
        }

        public Predstava(string naziv, int trajanje)
        {
            Id = -1;
            Naziv = naziv;
            Trajanje = trajanje;
        }

        public Predstava(int id, string naziv, int trajanje)
        {
            Id = id;
            Naziv = naziv;
            Trajanje = trajanje;
        }

        [DataMember]
        public int Id { get => id; set => id = value; }
        [DataMember]
        public string Naziv { get => naziv; set => naziv = value; }
        [DataMember]
        public int Trajanje { get => trajanje; set => trajanje = value; }

        public override string ToString()
        {
            return id + " " + naziv + " " + trajanje;
        }
    }
}
