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

public partial class admin_admin_add_kwds : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        ht.Add("KwdName", SqlStringConstructor.GetQuotedString(KwdName.Text));
        ht.Add("KwdLinkUrl", SqlStringConstructor.GetQuotedString(KwdLinkUrl.Text));
        ht.Add("KwdClassID", SqlStringConstructor.GetQuotedString(KwdClassID.Text));
        ht.Add("KwdDesc", SqlStringConstructor.GetQuotedString(KwdDesc.Text));
        ht.Add("KwdSortID", SqlStringConstructor.GetQuotedString(KwdSortID.Text));

        Kwds kwds = new Kwds();
        kwds.Add(ht);

        Response.Redirect("add_kwds_prs.aspx");
    }
}