using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DIPS_Challenge
{
    [TestClass]
    public class BankAccountTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var testBank = new Bank("DNB");
            var testUser = new Person("Test User");
            Assert.AreNotEqual(testUser.Name, "Test Use");
            Assert.AreEqual(testUser.Name, "Test User");
        }
    }
}
