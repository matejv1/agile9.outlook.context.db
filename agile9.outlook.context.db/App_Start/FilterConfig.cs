using System.Web;
using System.Web.Mvc;

namespace agile9.outlook.context.db
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
