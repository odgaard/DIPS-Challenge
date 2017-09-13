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

        public Person(string name, List<Account> accounts)
        {
            _name = name;
            _accounts = accounts;
            _accountSerialNumber = 0;
        }

        public string name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = name;
            }
        }

        public Account[] accounts
        {
            get
            {
                return _accounts.ToArray();
            }
        }

        public void AddAccount(Account newAccount)
        {
            // This may be too restrictive
            /*if(newAccount.owner == this)
            {
                _accounts.Add(newAccount);
            }*/
            _accounts.Add(newAccount);
        }

        public void incrementAccountSerialNumber()
        {
            ++_accountSerialNumber;
        }

        public int accountSerialNumber
        {
            get
            {
                return _accountSerialNumber;
            }
        }

        public Money money
        {
            get
            {
                return _money;
            }
            set
            {
                _money = money;
            }
        }

    }
}