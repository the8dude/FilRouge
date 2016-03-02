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
            string attendu = "dude";

            string str1 = "dude@gmail.com";
            string resultat;
            resultat = Program.strtok(str1, '@', 0);

            Assert.AreEqual(resultat, attendu);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string attendu = "gmail.com";

            string str1 = "dude@gmail.com";
            string resultat;
            resultat = Program.strtok(str1, '@', 0);

            Assert.AreEqual(resultat, attendu);
        }
    }
}
