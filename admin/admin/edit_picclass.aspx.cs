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

public partial class enet0769_admin_edit_picclass : System.Web.UI.Page
{
    public string Action;

    protected void Page_Load(object sender, EventArgs e)
    {
        Action = Convert.ToString(Request.QueryString["Action"]);
        switch (Action)
        {
            case "EditPicClass":
                if (!IsPostBack)
                    InitData();
                break;
            case "DeletePicClass":
                int picclassID = -1;
                if (Request.QueryString["PicClassID"] != "")
                    picclassID = Convert.ToInt32(Request.QueryString["PicClassID"]);

                PicClass picClass = new PicClass();
                picClass.LoadData(picclassID);
                picClass.Delete();
                Response.Redirect("manage_pic_class.aspx");

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
        int picclassID = -1;
        if (Request.QueryString["PicClassID"] != "")
            picclassID = Convert.ToInt32(Request.QueryString["PicClassID"]);

        PicClass picClass = new PicClass();
        picClass.LoadData(picclassID);

        PicClassName.Text = picClass.picClassName;
        PicSeoTitle.Text = picClass.picSeoTitle;
        PicSeoKeywords.Text = picClass.picSeoKeywords;
        PicSeoDesc.Text = picClass.picSeoDesc;
        PicClassSortID.Text = picClass.picClassSortID.ToString();

    }

    protected void Button1_Update_Click(object sender, EventArgs e)
    {
        PicClass picClass = new PicClass();
        picClass.picClassID = Convert.ToInt32(Request.QueryString["PicClassID"]);

        Hashtable ht = new Hashtable();
        ht.Add("PicClassName", SqlStringConstructor.GetQuotedString(PicClassName.Text));
        ht.Add("PicSeoTitle", SqlStringConstructor.GetQuotedString(PicSeoTitle.Text));
        ht.Add("PicSeoKeywords", SqlStringConstructor.GetQuotedString(PicSeoKeywords.Text));
        ht.Add("PicSeoDesc", SqlStringConstructor.GetQuotedString(PicSeoDesc.Text));
        ht.Add("PicClassSortID", SqlStringConstructor.GetQuotedString(PicClassSortID.Text));

        picClass.Update(ht);

        Page.Response.Redirect("manage_pic_class.aspx");
    }
}