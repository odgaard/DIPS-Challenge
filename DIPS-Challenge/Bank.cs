using System;
namespace DIPS_Challenge
{
    public class Bank : IBankable
    {
        // Comment?
        public Account CreateAccount(Person customer, Money initialDeposit)
        {
            throw new NotImplementedException();
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

        private bool _validTransferTransaction(Account from, Account to, Money amount)
        {
            return (
                _validWithdrawTransaction(from, amount) &&
                _validDepositTransaction(to, amount)
                );
        }

        // This method only supports one type of currency. 
        // Please update the Money Interface and Class before implementing support for multiple currencies
        private void _performDepositTransaction(Account transfer, Money amount)
        {
            transfer.money.value += amount.value;
        }

        private void _performWithdrawTransaction(Account transfer, Money amount)
        {
            transfer.money.value -= amount.value;    
        }

        // This method only supports one type of currency through _requestOwnerHasSufficientFunds
        // Please update the Money Interface and Class before implementing support for multiple currencies

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
    }
}