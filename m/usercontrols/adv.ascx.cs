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

public partial class m_usercontrols_adv : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string strSql = "";
                strSql = "select AdvID,AdvSortID,AdvClassID,AdvName,AdvPicUrl,LinkUrl,AddTime From Cai_Adv where AdvClassID=3 order by AdvSortID";

                DataView dvlist = FacPic.QueryFacPic(strSql);
                AdvList.DataSource = dvlist;
                AdvList.DataBind();
                Page.DataBind();
            }
            catch
            {
                Response.Write("发生错误.");
                Response.End();
            }
        }
    }
}