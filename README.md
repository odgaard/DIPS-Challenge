# DIPS-Challenge 2017

This is a development project for my summer internship application to DIPS.

## The Task
Create a class Bank with following methods in C#:
```C#
Account CreateAccount(Person customer, Money initialDeposit)
Account[] GetAccountsForCustomer(Person customer)
void Deposit(Account to, Money amount)
void Withdraw(Account from, Money amount)
void Transfer(Account from, Account to, Money amount)
```

## Current implementation
#### Code style
I have followed [Microsoft's C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions) in the main implementation.
The code also contains few comments because it strives to be self-documenting.

#### Implementation
The implemented solution uses the given interface and seems to solve the problem. 
The other classes are implemented based on the properties of the given interface.
The implemented tests cover 95% of the solution, where the remaining 5% are getters/setters. 

## Suggested improved implementation
In the task the text vaguely suggests a form of user authentication under bulletpoint 1 in the description of Withdraw and Deposit.
The given interface does not allow nicely for such an implementation, and this would have to be discussed with colleagues. 
The leader of the HR department did not comment on this issue. 
In addition to this the concept of a Person object containing Money seems like a bad design choice. 
I would therefore recommend to constrain the creation of new accounts to an initialValue of 0 and then optionally 
specify an account to transfer the money from.

An alteration to the interface that could allow this type of implementation:
#### Suggested interface
```C#
Account CreateAccount(Person customer, Money initialDeposit, Account from)
Account[] GetAccountsForCustomer(Person customer)
void Deposit(Person requestOwner, Account to, Money amount)
void Withdraw(Person requestOwner, Account from, Money amount)
void Transfer(Person requestOwner, Account from, Account to, Money amount)
```

This allows the programmer to check access rights from within the methods.

