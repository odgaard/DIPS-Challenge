using System;
using System.Collections.Generic;
namespace DIPS_Challenge
{
    public class Person
    {
        private string name;
        private List<Account> accounts;
        private int accountSerialNumber;
        private Money money;

        public Person(string name)
        {
            this.name = name;
            this.accountSerialNumber = 0;
            this.accounts = new List<Account>();
        }

        public Account[] Accounts => this.accounts.ToArray();

        public int AccountSerialNumber => this.accountSerialNumber;

        public void AddAccounts(Account newAccount) =>
            // This may be too restrictive
            //if(newAccount.owner == this)
            //{
            //    _accounts.Add(newAccount);
            //}

            this.accounts.Add(newAccount);

        public void IncrementAccountSerialNumber() => ++this.accountSerialNumber;

        public string Name { get => this.name; set => this.name = value; }

        public Money Money { get => this.money; set => this.money = value; }
        
    }
}