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

public partial class enet0769_admin_member_detail : System.Web.UI.Page
{
    public string Action;
    public string MemberAccount, MemberPassword, CompanyName, Address, ZipCode, Contactor, ContactorDuty, Tel, Fax, Mobile, Email, WebSite, MemberProfile, CheckState;
    public DateTime AddTime;

    protected void Page_Load(object sender, EventArgs e)
    {
        Action = Convert.ToString(Request.QueryString["Action"]);

        switch (Action)
        {
            case "CheckMemberOK":
                Member memberok = new Member();
                memberok.MemberID = Convert.ToInt32(Request.QueryString["MemberID"]);

                Hashtable ht1 = new Hashtable();
                ht1.Add("CheckState", "1");

                memberok.Update(ht1);
                Response.Redirect("manage_member.aspx");

                break;
            case "CheckMemberNO":
                Member memberno = new Member();
                memberno.MemberID = Convert.ToInt32(Request.QueryString["MemberID"]);

                Hashtable ht2 = new Hashtable();
                ht2.Add("CheckState", "2");

                memberno.Update(ht2);
                Response.Redirect("manage_member.aspx");

                break;
            case "ViewMember":
                if (!IsPostBack)
                    InitData();
                break;
            case "DeleteMember":
                int memberID = Convert.ToInt32(Request.QueryString["MemberID"]);
                Member member = new Member();

                member.LoadData(memberID);
                member.Delete();
                Response.Redirect("manage_member.aspx");

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
        int memberID = Convert.ToInt32(Request.QueryString["MemberID"]);
        Member member = new Member();

        member.LoadData(memberID);
        MemberAccount = member.MemberAccount;
        MemberPassword = member.MemberPassword;
        CompanyName = member.CompanyName;
        Address = member.Address;
        ZipCode = member.ZipCode;
        Contactor = member.Contactor;
        ContactorDuty = member.ContactorDuty;
        Tel = member.Tel;
        Fax = member.Fax;
        Mobile = member.Mobile;
        Email = member.Email;
        WebSite = member.WebSite;
        MemberProfile = member.MemberProfile;
        AddTime = member.AddTime;

        Page.DataBind();
    }
}
