
namespace Universitet_System
{
    // Student arver fra Bruker
    public class Student : Bruker
    {
        // Studentens unike ID
        public string StudentID { get; set; }

        // Liste over kurs studenten er påmeldt i
        public List<Kurs> KursListe { get; } = new List<Kurs>();

        // konstruktør: når vi lager en student
        public Student(string studentID, string Brukernavn, string epost)
        : base(Brukernavn, epost)
        {
            StudentID = studentID;
        }

        // Fin utskrift når vi skriver ut studenten
        public override string ToString()
        {
            return $"Student: {Brukernavn} (ID: {StudentID}, Epost: {Epost})";
        }
    }
}
