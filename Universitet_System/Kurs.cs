namespace Universitet_System
{
    public class Kurs
    {
        public string Kurskode { get; set; }
        public string Kursnavn { get; set; }
        public int Studiepoeng { get; set; }
        public int MaxAntallStudenter { get; set; }

        public List<Student> Deltakere { get; set; } = new List<Student>();

        public Kurs(string kurskode, string kursnavn, int studiepoeng, int maxAntallStudenter)
        {
            Kurskode = kurskode;
            Kursnavn = kursnavn;
            Studiepoeng = studiepoeng;
            MaxAntallStudenter = maxAntallStudenter;
        }

        public bool MeldPå(Student student)
        {
            if (Deltakere.Count >= MaxAntallStudenter)
            {
                Console.WriteLine("Kurset er fullt.");
                return false;
            }

            if (Deltakere.Contains(student))
            {
                Console.WriteLine("Studenten er allerede påmeldt.");
                return false;
            }

            Deltakere.Add(student);
            Console.WriteLine($"Student {student.Brukernavn} er meldt på {Kursnavn}.");
            return true;
        }

        public bool MeldAv(Student student)
        {
            if (!Deltakere.Contains(student))
            {
                Console.WriteLine("Studenten er ikke påmeldt.");
                return false;
            }

            Deltakere.Remove(student);
            Console.WriteLine($"Student {student.Brukernavn} er meldt av {Kursnavn}.");
            return true;
        }

        public void PrintDetaljer()
        {
            Console.WriteLine($"{Kurskode} - {Kursnavn} ({Studiepoeng} stp)");
            Console.WriteLine($"Antall studenter: {Deltakere.Count}/{MaxAntallStudenter}");
        }

        public override string ToString()
        {
            return $"{Kurskode} - {Kursnavn} ({Studiepoeng} stp)";
        }
    }
}
