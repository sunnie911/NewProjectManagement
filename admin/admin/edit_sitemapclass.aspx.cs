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

public partial class admin_admin_edit_sitemapclass : System.Web.UI.Page
{
    public string Action;

    protected void Page_Load(object sender, EventArgs e)
    {
        Action = Convert.ToString(Request.QueryString["Action"]);
        switch (Action)
        {
            case "EditSitemapClass":
                if (!IsPostBack)
                    InitData();
                break;
            case "DeleteSitemapClass":
                int sitemapClassID = -1;
                if (Request.QueryString["SitemapClassID"] != "")
                    sitemapClassID = Convert.ToInt32(Request.QueryString["SitemapClassID"]);
                SitemapClass sitemapClass = new SitemapClass();

                sitemapClass.LoadData(sitemapClassID);
                sitemapClass.Delete();
                Response.Redirect("manage_sitemap_class.aspx");

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
        int sitemapClassID = -1;
        if (Request.QueryString["SitemapClassID"] != "")
            sitemapClassID = Convert.ToInt32(Request.QueryString["SitemapClassID"]);

        SitemapClass sitemapClass = new SitemapClass();
        sitemapClass.LoadData(sitemapClassID);

        SitemapClassName.Text = sitemapClass.sitemapClassName;
        SitemapClassLinkUrl.Text = sitemapClass.sitemapClassLinkUrl;
        SitemapClassSortID.Text = sitemapClass.sitemapClassSortID.ToString();

    }

    protected void Button1_Update_Click(object sender, EventArgs e)
    {
        SitemapClass sitemapClass = new SitemapClass();
        sitemapClass.sitemapClassID = Convert.ToInt32(Request.QueryString["SitemapClassID"]);

        Hashtable ht = new Hashtable();
        ht.Add("SitemapClassName", SqlStringConstructor.GetQuotedString(SitemapClassName.Text));
        ht.Add("SitemapClassLinkUrl", SqlStringConstructor.GetQuotedString(SitemapClassLinkUrl.Text));
        ht.Add("SitemapClassSortID", SqlStringConstructor.GetQuotedString(SitemapClassSortID.Text));

        sitemapClass.Update(ht);

        Page.Response.Redirect("manage_sitemap_class.aspx");
    }
}