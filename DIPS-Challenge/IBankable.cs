using System;

namespace DIPS_Challenge
{
    public interface IBankable
    {
        Account CreateAccount(Person customer, Money initialDeposit);
        Account[] GetAccountsForCustomer(Person customer);
        void Deposit(IFund to, Money amount);
        void Withdraw(IFund from, Money amount);
        void Transfer(IFund from, IFund to, Money amount);
    }
}
