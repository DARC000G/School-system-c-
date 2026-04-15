using System.Collections.Generic;

namespace Universitet_System
{
    public class Kurs
    {
        public string Kode { get; }
        public string Navn { get; }
        public Faglaerer Faglaerer { get; }
        public int MaksStudenter { get; }

        public List<Student> Studenter { get; } = new();
        public string Pensum { get; set; } = "";
        public Dictionary<Student, string> Karakterer { get; } = new();

        public Kurs(string kode, string navn, Faglaerer faglaerer, int maksStudenter)
        {
            Kode = kode;
            Navn = navn;
            Faglaerer = faglaerer;
            MaksStudenter = maksStudenter;
        }

        public bool MeldPå(Student s)
        {
            if (Studenter.Contains(s)) return false;
            if (Studenter.Count >= MaksStudenter) return false;

            Studenter.Add(s);
            s.KursListe.Add(this);
            return true;
        }

        public bool MeldAv(Student s)
        {
            if (!Studenter.Contains(s)) return false;

            Studenter.Remove(s);
            s.KursListe.Remove(this);
            return true;
        }

        public void SettKarakter(Student s, string karakter)
        {
            if (Studenter.Contains(s))
                Karakterer[s] = karakter;
        }

        public string HentKarakter(Student s)
        {
            return Karakterer.TryGetValue(s, out var k) ? k : "Ingen karakter";
        }

        public override string ToString()
            => $"{Kode} - {Navn} ({Studenter.Count}/{MaksStudenter})";
    }
}
