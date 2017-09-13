using System;

namespace DIPS_Challenge
{
    public interface IBankable
    {
        Account CreateAccount(Person customer, Money initialDeposit);
        Account[] GetAccountsForCustomer(Person customer);
        void Deposit(Account to, Money amount);
        void Withdraw(Account from, Money amount);
        void Transfer(Account from, Account to, Money amount);
    }
}
