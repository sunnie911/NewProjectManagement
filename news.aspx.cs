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

public partial class news : System.Web.UI.Page
{
    public int classID;
    public string CompanyName,ShowNewsClass, ShowNewsPath, SeoTitle, SeoKeywords, SeoDesc;

    protected void Page_Load(object sender, EventArgs e)
    {
        //加载
        if (!IsPostBack)
        {
            Session["MUID"] = 3;
            try
            {
                bindData();
            }
            catch
            {
                Response.Write("发生错误.");
                Response.End();
            }
        }
    }

    void bindData()
    {
        int siteConfigID = 1;
        SiteConfig siteConfig = new SiteConfig();
        siteConfig.LoadData(siteConfigID);
        if (siteConfig.exist)
        {
            //显示站点配置详细内容
            CompanyName = siteConfig.companyName;
        }
        else
        {
            Response.Write("数据不存在.");
            Response.End();
        }

        int classID = -1;
        string strSql = "";

        strSql = "";
        strSql = "Select ClassID,ClassSortID,ClassName,ClassNameBig5,ClassNameEn,ClassPicPath,SeoTitle,SeoKeywords,SeoDesc,AddWho,AddTime From cai_NewsClass order by ClassSortID";

        DataView dvlist0 = MajorClass.QueryMajorClass(strSql);
        Newsfl.DataSource = dvlist0;
        Newsfl.DataBind();

        if (Request.QueryString["classid"] != "" && Request.QueryString["classid"] != null)
        {
            classID = Convert.ToInt32(Request.QueryString["classid"]);
            strSql = "select NewsID,ClassID,NewsTitle,SEOTitle,SeoKeywords,SeoDesc,PicPathSmall,NewsContent,ClickTimes,AddWho,AddTime,ReleaseTime,ClassName From cai_V_News where ClassID=" + classID + " and datediff('s',now(),ReleaseTime)<0 order by NewsID desc";

            NewsClass newsClass = new NewsClass();
            newsClass.LoadData(classID);

            ShowNewsPath = " &gt; <a href=news_" + newsClass.classID.ToString() + "_1.html>" + newsClass.className + "</a>";
            ShowNewsClass = newsClass.className;
            SeoTitle = newsClass.seoTitle;
            SeoKeywords = newsClass.seoKeywords;
            SeoDesc = newsClass.seoDesc;
        }
        else
        {
            strSql = "select NewsID,ClassID,NewsTitle,SEOTitle,SeoKeywords,SeoDesc,PicPathSmall,NewsContent,ClickTimes,AddWho,AddTime,ReleaseTime,ClassName From cai_V_News where datediff('s',now(),ReleaseTime)<0 order by NewsID desc";
            ShowNewsClass = "资讯中心";
            SeoTitle = "资讯中心";
            SeoKeywords = "最新资讯";
            SeoDesc = "最新资讯描述";
        }

        //绑定数据
        DataView dvlist = News.QueryNews(strSql);
        rp_NewsList.DataSource = dvlist;
        AspNetPager1.RecordCount = dvlist.Table.Rows.Count;

        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = AspNetPager1.PageSize;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        //pds.DataSource = (DataView)Session["dvlist"];
        pds.DataSource = dvlist;
        rp_NewsList.DataSource = pds;
        rp_NewsList.DataBind();

        Page.DataBind();
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        bindData();
    }

    public string IsNbsp(string i)
    {
        if (i == Convert.ToString(Request.QueryString["classid"]))
        {
            return "showmj";
        }
        else
        {
            return "";
        }
    }

    protected void rb_NewsType_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strSql = "";
        strSql = "select NewsID,ClassID,NewsTitle,SEOTitle,SeoKeywords,SeoDesc,NewsContent,ClickTimes,AddWho,AddTime,ClassName From cai_V_News";

        //绑定数据
        DataView dvlist = News.QueryNews(strSql);
        dvlist.RowFilter = "ClassID = " + classID;
        rp_NewsList.DataSource = dvlist;
        AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
        Session["dvlist"] = dvlist;
        bindData();
    }
}
