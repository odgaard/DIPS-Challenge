using System;
namespace DIPS_Challenge
{
    public class Bank : IBankable
    {
        // Comment?
        Account CreateAccount(Person customer, Money initialDeposit)
        {
            if(_requestOwnerHasSufficientFunds(customer, initialDeposit))
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
        Account[] GetAccountsForCustomer(Person customer)
        {
            return customer.accounts;
        }

        // Comment?
        private bool _requestOwnerOwnsAccount(Person requestOwner, Account transfer)
        {
            return transfer.owner == requestOwner;
        }

        // This method only supports one type of currency. 
        // Please update the Money Interface and Class before implementing support for multiple currencies
        private bool _requestOwnerHasSufficientFunds(Person requestOwner, Money amount)
        {
            var requestOwnerAccounts = this.GetAccountsForCustomer(requestOwner);
            foreach (Account account in requestOwnerAccounts)
            {
                _value += account.money.value;
            }
            return _value >= amount.value;
        }

        private bool _validTransaction(Person requestOwner, Account transfer, Money amount)
        {
            return (_requestOwnerOwnsAccount(requestOwner, transfer) && _requestOwnerHasSufficientFunds(requestOwner, amount));
        }

        private bool _performTransaction(Person requestOwner, Account transfer, Money amount)
        {
            _value = 0;
            _money = null;

            foreach (Account account in requestOwnerAccounts)
            {
                _money = account.money;
                _amount -= _money.value;
                if (_amount <= 0)
                {
                    account.money.value -= _amount;
                    to.money.value += amount.value;
                }
                else
                {

                }
            }
        }

        // This method only supports one type of currency through _requestOwnerHasSufficientFunds
        // Please update the Money Interface and Class before implementing support for multiple currencies
        void Deposit(Person requestOwner, Account to, Money amount)
        {
            if (_validTransaction(requestOwner, to, amount))
            {
                _performTransaction(requestOwner, transfer, amount);

            }
        }
    }
}