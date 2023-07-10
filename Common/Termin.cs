using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Common
{
    [DataContract]
    public class Termin
    {
        int id_predstave;
        int id_scene;
        DateTime datumOdrzavanja;
        int broj_prodatih_karata;
        TimeSpan vreme_odrzavanja;

        public Termin()
        {
            Id_predstave = -1;
            Id_scene = -1;
            DatumOdrzavanja = DateTime.Now;
            Broj_prodatih_karata = -1;
            Vreme_odrzavanja = new TimeSpan(0, 0, 0);
        }

        public Termin(int id_predstave, int id_scene, DateTime datumOdrzavanja, int broj_prodatih_karata, TimeSpan vreme_odrzavanja)
        {
            Id_predstave = id_predstave;
            Id_scene = id_scene;
            DatumOdrzavanja = datumOdrzavanja;
            Broj_prodatih_karata = broj_prodatih_karata;
            Vreme_odrzavanja = vreme_odrzavanja;
        }

        [DataMember]
        public int Id_predstave { get => id_predstave; set => id_predstave = value; }
        [DataMember]
        public int Id_scene { get => id_scene; set => id_scene = value; }
        [DataMember]
        public DateTime DatumOdrzavanja { get => datumOdrzavanja; set => datumOdrzavanja = value; }
        [DataMember]
        public int Broj_prodatih_karata { get => broj_prodatih_karata; set => broj_prodatih_karata = value; }
        [DataMember]
        public TimeSpan Vreme_odrzavanja { get => vreme_odrzavanja; set => vreme_odrzavanja = value; }
    }
}
