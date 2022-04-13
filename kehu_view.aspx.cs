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
using EnterpriseNET.DataAccessHelper;
using EnterpriseNET.CommonComponent;

public partial class kehu_view : System.Web.UI.Page
{
    public string CompanyName,FacPicTitle, PicPathBig, FacPicContent;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["MUID"] = 2;
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

                int facPicID = -1;
                string strSql = "";
                if (Request.QueryString["FacPicID"] != "")
                    facPicID = Convert.ToInt32(Request.QueryString["FacPicID"]);

                FacPic facPic = new FacPic();
                facPic.LoadData(facPicID);

                if (facPic.exist)
                {
                    //显示工程案例详细内容
                    FacPicTitle = facPic.facPicTitle;
                    PicPathBig = facPic.picPathBig;
                    FacPicContent = facPic.facPicContent;

                    //上一条
                    strSql = "select top 1 FacPicID,FacPicTitle,PicPathSmall from cai_FacPic where PicClassID=10 and FacPicID<" + facPicID + " order by FacPicID desc";
                    DataView dvlist_N = News.QueryNews(strSql);
                    if (dvlist_N.Count > 0)
                    {
                        this.pre_p.Text = "<a href=kehu_detail-" + dvlist_N.Table.Rows[0][0].ToString() + ".html>" + dvlist_N.Table.Rows[0][1].ToString() + "</a>";
                    }
                    else
                    {
                        this.pre_p.Text = "<a href=customers.html>[" + "企业风采" + "]</a>";
                    }

                    //下一条
                    strSql = "select top 1 FacPicID,FacPicTitle,PicPathSmall from cai_FacPic where PicClassID=10 and FacPicID>" + facPicID + " order by FacPicID";
                    DataView dvlist_N2 = Product2.QueryProducts(strSql);
                    if (dvlist_N2.Count > 0)
                    {
                        this.next_p.Text = "<a href=kehu_detail-" + dvlist_N2.Table.Rows[0][0].ToString() + ".html>" + dvlist_N2.Table.Rows[0][1].ToString() + "</a>";
                    }
                    else
                    {
                        this.next_p.Text = "<a href=customers.html>[" + "企业风采" + "]</a>";
                    }

                    Page.DataBind();

                    Random random = new Random(System.Guid.NewGuid().GetHashCode());
                    int r = random.Next();
                    strSql = "select top 4 FacPicID,FacPicTitle,PicPathSmall from cai_FacPic where PicClassID=10 order by rnd(" + (-r) + "*FacPicID)";
                    DataView dvlist = FacPic.QueryFacPic(strSql);
                    ProductListNew.DataSource = dvlist;
                    ProductListNew.DataBind();
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