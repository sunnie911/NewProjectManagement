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

public partial class enet0769_admin_manage_member : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //加载
        if (!IsPostBack)
        {
            //绑定数据
            //DataView dvlist = Member.QueryMembers();
            //AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
            //Session["dvlist"] = dvlist;
            bindData();
        }  
    }

    void bindData()
    {
        DataView dvlist = Member.QueryMembers();
        AspNetPager1.RecordCount = dvlist.Table.Rows.Count;

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

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblCheckState = (Label)e.Row.FindControl("lblCheckState");
            switch (lblCheckState.Text)
            {
                case "0":
                    lblCheckState.Text = "<span class='red'>未审核</span>";
                    break;
                case "1":
                    lblCheckState.Text = "√";
                    break;
                case "2":
                    lblCheckState.Text = "×";
                    break;
                default:
                    lblCheckState.Text = "未知";
                    break;
            }
        }
    }
}
