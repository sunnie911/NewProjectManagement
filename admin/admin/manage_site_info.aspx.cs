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

public partial class enet0769_admin_manage_site_info : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //加载
        if (!IsPostBack)
        {
            //绑定数据
            //DataView dvlist = SiteInfo.QuerySiteInfo();
            //AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
            //Session["dvlist"] = dvlist;
            bindData();
        }  
    }

    void bindData()
    {
        DataView dvlist = SiteInfo.QuerySiteInfo();
        AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
        //Session["dvlist"] = dvlist;

        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = AspNetPager1.PageSize;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        //pds.DataSource = (DataView)Session["dvlist"];
        pds.DataSource = dvlist;
        GridView1.DataSource = pds;
        GridView1.DataBind();
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        bindData();
    }

    protected void rb_NewsType_SelectedIndexChanged(object sender, EventArgs e)
    {
        //绑定数据
        DataView dvlist = SiteInfo.QuerySiteInfo();
        AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
        Session["dvlist"] = dvlist;
        bindData();
    }
}
