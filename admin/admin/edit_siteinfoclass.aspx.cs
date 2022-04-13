using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using EnterpriseNET.BusinessLogicLayer;
using EnterpriseNET.DataAccessHelper;
using EnterpriseNET.CommonComponent;

public partial class enet0769_admin_edit_siteinfoclass : System.Web.UI.Page
{
    public string Action;

    protected void Page_Load(object sender, EventArgs e)
    {
        Action = Convert.ToString(Request.QueryString["Action"]);
        switch (Action)
        {
            case "EditSiteInfoClass":
                if (!IsPostBack)
                    InitData();
                break;
            case "DeleteSiteInfoClass":
                int siteInfoClassID = Convert.ToInt32(Request.QueryString["SiteInfoClassID"]);
                SiteInfoClass siteInfoClass = new SiteInfoClass();

                siteInfoClass.LoadData(siteInfoClassID);
                siteInfoClass.Delete();
                Response.Redirect("manage_site_info_class.aspx");

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
        int siteInfoClassID = Convert.ToInt32(Request.QueryString["SiteInfoClassID"]);
        SiteInfoClass siteInfoClass = new SiteInfoClass();
        siteInfoClass.LoadData(siteInfoClassID);

        SiteClassName.Text = siteInfoClass.siteClassName;
        SiteInfoSortID.Text = siteInfoClass.siteInfoSortID.ToString();

    }

    protected void Button1_Update_Click(object sender, EventArgs e)
    {
        SiteInfoClass siteInfoClass = new SiteInfoClass();
        siteInfoClass.siteInfoClassID = Convert.ToInt32(Request.QueryString["SiteInfoClassID"]);

        Hashtable ht = new Hashtable();
        ht.Add("SiteClassName", SqlStringConstructor.GetQuotedString(SiteClassName.Text));
        ht.Add("SiteInfoSortID", SqlStringConstructor.GetQuotedString(SiteInfoSortID.Text));

        siteInfoClass.Update(ht);

        Page.Response.Redirect("manage_site_info_class.aspx");
    }
}
