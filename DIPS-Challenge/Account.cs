using System;
namespace DIPS_Challenge
{
    public class Account : IFund
    {
        private Money amount;
        private Person owner;
        private string name;
        public Account(Money money, Person owner)
        {
            owner.IncrementAccountSerialNumber();
            this.amount = money;
            this.owner = owner;
            this.name = owner.Name + " " + owner.AccountSerialNumber;
        }

        public Money Money { get => this.amount; set => this.amount = value; }
     
        public Person Owner { get => this.owner; set => this.owner = value; }

        public string Name => this.name;
    }
}