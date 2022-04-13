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
using EnterpriseNET.DataAccessHelper;
using EnterpriseNET.CommonComponent;

public partial class enet0769_admin_edit_newsclass : System.Web.UI.Page
{
    public string Action;

    protected void Page_Load(object sender, EventArgs e)
    {
        Action = Convert.ToString(Request.QueryString["Action"]);
        switch (Action)
        {
            case "EditNewsClass":
                if (!IsPostBack)
                    InitData();
                break;
            case "DeleteNewsClass":
                int classID = -1;
                if (Request.QueryString["ClassID"] != "")
                    classID = Convert.ToInt32(Request.QueryString["ClassID"]);
                NewsClass newsClass = new NewsClass();

                newsClass.LoadData(classID);
                newsClass.Delete();
                Response.Redirect("manage_news_class.aspx");

                break;

            default:
                break;
        }

    }

    /// <summary>
    /// 初始化页面数据
    /// </summary>
    private void InitData()
    {
        int classID = -1;
        if (Request.QueryString["ClassID"] != "")
            classID = Convert.ToInt32(Request.QueryString["ClassID"]);

        NewsClass newsClass = new NewsClass();
        newsClass.LoadData(classID);

        ClassName.Text = newsClass.className;
        SeoTitle.Text = newsClass.seoTitle;
        SeoKeywords.Text = newsClass.seoKeywords;
        SeoDesc.Text = newsClass.seoDesc;
        ClassSortID.Text = newsClass.classSortID.ToString();

    }

    protected void Button1_Update_Click(object sender, EventArgs e)
    {
        NewsClass newsClass = new NewsClass();
        newsClass.classID = Convert.ToInt32(Request.QueryString["ClassID"]);

        Hashtable ht = new Hashtable();
        ht.Add("ClassName", SqlStringConstructor.GetQuotedString(ClassName.Text));
        ht.Add("SeoTitle", SqlStringConstructor.GetQuotedString(SeoTitle.Text));
        ht.Add("SeoKeywords", SqlStringConstructor.GetQuotedString(SeoKeywords.Text));
        ht.Add("SeoDesc", SqlStringConstructor.GetQuotedString(SeoDesc.Text));
        ht.Add("ClassSortID", SqlStringConstructor.GetQuotedString(ClassSortID.Text));

        newsClass.Update(ht);

        Page.Response.Redirect("manage_news_class.aspx");
    }
}
