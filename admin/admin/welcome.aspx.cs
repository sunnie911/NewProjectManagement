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

public partial class enet0769_admin_welcome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {

                string strSql = "";
                strSql = "select top 9 ProductID,ProductName,ProductModel,MajorID,MajorName,PicPathSmall,PicPathBig,AddTime from cai_V_Product2 order by ProductID desc";
                DataView dvlist_rp = Product2.QueryProducts(strSql);
                rp_p1.DataSource = dvlist_rp;
                rp_p1.DataBind();

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
