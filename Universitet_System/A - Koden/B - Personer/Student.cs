using System.Collections.Generic;

namespace Universitet_System
{
    public class Student : Bruker
    {
        protected static int _teller = 1;

        public string StudentID { get; protected set; }
        public string FulltNavn { get; }
        public List<Kurs> KursListe { get; } = new();

        public Student(string epost, string passord, string fulltNavn = "Student")
            : base(epost, passord, Rolle.Student)
        {
            FulltNavn = fulltNavn;
            StudentID = $"S{_teller:D4}";
            _teller++;
        }

        public override string ToString() => $"{StudentID} - {Epost}";
    }
}
