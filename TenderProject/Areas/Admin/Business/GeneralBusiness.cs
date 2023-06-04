using Newtonsoft.Json;
using System.Security.Claims;
using Tender.DataAccess.Models;
using TenderProject.Areas.Admin.Models;
using TenderProject.Models;

namespace TenderProject.Areas.Admin.Business
{
    public class GeneralBusiness
    {
    

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
