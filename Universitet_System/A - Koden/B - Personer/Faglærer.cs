namespace Universitet_System
{
    public class Faglaerer : Bruker
    {
        public string FagOmråde { get; }

        public Faglaerer(string epost, string passord, string fagOmråde)
            : base(epost, passord, Rolle.Faglaerer)
        {
            FagOmråde = fagOmråde;
        }

        public override string ToString() => $"{Epost} - Faglærer ({FagOmråde})";
    }
}
