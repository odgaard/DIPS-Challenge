using System;
namespace DIPS_Challenge
{
    public class Account : Fund
    {
        public Account(Money initialDeposit, Person owner) : base(initialDeposit)
        {
            owner.IncrementAccountSerialNumber();
            Owner = owner;
            base.Name = owner.Name + " " + owner.AccountSerialNumber;
        }
        public Person Owner { get; set; }
    }
}