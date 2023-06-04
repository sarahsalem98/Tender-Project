using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.Intrinsics.Arm;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using TenderProject.Models;

namespace TenderProject.Helpers
{
    public class Auth
    {
        public string HashPassword(string password)
        {
            if (!password.IsNullOrEmpty())
            {
                SHA256 hash = SHA256.Create();
                var passwordBytes = Encoding.Default.GetBytes(password);
                var hashedPassword = hash.ComputeHash(passwordBytes);
                return Convert.ToHexString(hashedPassword);
            }
            else
            {
                return null;

            }
        }

        public bool ValidatePassword(string hashedPassword, string password)
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
    public static class AuthUser
    {
        public static string GetAuthenticatedUserString(this IPrincipal principal)
        {
            var claimIdentity = (ClaimsIdentity)principal.Identity;
            var userId = claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userRole = claimIdentity.FindFirst(ClaimTypes.Role).Value;

            if (userId != null)
            {
                return "Role" + ":" + userRole + "," + "Id" + ":" + userId;

            }
            else
            {
                return null;
            }
        }
        //public static Employee GetAuthenticatedUser(this IPrincipal principal)
        //{
        //    var claimIdentity = (ClaimsIdentity)principal.Identity;
        //    var userId = claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;


        //}
    }

}


