using System;
using System.Collections.Generic;
namespace DIPS_Challenge
{
    public class Person : IPerson
    {
        private string _name;
        private List<Account> _accounts;
        private int _accountSerialNumber;
        private Money _money;

        public Person(string name)
        {
            _name = name;
            _accountSerialNumber = 0;
            _accounts = new List<Account>();
        }

        public Account[] Accounts => _accounts.ToArray();

        public int AccountSerialNumber => _accountSerialNumber;

        public void AddAccounts(Account newAccount) =>
            // This may be too restrictive
            /*if(newAccount.owner == this)
            {
                _accounts.Add(newAccount);
            }*/

            _accounts.Add(newAccount);

        public void IncrementAccountSerialNumber() => ++_accountSerialNumber;

        public string Name { get => _name; set => _name = value; }

        public Money Money { get => _money; set => _money = value; }
        
    }
}