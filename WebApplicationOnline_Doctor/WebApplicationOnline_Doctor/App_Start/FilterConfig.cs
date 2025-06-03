using System.Web;
using System.Web.Mvc;

namespace WebApplicationOnline_Doctor
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
