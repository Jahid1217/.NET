using System.Web;
using System.Web.Mvc;

namespace WebApplicationCodeFrist
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
