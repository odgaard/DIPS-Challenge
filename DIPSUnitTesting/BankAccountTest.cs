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
            var testUser = new Person("Test User");

            Assert.AreEqual(testUser.Name, "Test User");
        }    
    }

    [TestClass]
    public class MoneyTest
    {
        [TestMethod]
        public void MoneyPositive()
        {
            decimal testAmount = 1;

            var testMoney = new Money(testAmount);

            Assert.AreEqual(testMoney.Value, testAmount);
        }

        [TestMethod]
        public void MoneyZero()
        {
            decimal testAmount = 0;

            var testMoney = new Money(testAmount);

            Assert.AreEqual(testMoney.Value, testAmount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MoneyNegative()
        {
            decimal testAmount = -1;

            var testMoney = new Money(testAmount);

            Assert.AreEqual(testMoney.Value, testAmount);
        }
    }

    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void AccountCreate()
        {
            decimal testAmount = 1;
            var testUserName = "Test User";

            var testUser = new Person(testUserName);
            var testMoney = new Money(testAmount);
            var testAccount = new Account(testMoney, testUser);

            Assert.AreEqual(testAccount.Balance.Value, testMoney.Value);
        }
    }

    class BankTestSetup
    {
        public BankTestSetup(string bankName = "DNB", string person1Name = "Jacob Tørring",
            string person2Name = "Erik Ormevik", decimal person1Fund = 1, decimal person2Fund = 1,
            decimal account1Fund = 0, decimal account2Fund = 0)
        {
            Bank = new Bank(bankName);

            Person1Money = new Money(person1Fund);
            Person2Money = new Money(person2Fund);
            Person1 = new Person(Person1Money , person1Name);
            Person2 = new Person(Person2Money, person2Name);

            Account1Money = new Money(account1Fund);
            Account2Money = new Money(account2Fund);
            Account1 = new Account(Account1Money, Person1);
            Account2 = new Account(Account2Money, Person2);
        }

        public Bank Bank { get; set; }
        public Money Person1Money { get; set; }
        public Money Person2Money { get; set; }
        public Money Account1Money { get; set; }
        public Money Account2Money { get; set; }
        public Person Person1 { get; set; }
        public Person Person2 { get; set; }
        public Account Account1 { get; set; }
        public Account Account2 { get; set; }
    }

    [TestClass]
    public class BankTest
    {
        [TestMethod]
        public void BankConstructor()
        {
            string bankName = "DNB";

            var testBank = new Bank(bankName);

            Assert.AreEqual(bankName, testBank.BankName);
        }

        [TestMethod]
        public void BankCreateAccountPass()
        {
            var setup = new BankTestSetup();

            setup.Bank.CreateAccount(setup.Person1, setup.Person1Money);

            int testPersonAccountsIndex = setup.Person1.Accounts.Length - 1;

            // The new account contains the amount deposited
            Assert.AreEqual(
                setup.Person1Money.Value,                                   
                setup.Person1.Accounts[testPersonAccountsIndex].Balance.Value
                );
            
            // The person's savings has been reduced accordingly
            Assert.AreEqual(
                setup.Person1.Balance.Value,                                     
                setup.Person1Money.Value - setup.Person1.Accounts[0].Balance.Value 
                );                                                          
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BankCreateAccountInsufficientFunds()
        {
            var setup = new BankTestSetup();

            // Expected to throw ArgumentException
            setup.Bank.CreateAccount(setup.Person1, new Money(setup.Person1.Balance.Value + 1));
        }

        [TestMethod]
        public void BankGetAccountsForCustomer()
        {
            var setup = new BankTestSetup();

            Assert.AreEqual(0, setup.Bank.GetAccountsForCustomer(setup.Person1).Length);

            var testAccount = new Account(new Money(0), setup.Person1);
            setup.Person1.AddAccounts(testAccount);

            int testPersonAccountsIndex = setup.Person1.Accounts.Length - 1;

            Assert.AreEqual(
                testAccount, 
                setup.Bank.GetAccountsForCustomer(setup.Person1)[testPersonAccountsIndex]
                );
        }

        [TestMethod]
        public void BankAccountWithdrawPass()
        {
            var setup = new BankTestSetup(account1Fund:1);

            setup.Bank.Withdraw(setup.Account1, setup.Account1Money);

            Assert.AreEqual(setup.Account1.Balance.Value, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BankAccountWithdrawInsufficientFunds()
        {
            var setup = new BankTestSetup(account1Fund:1);

            // Expected to throw ArgumentException
            setup.Bank.Withdraw(setup.Account1, new Money(setup.Account1Money.Value + 1)); 
        }
 
        [TestMethod]
        public void BankAccountDepositPass()
        {
            var setup = new BankTestSetup();

            setup.Bank.Deposit(setup.Account1, new Money(1));
        
            Assert.AreEqual(
                setup.Account1.Balance.Value,
                setup.Account1Money.Value + 1
                );
        }

        [TestMethod]
        public void BankAccountTransferPass()
        {
            var setup = new BankTestSetup(account1Fund:1, account2Fund:0);

            setup.Bank.Transfer(setup.Account1, setup.Account2, new Money(1));

            Assert.AreEqual(
                setup.Account1.Balance.Value,
                setup.Account1Money.Value - 1
                );

            Assert.AreEqual(
                setup.Account2.Balance.Value,
                setup.Account2Money.Value + 1 
                );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BankAccountTransferInsufficientFunds()
        {
            var setup = new BankTestSetup(account1Fund:0, account2Fund:0);
            
            // Expected to throw ArgumentException
            setup.Bank.Transfer(setup.Account1, setup.Account2, new Money(1));
        }
    }
}