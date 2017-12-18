using System;
using System.Collections.Generic;
namespace DIPS_Challenge
{
    public class Person : Fund
    {
        private List<Account> accounts;
        private int accountSerialNumber;

        public Person(string name) : this(new Money(0), name)
        {
        }

        public Person(Money initialDeposit, string name) : base(initialDeposit)
        {
            base.Name = name;
            accountSerialNumber = 0;
            accounts = new List<Account>();
        }

        public Account[] Accounts => accounts.ToArray();

        public int AccountSerialNumber => accountSerialNumber;

        public void AddAccounts(Account newAccount) => accounts.Add(newAccount);

        public void IncrementAccountSerialNumber() => ++accountSerialNumber;
    }
}