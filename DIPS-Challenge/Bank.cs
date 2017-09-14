using System;
namespace DIPS_Challenge
{
    public class Bank : IBankable
    {
        private string _bankName;

        public Bank(string name)
        {
            BankName = name;
        }

        public Account CreateAccount(Person customer, Money initialDeposit)
        {
            if (_validPersonWithdrawTransaction(customer, initialDeposit))
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
        private bool _requestPersonHasSufficientFunds(Person owner, Money amount) => (owner.Money.Value >= amount.Value);

        // This method only supports one type of currency.
        private bool _requestAccountHasSufficientFunds(Account transfer, Money amount) => (transfer.Money.Value >= amount.Value);

        private bool _requestMoneyIsPositive(Money amount) => (amount.Value > 0);

        private bool _validPersonWithdrawTransaction(Person owner, Money amount)
        {
            if (!_requestPersonHasSufficientFunds(owner, amount))
            {
                throw new ArgumentOutOfRangeException("Person has insufficient funds: " + owner.Money.Value + " < " + amount.Value);
            }

            if (!_requestMoneyIsPositive(amount))
            {
                throw new ArgumentOutOfRangeException("Invalid value, Negative " + amount.Value);
            }

            return true;
        }

        private bool _validAccountWithdrawTransaction(Account transfer, Money amount)
        {
            if (!_requestAccountHasSufficientFunds(transfer, amount))
            {
                throw new ArgumentOutOfRangeException("Account has insufficient funds: " + transfer.Money.Value + " < " + amount.Value);
            }

            if (!_requestMoneyIsPositive(amount))
            {
                throw new ArgumentOutOfRangeException("Invalid value, Negative " + amount.Value);
            }

            return true;
        }

        private bool _validAccountDepositTransaction(Account transfer, Money amount)
        {
            if (!_requestMoneyIsPositive(amount))
            {
                throw new ArgumentOutOfRangeException("Invalid value, Negative " + amount.Value);
            }

            return true;
        }

        private bool _validAccountTransferTransaction(Account from, Account to, Money amount) => (
                _validAccountWithdrawTransaction(from, amount) &&
                _validAccountDepositTransaction(to, amount)
                );

        // This method only supports one type of currency.
        private void _performAccountDepositTransaction(Account transfer, Money amount) => 
            transfer.Money = new Money(transfer.Money.Value + amount.Value);

        // This method only supports one type of currency.
        private void _performAccountWithdrawTransaction(Account transfer, Money amount) =>
            transfer.Money = new Money(transfer.Money.Value - amount.Value);

        public void Deposit(Account to, Money amount)
        {
            if (_validAccountDepositTransaction(to, amount))
            {
                _performAccountDepositTransaction(to, amount);
            }       
        }

        public void Withdraw(Account from, Money amount)
        {
            if(_validAccountWithdrawTransaction(from, amount))
            {
                _performAccountWithdrawTransaction(from, amount);
            }
        }

        public void Transfer(Account from, Account to, Money amount)
        {
            if(_validAccountTransferTransaction(from, to, amount))
            {
                Withdraw(from, amount);
                Deposit(to, amount);
            }
        }

        public string BankName { get => _bankName; set => _bankName = value; }
    }
}
