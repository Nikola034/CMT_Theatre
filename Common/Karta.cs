using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Common
{
    [DataContract]
    public class Karta
    {
        int id;
        int broj_sedista;
        int id_predstave;
        int id_scene;
        int id_gledaoca;
        DateTime datumOdrzavanja;

        public Karta()
        {
            Id = -1;
            Broj_sedista = -1;
            Id_predstave = -1;
            Id_scene = -1;
            Id_gledaoca = -1;
            DatumOdrzavanja = DateTime.Now;
        }

        public Karta(int broj_sedista, int id_predstave, int id_scene, int id_gledaoca, DateTime datumOdrzavanja)
        {
            Id = -1;
            Broj_sedista = broj_sedista;
            Id_predstave = id_predstave;
            Id_scene = id_scene;
            Id_gledaoca = id_gledaoca;
            DatumOdrzavanja = datumOdrzavanja;
        }

        public Karta(int id, int broj_sedista, int id_predstave, int id_scene, int id_gledaoca, DateTime datumOdrzavanja)
        {
            Id = id;
            Broj_sedista = broj_sedista;
            Id_predstave = id_predstave;
            Id_scene = id_scene;
            Id_gledaoca = id_gledaoca;
            DatumOdrzavanja = datumOdrzavanja;
        }

        [DataMember]
        public int Id { get => id; set => id = value; }
        [DataMember]
        public int Broj_sedista { get => broj_sedista; set => broj_sedista = value; }
        [DataMember]
        public int Id_predstave { get => id_predstave; set => id_predstave = value; }
        [DataMember]
        public int Id_scene { get => id_scene; set => id_scene = value; }
        [DataMember]
        public int Id_gledaoca { get => id_gledaoca; set => id_gledaoca = value; }
        [DataMember]
        public DateTime DatumOdrzavanja { get => datumOdrzavanja; set => datumOdrzavanja = value; }

        public override string ToString()
        {
            return id + " " + broj_sedista + " " + id_predstave + " " + id_scene + " " + id_gledaoca + " " + datumOdrzavanja.ToString();
        }
    }
}
