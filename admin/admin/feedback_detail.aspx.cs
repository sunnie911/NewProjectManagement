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

public partial class enet0769_admin_feedback_detail : System.Web.UI.Page
{
    public string Action;
    public string FBStyle, FBContent, CompanyName, FBName, Email, Fax, Tel, ZipCode, Address, AddTime;

    protected void Page_Load(object sender, EventArgs e)
    {
        Action = Convert.ToString(Request.QueryString["Action"]);
        switch (Action)
        {
            case "ViewFeedback":
                if (!IsPostBack)
                    InitData();
                break;
            case "DeleteFeedback":
                int feedbackID = Convert.ToInt32(Request.QueryString["FeedbackID"]);
                Feedback feedback = new Feedback();

                feedback.LoadData(feedbackID);
                feedback.Delete();
                Response.Redirect("manage_feedback.aspx");

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
        int feedbackID = Convert.ToInt32(Request.QueryString["FeedbackID"]);
        Feedback feedback = new Feedback();

        feedback.LoadData(feedbackID);
        FBStyle = feedback.fBStyle;
        FBContent = feedback.fBContent;
        CompanyName = feedback.companyName;
        FBName = feedback.fBName;
        Email = feedback.email;
        Fax = feedback.fax;
        Tel = feedback.tel;
        ZipCode = feedback.zipCode;
        Address = feedback.address;
        AddTime = feedback.addTime.ToLongDateString();

        Page.DataBind();
    }
}
