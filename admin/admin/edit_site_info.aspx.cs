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

public partial class enet0769_admin_edit_site_info : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string strSql = "";
            strSql = "select SiteInfoClassID,SiteInfoSortID,SiteClassName,AddWho,AddTime From cai_SiteInfoClass order by SiteInfoSortID";

            //绑定数据
            DataView dv = SiteInfoClass.QuerySiteInfoClass(strSql);
            SiteInfoClassID.DataValueField = dv.Table.Columns[0].Caption.ToString();
            SiteInfoClassID.DataTextField = dv.Table.Columns[2].Caption.ToString();
            SiteInfoClassID.DataSource = dv;
            SiteInfoClassID.DataBind();

        }

        if (!IsPostBack)
            InitData();
    }

    /// <summary>
    /// 初始化页面数据
    /// </summary>
    private void InitData()
    {
        int siteInfoID = Convert.ToInt32(Request.QueryString["SiteInfoID"]);
        SiteInfo siteInfo = new SiteInfo();
        siteInfo.LoadData(siteInfoID);

        SiteInfoTitle.Text = siteInfo.siteInfoTitle;
        SiteInfoClassID.Text = siteInfo.siteInfoClassID.ToString();
        SeoTitle.Text = siteInfo.seoTitle;
        SeoKeywords.Text = siteInfo.seoKeywords;
        SeoDesc.Text = siteInfo.seoDesc;
        content1.Value = siteInfo.siteContent;

    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        SiteInfo siteInfo = new SiteInfo();
        siteInfo.siteInfoID = Convert.ToInt32(Request.QueryString["SiteInfoID"]);

        Hashtable ht = new Hashtable();
        ht.Add("SiteInfoTitle", SqlStringConstructor.GetQuotedString(SiteInfoTitle.Text));
        ht.Add("SiteInfoClassID", SqlStringConstructor.GetQuotedString(SiteInfoClassID.SelectedItem.Value));
        ht.Add("SeoTitle", SqlStringConstructor.GetQuotedString(SeoTitle.Text));
        ht.Add("SeoKeywords", SqlStringConstructor.GetQuotedString(SeoKeywords.Text));
        ht.Add("SeoDesc", SqlStringConstructor.GetQuotedString(SeoDesc.Text));
        ht.Add("SiteContent", SqlStringConstructor.GetQuotedString(content1.Value));

        siteInfo.Update(ht);

        Page.Response.Redirect("manage_site_info.aspx");
    }
}
