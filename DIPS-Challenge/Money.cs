using System;
namespace DIPS_Challenge
{
    public class Money
    {

        private decimal _value;
        private Person _owner;
        private Account _account;
        public Money(decimal value)
        {

            _value = value;
        }

        public decimal value
        {
            get
            {
                return _value;
            }

            set
            {
                _value = value;
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
    }
}