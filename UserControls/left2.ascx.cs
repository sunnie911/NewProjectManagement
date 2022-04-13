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

public partial class UserControls_left2 : System.Web.UI.UserControl
{
    public string SiteConfigID, CompanyName, LogoPicUrl, LogoAlt, Address, Tel, Contacts, Tel400, Mobile;
    public string Fax, Email, WebSite, RecordNumber, Statistics, SiteProfile;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                bindSiteConfig();
            }
            catch
            {
                Response.Write("发生错误.");
                Response.End();
            }
        }
    }

    void bindSiteConfig()
    {
        int siteConfigID = 1;

        SiteConfig siteConfig = new SiteConfig();
        siteConfig.LoadData(siteConfigID);

        if (siteConfig.exist)
        {
            //显示站点配置详细内容
            CompanyName = siteConfig.companyName;
            LogoPicUrl = siteConfig.logoPicUrl;
            LogoAlt = siteConfig.logoAlt;
            Address = siteConfig.address;
            Tel = siteConfig.tel;
            Contacts = siteConfig.contacts;
            Tel400 = siteConfig.tel400;
            Mobile = siteConfig.mobile;
            Fax = siteConfig.fax;
            Email = siteConfig.email;
            WebSite = siteConfig.webSite;
            RecordNumber = siteConfig.recordNumber;
            Statistics = siteConfig.statistics;

            Page.DataBind();
        }
        else
        {
            Response.Write("数据不存在.");
            Response.End();
        }
    }
}