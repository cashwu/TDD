using System;
namespace RsaSecureToken
{
    public interface IRsaTokenDao
    {
        string GetRandom(string account);
    }
}
