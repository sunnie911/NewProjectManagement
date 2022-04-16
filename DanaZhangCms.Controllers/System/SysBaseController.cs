using DanaZhangCms.Controllers.Filters;
using Microsoft.AspNetCore.Authorization;

namespace DanaZhangCms.Controllers
{
    [Authorize, RequestFilter]
    public abstract class SysBaseController : BaseController
    {
    }
    
}