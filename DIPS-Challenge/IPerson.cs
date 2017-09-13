using System;
namespace DIPS_Challenge
{
    public interface IPerson
    {

        void IncrementAccountSerialNumber();

        string Name
        {
            get;
            set;
        }

        Account[] Accounts
        {
            get;
        }


        int AccountSerialNumber
        {
            get;
        }
    }
}