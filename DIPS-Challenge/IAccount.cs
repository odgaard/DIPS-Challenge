using System;
namespace DIPS_Challenge
{
    public interface IAccount
    {
        Money money
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
