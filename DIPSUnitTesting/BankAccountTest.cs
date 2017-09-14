using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DIPS_Challenge
{

    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void PersonCreate()
        {
            // Setup test variables
            var testUser = new Person("Test User");

            // Perform test
            Assert.AreEqual(testUser.Name, "Test User");
        }    
    }

    [TestClass]
    public class MoneyTest
    {
        [TestMethod]
        public void MoneyCreate()
        {
            // Setup test variables
            decimal testAmount = 1000;

            // Setup test objects
            var testMoney = new Money(testAmount);

            // Perform test
            Assert.AreEqual(testMoney.Value, testAmount);
        }
    }

    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void AccountCreate()
        {
            // Setup test variables
            decimal testAmount = 1000;
            var testUserName = "Test User";

            // Setup test objects
            var testUser = new Person(testUserName);
            var testMoney = new Money(testAmount);
            var testAccount = new Account(testMoney, testUser);

            // Perform test
            Assert.AreEqual(testAccount.Money.Value, testMoney.Value);
        }
    }

    [TestClass]
    public class BankTest
    {

        private const string _testBankName = "DNB";
        private const string _testPerson1Name = "Jacob Tørring";
        private const string _testPerson2Name = "Erik Ormevik";
        private const decimal _testMoneyAccount1Amount = 1000;
        private const decimal _testMoneyAccount2Amount = 1000;

        [TestMethod]
        public void BankConstructor()
        {
            // Setup test objects
            var testBank = new Bank(_testBankName);

            // Assert
            Assert.AreEqual(_testBankName, testBank.BankName);
        }

        [TestMethod]
        public void BankCreateAccountPass()
        {
            // Setup test variables
            decimal testMoneyPersonAmount = 1600;

            // Setup test objects
            var testBank = new Bank(_testBankName);
            var testPerson = new Person(_testPerson1Name);
            var testMoneyAccount = new Money(_testMoneyAccount1Amount);
            var testMoneyPerson = new Money(testMoneyPersonAmount);
            var testAccount = new Account(testMoneyAccount, testPerson);

            // Perform test
            testPerson.Money = testMoneyPerson;
            testBank.CreateAccount(testPerson, testMoneyAccount);

            // Assert
            int testPersonAccountsIndex = testPerson.Accounts.Length - 1;

            // The new account has been created and added to person
            Assert.AreEqual(
                testAccount.Money.Value,
                testPerson.Accounts[testPersonAccountsIndex].Money.Value
                );

            // The new account contains the amount deposited
            Assert.AreEqual(
                _testMoneyAccount1Amount,                                   // The value to deposit
                testPerson.Accounts[testPersonAccountsIndex].Money.Value    // The value contained in the person's newest account
                );
                
            // The person's savings has been reduced accordingly
            Assert.AreEqual(
                testPerson.Money.Value,                                     // The current value of personal savings
                testMoneyPersonAmount - testPerson.Accounts[0].Money.Value  // The personal savings before creation - the value
                );                                                          // in person's newest account
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BankCreateAccountFail()
        {
            // Setup test variables
            decimal testMoneyPersonAmount = 800;

            // Setup test objects
            var testBank = new Bank(_testBankName);
            var testPerson = new Person(_testPerson1Name);
            var testMoneyAccount = new Money(_testMoneyAccount1Amount);
            var testMoneyPerson = new Money(testMoneyPersonAmount);

            // Perform test
            testPerson.Money = testMoneyPerson;

            // Assert
            // Expected to throw ArgumentOutOfRangeException
            testBank.CreateAccount(testPerson, testMoneyAccount);
        }

        [TestMethod]
        public void BankGetAccountsForCustomer()
        {
            // Setup test variables
            decimal testMoneyWithdrawAmount = 300;

            // Setup test objects
            var testBank = new Bank(_testBankName);
            var testPerson = new Person(_testPerson1Name);
            var testMoneyAccount = new Money(_testMoneyAccount1Amount);
            var testMoneyWithdraw = new Money(testMoneyWithdrawAmount);
            var testAccount = new Account(testMoneyAccount, testPerson);

            // Perform test
            testPerson.AddAccounts(testAccount);

            // Assert
            int testPersonAccountsIndex = testPerson.Accounts.Length - 1;

            Assert.AreEqual(
                testAccount, 
                testBank.GetAccountsForCustomer(testPerson)[testPersonAccountsIndex]
                );
        }

        [TestMethod]
        public void BankWithdraw()
        {
            // Setup test variables
            decimal testMoneyWithdrawAmount = 300;

            // Setup test objects
            var testBank = new Bank(_testBankName);
            var testPerson = new Person(_testPerson1Name);
            var testMoneyAccount = new Money(_testMoneyAccount1Amount);
            var testMoneyWithdraw = new Money(testMoneyWithdrawAmount);
            var testAccount = new Account(testMoneyAccount, testPerson);

            // Perform test
            testBank.Withdraw(testAccount, testMoneyWithdraw);

            // Assert
            Assert.AreEqual(
                testAccount.Money.Value, 
                _testMoneyAccount1Amount - testMoneyWithdrawAmount
                );
        }

        [TestMethod]
        public void BankDeposit()
        {
            // Setup test variables
            decimal testMoneyDepositAmount = 300;

            // Setup test objects
            var testBank = new Bank(_testBankName);
            var testPerson = new Person(_testPerson1Name);
            var testMoneyDeposit = new Money(testMoneyDepositAmount);
            var testMoneyAccount = new Money(_testMoneyAccount1Amount);
            var testAccount = new Account(testMoneyAccount, testPerson);

            // Perform test
            testBank.Deposit(testAccount, testMoneyDeposit);
        
            // Assert
            Assert.AreEqual(
                testAccount.Money.Value,
                _testMoneyAccount1Amount + testMoneyDepositAmount
                );
        }

        [TestMethod]
        public void BankTransfer()
        {
            // Setup test variables
            decimal testMoneyTransferAmount = 300;

            // Setup test objects
            var testBank = new Bank(_testBankName);

            var testPerson1 = new Person(_testPerson1Name);
            var testPerson2 = new Person(_testPerson2Name);

            var testMoneyAccount1 = new Money(_testMoneyAccount1Amount);
            var testMoneyAccount2 = new Money(_testMoneyAccount2Amount);
            var testMoneyTransfer = new Money(testMoneyTransferAmount);

            var testAccount1 = new Account(testMoneyAccount1, testPerson1);
            var testAccount2 = new Account(testMoneyAccount2, testPerson2);

            // Perform test
            // Transfer FROM testAccount1 TO testAccount2 WITH testMoneyTransfer
            testBank.Transfer(testAccount1, testAccount2, testMoneyTransfer);

            // Assert
            Assert.AreEqual(
                testAccount1.Money.Value,
                _testMoneyAccount1Amount - testMoneyTransferAmount
                );

            Assert.AreEqual(
                testAccount2.Money.Value,
                _testMoneyAccount1Amount + testMoneyTransferAmount
                );
        } 
    }
}