using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdresseMail;

namespace TestMail
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string attendu = "Il n'y a pas de '.'";

            string resultat;
            resultat = Program.CheckMail("dude@gmailcom");

            Assert.AreEqual(resultat, attendu);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string attendu = "Il n'y a pas de '@'";

            string resultat;
            resultat = Program.CheckMail("dudegmail.com");

            Assert.AreEqual(resultat, attendu);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string attendu = "Il y a moins de 2 caractères avant le '@'";

            string resultat;
            resultat = Program.CheckMail("d@gmail.com");

            Assert.AreEqual(resultat, attendu);
        }

        [TestMethod]
        public void TestMethod4()
        {
            string attendu = "Il y a moins de 2 caractères entre le '@' et le '.'";

            string resultat;
            resultat = Program.CheckMail("dude@g.com");

            Assert.AreEqual(resultat, attendu);
        }

        [TestMethod]
        public void TestMethod5()
        {
            string attendu = "Il y a moins de 2 caractères après le '.'";

            string resultat;
            resultat = Program.CheckMail("dude@gmail.c");

            Assert.AreEqual(resultat, attendu);
        }

        [TestMethod]
        public void TestMethod6()
        {
            string attendu = "La partie avant '@' ne convient pas !";

            string resultat;
            resultat = Program.CheckMail("dude+/*@gmail.com");

            Assert.AreEqual(resultat, attendu);
        }

        [TestMethod]
        public void TestMethod7()
        {
            string attendu = "La partie entre '@' et '.' ne convient pas !";

            string resultat;
            resultat = Program.CheckMail("dude@gmail+/*.com");

            Assert.AreEqual(resultat, attendu);
        }

        [TestMethod]
        public void TestMethod8()
        {
            string attendu = "La partie après '.' ne convient pas !";

            string resultat;
            resultat = Program.CheckMail("dude@gmail.com+/*");

            Assert.AreEqual(resultat, attendu);
        }

        [TestMethod]
        public void TestMethod9()
        {
            string attendu = "OK";

            string resultat;
            resultat = Program.CheckMail("dude@gmail.com");

            Assert.AreEqual(resultat, attendu);
        }
    }
}
