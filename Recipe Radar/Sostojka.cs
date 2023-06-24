namespace Recipe_Radar
{
    public class Sostojka
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public double Kolicina { get; set; }
        public string Edinica { get; set; }
        public HranlivaVrednost HranlivaVrednost { get; set; }

        public Sostojka(int id, string ime, double kolicina, string edinica, HranlivaVrednost hranlivaVrednost)
        {
            Id = id;
            Ime = ime;
            Kolicina = kolicina;
            Edinica = edinica;
            HranlivaVrednost = hranlivaVrednost;
        }
    }
}