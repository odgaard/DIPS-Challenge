using System;

namespace DIPS_Challenge
{
    public interface IBankable
    {
        Account CreateAccount(Person customer, Money initialDeposit);
        Account[] GetAccountsForCustomer(Person customer);
        void Deposit(Fund to, Money amount);
        void Withdraw(Fund from, Money amount);
        void Transfer(Fund from, Fund to, Money amount);
    }
}
