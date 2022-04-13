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

public partial class enet0769_admin_manage_pic_class : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //加载
        if (!IsPostBack)
        {
            bindData();
        } 
    }

    void bindData()
    {
        string strSql = "";
        strSql = "select PicClassID,PicClassSortID,PicClassName,PicClassNameBig5,PicClassNameEn,ClassPicPath,PicSeoTitle,PicSeoKeywords,PicSeoDesc,AddWho,AddTime from cai_PicClass order by PicClassID";

        //绑定数据
        DataView dvlist = PicClass.QueryPicClass(strSql);
        AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
        //Session["dvlist"] = dvlist;

        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = AspNetPager1.PageSize;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        //pds.DataSource = (DataView)Session["dvlist"];
        pds.DataSource = dvlist;
        GridView1.DataSource = pds;
        GridView1.DataBind();
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        bindData();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        ht.Add("PicClassName", SqlStringConstructor.GetQuotedString(PicClassName.Text));
        ht.Add("PicSeoTitle", SqlStringConstructor.GetQuotedString(PicSeoTitle.Text));
        ht.Add("PicSeoKeywords", SqlStringConstructor.GetQuotedString(PicSeoKeywords.Text));
        ht.Add("PicSeoDesc", SqlStringConstructor.GetQuotedString(PicSeoDesc.Text));
        ht.Add("PicClassSortID", SqlStringConstructor.GetQuotedString(PicClassSortID.Text));

        PicClass picClass=new PicClass();
        picClass.Add(ht);

        Response.Redirect("manage_pic_class.aspx");
    }
}