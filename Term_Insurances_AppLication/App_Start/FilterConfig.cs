using System.Web;
using System.Web.Mvc;

namespace Term_Insurances_AppLication
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
