using System;
namespace DIPS_Challenge
{
    public class Bank : IBankable
    {
        // Comment?
        Account CreateAccount(Person customer, Money initialDeposit)
        {
            if (_requestOwnerHasSufficientFunds(customer, initialDeposit))
            {
                Account newAccount = new Account(customer, initialDeposit);
                var accounts = this.GetAccountsForCustomer(customer);
                accounts.Add(newAccount);
                return newAccount;
            }
            else
            {
                throw ArgumentOutOfRangeException;
            }
        }

        // Comment?
        public Account[] GetAccountsForCustomer(Person customer)
        {
            return customer.accounts;
        }

        // Comment?
        private bool _requestOwnerOwnsAccount(Account transfer, Person requestOwner)
        {
            return transfer.owner == requestOwner;
        }

        // This method only supports one type of currency. 
        // Please update the Money Interface and Class before implementing support for multiple currencies
        private bool _requestAccountHasSufficientFunds(Account transfer, Money amount)
        {
            return transfer.money.value >= amount.value;
        }

        private bool _requestMoneyIsPositive(Money amount)
        {
            return amount.value >= 0;
        }

        private bool _validWithdrawTransaction(Account transfer, Money amount)
        {
            return (
                _requestOwnerOwnsAccount(transfer, amount.owner) && 
                _requestAccountHasSufficientFunds(transfer, amount) && 
                _requestMoneyIsPositive(amount)
                );
        }

        private bool _validDepositTransaction(Account transfer, Money amount)
        {
            return (
                _requestOwnerOwnsAccount(transfer, amount.owner) && 
                _requestMoneyIsPositive(amount)
                );
        }

        // This method only supports one type of currency. 
        // Please update the Money Interface and Class before implementing support for multiple currencies
        private void _performDepositTransaction(Account transfer, Money amount)
        {
            transfer.money.value += amount.value;
            amount.value = 0;
        }

        private void _performWithdrawTransaction(Account transfer, Money amount)
        {
            transfer.money.value -= amount
            
        }

        // This method only supports one type of currency through _requestOwnerHasSufficientFunds
        // Please update the Money Interface and Class before implementing support for multiple currencies

        public Account CreateAccount(Person customer, Money initialDeposit)
        {
            throw new NotImplementedException();
        }

        public void Deposit(Account to, Money amount)
        {
            if (_validTransaction(to, amount))
            {
                _performDepositTransaction(to, amount);
            }
            else
            {

            }
        }

        public void Withdraw(Account from, Money amount)
        {
            throw new NotImplementedException();
        }

        public void Transfer(Account from, Account to, Money amount)
        {
            throw new NotImplementedException();
        }
    }
}