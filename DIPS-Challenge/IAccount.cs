using System;
namespace DIPS_Challenge
{
    public interface IAccount
    {
        Money Money
        {
            get;
            set;
        }
        Person Owner
        {
            get;
            set;
        }
        string Name
        {
            get;
        }
    }
}
