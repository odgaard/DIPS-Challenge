using System;

public interface IBankable
{
    Account CreateAccount(Person customer, Money initialDeposit);
    Account[] GetAccountsForCustomer(Person customer);
    void Deposit(Person requestOwner, Account to, Money amount);
    void Withdraw(Person requestOwner, Account from, Money amount);
    void Transfer(Account from, Account to, Money amount);
}
