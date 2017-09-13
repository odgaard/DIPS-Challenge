using System;
namespace DIPS_Challenge
{
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
}