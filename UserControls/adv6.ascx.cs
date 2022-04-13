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

public partial class UserControls_adv6 : System.Web.UI.UserControl
{
    public string AdvName, AdvPicUrl, LinkUrl;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                int advID = 12;

                Adv adv = new Adv();
                adv.LoadData(advID);

                if (adv.exist)
                {
                    //显示Banner广告详细内容
                    AdvPicUrl = adv.advPicUrl;
                    AdvName = adv.advName;
                    LinkUrl = adv.linkUrl;
                    Page.DataBind();
                }
                else
                {
                    AdvPicUrl = "2019/05/26/20190526052707550.JPG";
                    AdvName = "产品中心";
                    LinkUrl = "product____1.html";
                }
            }
            catch
            {
                Response.Write("发生错误.");
                Response.End();
            }
        }
    }
}