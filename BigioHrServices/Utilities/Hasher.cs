using System.Security.Cryptography;
using System.Text;

namespace BigioHrServices.Utilities
{
    public static class Hasher
    {
        private static readonly string DefaultPassword = "pegawai";
        private static readonly string DefaultPIN = "101010";
        public static string HashString(string value)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(value);
            byte[] result = MD5.HashData(bytes);
            return Convert.ToBase64String(result);
        }

        public static string HashDefaultPassword()
        {
            return HashString(DefaultPassword);
        }

        public static string HashDefaultPIN()
        {
            return HashString(DefaultPIN);
        }

        public static bool VerifyPassword(string Password, string HashedPassword)
        {
            return HashedPassword == HashString(Password);
        }
    }
}
