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

public partial class enet0769_admin_add_friendlink : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        ht.Add("LinkKeyword", SqlStringConstructor.GetQuotedString(LinkKeyword.Text));
        ht.Add("LinkUrl", SqlStringConstructor.GetQuotedString(LinkUrl.Text));
        ht.Add("LinkDesc", SqlStringConstructor.GetQuotedString(LinkDesc.Text));
        ht.Add("LinkSortID", SqlStringConstructor.GetQuotedString(LinkSortID.Text));

        FriendLink friendlink = new FriendLink();
        friendlink.Add(ht);

        Response.Redirect("add_friend_link_prs.aspx");
    }
}
