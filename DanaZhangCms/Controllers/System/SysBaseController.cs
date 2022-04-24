 
using Microsoft.AspNetCore.Authorization;

namespace DanaZhangCms
{
    [Authorize, RequestFilter]
    public abstract class SysBaseController : BaseController
    {
    }
    
}