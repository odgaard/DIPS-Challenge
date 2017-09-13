using System;
namespace DIPS_Challenge
{
    public class Person : IPerson
    {
        private string _name;
        private Account[] _accounts;
        private int _accountSerialNumber;
        public Person(string name, Account[] accounts)
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
                return _accounts;
            }

            set
            {
                _accounts = accounts;
            }
        }

        public void incrementSerialNumber()
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

    }
}