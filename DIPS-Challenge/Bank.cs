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
            var newAccount = new Account(new Money(0), customer);
            Transfer(customer, newAccount, initialDeposit);
            customer.AddAccounts(newAccount);
            return newAccount;
        }

        public Account[] GetAccountsForCustomer(Person customer) => customer.Accounts;

        // This method only supports one type of currency.
        private bool RequestFundHasSufficientFunds(IFund fund, Money amount) => (fund.Money.Value >= amount.Value);

        private void ValidateWithdrawTransaction(IFund fund, Money amount) {
            if (!RequestFundHasSufficientFunds(fund, amount))
            {
                throw new ArgumentException(String.Format("{0} has insufficient funds to withdraw: {1} < {2}",
                                                fund, fund.Money.Value, amount.Value));
            }
        }

        private void ValidateDepositTransaction(IFund transfer, Money amount)
        {

        }

        private void ValidateTransferTransaction(IFund from, IFund to, Money amount) {
            ValidateDepositTransaction(to, amount);
            ValidateWithdrawTransaction(from, amount);
        }

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

        public void Deposit(IFund to, Money amount)
        {
            ValidateDepositTransaction(to, amount);
            PerformDepositTransaction(to, amount);
        }

        public void Withdraw(IFund from, Money amount)
        {
            ValidateWithdrawTransaction(from, amount); 
            PerformWithdrawTransaction(from, amount);
        }

        public void Transfer(IFund from, IFund to, Money amount)
        {
            ValidateTransferTransaction(from, to, amount);
            PerformTransferTransaction(from, to, amount);
        }

        public string BankName { get => bankName; set => bankName = value; }
    }
}
