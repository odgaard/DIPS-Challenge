namespace DIPS_Challenge
{
    internal class Money
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
}