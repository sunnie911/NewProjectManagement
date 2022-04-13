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

public partial class sitemap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["MUID"] = -1;
            try
            {
                DataView dvlist0 = SitemapClass.QuerySitemapClass();
                ShowSitemapClass.DataSource = dvlist0;
                ShowSitemapClass.DataBind();
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

    protected void ShowSitemapClass_ItemDataBind(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            int sitemapClassID = Int32.Parse(((HiddenField)e.Item.FindControl("hidSitemapClassID")).Value.ToString());    //找到隐藏的majorID

            Repeater ShowSitemap = (Repeater)e.Item.FindControl("ShowSitemap");
            ShowSitemap.DataSource = Sitemap.QuerySitemapClass(sitemapClassID);
            ShowSitemap.DataBind();
        }
    }
}