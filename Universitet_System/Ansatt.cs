
namespace Universitet_System
{
    // Ansatt arver fra Bruker
    public class Ansatt : Bruker
    {
        // Ansattes unike ID
        public string AnsattID { get; set; }
        public string Stilling { get; set; }
        public string Avdeling { get; set; }

        // Konstruktør: når vi lager en ansatt
        public Ansatt(string ansattID, string Brukernavn, string epost, string stilling, string avdeling)
        : base(Brukernavn, epost)
        {
            AnsattID = ansattID;
            Stilling = stilling;
            Avdeling = avdeling;
        }

        // Fin utskrift når vi skriver ut den ansatte
        public override string ToString()
        {
            return $"Ansatt: {Brukernavn} (ID: {AnsattID}, Epost: {Epost}, Stilling: {Stilling})";
        }
    }
}