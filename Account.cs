using System;
namespace DIPS_Challenge
{
    class Account : IAccount
    {
        private Money _amount;
        private Person _owner;
        private string _name;
        public Account(Money money, Person owner)
        {
            _amount = money;
            _owner = owner;
            _name = owner.name + " " + owner.accountSerialNumber;
            owner.incrementSerialNumber();
        }

        public Money money
        {
            get
            {
                return _amount;
            }

            set
            {
                _amount = money;
            }
        }

        public Person owner
        {
            get
            {
                return _owner;
            }

            set
            {
                _owner = owner;
            }
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
    }
}