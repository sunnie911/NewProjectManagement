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

public partial class enet0769_admin_manage_product2 : System.Web.UI.Page
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
        strSql = "select ProductID,ProductName,ProductModel,MajorID,MajorName,PicPathSmall,PicPathBig,IsRecommended,AddTime from cai_V_Product2 order by ProductID desc";

        //绑定数据
        DataView dvlist = Product2.QueryProducts(strSql);
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

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblIsRecommended = (Label)e.Row.FindControl("lblIsRecommended");
            switch (lblIsRecommended.Text)
            {
                case "0":
                    lblIsRecommended.Text = "--";
                    break;
                case "1":
                    lblIsRecommended.Text = "<span class='red'>推荐</span>";
                    break;
                default:
                    lblIsRecommended.Text = "--";
                    break;
            }

            //当鼠标停留时更改背景色
            e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#eeeeee'");
            //当鼠标移开时还原背景色
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string keywords = Convert.ToString(Keywords.Text);
        string strSql = "";
        strSql = "select * from cai_V_Product2 where ProductName like \'%" + keywords + "%\' or ProductModel like \'%" + keywords + "%\' order by ProductID desc";

        //绑定数据
        DataView dvlist = Product2.QueryProducts(strSql);
        AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
        //Session["dvlist"] = dvlist;
        //bindData();

        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = AspNetPager1.PageSize;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        //pds.DataSource = (DataView)Session["dvlist"];
        pds.DataSource = dvlist;
        GridView1.DataSource = pds;
        GridView1.DataBind();

    }
}
