using System;
namespace DIPS_Challenge
{
    public interface IPerson
    {

        public void incrementAccountSerialNumber();

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


        int accountSerialNumber
        {
            get;
        }
    }
}