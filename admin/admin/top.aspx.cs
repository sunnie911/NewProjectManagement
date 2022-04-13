using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin2016_admin_top : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["ENETAdmin"] != null)
        {
            string tempTop = Convert.ToString(Request.Cookies["ENETAdmin"].Values["AdminAccount"]);     //读全部就用Request.Cookies["meiqi"].Value)
            if (tempTop == "")
            {
                Response.Write("您还没有登陆！");
                Response.End();
            }
            else
            {
                this.AdminTopAccount.Text = tempTop;
            }
        }
        else
        {
            Response.Write("您还没有登陆！");
            Response.End();
        }
    }
}