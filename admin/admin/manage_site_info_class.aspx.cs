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

public partial class enet0769_admin_manage_site_info_class : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //加载
        if (!IsPostBack)
        {
            //string strSql = "";
            //strSql = "select SiteInfoClassID,SiteInfoSortID,SiteClassName,AddWho,AddTime From cai_SiteInfoClass order by SiteInfoSortID";

            //绑定数据
            //DataView dvlist = SiteInfoClass.QuerySiteInfoClass(strSql);
            //AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
            //Session["dvlist"] = dvlist;
            bindData();
        } 
    }

    void bindData()
    {
        string strSql = "";
        strSql = "select SiteInfoClassID,SiteInfoSortID,SiteClassName,AddWho,AddTime From cai_SiteInfoClass order by SiteInfoSortID";

        //绑定数据
        DataView dvlist = SiteInfoClass.QuerySiteInfoClass(strSql);
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        ht.Add("SiteClassName", SqlStringConstructor.GetQuotedString(SiteClassName.Text));
        ht.Add("SiteInfoSortID", SqlStringConstructor.GetQuotedString(SiteInfoSortID.Text));

        SiteInfoClass siteInfoClass = new SiteInfoClass();
        siteInfoClass.Add(ht);

        Response.Redirect("manage_site_info_class.aspx");
    }
}
