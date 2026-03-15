

namespace Universitet_System
{
    // Grunn-klasse som beskriver bruker i systemet
    public class Bruker
    {
        // Felles egenskaper
        public string Brukernavn { get; set; }
        public string Epost { get; set; }

        public Bruker(string brukernavn, string epost)
        {
            Brukernavn = brukernavn;
            Epost = epost;
        }

        public override string ToString()
        {
            return $"{Brukernavn} ({Epost})";
        }

    }
    
}