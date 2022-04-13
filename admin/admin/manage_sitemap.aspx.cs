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

public partial class admin_admin_manage_sitemap : System.Web.UI.Page
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
        //绑定数据
        string strSql = "";
        strSql = "select SitemapID,SitemapTitle,SitemapClassID,SitemapClassName,SitemapLinkUrl,SitemapPriority,SitemapChangeFreq,SitemapSortID,AddWho,AddTime From cai_V_Sitemap order by SitemapSortID";

        DataView dvlist = FriendLink.QueryFriendLink(strSql);
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
}