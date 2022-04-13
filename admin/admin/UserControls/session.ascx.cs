using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class enet0769_admin_UserControls_session : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["AdminAccount"] == null)
        //{
           // Response.Write("您还没有登陆！");
           // Response.End();
        //}
        if (Request.Cookies["ENETAdmin"] != null)
        {
            string temp = Convert.ToString(Request.Cookies["ENETAdmin"].Values["AdminAccount"]);     //读全部就用Request.Cookies["ENETAdmin"].Value)
            if (temp == "")
            {
                Response.Write("您还没有登陆！");
                Response.End();
            }
            else
            {
            }
        }
        else
        {
            Response.Write("您还没有登陆！");
            Response.End();
        }
    }
}
