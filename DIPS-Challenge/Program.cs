using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPS_Challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World");
            decimal testValue = 1000;
            Money testMoney = new Money(testValue);

            var testBank = new Bank("DNB");

            var testPerson = new Person("Jacob Tørring");

            testPerson.Money = testMoney;
            var testAccount = testBank.CreateAccount(testPerson, new Money(200));

            System.Console.WriteLine(testAccount.Name);
            System.Console.WriteLine(testAccount.Money.Value);
            System.Console.WriteLine(testPerson.Money.Value);
            var name = Console.ReadLine();
        }
    }
}
