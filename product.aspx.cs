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

public partial class product : System.Web.UI.Page
{
    public int classID;
    public string CompanyName,ShowMajorClass, ShowMajorPath, SeoTitle, SeoKeywords, SeoDesc;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["MUID"] = 1;
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

        string strSql = "";
        int majorID = -1;
        int subID = -1;

        string action = Convert.ToString(Request.QueryString["action"]);
        if (Request.QueryString["MajorID"] != "")
            majorID = Convert.ToInt32(Request.QueryString["MajorID"]);
        if (Request.QueryString["SubID"] != "")
            subID = Convert.ToInt32(Request.QueryString["SubID"]);

        switch (action)
        {
            case "mc":
                strSql = "select ProductID,ProductName,ProductModel,MajorID,SubID,PicPathSmall,PicPathBig,AddTime From cai_Product2 where MajorID=" + majorID + " order by ProductID desc";
                
                MajorClass majorClass = new MajorClass();
                majorClass.LoadData(majorID);
                ShowMajorPath = " &gt; <a href=product_mc_" + majorClass.majorID.ToString() + "__1.html>" + majorClass.majorName + "</a>";
                ShowMajorClass = majorClass.majorName;
                SeoTitle = majorClass.seoTitle;
                SeoKeywords = majorClass.seoKeywords;
                SeoDesc = majorClass.seoDesc;

                break;

            case "sc":
                strSql = "select ProductID,ProductName,ProductModel,MajorID,SubID,PicPathSmall,PicPathBig,AddTime From cai_Product2 where MajorID=" + majorID + " and SubID=" + subID + " order by ProductID desc";

                SubClass subClass = new SubClass();
                subClass.LoadData1(subID);
                ShowMajorPath = " &gt; <a href=product_mc_" + subClass.majorID.ToString() + "__1.html>" + subClass.majorName + "</a>" + " &gt; <a href=product_sc_" + subClass.majorID.ToString() + "_" + subClass.subID.ToString() + "_1.html>" + subClass.subName + "</a>";
                ShowMajorClass = subClass.subName;
                SeoTitle = subClass.seoTitle;
                SeoKeywords = subClass.seoKeywords;
                SeoDesc = subClass.seoDesc;

                break;

            default:
                //strSql = "select ProductID,ProductName,ProductModel,MajorID,SubID,PicPathSmall,PicPathBig,AddTime From cai_Product2 order by ProductID desc";
                strSql = "select ProductID,ProductName,ProductModel,MajorID,SubID,PicPathSmall,PicPathBig,AddTime From cai_V_Product2 order by MajorSortID,ProductID desc";
                ShowMajorClass = "产品中心";
                int seoID = 2;
                Seo seo = new Seo();
                seo.LoadData(seoID);
                if (seo.exist)
                {
                    //显示产品中心SEO内容
                    SeoTitle = seo.seoTitle;
                    SeoKeywords = seo.seoKeywords;
                    SeoDesc = seo.seoDesc;
                }  

                break;
        }

        //绑定数据
        DataView dvlist2 = Product2.QueryProducts(strSql);
        ProductList.DataSource = dvlist2;
        AspNetPager1.RecordCount = dvlist2.Table.Rows.Count;

        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = AspNetPager1.PageSize;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        //pds.DataSource = (DataView)Session["dvlist2"];
        pds.DataSource = (DataView)dvlist2;
        ProductList.DataSource = pds;
        ProductList.DataBind();

        Page.DataBind();
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        bindData();
    }

    protected string cutstr(string strChar, int intLength)
    {
        //取得自定义长度的字符串
        if (strChar.Length > intLength)
        {
            return strChar.Substring(0, intLength);
        }
        else
        {
            return strChar;
        }
    }
}
