using Microsoft.IdentityModel.Tokens;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace TenderProject.Helpers
{
    public class Auth
    {
        public string HashPassword(string password)
        {
            if(!password.IsNullOrEmpty())
            {
                SHA256 hash = SHA256.Create();
                var passwordBytes=Encoding.Default.GetBytes(password);
                var hashedPassword=hash.ComputeHash(passwordBytes); 
                return Convert.ToHexString(hashedPassword);
            }
            else
            {
            return null;

            }
        }
        public bool ValidatePassword(string hashedPassword,string password)
        {
            if (HashPassword(password) == hashedPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }   
    }
}
