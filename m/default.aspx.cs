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

public partial class m_default : System.Web.UI.Page
{
    public string SiteContent;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {

                string strSql = "";
                strSql = "select top 6 ProductID,ProductName,ProductModel,MajorID,MajorName,PicPathSmall,PicPathBig,AddTime from cai_V_Product2 order by MajorID desc,ProductID desc";

                //绑定数据
                DataView dvlist = Product2.QueryProducts(strSql);
                ProductList.DataSource = dvlist;
                ProductList.DataBind();

                int siteInfoID = 36;
                SiteInfo siteinfo = new SiteInfo();
                siteinfo.LoadData(siteInfoID);

                if (siteinfo.exist)
                {
                    //显示站点信息详细内容
                    SiteContent = siteinfo.siteContent;
                    Page.DataBind();
                }
                else
                {
                    Response.Write("数据不存在.");
                    Response.End();
                }

                strSql = "";
                strSql = "select top 5 NewsID,ClassID,NewsTitle,SEOTitle,SeoKeywords,SeoDesc,NewsContent,ClickTimes,AddWho,AddTime,ReleaseTime,ClassName From cai_V_News where datediff('s',now(),ReleaseTime)<0 order by NewsID desc";

                DataView dvlist_news1 = News.QueryNews(strSql);
                rp_NewsList1.DataSource = dvlist_news1;
                rp_NewsList1.DataBind();
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