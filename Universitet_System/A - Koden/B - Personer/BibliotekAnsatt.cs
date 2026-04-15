namespace Universitet_System
{
    public class BibliotekAnsatt : Bruker
    {
        public string Arbeidssted { get; }

        public BibliotekAnsatt(string epost, string passord, string arbeidssted)
            : base(epost, passord, Rolle.BibliotekAnsatt)
        {
            Arbeidssted = arbeidssted;
        }

        public override string ToString() => $"{Epost} - Bibliotekansatt ({Arbeidssted})";
    }
}
