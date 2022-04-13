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

public partial class admin_admin_edit_kwd : System.Web.UI.Page
{
    public string Action;

    protected void Page_Load(object sender, EventArgs e)
    {
        Action = Convert.ToString(Request.QueryString["Action"]);

        switch (Action)
        {
            case "EditKwd":
                if (!IsPostBack)
                    InitData();
                break;
            case "DeleteKwd":
                int kwdID = Convert.ToInt32(Request.QueryString["KwdID"]);
                Kwds kwds = new Kwds();

                kwds.LoadData(kwdID);
                kwds.Delete();

                Response.Redirect("manage_kwds.aspx");

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
        int kwdID = Convert.ToInt32(Request.QueryString["KwdID"]);
        Kwds kwds = new Kwds();
        kwds.LoadData(kwdID);

        KwdName.Text = kwds.kwdName;
        KwdLinkUrl.Text = kwds.kwdLinkUrl;
        KwdClassID.Text = kwds.kwdClassID.ToString();
        KwdDesc.Text = kwds.kwdDesc;
        KwdSortID.Text = kwds.kwdSortID.ToString();

    }

    protected void Button1_Update_Click(object sender, EventArgs e)
    {
        Kwds kwds = new Kwds();
        kwds.kwdID = Convert.ToInt32(Request.QueryString["KwdID"]);

        Hashtable ht = new Hashtable();
        ht.Add("KwdName", SqlStringConstructor.GetQuotedString(KwdName.Text));
        ht.Add("KwdLinkUrl", SqlStringConstructor.GetQuotedString(KwdLinkUrl.Text));
        ht.Add("KwdClassID", SqlStringConstructor.GetQuotedString(KwdClassID.Text));
        ht.Add("KwdDesc", SqlStringConstructor.GetQuotedString(KwdDesc.Text));
        ht.Add("KwdSortID", SqlStringConstructor.GetQuotedString(KwdSortID.Text));

        kwds.Update(ht);

        Page.Response.Redirect("manage_kwds.aspx");
    }
}