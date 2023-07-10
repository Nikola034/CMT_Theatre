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
    public partial class FormPomoc : Form
    {
        Jezici jezik;
        public FormPomoc(Jezici jezik = Jezici.SRBL)
        {
            this.jezik = jezik;
            InitializeComponent();
            CenterToScreen();

            switch (jezik)
            {
                case Jezici.SRBL:
                    this.Text = "Pomoć";
                    labelPomoc.Text = "Pomoć";
                    richTextBoxPomoc.Text = "Pri pokretanju programa potrebno je uneti odgovarajuće korisničko ime i lozinku. Ukoliko korisnik nema " +
                        "nalog, klikom na labelu ispod polja za unos može napraviti novi. Ako se korisnik ne prijavi ili registruje, program će se " +
                        "ugasiti. Nakon uspešnog prijavljivanja, otvara se forma za prikaz i obradu tabela iz baze podataka. Na vrhu forme " +
                        "nalazi traka sa alatima sledećim alatima - dodaj, izmeni, briši i pretraga. Na levoj strani forme, nalaze se dva dugmeta - Tabele i Podešavanja. " +
                        "Klikom na dugme Tabele korisnik može izabrati nad kojom tabelom će biti izvršavane operacije. Klikom na dugme Podešavanja, pojavljuju se tri dugmeta" +
                        " - Jezik, O aplikaciji i Popmoć. " +
                        "Klikom na dugme Dodaj, pojavljuje se forma za dodavanje novog podatka." +
                        " Ako forma ne bude pravilno popunjena program će obavestiti korisnika i izbaciti grešku. Nakon uspešnog popunjavanja forme " +
                        "podatak će biti upisan u bazu podataka, kao i u tabelu za prikaz. Ukoliko korisnik želi da izmeni ili obriše podatak, mora " +
                        "da ga selektuje. Klikom na dugme Izmeni, korisnik dobija uvid u formu za izmenu selektovanog podatka. Klikom na dugme Briši" +
                        " korisnik će morati da potvrdi svoj izbor i podatak će biti obrisan. Klikom na dugme u obliku lupe, korisnik će dobiti " +
                        "pristup padajućem meniju sa parametrima pretrage, kao i polje za pretragu. Svaka promena u polju za pretragu ili u padajućem" +
                        " meniju sa parametrima, izazvaće promenu izlaznih podataka. U meniju sa dodatnim opcijama, korisnik može da bira " +
                        "između tri opcije i na osnovu njegovog izbora, na ekranu se pojavljuje odgovarajuća forma. Na desnoj strani menija sa alatima" +
                        " nalazi se korisničko ime prijavljenog korisnika. Pri unosu svakog podatka, veoma je važno obratiti pažnju na tip podatka," +
                        " odnosno na to da li je podatak broj ili niz karaktera. Program će sprečiti svaki pogrešan unos i obavestiti korisnika o " +
                        "tome. Zavšretak rada programa postiže se klikom na dugme u obliku slova X, u gornjem desnom uglu forme.";
                    break;
                case Jezici.SRBC:
                    this.Text = "Помоћ";
                    labelPomoc.Text = "Помоћ";
                    richTextBoxPomoc.Text = "При покретању програма потребно је унети одговарајуће корисничко име и лозинку. Уколико корисник нема " +
                        "налог, кликом на лабелу испод поља за унос може направити нови. Ако се корисник не пријави или региструје, програм ће се " +
                        "угасити. Након успешног пријављивања, отвара се форма за приказ и обраду табела из базе података. На врху форме " +
                        "налази трака са алатима следећим алатима - додај, измени, бриши и претрага. На левој страни форме, налазе се два дугмета - Табеле и Подешавања. " +
                        "Кликом на дугме Табеле корисник може изабрати над којом табелом ће бити извршаване операције. Кликом на дугме Подешавања, појављују се три дугмета - " +
                        "Језик, О апликацији и Помоћ. " +
                        "Кликом на дугме Додај, појављује се форма за додавање новог податка." +
                        " Ако форма не буде правилно попуњена програм ће обавестити корисника и избацити грешку. Након успешног попуњавања форме " +
                        "податак ће бити уписан у базу података, као и у табелу за приказ. Уколико корисник жели да измени или обрише податак, мора " +
                        "да га селектује. Кликом на дугме Измени, корисник добија увид у форму за измену селектованог податка. Кликом на дугме Бриши" +
                        " корисник ће морати да потврди свој избор и податак ће бити обрисан. Кликом на дугме у облику лупе, корисник ће добити " +
                        "приступ падајућем менију са параметрима претраге, као и поље за претрагу. Свака промена у пољу за претрагу или у падајућем" +
                        " менију са параметрима, изазваће промену излазних података. У менију са додатним опцијама, корисник може да бира " +
                        "између три опције и на основу његовог избора, на екрану се појављује одговарајућа форма. На десној страни менија са алатима" +
                        " налази се корисничко име пријављеног корисника. При уносу сваког податка, веома је важно обратити пажњу на тип податка," +
                        " односно на то да ли је податак број или низ карактера. Програм ће спречити сваки погрешан унос и обавестити корисника о " +
                        "томе. Завшретак рада програма постиже се кликом на дугме у облику слова X, у горњем десном углу форме.";   
                    break;
                case Jezici.UK:
                    this.Text = "User guide";
                    labelPomoc.Text = "User guide";
                    richTextBoxPomoc.Text = "When the program is started, it's necessary to input valid username and password. If the user has no " +
                        "account, by clicking on the label bellow, he can make a new one. If the user doesn't log-in or register, the program will" +
                        " shut down. After successful logging-in, the main form for data reviewing and processing will be displayed to the user. " +
                        "At the top of the form, there is toolbar with these buttons: Add, Edit, Delete and Search. On the left side of the form, " +
                        " there are two buttons - Tables and Settings. By clicking on the button Tables, the user can select table to manipulate. " +
                        "By clicking on the button Settings, buttons Language, About and Help will be displayed. By clicking on the button Add, the form for adding new data will be displayed." +
                        " If the user doesn't fill this form correctly, the program will inform him about mistake. After successull filling the form" +
                        ", a new data will be saved to database as well as in the table for review. If the user wants to edit or delete data, he " +
                        "must select it. By clicking on the button Edit, the form for editing selected data will be displayed. By clicking on the " +
                        "button Delete, the user will have to confirm his choice and selected data will be deleted. By clicking on the magnifier button" +
                        "(Search), the user will get access to the dropdown menu for selecting the parameter of search as well as the field for searching." +
                        " Every change in dropdown menu or searching field will affect the search results. In the dropdown menu for selecting additional features, the user can choose between three options and" +
                        " the corresponding form will be displayed, based on user's choice. On the right side of the toolbar, there is username of " +
                        "the logged user. When entering each data, you must pay attention on its type, that is, whether it is number or array of " +
                        "characters. The program will prevent every incorrect input and inform user about that. The end of program operation is " +
                        "achieved by clicking on the X-shapped button, in the upper-right corner of the form.";
                    break;
                default:
                    break;
            }
        }
    }
}
