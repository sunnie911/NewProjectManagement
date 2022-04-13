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

using EnterpriseNET.BusinessLogicLayer;
using EnterpriseNET.DataAccessHelper;
using EnterpriseNET.CommonComponent;

public partial class enet0769_admin_guestbook_detail : System.Web.UI.Page
{
    public string Action;
    public string GuestName,GuestPosition,Sex,CompanyName,Tel,Email,WebSite,GuestContent;

    protected void Page_Load(object sender, EventArgs e)
    {
        Action = Convert.ToString(Request.QueryString["Action"]);
        switch (Action)
        {
            case "ViewGuestbook":
                if (!IsPostBack)
                    InitData();
                break;
            case "DeleteGuestbook":
                int guestBookID = Convert.ToInt32(Request.QueryString["GuestBookID"]);
                Guestbook guestbook = new Guestbook();

                guestbook.LoadData(guestBookID);
                guestbook.Delete();
                Response.Redirect("manage_guestbook.aspx");

                break;

            default:
                break;
        }
    }

    /// <summary>
    /// 初始化页面数据
    /// </summary>
    private void InitData()
    {
        int guestBookID = Convert.ToInt32(Request.QueryString["GuestBookID"]);
        Guestbook guestbook = new Guestbook();

        guestbook.LoadData(guestBookID);
        GuestName=guestbook.guestName;
        GuestPosition=guestbook.guestPosition;
        Sex=guestbook.sex;
        CompanyName=guestbook.companyName;
        Tel=guestbook.tel;
        Email=guestbook.email;
        WebSite=guestbook.webSite;
        GuestContent = guestbook.guestContent;

        Page.DataBind();
    }

}
