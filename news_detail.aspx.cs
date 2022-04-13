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

using System.Collections.Generic;
using System.Text.RegularExpressions;

using EnterpriseNET.BusinessLogicLayer;

public partial class news_detail : System.Web.UI.Page
{
    public string CompanyName, NewsTitle, SeoTitle, SeoKeywords, SeoDesc, NewsContent, AddTime, ReleaseTime;
    public int ClassID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["MUID"] = 3;
            try
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

                int newsID = -1;
                string strSql = "";

                if (Request.QueryString["NewsID"] != "")
                    newsID = Convert.ToInt32(Request.QueryString["NewsID"]);

                News news = new News();
                news.LoadData(newsID);

                if (news.exist)
                {
                    //显示新闻信息详细内容
                    NewsTitle = news.newsTitle;
                    SeoTitle = news.seoTitle;
                    SeoKeywords = news.seoKeywords;
                    SeoDesc = news.seoDesc;
                    ClassID = news.classID;
                    NewsContent = news.newsContent;
                    ReleaseTime = news.releaseTime.ToString();

                    List<ContModel> strarr = new List<ContModel>();
                    strSql = "";
                    strSql = "select KwdID,KwdSortID,KwdName,KwdLinkUrl,KwdDesc,AddTime From cai_Kwd where KwdClassID=2 order by KwdSortID";
                    DataView dvKeyword = Kwds.QueryKwds(strSql);
                    for (int i = 0; i < dvKeyword.Table.Rows.Count; i++)
                    {
                        strarr.Add(new ContModel() { key = dvKeyword.Table.Rows[i][2].ToString(), Url = dvKeyword.Table.Rows[i][3].ToString() });
                    }                  
                    foreach (var s in strarr)
                    {
                        NewsContent = GetInnertLink(NewsContent, s.key, s.key, s.Url, "_blank", 1);
                    }

                    //上一条
                    strSql = "select top 1 NewsID,ClassID,NewsTitle from cai_News where NewsID<" + newsID + " and datediff('s',now(),ReleaseTime)<0 order by NewsID desc";
                    DataView dvlist_N = News.QueryNews(strSql);
                    if (dvlist_N.Count > 0)
                    {
                        this.pre_p.Text = "<a href=news_detail-" + dvlist_N.Table.Rows[0][0].ToString() + ".html>" + dvlist_N.Table.Rows[0][2].ToString() + "</a>";
                    }
                    else
                    {
                        this.pre_p.Text = "<a href=news__1.html>[" + "资讯中心" + "]</a>";
                    }

                    //下一条
                    strSql = "select top 1 NewsID,ClassID,NewsTitle from cai_News where NewsID>" + newsID + " and datediff('s',now(),ReleaseTime)<0 order by NewsID";
                    DataView dvlist_N2 = Product2.QueryProducts(strSql);
                    if (dvlist_N2.Count > 0)
                    {
                        this.next_p.Text = "<a href=news_detail-" + dvlist_N2.Table.Rows[0][0].ToString() + ".html>" + dvlist_N2.Table.Rows[0][2].ToString() + "</a>";
                    }
                    else
                    {
                        this.next_p.Text = "<a href=news__1.html>[" + "资讯中心" + "]</a>";
                    }

                    Page.DataBind();
                }
                else
                {
                    Response.Write("数据不存在.");
                    Response.End();
                }
            }
            catch
            {
                Response.Write("发生错误.");
                Response.End();
            }
        }
    }


    /// <summary> 
    /// 为关键词加上超链接 
    /// </summary> 
    /// <param name="htmlcode">要把关键词加上超链接的html源文本</param> 
    /// <param name="keyword">将要加上超链接的关键词</param> 
    /// <param name="title">将要加上的超链接的描文本</param> 
    /// <param name="url">将要加上的超链接的url地址</param> 
    /// <param name="target">将要加上的超链接的打开方式</param> 
    /// <param name="num">为html文本内的前num个关键词加上超链接,0代表全加上超链接</param> 
    /// <returns>返回为关键词加上超链接后的html文本</returns> 
    public static string GetInnertLink(string htmlcode, string keyword, string title, string url, string target, int num)
    {
        string htmlcodeResult = htmlcode; //用于保存最新的html文本
        string htmlcodeLower = htmlcodeResult.ToLower(); //用于保存最新的Hmtl文本的小写，方便不分大小写找出关键词
        string keywordResult = ""; //用于保存关键词的原来面貌，可能是大写，或者有大也有小
        int keyIndex = 0; //关键词所在位置
        int currentIndex = 0; //每次搜索关键词的开始位置
        int currentNum = 0; //保存当前加上了多少个有效超链接
        int LBracketIndex = 0; //左尖括号<位置
        int RBracketIndex = 0; //右尖括号>位置
        if (num == 0)
        {
            num = htmlcode.Length;
        }
        while (currentIndex <= htmlcodeLower.Length && currentNum < num)
        {
            if (htmlcodeLower.IndexOf(keyword.ToLower(), currentIndex) > -1)
            {
                keyIndex = htmlcodeLower.IndexOf(keyword.ToLower(), currentIndex);
                LBracketIndex = keyIndex;
                do
                {
                    LBracketIndex = htmlcodeLower.LastIndexOf("<", LBracketIndex - 1, LBracketIndex - currentIndex);
                }
                while (LBracketIndex != -1 && htmlcodeLower.Substring(LBracketIndex + 1, 1) == "/");
                RBracketIndex = htmlcodeLower.LastIndexOf(">", keyIndex - 1, keyIndex - currentIndex);
                if (LBracketIndex <= RBracketIndex)
                {
                    //不在标签的属性内，可以有在标签开始与结束标志内，或在开始与结束标志外 
                    LBracketIndex = htmlcodeLower.LastIndexOf("<", keyIndex - 1, keyIndex - currentIndex);
                    if (LBracketIndex != -1 && htmlcodeLower.Substring(LBracketIndex + 1, 1) != "/")
                    {
                        //在开始与结束标志内 
                        //关键词在开始标签与结束标签内，要再判定是不是a标签或pre标签 
                        if (htmlcodeLower.Substring(LBracketIndex + 1, 1) == "a" || htmlcodeLower.Substring(LBracketIndex + 3, 3) == "pre")
                        {
                            //关键词在开始与结束a标签或pre标签内，不可加超链接，循环再来 
                            currentIndex = keyIndex + keyword.Length;
                        }
                        else
                        {
                            //可以加超链接 
                            keywordResult = htmlcodeResult.Substring(keyIndex, keyword.Length);
                            htmlcodeResult = htmlcodeResult.Remove(keyIndex, keyword.Length);
                            htmlcodeResult = htmlcodeResult.Insert(keyIndex, "<a href='" + url + "' title='" + title + "' target='" + target + "'>" + keywordResult + "</a>");
                            htmlcodeLower = htmlcodeResult.ToLower();
                            currentIndex = htmlcodeResult.IndexOf("</a>", keyIndex) + 4;
                            currentNum += 1;
                        }
                    }
                    else if ((RBracketIndex = htmlcodeLower.LastIndexOf(">", keyIndex - 1, keyIndex - currentIndex)) != -1)
                    {
                        //
                        // 当查找范围内存在'>'标签则说明在一个静态控件中则需要判断这个控件是否是a标签
                        //
                        if (htmlcodeLower.Substring(htmlcodeLower.IndexOf('<', currentIndex) + 1, 2) == "/a")
                        {
                            //关键词在a标签内则不能添加超链接
                            currentIndex = keyIndex + keyword.Length;
                        }
                        else
                        {
                            //可以加超链接 
                            keywordResult = htmlcodeResult.Substring(keyIndex, keyword.Length);
                            htmlcodeResult = htmlcodeResult.Remove(keyIndex, keyword.Length);
                            htmlcodeResult = htmlcodeResult.Insert(keyIndex, "<a href='" + url + "' title='" + title + "' target='" + target + "'>" + keywordResult + "</a>");
                            htmlcodeLower = htmlcodeResult.ToLower();
                            currentIndex = htmlcodeResult.IndexOf("</a>", keyIndex) + 4;
                            currentNum += 1;
                        }
                    }
                    else
                    {
                        //在结束标志外,可以加超链接 
                        keywordResult = htmlcodeResult.Substring(keyIndex, keyword.Length);
                        htmlcodeResult = htmlcodeResult.Remove(keyIndex, keyword.Length);
                        htmlcodeResult = htmlcodeResult.Insert(keyIndex, "<a href='" + url + "' title='" + title + "' target='" + target + "'>" + keywordResult + "</a>");
                        htmlcodeLower = htmlcodeResult.ToLower();
                        currentIndex = htmlcodeResult.IndexOf("</a>", keyIndex) + 4;
                        currentNum += 1;
                    }
                }
                else
                {
                    //关键词是标签内的属性值，不可加超链接，循环再来 
                    currentIndex = keyIndex + keyword.Length;
                }
            }
            else
            {
                currentIndex = htmlcodeLower.Length + 1;
            }
        }
        return htmlcodeResult;
    }

    public class ContModel
    {
        public string key { get; set; }
        public string Url { get; set; }
    }
}
