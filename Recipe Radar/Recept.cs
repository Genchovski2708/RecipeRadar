namespace Recipe_Radar
{
    public class Recept
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public int VremeZaGotvenje { get; set; }
        public string Instrukcii { get; set; }
        public List<Sostojka> Sostojki { get; set; }

        public Recept(int id, string ime, int vremeZaGotvenje, string instrukcii, List<Sostojka> sostojki)
        {
            Id = id;
            Ime = ime;
            VremeZaGotvenje = vremeZaGotvenje;
            Instrukcii = instrukcii;
            Sostojki = sostojki;
        }
    }
}