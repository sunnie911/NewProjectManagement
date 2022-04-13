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

public partial class UserControls_bottom : System.Web.UI.UserControl
{
    public string SiteConfigID, CompanyName, LogoPicUrl, LogoAlt, ErweimaPicUrl, ErweimaAlt, MobilePicUrl, MobileAlt, Address, Tel, Contacts, Tel400, Mobile;
    public string Fax, Email, WebSite, RecordNumber, Statistics, SiteProfile;

    protected void Page_Load(object sender, EventArgs e)
    {
        //加载
        if (!IsPostBack)
        {
            try
            {
                string strSql = "";
                //strSql = "select top 6 SubID,SubSortID,MajorID,MajorName,MajorNameEn,SubName,subNameEn,AddTime From cai_V_Major_Sub_Class order by SubSortID";
                strSql = "select top 6 MajorID,MajorSortID,MajorName,MajorNameEn,AddTime From cai_MajorClass order by MajorSortID";

                //MenuSubClass.DataSource = SubClass.QuerySubClass(strSql);
                //MenuSubClass.DataBind();
                DataView dvlist0 = MajorClass.QueryMajorClass(strSql);
                ShowMajorClass.DataSource = dvlist0;
                ShowMajorClass.DataBind();

                strSql = "";
                strSql = "select top 6 FacPicID,PicClassID,FacPicTitle,PicPathSmall,PicClassName From cai_V_FacPic where PicClassID=1 order by FacPicID desc";
                DataView dvlist1 = FacPic.QueryFacPic(strSql);
                ShowCase.DataSource = dvlist1;
                ShowCase.DataBind();

                bindSiteConfig();
            }
            catch
            {
                Response.Write("发生错误.");
                Response.End();
            }
        }
    }

    void bindSiteConfig()
    {
        int siteConfigID = 1;

        SiteConfig siteConfig = new SiteConfig();
        siteConfig.LoadData(siteConfigID);

        if (siteConfig.exist)
        {
            //显示站点配置详细内容
            CompanyName = siteConfig.companyName;
            LogoPicUrl = siteConfig.logoPicUrl;
            LogoAlt = siteConfig.logoAlt;
            ErweimaPicUrl = siteConfig.erweimaPicUrl;
            ErweimaAlt = siteConfig.erweimaAlt;
            MobilePicUrl = siteConfig.mobilePicUrl;
            MobileAlt = siteConfig.mobileAlt;
            Address = siteConfig.address;
            Tel = siteConfig.tel;
            Contacts = siteConfig.contacts;
            Tel400 = siteConfig.tel400;
            Mobile = siteConfig.mobile;
            Fax = siteConfig.fax;
            Email = siteConfig.email;
            WebSite = siteConfig.webSite;
            RecordNumber = siteConfig.recordNumber;
            Statistics = siteConfig.statistics;

            Page.DataBind();
        }
        else
        {
            Response.Write("数据不存在.");
            Response.End();
        }
    }
}
