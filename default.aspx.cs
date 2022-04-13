using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using EnterpriseNET.BusinessLogicLayer;

public partial class _Default : System.Web.UI.Page
{
    public string n1Link, n1Title, n1Desc, NewsPic1Url, n2Link, n2Title, n2Desc, NewsPic2Url, n3Link, n3Title, n3Desc, NewsPic3Url;
    public string CompanyName,SeoTitle, SeoKeywords, SeoDesc;
    public string AdvantageContent,AboutUsContent;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["MUID"] = 0;
            try
            {
                int seoID = 1;

                Seo seo = new Seo();
                seo.LoadData(seoID);

                if (seo.exist)
                {
                    //显示首页SEO内容
                    SeoTitle = seo.seoTitle;
                    SeoKeywords = seo.seoKeywords;
                    SeoDesc = seo.seoDesc;
                }

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
                strSql = "select top 6 ProductID,ProductName,ProductModel,MajorID,MajorName,PicPathSmall,PicPathBig,AddTime from cai_V_Product2 where IsRecommended=1 order by HomeOrder desc,ProductID desc";

                //绑定数据
                DataView dvlist_rp = Product2.QueryProducts(strSql);
                ProductListR.DataSource = dvlist_rp;
                ProductListR.DataBind();
               
                //首页关于我们
                int siteInfoID = 39;
                SiteInfo siteinfo1 = new SiteInfo();
                siteinfo1.LoadData(siteInfoID);
                if (siteinfo1.exist)
                {
                    //显示站点信息详细内容
                    AboutUsContent = siteinfo1.siteContent;
                }
                else
                {
                    Response.Write("数据不存在.");
                    Response.End();
                }

                strSql = "";
                strSql = "select top 15 FacPicID,PicClassID,FacPicTitle,PicPathSmall,PicClassName From cai_V_FacPic where PicClassID=13 and IsRecommended=1 order by FacPicID desc";

                DataView dvlistCertPic = FacPic.QueryFacPic(strSql);
                CertPicList.DataSource = dvlistCertPic;
                CertPicList.DataBind();

                strSql = "";
                strSql = "select LinkID,LinkSortID,LinkKeyword,LinkUrl,LinkDesc,LinkPic,AddTime From cai_FriendLink order by LinkSortID";

                DataView dvlist1 = FriendLink.QueryFriendLink(strSql);
                FriendLinkList.DataSource = dvlist1;
                FriendLinkList.DataBind();

                strSql = "";
                strSql = "select top 1 NewsID,ClassID,NewsTitle,SeoDesc,PicPathSmall from cai_News where ClassID=1 and len(PicPathSmall)>10 and datediff('s',now(),ReleaseTime)<0 order by NewsID desc";
                DataView dvlist_N = News.QueryNews(strSql);
                if (dvlist_N.Count > 0)
                {
                    this.n1Link = "news_detail-" + dvlist_N.Table.Rows[0][0].ToString() + ".html";
                    this.n1Title = dvlist_N.Table.Rows[0][2].ToString();
                    this.n1Desc = dvlist_N.Table.Rows[0][3].ToString();
                    this.NewsPic1.ImageUrl = "/upimage/" + dvlist_N.Table.Rows[0][4].ToString();

                    strSql = "";
                    strSql = "select top 2 NewsID,ClassID,NewsTitle,SEOTitle,SeoKeywords,SeoDesc,ClickTimes,AddWho,AddTime,ClassName From cai_V_News where ClassID=1 and datediff('s',now(),ReleaseTime)<0 and NewsID<>" + dvlist_N.Table.Rows[0][0].ToString() + " order by NewsID desc";

                    DataView dvlist_news1 = News.QueryNews(strSql);
                    rp_NewsList1.DataSource = dvlist_news1;
                    rp_NewsList1.DataBind();
                }
                else
                {
                    this.n1Link = "";
                    this.n1Title = "";
                    this.n1Desc = "";
                    this.NewsPic1.ImageUrl = "";

                    strSql = "";
                    strSql = "select top 2 NewsID,ClassID,NewsTitle,SEOTitle,SeoKeywords,SeoDesc,ClickTimes,AddWho,AddTime,ClassName From cai_V_News where ClassID=1 and datediff('s',now(),ReleaseTime)<0 order by NewsID desc";

                    DataView dvlist_news1 = News.QueryNews(strSql);
                    rp_NewsList1.DataSource = dvlist_news1;
                    rp_NewsList1.DataBind();
                }

                strSql = "";
                strSql = "select top 1 NewsID,ClassID,NewsTitle,SeoDesc,PicPathSmall from cai_News where ClassID=2 and datediff('s',now(),ReleaseTime)<0 and len(PicPathSmall)>10 order by NewsID desc";
                DataView dvlist_N2 = News.QueryNews(strSql);
                if (dvlist_N2.Count > 0)
                {
                    this.n2Link = "news_detail-" + dvlist_N2.Table.Rows[0][0].ToString() + ".html";
                    this.n2Title = dvlist_N2.Table.Rows[0][2].ToString();
                    this.n2Desc = dvlist_N2.Table.Rows[0][3].ToString();
                    this.NewsPic2.ImageUrl = "/upimage/" + dvlist_N2.Table.Rows[0][4].ToString();

                    strSql = "";
                    strSql = "select top 2 NewsID,ClassID,NewsTitle,SEOTitle,SeoKeywords,SeoDesc,ClickTimes,AddWho,AddTime,ClassName From cai_V_News where ClassID=2  and datediff('s',now(),ReleaseTime)<0 and NewsID<>" + dvlist_N2.Table.Rows[0][0].ToString() + " order by NewsID desc";

                    DataView dvlist_news2 = News.QueryNews(strSql);
                    rp_NewsList2.DataSource = dvlist_news2;
                    rp_NewsList2.DataBind();
                }
                else
                {
                    this.n2Link = "";
                    this.n2Title = "";
                    this.n2Desc = "";
                    this.NewsPic2.ImageUrl = "";

                    strSql = "";
                    strSql = "select top 2 NewsID,ClassID,NewsTitle,SEOTitle,SeoKeywords,SeoDesc,ClickTimes,AddWho,AddTime,ClassName From cai_V_News where ClassID=2 and datediff('s',now(),ReleaseTime)<0 order by NewsID desc";

                    DataView dvlist_news2 = News.QueryNews(strSql);
                    rp_NewsList2.DataSource = dvlist_news2;
                    rp_NewsList2.DataBind();
                }

                strSql = "";
                strSql = "select top 1 NewsID,ClassID,NewsTitle,SeoDesc,PicPathSmall from cai_News where ClassID=3 and datediff('s',now(),ReleaseTime)<0 and len(PicPathSmall)>10 order by NewsID desc";
                DataView dvlist_N3 = News.QueryNews(strSql);
                if (dvlist_N3.Count > 0)
                {
                    this.n3Link = "news_detail-" + dvlist_N3.Table.Rows[0][0].ToString() + ".html";
                    this.n3Title = dvlist_N3.Table.Rows[0][2].ToString();
                    this.n3Desc = dvlist_N3.Table.Rows[0][3].ToString();
                    this.NewsPic3.ImageUrl = "/upimage/" + dvlist_N3.Table.Rows[0][4].ToString();

                    strSql = "";
                    strSql = "select top 2 NewsID,ClassID,NewsTitle,SEOTitle,SeoKeywords,SeoDesc,ClickTimes,AddWho,AddTime,ClassName From cai_V_News where ClassID=3 and datediff('s',now(),ReleaseTime)<0 and NewsID<>" + dvlist_N3.Table.Rows[0][0].ToString() + " order by NewsID desc";

                    DataView dvlist_news3 = News.QueryNews(strSql);
                    rp_NewsList3.DataSource = dvlist_news3;
                    rp_NewsList3.DataBind();
                }
                else
                {
                    this.n3Link = "";
                    this.n3Title = "";
                    this.n3Desc = "";
                    this.NewsPic3.ImageUrl = "";

                    strSql = "";
                    strSql = "select top 2 NewsID,ClassID,NewsTitle,SEOTitle,SeoKeywords,SeoDesc,ClickTimes,AddWho,AddTime,ClassName From cai_V_News where ClassID=3 and datediff('s',now(),ReleaseTime)<0 order by NewsID desc";

                    DataView dvlist_news3 = News.QueryNews(strSql);
                    rp_NewsList3.DataSource = dvlist_news3;
                    rp_NewsList3.DataBind();

                }

                Page.DataBind();
            }
            catch
            {
                Response.Write("发生错误.");
                Response.End();
            }
        }
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
