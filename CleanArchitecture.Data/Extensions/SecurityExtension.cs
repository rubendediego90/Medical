using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using XSystem.Security.Cryptography;

namespace CleanArchitecture.Infrastructure.Extensions
{
    public static class SecurityExtension
    {
        public static string EncryptMd5(this string valor)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(valor);
            data = x.ComputeHash(data);
            string resp = "";
            for (int i = 0; i < data.Length; i++)
                resp += data[i].ToString("x2").ToLower();
            return resp;
        }
    }
}
