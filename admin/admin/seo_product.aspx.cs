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

public partial class hailiadmin_admin_seo_product : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitData();
        }
    }

    /// <summary>
    /// 初始化页面数据
    /// </summary>
    private void InitData()
    {
        int seoID = 2;
        //if (Request.QueryString["SeoID"] != "")
        //classID = Convert.ToInt32(Request.QueryString["seoID"]);

        Seo seo = new Seo();
        seo.LoadData(seoID);

        SeoTitle.Text = seo.seoTitle;
        SeoKeywords.Text = seo.seoKeywords;
        SeoDesc.Text = seo.seoDesc;
    }

    protected void Button1_Update_Click(object sender, EventArgs e)
    {
        Seo seo = new Seo();
        seo.seoID = 2;

        Hashtable ht = new Hashtable();
        ht.Add("SeoTitle", SqlStringConstructor.GetQuotedString(SeoTitle.Text));
        ht.Add("SeoKeywords", SqlStringConstructor.GetQuotedString(SeoKeywords.Text));
        ht.Add("SeoDesc", SqlStringConstructor.GetQuotedString(SeoDesc.Text));

        seo.Update(ht);

        Page.Response.Redirect("seo_product_prs.aspx");
    }
}