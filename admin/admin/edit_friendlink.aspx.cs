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

public partial class enet0769_admin_edit_friendlink : System.Web.UI.Page
{
    public string Action;

    protected void Page_Load(object sender, EventArgs e)
    {
        Action = Convert.ToString(Request.QueryString["Action"]);

        switch (Action)
        {
            case "EditFriendLink":
                if (!IsPostBack)
                    InitData();
                break;
            case "DeleteFriendLink":
                int linkID = Convert.ToInt32(Request.QueryString["LinkID"]);
                FriendLink friendlink = new FriendLink();

                friendlink.LoadData(linkID);
                friendlink.Delete();

                Response.Redirect("manage_friendlink.aspx");

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
        int linkID = Convert.ToInt32(Request.QueryString["LinkID"]);
        FriendLink friendlink = new FriendLink();
        friendlink.LoadData(linkID);

        LinkKeyword.Text = friendlink.linkKeyword;
        LinkUrl.Text = friendlink.linkUrl;
        LinkDesc.Text = friendlink.linkDesc;
        LinkSortID.Text = friendlink.linkSortID.ToString();

    }

    protected void Button1_Update_Click(object sender, EventArgs e)
    {
        FriendLink friendlink = new FriendLink();
        friendlink.linkID = Convert.ToInt32(Request.QueryString["LinkID"]);

        Hashtable ht = new Hashtable();
        ht.Add("LinkKeyword", SqlStringConstructor.GetQuotedString(LinkKeyword.Text));
        ht.Add("LinkUrl", SqlStringConstructor.GetQuotedString(LinkUrl.Text));
        ht.Add("LinkDesc", SqlStringConstructor.GetQuotedString(LinkDesc.Text));
        ht.Add("LinkSortID", SqlStringConstructor.GetQuotedString(LinkSortID.Text));

        friendlink.Update(ht);

        Page.Response.Redirect("manage_friendlink.aspx");
    }
}
