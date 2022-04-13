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

public partial class enet0769_admin_joinin_detail : System.Web.UI.Page
{
    public string Action;
    public string UserName, Email, MSN, Skype, CompanyName, CompanyNum, Contactor, Sex, Tel, Fax, Address, WebSite, AddTime;

    protected void Page_Load(object sender, EventArgs e)
    {
        Action = Convert.ToString(Request.QueryString["Action"]);
        switch (Action)
        {
            case "ViewJoinIn":
                if (!IsPostBack)
                    InitData();
                break;
            case "DeleteJoinIn":
                int joinInID = Convert.ToInt32(Request.QueryString["JoinInID"]);
                JoinIn joinIn = new JoinIn();

                joinIn.LoadData(joinInID);
                joinIn.Delete();
                Response.Redirect("manage_union.aspx");

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
        int joinInID = Convert.ToInt32(Request.QueryString["JoinInID"]);
        JoinIn joinIn = new JoinIn();

        joinIn.LoadData(joinInID);
        UserName = joinIn.userName;
        Email = joinIn.email;
        MSN = joinIn.mSN;
        Skype = joinIn.skype;
        CompanyName = joinIn.companyName;
        CompanyNum = joinIn.companyNum;
        Contactor = joinIn.contactor;
        Sex = joinIn.sex;
        Tel = joinIn.tel;
        Fax = joinIn.fax;
        Address = joinIn.address;
        WebSite = joinIn.webSite;
        AddTime = joinIn.addTime.ToLongDateString();

        Page.DataBind();
    }
}
