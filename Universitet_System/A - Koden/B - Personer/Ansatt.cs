namespace Universitet_System
{
    // ============================
    //  BASE: ANSATT
    // ============================
    public abstract class Ansatt : Bruker
    {
        public string Avdeling { get; }

        protected Ansatt(string epost, string passord, Rolle rolle, string avdeling)
            : base(epost, passord, rolle)
        {
            Avdeling = avdeling;
        }

        public override string ToString() => $"{Epost} ({Rolle}, {Avdeling})";
    }
}
