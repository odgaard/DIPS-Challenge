using System;
namespace DIPS_Challenge
{
    public class Bank : IBankable
    {
        private string bankName;

        public Bank(string name)
        {
            BankName = name;
        }

        public Account CreateAccount(Person customer, Money initialDeposit)
        {
            if (ValidPersonWithdrawTransaction(customer, initialDeposit))
            {
                var newAccount = new Account(initialDeposit, customer);
                customer.Money = new Money(customer.Money.Value - initialDeposit.Value);
                customer.AddAccounts(newAccount);
                return newAccount;
            }
            return null;
        }

        public Account[] GetAccountsForCustomer(Person customer) => customer.Accounts;

        // This method only supports one type of currency.
        private bool RequestPersonHasSufficientFunds(Person owner, Money amount) => (owner.Money.Value >= amount.Value);

        // This method only supports one type of currency.
        private bool RequestAccountHasSufficientFunds(Account transfer, Money amount) => (transfer.Money.Value >= amount.Value);

        private bool ValidPersonWithdrawTransaction(Person owner, Money amount)
        {
            if (!RequestPersonHasSufficientFunds(owner, amount))
            {
                throw new ArgumentException("Person has insufficient funds: " + owner.Money.Value + " < " + amount.Value);
            }

            return true;
        }

        private bool ValidAccountWithdrawTransaction(Account transfer, Money amount)
        {
            if (!RequestAccountHasSufficientFunds(transfer, amount))
            {
                throw new ArgumentException("Account has insufficient funds: " + transfer.Money.Value + " < " + amount.Value);
            }

            return true;
        }

        private bool ValidAccountDepositTransaction(Account transfer, Money amount)
        {
            return true;
        }

        private bool ValidAccountTransferTransaction(Account from, Account to, Money amount) => (
               ValidAccountDepositTransaction(to, amount)
            && ValidAccountWithdrawTransaction(from, amount)
            );

        // This method only supports one type of currency.
        private void PerformAccountDepositTransaction(Account transfer, Money amount) => 
            transfer.Money = new Money(transfer.Money.Value + amount.Value);

        // This method only supports one type of currency.
        private void PerformAccountWithdrawTransaction(Account transfer, Money amount) =>
            transfer.Money = new Money(transfer.Money.Value - amount.Value);

        public void Deposit(Account to, Money amount)
        {
            if (ValidAccountDepositTransaction(to, amount))
            {
                PerformAccountDepositTransaction(to, amount);
            }       
        }

        public void Withdraw(Account from, Money amount)
        {
            if(ValidAccountWithdrawTransaction(from, amount))
            {
                PerformAccountWithdrawTransaction(from, amount);
            }
        }

        public void Transfer(Account from, Account to, Money amount)
        {
            if(ValidAccountTransferTransaction(from, to, amount))
            {
                Withdraw(from, amount);
                Deposit(to, amount);
            }
        }

        public string BankName { get => bankName; set => bankName = value; }
    }
}
