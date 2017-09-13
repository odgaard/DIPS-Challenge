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
            System.Console.WriteLine(testMoney.value);
            var name = Console.ReadLine();
        }
    }
}
