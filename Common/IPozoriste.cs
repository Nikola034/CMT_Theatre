using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Common
{
    [ServiceContract]
    public interface IPozoriste
    {
        [OperationContract]
        [FaultContract(typeof(string))]
        List<Gledalac> SviGledaoci();

        [OperationContract]
        [FaultContract(typeof(string))]
        List<Karta> SveKarte();

        [OperationContract]
        [FaultContract(typeof(string))]
        List<Predstava> SvePredstave();

        [OperationContract]
        [FaultContract(typeof(string))]
        List<Scena> SveScene();

        [OperationContract]
        [FaultContract(typeof(string))]
        List<Termin> SviTermini();

        [OperationContract]
        [FaultContract(typeof(string))]
        bool DodajGledaoca(Gledalac gledalac);

        [OperationContract]
        [FaultContract(typeof(string))]
        bool DodajKartu(Karta karta);

        [OperationContract]
        [FaultContract(typeof(string))]
        List<DateTime> DatumiTermina(int id_predstave, int id_scene);

        [OperationContract]
        [FaultContract(typeof(string))]
        bool DodajPredstavu(Predstava predstava);

        [OperationContract]
        [FaultContract(typeof(string))]
        bool DodajTermin(Termin termin);

        [OperationContract]
        [FaultContract(typeof(string))]
        bool DodajScenu(Scena scena);

        [OperationContract]
        [FaultContract(typeof(string))]
        bool ObrisiGledaoca(int id);

        [OperationContract]
        [FaultContract(typeof(string))]
        bool ObrisiKartu(int id);

        [OperationContract]
        [FaultContract(typeof(string))]
        bool ObrisiPredstavu(int id);

        [OperationContract]
        [FaultContract(typeof(string))]
        bool ObrisiScenu(int id);

        [OperationContract]
        [FaultContract(typeof(string))]
        bool ObrisiTermin(Termin termin);

        [OperationContract]
        [FaultContract(typeof(string))]
        bool IzmeniGledaoca(Gledalac gledalac);

        [OperationContract]
        [FaultContract(typeof(string))]
        bool IzmeniKartu(Karta karta);

        [OperationContract]
        [FaultContract(typeof(string))]
        bool IzmeniPredstavu(Predstava predstava);

        [OperationContract]
        [FaultContract(typeof(string))]
        bool IzmeniScenu(Scena scena);

        [OperationContract]
        [FaultContract(typeof(string))]
        bool IzmeniTermin(Termin termin, Termin stari);

        [OperationContract]
        [FaultContract(typeof(string))]
        List<Gledalac> PretragaGledalaca(string s, string parametar);

        [OperationContract]
        [FaultContract(typeof(string))]
        List<Karta> PretragaKarata(string s, string parametar);

        [OperationContract]
        [FaultContract(typeof(string))]
        List<Predstava> PretragaPredstava(string s, string parametar);

        [OperationContract]
        [FaultContract(typeof(string))]
        List<Scena> PretragaScena(string s, string parametar);

        [OperationContract]
        [FaultContract(typeof(string))]
        List<Termin> PretragaTermina(string s, string parametar);

        [OperationContract]
        [FaultContract(typeof(string))]
        List<Predstava> PredstaveZaIzabraniDatum(DateTime datum);

        [OperationContract]
        [FaultContract(typeof(string))]
        List<Predstava> PredstaveGledaoca(int id_gledaoca);

        [OperationContract]
        [FaultContract(typeof(string))]
        List<Predstava> PredstavePoTrajanju(int trajanje, char znak);
    }
}
