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

public partial class enet0769_admin_manage_news : System.Web.UI.Page
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
        strSql = "select NewsID,ClassID,NewsTitle,SEOTitle,SeoKeywords,SeoDesc,NewsContent,ClickTimes,AddWho,AddTime,ReleaseTime,ClassName From cai_V_News order by NewsID desc";

        //绑定数据
        DataView dvlist = News.QueryNews(strSql);
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        string keywords = Convert.ToString(Keywords.Text);
        string strSql = "";
        strSql = "select * from cai_V_News where NewsTitle like \'%" + keywords + "%\' or SeoKeywords like \'%" + keywords + "%\' order by NewsID desc";

        //绑定数据
        DataView dvlist = News.QueryNews(strSql);
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
