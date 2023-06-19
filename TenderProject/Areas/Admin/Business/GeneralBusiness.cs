using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using Tender.DataAccess.Models;
using TenderProject.Areas.Admin.Models;
using TenderProject.Models;

namespace TenderProject.Areas.Admin.Business
{
    public class GeneralBusiness
    {
    

    }

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
    public static class GeneralStaticBusiness
    {
        public static bool CheckPermitedPages(string action, string controller,IHttpContextAccessor httpContext)
        {
            bool hasPermission = false;
            var userPermissions=httpContext.HttpContext.User.FindFirst(c=>c.Type== "Permissions");
            if(userPermissions != null)
            {
                var userPermissionsList = JsonConvert.DeserializeObject<List<Permission>>(userPermissions.Value);

                foreach (var userInfPermitedPage in userPermissionsList)
                {
                    if (userInfPermitedPage.Controller.Trim() == controller.Trim() && userInfPermitedPage.Action.Trim() == action.Trim())
                    {
                        hasPermission = true;
                        return hasPermission;
                    }
                }
            }

           

            return hasPermission;
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
    public static class SessionExtensions
        {
            public static void SetObjectAsJson(this ISession session,string key,object value)
            {
                session.SetString(key,JsonConvert.SerializeObject(value));

            }
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
