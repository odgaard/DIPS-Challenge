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
            if(_requestOwnerHasSufficientFunds(customer, initialDeposit))
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
        private bool _requestOwnerHasSufficientFunds(Person owner, Money amount) => owner.Money.Value >= amount.Value;

        // This method only supports one type of currency.
        private bool _requestAccountHasSufficientFunds(Account transfer, Money amount) => transfer.Money.Value >= amount.Value;

        private bool _requestMoneyIsPositive(Money amount) => amount.Value >= 0;

        private bool _validWithdrawTransaction(Account transfer, Money amount) => (
                _requestAccountHasSufficientFunds(transfer, amount) &&
                _requestMoneyIsPositive(amount)
                );

        private bool _validDepositTransaction(Account transfer, Money amount) => (
                _requestMoneyIsPositive(amount)
                );

        private bool _validTransferTransaction(Account from, Account to, Money amount) => (
                _validWithdrawTransaction(from, amount) &&
                _validDepositTransaction(to, amount)
                );

        // This method only supports one type of currency.
        private void _performDepositTransaction(Account transfer, Money amount) => 
            transfer.Money = new Money(transfer.Money.Value + amount.Value);

        // This method only supports one type of currency.
        private void _performWithdrawTransaction(Account transfer, Money amount) =>
            transfer.Money = new Money(transfer.Money.Value - amount.Value);

        public void Deposit(Account to, Money amount)
        {
            if (_validDepositTransaction(to, amount))
            {
                _performDepositTransaction(to, amount);
            }       
        }

        public void Withdraw(Account from, Money amount)
        {
            if(_validWithdrawTransaction(from, amount))
            {
                _performWithdrawTransaction(from, amount);
            }
        }

        public void Transfer(Account from, Account to, Money amount)
        {
            if(_validTransferTransaction(from, to, amount))
            {
                Withdraw(from, amount);
                Deposit(to, amount);
            }
        }

        public string BankName { get => _bankName; set => _bankName = value; }
    }
}
