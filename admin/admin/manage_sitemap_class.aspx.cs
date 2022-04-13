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

public partial class admin_admin_manage_sitemap_class : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //加载
        if (!IsPostBack)
        {
            bindData();
        } 
    }

    void bindData()
    {
        string strSql = "";
        strSql = "select SitemapClassID,SitemapClassSortID,SitemapClassName,SitemapClassLinkUrl,AddWho,AddTime from cai_SitemapClass order by SitemapClassID";

        //绑定数据
        DataView dvlist = SitemapClass.QuerySitemapClass(strSql);
        AspNetPager1.RecordCount = dvlist.Table.Rows.Count;

        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = AspNetPager1.PageSize;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.DataSource = dvlist;
        GridView1.DataSource = pds;
        GridView1.DataBind();
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        bindData();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        ht.Add("SitemapClassName", SqlStringConstructor.GetQuotedString(SitemapClassName.Text));
        ht.Add("SitemapClassLinkUrl", SqlStringConstructor.GetQuotedString(SitemapClassLinkUrl.Text));
        ht.Add("SitemapClassSortID", SqlStringConstructor.GetQuotedString(SitemapClassSortID.Text));

        SitemapClass sitemapClass = new SitemapClass();
        sitemapClass.Add(ht);

        Response.Redirect("manage_sitemap_class.aspx");
    }
}