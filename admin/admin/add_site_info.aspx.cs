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

public partial class enet0769_admin_add_site_info : System.Web.UI.Page
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
    }

    protected void btn_Ok_Click(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        ht.Add("SiteInfoTitle", SqlStringConstructor.GetQuotedString(SiteInfoTitle.Text));
        ht.Add("SiteInfoClassID", SqlStringConstructor.GetQuotedString(SiteInfoClassID.SelectedItem.Value));
        ht.Add("SeoTitle", SqlStringConstructor.GetQuotedString(SeoTitle.Text));
        ht.Add("SeoKeywords", SqlStringConstructor.GetQuotedString(SeoKeywords.Text));
        ht.Add("SeoDesc", SqlStringConstructor.GetQuotedString(SeoDesc.Text));
        ht.Add("SiteContent", SqlStringConstructor.GetQuotedString(content1.Value));

        SiteInfo siteInfo = new SiteInfo();
        siteInfo.Add(ht);

        Response.Redirect("add_site_info_prs.aspx");
    }
}
