using DanaZhangCms;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace CompanyCms
{
    public class PCBaseController : BaseController
    {
        public PCBaseController() { }
        //protected bool IsMobileVisit()
        //{
        //    try
        //    {
        //        string osPat = "Android|Mobile|iPhone|Symbian|Windows Phone";
        //        string uAgent = Request.ServerVariables["HTTP_USER_AGENT"];
        //        Regex reg = new Regex(osPat);
        //        return reg.IsMatch(uAgent);
        //    }
        //    catch { return false; }
        //}
    }
}
