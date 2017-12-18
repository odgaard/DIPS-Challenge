using System;
namespace DIPS_Challenge
{
    public abstract class Fund
    {
        private Money balance;

        public Fund(Money initialDeposit)
        {
            balance = initialDeposit;
        }

        public virtual void ValidateWithdraw(Money amount)
        {
            if (!RequestFundHasSufficientFunds(amount))
            {
                throw new ArgumentException(String.Format("{0} has insufficient funds to withdraw: {1} < {2}",
                                                Name, balance.Value, amount.Value));
            }
        }

        public virtual void ValidateDeposit(Money amount)
        {
        }

        public void Deposit(Money amount)
        {
            ValidateDeposit(amount);
            PerformDeposit(amount);
        }

        public void Withdraw(Money amount)
        {
            ValidateWithdraw(amount);
            PerformWithdraw(amount);
        }

        private bool RequestFundHasSufficientFunds(Money amount) => (balance.Value >= amount.Value);

        private void PerformDeposit(Money amount) =>
            balance = new Money(balance.Value + amount.Value);
        private void PerformWithdraw(Money amount) =>
            balance = new Money(balance.Value - amount.Value);

        public Money Balance => this.balance;
        public string Name { get; set; }
    }
}
