using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Data.SqlClient;
using System.ServiceModel;

namespace Server
{
    public class Pozoriste : IPozoriste
    {
        const string _connectionString = "Data source = DESKTOP-4RPKNEU\\SQLEXPRESS ;Initial Catalog = Pozoriste; Integrated Security = true;";

        public List<DateTime> DatumiTermina(int id_predstave, int id_scene)
        {
            List<DateTime> returnLista = new List<DateTime>();

            string query = "SELECT datum_odrzavanja FROM seigranasceni WHERE id_predstave = " + id_predstave + " AND id_scene = " + id_scene;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    returnLista.Add(reader.GetDateTime(0));
                }
            }

            return returnLista;
        }

        public bool DodajGledaoca(Gledalac gledalac)
        {
            string query = "INSERT INTO gledalac(email, ime, prezime) values('" + gledalac.Email + "', '" + gledalac.Ime + "', '"
                + gledalac.Prezime + "')";

            if (IzvrsiKomandu(query) > 0)
            {
                return true;
            }
            return false;
        }

        public bool DodajKartu(Karta karta)
        {
            string query = "INSERT INTO karta(broj_sedista, id_predstave, id_scene, id_gledaoca, datum_odrzavanja) " +
                "values('" + karta.Broj_sedista + "', '" + karta.Id_predstave + "', '" + karta.Id_scene + "', '" +
                karta.Id_gledaoca + "', '" + karta.DatumOdrzavanja + "')";

            if (IzvrsiKomandu(query) > 0)
            {
                OsveziBrojeveProdatihKarata();
                return true;
            }

            return false;
        }

        public bool DodajPredstavu(Predstava predstava)
        {
            string query = "INSERT INTO predstava(naziv_predstave, trajanje) values('" + predstava.Naziv + "', '" + predstava.Trajanje + "')";

            if (IzvrsiKomandu(query) > 0)
            {
                return true;
            }
            return false;
        }

        public bool DodajScenu(Scena scena)
        {
            string query = "INSERT INTO scena(naziv_scene, kapacitet) values('" + scena.Naziv + "', '" + scena.Kapacitet + "')";

            if (IzvrsiKomandu(query) > 0)
            {
                return true;
            }
            return false;
        }

        public bool DodajTermin(Termin termin)
        {
            string query = "INSERT INTO seigranasceni(id_predstave, id_scene, datum_odrzavanja, broj_prodatih_karata, vreme_odrzavanja)" +
                " values('" + termin.Id_predstave + "', '" + termin.Id_scene + "', '" + termin.DatumOdrzavanja + "', '"
                + termin.Broj_prodatih_karata + "', '" + termin.Vreme_odrzavanja + "')";

            if (IzvrsiKomandu(query) > 0)
            {
                return true;
            }
            return false;
        }

        public bool IzmeniGledaoca(Gledalac gledalac)
        {
            string query = "UPDATE gledalac SET email = '" + gledalac.Email + "', ime = '" + gledalac.Ime + "', prezime = '" + gledalac.Prezime
                + "' WHERE id_gledaoca = " + gledalac.Id;

            if (IzvrsiKomandu(query) > 0)
            {
                return true;
            }
            return false;
        }

        public bool IzmeniKartu(Karta karta)
        {
            string query = "UPDATE karta SET broj_sedista = " + karta.Broj_sedista + ", id_predstave = " + karta.Id_predstave +
                ", id_scene = " + karta.Id_scene + ", id_gledaoca = " + karta.Id_gledaoca + ", datum_odrzavanja = '" +
                karta.DatumOdrzavanja.Year + "-" + karta.DatumOdrzavanja.Month + "-" + karta.DatumOdrzavanja.Day + "' WHERE " +
                "id_karte = " + karta.Id;

            if (IzvrsiKomandu(query) > 0)
            {
                OsveziBrojeveProdatihKarata();
                return true;
            }
            return false;
        }

        public bool IzmeniPredstavu(Predstava predstava)
        {
            string query = "UPDATE predstava SET naziv_predstave = '" + predstava.Naziv + "', trajanje = " + predstava.Trajanje + " " +
                "WHERE id_predstave = " + predstava.Id;

            if (IzvrsiKomandu(query) > 0)
            {
                return true;
            }
            return false;
        }

        public bool IzmeniScenu(Scena scena)
        {
            string query = "UPDATE scena SET naziv_scene = '" + scena.Naziv + "' WHERE id_scene = " + scena.Id;

            if (IzvrsiKomandu(query) > 0)
            {
                return true;
            }
            return false;
        }

        public bool IzmeniTermin(Termin termin, Termin stari)
        {
            string query = "UPDATE seigranasceni SET id_predstave = " + termin.Id_predstave + ", id_scene = " + termin.Id_scene + "" +
                ", datum_odrzavanja = '" + termin.DatumOdrzavanja.Year + "-" + termin.DatumOdrzavanja.Month +
                "-" + termin.DatumOdrzavanja.Day + "', vreme_odrzavanja = '" + termin.Vreme_odrzavanja.Hours + ":" +
                termin.Vreme_odrzavanja.Minutes + "' WHERE id_predstave = " + stari.Id_predstave + " AND id_scene = " + stari.Id_scene +
                " AND datum_odrzavanja = '" + stari.DatumOdrzavanja.Year + "-" + stari.DatumOdrzavanja.Month +
                "-" + stari.DatumOdrzavanja.Day + "'";

            if (IzvrsiKomandu(query) > 0)
            {
                return true;
            }
            return false;
        }

        public bool ObrisiGledaoca(int id)
        {
            string query = "DELETE FROM karta WHERE id_gledaoca = " + id;

            int x = IzvrsiKomandu(query);

            OsveziBrojeveProdatihKarata();

            query = "DELETE FROM gledalac WHERE id_gledaoca = " + id;

            if (IzvrsiKomandu(query) > 0)
            {
                return true;
            }
            return false;
        }

        public bool ObrisiKartu(int id)
        {
            string query = "DELETE FROM karta WHERE id_karte = " + id;

            if (IzvrsiKomandu(query) > 0)
            {
                OsveziBrojeveProdatihKarata();
                return true;
            }
            return false;
        }

        public bool ObrisiPredstavu(int id)
        {
            string query = "DELETE FROM karta WHERE id_predstave = " + id;
            int x = IzvrsiKomandu(query);

            query = "DELETE FROM seigranasceni WHERE id_predstave = " + id;
            x = IzvrsiKomandu(query);

            query = "DELETE FROM predstava WHERE id_predstave = " + id;

            if (IzvrsiKomandu(query) > 0)
            {
                return true;
            }
            return false;
        }

        public bool ObrisiScenu(int id)
        {
            string query = "DELETE FROM karta WHERE id_scene = " + id;
            int x = IzvrsiKomandu(query);

            query = "DELETE FROM seigranasceni WHERE id_scene = " + id;
            x = IzvrsiKomandu(query);

            query = "DELETE FROM scena WHERE id_scene = " + id;

            if (IzvrsiKomandu(query) > 0)
            {
                return true;
            }
            return false;
        }

        public bool ObrisiTermin(Termin termin)
        {
            string query = "DELETE FROM karta WHERE id_predstave = " + termin.Id_predstave + " AND id_scene = " + termin.Id_scene +
                " AND datum_odrzavanja = '" + termin.DatumOdrzavanja.Year + "-" + termin.DatumOdrzavanja.Month + "-" +
                termin.DatumOdrzavanja.Day + "'";
            int x = IzvrsiKomandu(query);

            query = "DELETE FROM seigranasceni WHERE id_predstave = " + termin.Id_predstave + " AND id_scene = " + termin.Id_scene +
                " AND datum_odrzavanja = '" + termin.DatumOdrzavanja.Year + "-" + termin.DatumOdrzavanja.Month + "-" +
                termin.DatumOdrzavanja.Day + "'";

            if (IzvrsiKomandu(query) > 0)
            {
                return true;
            }
            return false;
        }

        public List<Karta> SveKarte()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM karta";
                    SqlCommand command = new SqlCommand(query, connection);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Karta> returnLista = new List<Karta>();

                        while (reader.Read())
                        {
                            returnLista.Add(new Karta(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3),
                                reader.GetInt32(4), reader.GetDateTime(5)));
                        }
                        return returnLista;

                    }
                }
            }
            catch (SqlException ex)
            {

                throw new FaultException<string>(ex.Message);
            }
        }

        public List<Predstava> SvePredstave()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM predstava";
                    SqlCommand command = new SqlCommand(query, connection);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Predstava> returnLista = new List<Predstava>();

                        while (reader.Read())
                        {
                            returnLista.Add(new Predstava(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
                        }
                        return returnLista;

                    }
                }
            }
            catch (SqlException ex)
            {

                throw new FaultException<string>(ex.Message);
            }
        }

        public List<Scena> SveScene()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM scena";
                    SqlCommand command = new SqlCommand(query, connection);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Scena> returnLista = new List<Scena>();

                        while (reader.Read())
                        {
                            returnLista.Add(new Scena(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
                        }
                        return returnLista;

                    }
                }
            }
            catch (SqlException ex)
            {

                throw new FaultException<string>(ex.Message);
            }
        }

        public List<Gledalac> SviGledaoci()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM gledalac";
                    SqlCommand command = new SqlCommand(query, connection);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Gledalac> returnLista = new List<Gledalac>();

                        while (reader.Read())
                        {
                            returnLista.Add(new Gledalac(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
                        }
                        return returnLista;

                    }
                }
            }
            catch (SqlException ex)
            {

                throw new FaultException<string>(ex.Message);
            }
        }

        public List<Termin> SviTermini()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM seigranasceni";
                    SqlCommand command = new SqlCommand(query, connection);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Termin> returnLista = new List<Termin>();

                        while (reader.Read())
                        {
                            returnLista.Add(new Termin(reader.GetInt32(0), reader.GetInt32(1), reader.GetDateTime(2), reader.GetInt32(3),
                                reader.GetTimeSpan(4)));
                        }
                        return returnLista;

                    }
                }
            }
            catch (SqlException ex)
            {

                throw new FaultException<string>(ex.Message);
            }
        }

        private void OsveziBrojeveProdatihKarata()
        {
            List<Termin> termini = SviTermini();
            List<Karta> karte = SveKarte();

            foreach(Termin t in termini)
            {
                int broj_prodatih_karata = 0;

                foreach(Karta k in karte)
                {
                    if(k.Id_predstave == t.Id_predstave && k.Id_scene == t.Id_scene && k.DatumOdrzavanja.Year == t.DatumOdrzavanja.Year
                        && k.DatumOdrzavanja.Month == t.DatumOdrzavanja.Month && k.DatumOdrzavanja.Day == t.DatumOdrzavanja.Day)
                    {
                        broj_prodatih_karata++;

                        string query = "UPDATE seigranasceni SET broj_prodatih_karata = " + broj_prodatih_karata + " WHERE id_predstave = " +
                            k.Id_predstave + " AND id_scene = " + k.Id_scene + " AND datum_odrzavanja = '" + k.DatumOdrzavanja.Year + "-" +
                            k.DatumOdrzavanja.Month + "-" + k.DatumOdrzavanja.Day + "'";

                        int x = IzvrsiKomandu(query);
                    }
                }

                if(broj_prodatih_karata == 0)
                {
                    string query2 = "UPDATE seigranasceni SET broj_prodatih_karata = " + broj_prodatih_karata + " WHERE id_predstave = " +
                            t.Id_predstave + " AND id_scene = " + t.Id_scene + " AND datum_odrzavanja = '" + t.DatumOdrzavanja.Year + "-" +
                            t.DatumOdrzavanja.Month + "-" + t.DatumOdrzavanja.Day + "'";

                    int y = IzvrsiKomandu(query2);
                }
            }
        }
        private int IzvrsiKomandu(string query)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);

                    return command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new FaultException<string>(ex.Message);
            }
        }

        public List<Gledalac> PretragaGledalaca(string s, string parametar)
        {
            string query = "SELECT * FROM gledalac WHERE " + parametar + " LIKE '%" + s + "%'";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();

                List<Gledalac> returnLista = new List<Gledalac>();

                while (reader.Read())
                {
                    returnLista.Add(new Gledalac(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
                }
                return returnLista;
            }
        }

        public List<Karta> PretragaKarata(string s, string parametar)
        {
            string query = "";

            if(parametar == "id_predstave" || parametar == "id_scene" || parametar == "broj_sedista" || parametar == "id_gledaoca")
            {
                if(!int.TryParse(s, out int x))
                {
                    return SveKarte();
                }

                query = "SELECT * FROM karta WHERE " + parametar + " = " + x;
            }
            else
            {
                query = "SELECT * FROM karta WHERE " + parametar + " LIKE '%" + s + "%'";
            }

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();

                List<Karta> returnLista = new List<Karta>();

                while (reader.Read())
                {
                    returnLista.Add(new Karta(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3),
                                reader.GetInt32(4), reader.GetDateTime(5)));
                }
                return returnLista;
            }
        }

        public List<Predstava> PretragaPredstava(string s, string parametar)
        {
            string query = "";

            if(parametar == "trajanje")
            {
                if(!int.TryParse(s, out int x))
                {
                    return SvePredstave();
                }

                query = "SELECT * FROM predstava WHERE " + parametar + " = " + x;
            }
            else
            {
                query = "SELECT * FROM predstava WHERE " + parametar + " LIKE '%" + s + "%'";
            }

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();

                List<Predstava> returnLista = new List<Predstava>();

                while (reader.Read())
                {
                    returnLista.Add(new Predstava(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
                }
                return returnLista;
            }
        }

        public List<Scena> PretragaScena(string s, string parametar)
        {
            string query = "";

            if (parametar == "kapacitet")
            {
                if (!int.TryParse(s, out int x))
                {
                    return SveScene();
                }

                query = "SELECT * FROM scena WHERE " + parametar + " = " + x;
            }
            else
            {
                query = "SELECT * FROM scena WHERE " + parametar + " LIKE '%" + s + "%'";
            }

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();

                List<Scena> returnLista = new List<Scena>();

                while (reader.Read())
                {
                    returnLista.Add(new Scena(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
                }
                return returnLista;
            }
        }

        public List<Termin> PretragaTermina(string s, string parametar)
        {
            string query = "";

            if (parametar == "id_predstave" || parametar == "id_scene" || parametar == "broj_prodatih_karata")
            {
                if (!int.TryParse(s, out int x))
                {
                    return SviTermini();
                }

                query = "SELECT * FROM seigranasceni WHERE " + parametar + " = " + x;
            }
            else
            {
                query = "SELECT * FROM seigranasceni WHERE " + parametar + " LIKE '%" + s + "%'";
            }

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();

                List<Termin> returnLista = new List<Termin>();

                while (reader.Read())
                {
                    returnLista.Add(new Termin(reader.GetInt32(0), reader.GetInt32(1), reader.GetDateTime(2), reader.GetInt32(3),
                                reader.GetTimeSpan(4)));
                }
                return returnLista;
            }
        }

        public List<Predstava> PredstaveZaIzabraniDatum(DateTime datum)
        {
            List<Termin> termini = SviTermini();
            List<Predstava> predstave = SvePredstave();
            List<int> predstave_id = new List<int>();

            foreach (Termin t in termini)
            {
                if (t.DatumOdrzavanja.Year == datum.Year && t.DatumOdrzavanja.Month == datum.Month
                    && t.DatumOdrzavanja.Day == datum.Day)
                {
                    predstave_id.Add(t.Id_predstave);
                }
            }

            List<Predstava> returnLista = new List<Predstava>();

            foreach(Predstava p in predstave)
            {
                foreach(int x in predstave_id)
                {
                    if(p.Id == x)
                    {
                        returnLista.Add(p);
                    }
                }
            }

            return returnLista;
        }

        public List<Predstava> PredstaveGledaoca(int id_gledaoca)
        {
            List<Predstava> predstave = SvePredstave();
            List<Predstava> returnLista = new List<Predstava>();
            List<int> predstave_id = new List<int>();

            string query = "SELECT id_predstave FROM karta WHERE id_gledaoca = " + id_gledaoca;

            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        predstave_id.Add(reader.GetInt32(0));
                    }
                }
            }

            foreach(Predstava p in predstave)
            {
                foreach(int x in predstave_id)
                {
                    if(p.Id == x)
                    {
                        returnLista.Add(p);
                    }
                }
            }

            return returnLista;
        }

        public List<Predstava> PredstavePoTrajanju(int trajanje, char znak)
        {
            List<Predstava> predstave = SvePredstave();
            List<Predstava> returnLista = new List<Predstava>();

            switch (znak)
            {
                case '<':
                    foreach(Predstava p in predstave)
                    {
                        if (p.Trajanje < trajanje)
                        {
                            returnLista.Add(p);
                        }
                    }
                    break;
                case '>':
                    foreach (Predstava p in predstave)
                    {
                        if (p.Trajanje > trajanje)
                        {
                            returnLista.Add(p);
                        }
                    }
                    break;
                default:
                    break;
            }

            return returnLista;
        }
    }
}
