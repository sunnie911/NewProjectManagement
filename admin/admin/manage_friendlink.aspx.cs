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


public partial class enet0769_admin_manage_friendlink : System.Web.UI.Page
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
        strSql = "select LinkID,LinkSortID,LinkKeyword,LinkUrl,LinkDesc,LinkPic,AddTime From cai_FriendLink order by LinkSortID";

        DataView dvlist = FriendLink.QueryFriendLink(strSql);
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
}
