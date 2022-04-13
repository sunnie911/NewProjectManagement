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

public partial class psearch : System.Web.UI.Page
{
    public string keywords11;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["MUID"] = 9;

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
        string strSql = "";
        string keywords = "";

        if (Request.QueryString["keywords"] != "")
            keywords11 = Request.QueryString["keywords"];

        if (keywords11 != "")
        {
            strSql = "select ProductID,ProductName,ProductModel,MajorID,SubID,PicPathSmall,PicPathBig,AddTime From cai_Product2 where ProductName like \'%" + keywords11 + "%\' or ProductModel like \'%" + keywords11 + "%\' order by HomeOrder desc";
        }
        else
        {
            strSql = "select ProductID,ProductName,ProductModel,MajorID,SubID,PicPathSmall,PicPathBig,AddTime From cai_Product2 order by HomeOrder desc";
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