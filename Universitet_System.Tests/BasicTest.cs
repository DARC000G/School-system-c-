using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Universitet_System.Tests
{
    [TestClass]
    public class BasicTests
    {
        [TestMethod]
        public void Student_CannotEnrollSameCourseTwice()
        {
            var fag = new Faglaerer("fag@uni.no", "123", "IT");
            var kurs = new Kurs("IT101", "Testkurs", fag, 30);
            var student = new Student("s@uni.no", "123", "Test Student");

            bool first = kurs.MeldPå(student);
            bool second = kurs.MeldPå(student);

            Assert.IsTrue(first);
            Assert.IsFalse(second);
            Assert.AreEqual(1, kurs.Studenter.Count);
        }

        [TestMethod]
        public void CannotCreateCourseWithDuplicateCode()
        {
            var fag = new Faglaerer("fag@uni.no", "123", "IT");
            var kursListe = new List<Kurs>
            {
                new Kurs("IT101", "Eksisterende", fag, 30)
            };

            bool finnes = kursListe.Exists(k => k.Kode == "IT101");

            Assert.IsTrue(finnes);
        }

        [TestMethod]
        public void Library_PreventsDuplicateActiveLoan()
        {
            var bib = new Bibliotek();
            var bok = new Bok("123", "Testbok", "Forfatter", 2020, 1);
            bib.LeggTilBok(bok);

            var bruker = new Student("s@uni.no", "123", "Test Student");

            bib.LeggTilLån(new Lån(bruker, bok, DateTime.Now));

            Assert.AreEqual(1, bib.LånListe.Count);
        }

        [TestMethod]
        public void RegisterBookAddsToLibrary()
        {
            var bib = new Bibliotek();

            bib.LeggTilBok(new Bok("123", "Testbok", "Forfatter", 2020, 2));

            Assert.AreEqual(1, bib.BokListe.Count);
            Assert.AreEqual("123", bib.BokListe[0].ISBN);
        }
    }
}
