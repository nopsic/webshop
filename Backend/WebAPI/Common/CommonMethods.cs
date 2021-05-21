using Microsoft.Extensions.Configuration;
using System;
using System.Text;

namespace WebAPI.Common
{
    public static class CommonMethods
    {
        public static string myKey = "$Łł93duirz{#8ke3";

        public static string EncryptPassword(string psw)
        {
            if (string.IsNullOrEmpty(psw))
            {
                return "";
            }

            psw += myKey;

            var pswBytes = Encoding.UTF8.GetBytes(psw);

            return Convert.ToBase64String(pswBytes);
        }

        public static string DecryptPassword(string encodedData)
        {
            if (string.IsNullOrEmpty(encodedData))
            {
                return "";
            }

            var encodedBytes = Convert.FromBase64String(encodedData);

            var decryptedPassword = Encoding.UTF8.GetString(encodedBytes);

            decryptedPassword = decryptedPassword.Substring(0, decryptedPassword.Length - myKey.Length);

            return decryptedPassword;
        }
    }
}
