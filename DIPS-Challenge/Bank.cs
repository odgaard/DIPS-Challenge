using System;
namespace DIPS_Challenge
{
    public class Bank : IBankable
    {
        public Bank(string name)
        {
            BankName = name;
        }

        public Account CreateAccount(Person customer, Money initialDeposit)
        {
            var newAccount = new Account(new Money(0), customer);
            Transfer(customer, newAccount, initialDeposit);
            customer.AddAccounts(newAccount);
            return newAccount;
        }

        public Account[] GetAccountsForCustomer(Person customer) => customer.Accounts;

        private void ValidateTransfer(Fund from, Fund to, Money amount) {
            from.ValidateWithdraw(amount);
            to.ValidateDeposit(amount);
        }
        
        private void PerformTransfer(Fund from, Fund to, Money amount)
        {
            from.Withdraw(amount);
            to.Deposit(amount);
        }

        public void Deposit(Fund to, Money amount) {
            to.Deposit(amount);
        }

        public void Withdraw(Fund from, Money amount)
        {
            from.Withdraw(amount);
        }

        public void Transfer(Fund from, Fund to, Money amount)
        {
            ValidateTransfer(from, to, amount);
            PerformTransfer(from, to, amount);
        }

        public string BankName { get; set; }
    }
}
