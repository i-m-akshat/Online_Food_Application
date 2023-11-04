using System.Security.Cryptography;
using System.Text;

namespace OnlineFastFoodDelivery.Utilites
{
    public static class _passSecurity
    {
       
        const int keySize = 64;
        const int iteration = 350000;
       private static readonly HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
        //public static string Hashpassword(string Password,out byte[] salt)
        //{
        //    salt=RandomNumberGenerator.GetBytes(keySize);
        //    var hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(Password), salt, iteration, hashAlgorithm, keySize);
        //    return string.Join('#', Convert.ToHexString(hash), Convert.ToHexString(salt), iteration, hashAlgorithm);
        //}
        public static string Hashpassword(string Password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(keySize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(Password), salt, iteration, hashAlgorithm, keySize);
            return string.Join('#', Convert.ToHexString(hash), Convert.ToHexString(salt), iteration, hashAlgorithm);
        }
        public static bool verify(string Password,string hashString) 
        {
            string[] segments = hashString.Split('#');
            byte[] hash = Convert.FromHexString(segments[0]);
            byte[] salt = Convert.FromHexString(segments[1]);
            int iterations = int.Parse(segments[2]);
           HashAlgorithmName _hashalgoName = new HashAlgorithmName(segments[3]);
            byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(Password, salt, iterations, _hashalgoName, hash.Length);
            return CryptographicOperations.FixedTimeEquals(inputHash, hash);    
            //var hashTocompare = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(Password), salt, iteration, hashAlgorithm, keySize);
            //return CryptographicOperations.FixedTimeEquals(hashTocompare, Convert.FromHexString(hash));
        }
    }
}
