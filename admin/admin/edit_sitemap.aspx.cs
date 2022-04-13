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


public partial class admin_admin_edit_sitemap : System.Web.UI.Page
{
    public string Action;

    protected void Page_Load(object sender, EventArgs e)
    {
        Action = Convert.ToString(Request.QueryString["Action"]);

        switch (Action)
        {
            case "EditSitemap":
                if (!IsPostBack)
                    InitData();
                break;
            case "DeleteSitemap":
                int sitemapID = Convert.ToInt32(Request.QueryString["SitemapID"]);
                Sitemap sitemap = new Sitemap();

                sitemap.LoadData(sitemapID);
                sitemap.Delete();

                Response.Redirect("manage_sitemap.aspx");

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
        string strSql = "";
        strSql = "select SitemapClassID,SitemapClassSortID,SitemapClassName,SitemapClassLinkUrl,AddWho,AddTime From cai_SitemapClass order by SitemapClassID";

        //绑定数据
        DataView dv = SitemapClass.QuerySitemapClass(strSql);
        SitemapClassID.DataValueField = dv.Table.Columns[0].Caption.ToString();
        SitemapClassID.DataTextField = dv.Table.Columns[2].Caption.ToString();
        SitemapClassID.DataSource = dv;
        SitemapClassID.DataBind();

        int sitemapID = Convert.ToInt32(Request.QueryString["SitemapID"]);
        Sitemap sitemap = new Sitemap();
        sitemap.LoadData(sitemapID);

        SitemapTitle.Text = sitemap.sitemapTitle;
        SitemapClassID.Text = sitemap.sitemapClassID.ToString();
        SitemapLinkUrl.Text = sitemap.sitemapLinkUrl;
        SitemapPriority.Text = sitemap.sitemapPriority.ToString();
        SitemapChangeFreq.Text = sitemap.sitemapChangeFreq;
        SitemapSortID.Text = sitemap.sitemapSortID.ToString();

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Sitemap sitemap = new Sitemap();
        sitemap.sitemapID = Convert.ToInt32(Request.QueryString["SitemapID"]);

        Hashtable ht = new Hashtable();
        ht.Add("SitemapTitle", SqlStringConstructor.GetQuotedString(SitemapTitle.Text));
        ht.Add("SitemapClassID", SqlStringConstructor.GetQuotedString(SitemapClassID.SelectedItem.Value));
        ht.Add("SitemapLinkUrl", SqlStringConstructor.GetQuotedString(SitemapLinkUrl.Text));
        ht.Add("SitemapPriority", SqlStringConstructor.GetQuotedString(SitemapPriority.SelectedItem.Value));
        ht.Add("SitemapChangeFreq", SqlStringConstructor.GetQuotedString(SitemapChangeFreq.SelectedItem.Value));
        ht.Add("SitemapSortID", SqlStringConstructor.GetQuotedString(SitemapSortID.Text));

        sitemap.Update(ht);

        Page.Response.Redirect("manage_sitemap.aspx");
    }
}