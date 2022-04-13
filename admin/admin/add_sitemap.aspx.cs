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

public partial class admin_admin_add_sitemap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string strSql = "";
            strSql = "select SitemapClassID,SitemapClassSortID,SitemapClassName,SitemapClassLinkUrl,AddWho,AddTime From cai_SitemapClass order by SitemapClassID";

            //绑定数据
            DataView dv = SitemapClass.QuerySitemapClass(strSql);
            SitemapClassID.DataValueField = dv.Table.Columns[0].Caption.ToString();
            SitemapClassID.DataTextField = dv.Table.Columns[2].Caption.ToString();
            SitemapClassID.DataSource = dv;
            SitemapClassID.DataBind();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        ht.Add("SitemapTitle", SqlStringConstructor.GetQuotedString(SitemapTitle.Text));
        ht.Add("SitemapClassID", SqlStringConstructor.GetQuotedString(SitemapClassID.SelectedItem.Value));
        ht.Add("SitemapLinkUrl", SqlStringConstructor.GetQuotedString(SitemapLinkUrl.Text));
        ht.Add("SitemapPriority", SqlStringConstructor.GetQuotedString(SitemapPriority.SelectedItem.Value));
        ht.Add("SitemapChangeFreq", SqlStringConstructor.GetQuotedString(SitemapChangeFreq.SelectedItem.Value));
        ht.Add("SitemapSortID", SqlStringConstructor.GetQuotedString(SitemapSortID.Text));

        Sitemap sitemap = new Sitemap();
        sitemap.Add(ht);

        Response.Redirect("add_sitemap_prs.aspx");
    }
}