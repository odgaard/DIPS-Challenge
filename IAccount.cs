using System;
namespace DIPS_Challenge
{
    public interface IAccount
    {
        Money amount
        {
            get;
            set;
        }
        Person owner
        {
            get;
            set;
        }
    }
}
