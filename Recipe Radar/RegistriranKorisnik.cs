using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_Radar
{
    public class RegistriranKorisnik
    {
        private string ime;
        private string prezime;
        private int vozrast;
        private string email;
        private string pol;
        private List<Obrok> omileniObroci;
        private List<Sostojka> kosnickaSostojki;

        public RegistriranKorisnik(string ime, string prezime, int vozrast, string email, string pol)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.vozrast = vozrast;
            this.email = email;
            this.pol = pol;
            this.omileniObroci = new List<Obrok>();
            this.kosnickaSostojki = new List<Sostojka>();
        }

        private void DodadiVoOmileni(Obrok obrok)
        {
            omileniObroci.Add(obrok);
        }

        public void DodadiVoKosnicka(Sostojka sostojka)
        {
            kosnickaSostojki.Add(sostojka);
        }
    }
}
