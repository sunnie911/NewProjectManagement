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

public partial class enet0769_admin_manage_news_class : System.Web.UI.Page
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
        strSql = "select ClassID,ClassSortID,ClassName,SeoTitle,SeoKeywords,SeoDesc,AddWho,AddTime from cai_NewsClass order by ClassID";

        //绑定数据
        DataView dvlist = NewsClass.QueryNewsClass(strSql);
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
        Hashtable ht = new Hashtable();
        ht.Add("ClassName", SqlStringConstructor.GetQuotedString(ClassName.Text));
        ht.Add("SeoTitle", SqlStringConstructor.GetQuotedString(SeoTitle.Text));
        ht.Add("SeoKeywords", SqlStringConstructor.GetQuotedString(SeoKeywords.Text));
        ht.Add("SeoDesc", SqlStringConstructor.GetQuotedString(SeoDesc.Text));
        ht.Add("ClassSortID", SqlStringConstructor.GetQuotedString(ClassSortID.Text));

        NewsClass newsClass = new NewsClass();
        newsClass.Add(ht);

        Response.Redirect("manage_news_class.aspx");
    }
}
