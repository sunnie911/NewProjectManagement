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

public partial class m_contact : System.Web.UI.Page
{
    public string SiteInfoTitle, SeoTitle, SeoKeywords, SeoDesc, SiteContent;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                int siteInfoID = 38;
                SiteInfo siteinfo = new SiteInfo();
                siteinfo.LoadData(siteInfoID);

                if (siteinfo.exist)
                {
                    //显示站点信息详细内容
                    SiteInfoTitle = siteinfo.siteInfoTitle;
                    SeoTitle = siteinfo.seoTitle;
                    SeoKeywords = siteinfo.seoKeywords;
                    SeoDesc = siteinfo.seoDesc;
                    SiteContent = siteinfo.siteContent;

                    Page.DataBind();
                }
                else
                {
                    Response.Write("数据不存在.");
                    Response.End();
                }
            }
            catch
            {
                Response.Write("发生错误.");
                Response.End();
            }
        }
    }
}