namespace Universitet_System
{
    public class UtvekslingStudent : Student
    {
        public string Hjemuniversitet { get; set; }
        public string Land { get; set; }
        public DateTime PeriodeFra { get; set; }
        public DateTime PeriodeTil { get; set; }

        public UtvekslingStudent(
            string studentID,
            string brukernavn,
            string epost,
            string hjemuniversitet,
            string land,
            DateTime fra,
            DateTime til)
            : base(studentID, brukernavn, epost)
        {
            Hjemuniversitet = hjemuniversitet;
            Land = land;
            PeriodeFra = fra;
            PeriodeTil = til;
        }

        public override string ToString()
        {
            return $"Utvekslingsstudent: {Brukernavn} ({StudentID}) fra {Hjemuniversitet}, {Land}";
        }
    }
}
