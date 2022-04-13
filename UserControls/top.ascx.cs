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

public partial class UserControls_top : System.Web.UI.UserControl
{
    public string SiteConfigID, CompanyName, Tel400,Mobile, LogoPicUrl, LogoAlt;

    protected void Page_Load(object sender, EventArgs e)
    {
        //加载
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
            //CompanyName = siteConfig.companyName;
            LogoPicUrl = siteConfig.logoPicUrl;
            LogoAlt = siteConfig.logoAlt;

            Page.DataBind();
        }
        else
        {
            Response.Write("数据不存在.");
            Response.End();
        }
    }

   
}
