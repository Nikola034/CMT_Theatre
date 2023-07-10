using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class FormOAplikaciji : Form
    {
        Jezici jezik;
        public FormOAplikaciji(Jezici jezik = Jezici.SRBL)
        {
            this.jezik = jezik;
            InitializeComponent();
            CenterToScreen();

            switch (jezik)
            {
                case Jezici.SRBL:
                    this.Text = "O autoru i aplikaciji";
                    labelOaplikaciji.Left = 235;
                    labelOaplikaciji.Text = "O autoru i aplikaciji";
                    richTextBoxOaplikaciji.Text = "\nAutor ove aplikacije, Nikola S. Bandulaja, rođen je 2003. godine u Novom Sadu. Živi" +
                        " u Rumenci, gde je završio osnovnu školu. Upisao je Elektrotehničku školu \"Mihajlo Pupin\" 2018. godine, a smer koji je " +
                        "izabrao je Elektrotehničar informacionih tehnologija. Teži ka tome da ostvari svoju najveću želju, odnosno da se profesionalno bavi" +
                        " programiranjem i ostalim oblastima koje podrazumevaju razvoj softvera. Privatno se bavi lakom industrijom, a slobodno" +
                        " vreme provodi sa porodicom, prijateljima i kolegama.\n\n";

                    richTextBoxOaplikaciji.Text += "Ova aplikacija pruža korisniku jednostavan prikaz podataka o pozorištu. Omogućava " +
                        "i manipulaciju tim podacima, odnosno dodavanje novih podataka i menjanje i brisanje postojećih. Korisnik ima pristup svim " +
                        "tabelama u bazi podataka, kao i mogućnost pretraživanja u okviru tih tabela, po svim parametrima. Od dodatnih " +
                        "funkcionalnosti mogu se izdvojiti prikaz predstava koje se igraju određenog datuma, prikaz predstava određenog gledaoca, kao i " +
                        "predstave koje traju manje ili više od određenog vremena.";
                    break;
                case Jezici.SRBC:
                    this.Text = "О аутору и апликацији";
                    labelOaplikaciji.Left = 235;
                    labelOaplikaciji.Text = "О аутору и апликацији";
                    richTextBoxOaplikaciji.Text = "\nАутор ове апликације, Никола С. Бандулаја, рођен је 2003. године у Новом Саду. Живи у Руменци, " +
                        "где је завршио основну школу. Уписао је Електротехничку школу \"Михајло Пупин\" 2018. године, а смер који је изабрао је Електротехничар " +
                        "информационих технологија. Тежи ка томе да оствари своју највећу жељу, односно да се професионално бави програмирањем и " +
                        "осталим областима које подразумевају развој софтвера. Приватно се бави лаком индустријом, а слободно време проводи са" +
                        " породицом, пријатељима и колегама.\n\n";

                    richTextBoxOaplikaciji.Text += "Ова апликација пружа кориснику једноставан приказ података о позоришту. Омогућава и манипулацију" +
                        " тим подацима, односно додавање нових података и мењање и брисање постојећих. Корисник има приступ свим табелама у бази" +
                        " података, као и могућност претраживања у оквиру тих табела, по свим параметрима. Од додатних функционалности могу се" +
                        " издвојити приказ представа које се играју одређеног датума, приказ представа одређеног гледаоца, као и представе које" +
                        " трају мање или више од одређеног времена.";
                    break;
                case Jezici.UK:
                    this.Text = "About";
                    labelOaplikaciji.Left = 215;
                    labelOaplikaciji.Text = "About author and application";
                    richTextBoxOaplikaciji.Text = "\nThis application was made by Nikola S. Bandulaja, who was born in 2003. in Novi Sad. " +
                        "He lives in Rumenka, where he has finished elementary school. He enrolled in Electrotehnical school \"Mihajlo Pupin\"" +
                        " in 2018. and chose to study Information technology. His main goal is to work as a professional software developer and " +
                        "he is trying hard to reach it. Out of work, he works in light industry and spends his free time with family, friends and" +
                        " colleagues.\n\n";

                    richTextBoxOaplikaciji.Text += "This application gives to the users simple review of theater data. It also allows data " +
                        "manipulation, like adding new data or editing and deleting existing data. The user has access to all of database tables" +
                        " together with search option, by all of the parameters. We can stand out a couple of additional features, such as " +
                        "review of all the shows that was watched by chosen user, review of all the shows that will be played on chosen date and " +
                        "comparing shows by their duration with some value.";
                    break;
                default:
                    break;
            }
        }
    }
}
