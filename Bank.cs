using System;
namespace Bank
{
    public interface IBankable
    {
        Account CreateAccount(Person customer, Money initialDeposit);
        Account[] GetAccountsForCustomer(Person customer);
        void Deposit(Account to, Money amount);
        void Withdraw(Account from, Money amount);
        void Transfer(Account from, Account to, Money amount);
    }

    public interface ICurrency
    {
      decimal value
      {
        get;
        set;
      }
    }

    public interface IPerson
    {
      string name
      {
        get;
        set;
      }

      Account[] accounts
      {
        get;
        set;
      }
    }

    public interface IAccount
    {
      Money value
      {
        get;
        set;
      }
      Person owner
      {
        get;
        set;
      }
    }

    public class Bank : IBankable
    {
      Account CreateAccount(Person customer, Money initialDeposit)
      {
        Money total;
        foreach (var account in this.GetAccountsForCustomer(customer))
        {
          total +=  account.amount;
        }
        if(total < initialDeposit) {
          throw new ArgumentOutOfRangeException("Insufficient funds");
        }

        var accounts = this.GetAccountsForCustomer(customer);
        var name = customer.name + accounts.Length + 1;
        return accounts.Add(new Account(customer, name, initialDeposit));
      }

      Account[] GetAccountsForCustomer(Person customer){
        return customer.accounts;
      }

      void Deposit(Account to, Money amount){
        foreach (var account in this.GetAccountsForCustomer(to.customer)){
          if (to == account){

          }
        }
      }
    }


    public class Money : ICurrency
    {

      private decimal _value;
      public Money(decimal value)
      {
        _value = value;
      }

      public decimal value
      {
        get
        {
          return _value;
        }

        set
        {
          _value = value;
        }
      }
    }

    public class Person : IPerson
    {
      private string _name;
      private Account[] _accounts;
      public Person(string name, Account[] accounts)
      {
        _name = name;
        _accounts = accounts;
      }

      public string name
      {
        get
        {
          return _name;
        }

        set
        {
          _name = name;
        }
      }

      public Account[] accounts
      {
        get
        {
          return _accounts;
        }

        set
        {
          _accounts = accounts;
        }
      }
    }

    class Account : IAccount
    {
      private Money _value;
      private Person _owner;
      public Account(Money value, Person owner)
      {
        _value = value;
        _owner = owner;
      }

      public Money value
      {
        get
        {
          return _value;
        }

        set
        {
          _value = value;
        }
      }

      public Person owner
      {
        get
        {
          return _owner;
        }

        set
        {
          _owner = owner;
        }
      }
    }

    class ExecuteBank
    {
      static void Main(string[] args) 
      {
         
      }
    }
}