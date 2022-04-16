using Microsoft.AspNetCore.Mvc.Filters;
using DanaZhangCms.Core.Helpers;

namespace DanaZhangCms.Core.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            var type = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType;
            Log4NetHelper.WriteError(type, filterContext.Exception);
            filterContext.ExceptionHandled = true;
        }
    }
}
