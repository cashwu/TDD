using System;
namespace RsaSecureToken
{
    public interface IProfileDao
    {
        string GetPassword(string account);
    }
}
