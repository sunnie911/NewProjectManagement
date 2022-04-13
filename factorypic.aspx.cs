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

public partial class factorypic : System.Web.UI.Page
{
    public string CompanyName;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["MUID"] = 4;
            try
            {
                int siteConfigID = 1;
                SiteConfig siteConfig = new SiteConfig();
                siteConfig.LoadData(siteConfigID);
                if (siteConfig.exist)
                {
                    //显示站点配置详细内容
                    CompanyName = siteConfig.companyName;
                }
                else
                {
                    Response.Write("数据不存在.");
                    Response.End();
                }

                //绑定数据
                string strSql = "";
                strSql = "select FacPicID,PicClassID,FacPicTitle,PicPathSmall,PicClassName From cai_V_FacPic where PicClassID=1 order by FacPicID desc";

                DataView dvlist = FacPic.QueryFacPic(strSql);
                FactoryPicList.DataSource = dvlist;
                AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
                Session["dvlist"] = dvlist;
                bindData();
            }
            catch
            {
                Response.Write("发生错误.");
                Response.End();
            }
        }
    }

    void bindData()
    {
        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = AspNetPager1.PageSize;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.DataSource = (DataView)Session["dvlist"];
        FactoryPicList.DataSource = pds;
        FactoryPicList.DataBind();
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        bindData();
    }

    protected string cutstr(string strChar, int intLength)
    {
        //取得自定义长度的字符串
        if (strChar.Length > intLength)
        {
            return strChar.Substring(0, intLength);
        }
        else
        {
            return strChar;
        }
    }
}