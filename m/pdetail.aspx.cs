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

public partial class m_pdetail : System.Web.UI.Page
{
    public string ProductName, SeoTitle, SeoKeywords, SeoDesc, ProductModel, PicPathBig, ProductContent, ProductContent1, ProductContent2, ShowMajorPath, ShowSubClass;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
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
                    int subID = -1;
                    majorID = product2.majorID;
                    subID = product2.subID;

                    SeoTitle = product2.seoTitle;
                    ProductName = product2.productName;
                    SeoTitle = product2.seoTitle;
                    SeoKeywords = product2.seoKeywords;
                    SeoDesc = product2.seoDesc;
                    ProductModel = product2.productModel;
                    PicPathBig = product2.picPathBig;
                    ProductContent2 = product2.productContent2;

                    //上一个产品
                    strSql = "select top 1 ProductID,ProductName,MajorID,MajorName from cai_V_Product2 where ProductID<" + productID + " order by ProductID desc";
                    DataView dvlist_P = Product2.QueryProducts(strSql);
                    if (dvlist_P.Count > 0)
                    {
                        this.pre_p.Text = "<a href=pdetail-" + dvlist_P.Table.Rows[0][0].ToString() + ".html>" + dvlist_P.Table.Rows[0][1].ToString() + "</a>";
                    }
                    else
                    {
                        this.pre_p.Text = "<a href=product____1.html>[" + "产品中心" + "]</a>";
                    }

                    //下一个产品
                    strSql = "select top 1 ProductID,ProductName,MajorID,MajorName from cai_V_Product2 where ProductID>" + productID + " order by ProductID";
                    DataView dvlist_P2 = Product2.QueryProducts(strSql);
                    if (dvlist_P2.Count > 0)
                    {
                        this.next_p.Text = "<a href=pdetail-" + dvlist_P2.Table.Rows[0][0].ToString() + ".html>" + dvlist_P2.Table.Rows[0][1].ToString() + "</a>";
                    }
                    else
                    {
                        this.next_p.Text = "<a href=product____1.html>[" + "产品中心" + "]</a>";
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