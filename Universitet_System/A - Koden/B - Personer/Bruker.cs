namespace Universitet_System
{
    public abstract class Bruker
    {
        public string Epost { get; }
        private string Passord { get; }
        public Rolle Rolle { get; }

        protected Bruker(string epost, string passord, Rolle rolle)
        {
            Epost = epost;
            Passord = passord;
            Rolle = rolle;
        }

        public bool SjekkPassord(string pass) => pass == Passord;
    }
}
