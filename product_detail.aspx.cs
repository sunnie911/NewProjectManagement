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

public partial class product_detail : System.Web.UI.Page
{
    public string CompanyName,ProductName, SeoTitle, SeoKeywords, SeoDesc, ProductModel, PicPathSmall, PicPathBig, ProductContent, ProductContent1, ProductContent2, ShowMajorPath, ShowSubClass;
    public string PicPathSmall1, PicPathBig1, PicPathSmall2, PicPathBig2, PicPathSmall3, PicPathBig3, PicPathSmall4, PicPathBig4, PicPathSmall5, PicPathBig5;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["MUID"] = 1;
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

                int productID = -1;
                string strSql = "";
                if (Request.QueryString["ProductID"] != "")
                    productID = Convert.ToInt32(Request.QueryString["ProductID"]);

                Product2 product2 = new Product2();
                product2.LoadData(productID);

                if (product2.exist)
                {
                    //显示产品大类路径
                    int majorID = -1;
                    majorID = product2.majorID;

                    //显示产品详细内容
                    //hidProductID.Value = product2.productID.ToString();
                    ProductName = product2.productName;
                    SeoTitle = product2.seoTitle;
                    SeoKeywords = product2.seoKeywords;
                    SeoDesc = product2.seoDesc;
                    ProductModel = product2.productModel;
                    PicPathSmall = product2.picPathSmall;
                    PicPathBig = product2.picPathBig;
                    PicPathSmall1 = product2.picPathSmall1;
                    PicPathBig1 = product2.picPathBig1;
                    PicPathSmall2 = product2.picPathSmall2;
                    PicPathBig2 = product2.picPathBig2;
                    PicPathSmall3 = product2.picPathSmall3;
                    PicPathBig3 = product2.picPathBig3;
                    PicPathSmall4 = product2.picPathSmall4;
                    PicPathBig4 = product2.picPathBig4;
                    PicPathSmall5 = product2.picPathSmall5;
                    PicPathBig5 = product2.picPathBig5;
                    ProductContent = product2.productContent;
                    ProductContent1 = product2.productContent1;
                    //ProductContent2 = product2.productContent2;

                    //上一个产品
                    strSql = "select top 1 ProductID,ProductName,MajorID,MajorName from cai_V_Product2 where ProductID<" + productID + " and MajorID=" + majorID + " order by ProductID desc";
                    DataView dvlist_P = Product2.QueryProducts(strSql);
                    if (dvlist_P.Count > 0)
                    {
                        this.pre_p.Text = "<a href=product_detail-" + dvlist_P.Table.Rows[0][0].ToString() + ".html>" + dvlist_P.Table.Rows[0][1].ToString() + "</a>";
                    }
                    else
                    {
                        this.pre_p.Text = "<a href=product____1.html>[ 产品中心 ]</a>";
                    }

                    //下一个产品
                    strSql = "select top 1 ProductID,ProductName,MajorID,MajorName from cai_V_Product2 where ProductID>" + productID + " and MajorID=" + majorID + " order by ProductID";
                    DataView dvlist_P2 = Product2.QueryProducts(strSql);
                    if (dvlist_P2.Count > 0)
                    {
                        this.next_p.Text = "<a href=product_detail-" + dvlist_P2.Table.Rows[0][0].ToString() + ".html>" + dvlist_P2.Table.Rows[0][1].ToString() + "</a>";
                    }
                    else
                    {
                        this.next_p.Text = "<a href=product____1.html>[ 产品中心 ]</a>";
                    }

                    Page.DataBind();

                    Random random = new Random(System.Guid.NewGuid().GetHashCode());
                    int r = random.Next();
                    strSql = "select top 4 ProductID,ProductName,PicPathSmall from cai_Product2 order by rnd(" + (-r) + "*ProductID)";
                    DataView dvlist = Product2.QueryProducts(strSql);
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
