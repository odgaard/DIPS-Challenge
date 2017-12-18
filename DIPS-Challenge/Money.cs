using System;
namespace DIPS_Challenge
{
    public class Money
    {

        private readonly decimal value;

        public Money(decimal value)
        {
            ValidateValue(value);
            this.value = value;
        }

        private void ValidateValue(decimal value)
        {
            if(value < 0)
            {
                throw new ArgumentException("Money's value can't be negative " + value);
            }
        }
        public decimal Value { get => value; }
    }
}