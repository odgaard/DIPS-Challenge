using System;
namespace DIPS_Challenge
{
    public class Money
    {

        private readonly decimal _value;

        public Money(decimal value)
        {
            _value = value;
        }

        public decimal Value { get => _value; }
    }
}