using System;
namespace DIPS_Challenge
{
    public class Account : IAccount
    {
        private Money _amount;
        private Person _owner;
        private string _name;
        public Account(Money money, Person owner)
        {
            owner.IncrementAccountSerialNumber();
            _amount = money;
            _owner = owner;
            _name = owner.Name + " " + owner.AccountSerialNumber;
        }

        public Money Money { get => _amount; set => _amount = value; }
     
        public Person Owner { get => _owner; set => _owner = value; }

        public string Name => _name;
    }
}