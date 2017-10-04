using System;
namespace DIPS_Challenge
{
    public class Bank : IBankable
    {
        private string bankName;

        public Bank(string name)
        {
            BankName = name;
        }

        public Account CreateAccount(Person customer, Money initialDeposit)
        {
            if (ValidWithdrawTransaction(customer, initialDeposit))
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
        private bool RequestFundHasSufficientFunds(IFund fund, Money amount) => (fund.Money.Value >= amount.Value);

        private bool ValidWithdrawTransaction(IFund fund, Money amount) => RequestFundHasSufficientFunds(fund, amount);

        private bool ValidDepositTransaction(IFund transfer, Money amount) => true;

        private bool ValidTransferTransaction(IFund from, IFund to, Money amount) => (
               ValidDepositTransaction(to, amount)
            && ValidWithdrawTransaction(from, amount)
            );

        // This method only supports one type of currency.
        private void PerformDepositTransaction(IFund fund, Money amount) => 
            fund.Money = new Money(fund.Money.Value + amount.Value);

        // This method only supports one type of currency.
        private void PerformWithdrawTransaction(IFund fund, Money amount) =>
            fund.Money = new Money(fund.Money.Value - amount.Value);

        private void PerformTransferTransaction(IFund from, IFund to, Money amount)
        {
            PerformWithdrawTransaction(from, amount);
            PerformDepositTransaction(to, amount);
        }

        public void Deposit(Account to, Money amount)
        {
            if (ValidDepositTransaction(to, amount))
            {
                PerformDepositTransaction(to, amount);
            }
            else
            {
                throw new ArgumentException("Unable to deposit to this account");
            }
        }

        public void Withdraw(Account from, Money amount)
        {
            if(ValidWithdrawTransaction(from, amount))
            {
                PerformWithdrawTransaction(from, amount);
            }
            else
            {
                throw new ArgumentException(String.Format("{0} has insufficient funds to withdraw: {1} < {2}",
                                                            from, from.Money.Value, amount.Value));
            }
        }

        public void Transfer(Account from, Account to, Money amount)
        {
            if(ValidTransferTransaction(from, to, amount))
            {
                PerformTransferTransaction(from, to, amount);
            }
            else
            {
                throw new ArgumentException(String.Format("{0} has insufficient funds to transfer to {1}: {2} < {3}",
                                                            from, to, from.Money.Value, amount.Value));
            }
        }

        public string BankName { get => bankName; set => bankName = value; }
    }
}
