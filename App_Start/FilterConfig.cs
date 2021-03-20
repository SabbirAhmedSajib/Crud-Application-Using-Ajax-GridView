using System.Web;
using System.Web.Mvc;

namespace Crud_Application_Using_Ajax_GridView
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
