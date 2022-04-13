using System;
using System.Data;
using System.IO;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using EnterpriseNET.BusinessLogicLayer;
using EnterpriseNET.DataAccessHelper;
using EnterpriseNET.CommonComponent;

public partial class hailiadmin_admin_site_config : System.Web.UI.Page
{
    public string pic_fpath = "..\\..\\upimage\\" + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Now.ToString("MM") + "\\" + DateTime.Now.ToString("dd") + "\\";
    public string pic_sfpath = "../../upimage/" + DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("dd") + "/";
    public string pic_dfpath = DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("dd") + "/";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitData();
        }
    }

    /// <summary>
    /// 初始化页面数据
    /// </summary>
    private void InitData()
    {
        int siteConfigID =1;
        SiteConfig siteConfig = new SiteConfig();
        siteConfig.LoadData(siteConfigID);

        CompanyName.Text = siteConfig.companyName;
        if (siteConfig.logoPicUrl != "" && siteConfig.logoPicUrl != null && siteConfig.logoPicUrl != "nopic1.jpg")
        {
            LogoPicUrl.ImageUrl = "/upimage/" + siteConfig.logoPicUrl;
        }
        else
        {
            LogoPicUrl.Visible = false;
        }
        if (siteConfig.erweimaPicUrl != "" && siteConfig.erweimaPicUrl != null && siteConfig.erweimaPicUrl != "nopic1.jpg")
        {
            ErweimaPicUrl.ImageUrl = "/upimage/" + siteConfig.erweimaPicUrl;
        }
        else
        {
            ErweimaPicUrl.Visible = false;
        }
        if (siteConfig.mobilePicUrl != "" && siteConfig.mobilePicUrl != null && siteConfig.mobilePicUrl != "nopic1.jpg")
        {
            MobilePicUrl.ImageUrl = "/upimage/" + siteConfig.mobilePicUrl;
        }
        else
        {
            MobilePicUrl.Visible = false;
        }
        LogoAlt.Text = siteConfig.logoAlt;
        ErweimaAlt.Text = siteConfig.erweimaAlt;
        MobileAlt.Text = siteConfig.mobileAlt;
        Address.Text = siteConfig.address;
        Tel.Text = siteConfig.tel;
        Contacts.Text = siteConfig.contacts;
        Tel400.Text = siteConfig.tel400;
        Mobile.Text = siteConfig.mobile;
        Fax.Text = siteConfig.fax;
        Email.Text = siteConfig.email;
        WebSite.Text = siteConfig.webSite;
        RecordNumber.Text = siteConfig.recordNumber;
        Statistics.Text = siteConfig.statistics;
        //FCKeditor1.Value = siteConfig.siteProfile;
    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        SiteConfig siteConfig = new SiteConfig();
        siteConfig.siteConfigID = 1;

        Hashtable ht = new Hashtable();

        string img_url, img_url1, img_url1to, from_img_url, sourceImage, imageMapth, stringmode;
        string img_url2, img_url22, img_url2to, from_img2_url, sourceImage2, image2Mapth, stringmode2;
        string img_url3, img_url33, img_url3to, from_img3_url, sourceImage3, image3Mapth, stringmode3;
        img_url = UploadPicFile(myfileAdd);
        img_url2 = UploadPicFile(myfile1Add);
        img_url3 = UploadPicFile(myfile2Add);
        if (img_url == "tipShow" || img_url2 == "tipShow" || img_url3 == "tipShow")
        {

        }
        else
        {
            if (img_url == "")
            {
                img_url = "nopic.jpg";
                img_url1 = "nopic1.jpg";
            }
            else
            {
                stringmode = "hw";
                from_img_url = pic_sfpath + img_url;
                img_url1 = "s" + img_url;
                img_url1to = pic_sfpath + img_url1;
                sourceImage = Server.MapPath(from_img_url);
                imageMapth = Server.MapPath(img_url1to);
                PictureSlightly pictureSlightly = new PictureSlightly();
                pictureSlightly.MakeImage(sourceImage, imageMapth, 451, 51, stringmode);

                img_url = pic_dfpath + img_url;
                img_url1 = pic_dfpath + img_url1;

                //ht.Add("PicPathSmall", SqlStringConstructor.GetQuotedString(img_url1));
                ht.Add("LogoPicUrl", SqlStringConstructor.GetQuotedString(img_url));
            }

            if (img_url2 == "")
            {
                img_url2 = "nopic.jpg";
                img_url22 = "nopic1.jpg";
            }
            else
            {
                stringmode2 = "hw";
                from_img2_url = pic_sfpath + img_url2;
                img_url22 = "s" + img_url2;
                img_url2to = pic_sfpath + img_url22;
                sourceImage2 = Server.MapPath(from_img2_url);
                image2Mapth = Server.MapPath(img_url2to);
                PictureSlightly pictureSlightly = new PictureSlightly();
                pictureSlightly.MakeImage(sourceImage2, image2Mapth, 127, 127, stringmode2);

                img_url2 = pic_dfpath + img_url2;
                img_url22 = pic_dfpath + img_url22;

                ht.Add("ErweimaPicUrl", SqlStringConstructor.GetQuotedString(img_url2));
            }

            if (img_url3 == "")
            {
                img_url3 = "nopic.jpg";
                img_url33 = "nopic1.jpg";
            }
            else
            {
                stringmode3 = "hw";
                from_img3_url = pic_sfpath + img_url3;
                img_url33 = "s" + img_url3;
                img_url3to = pic_sfpath + img_url33;
                sourceImage3 = Server.MapPath(from_img3_url);
                image3Mapth = Server.MapPath(img_url3to);
                PictureSlightly pictureSlightly = new PictureSlightly();
                pictureSlightly.MakeImage(sourceImage3, image3Mapth, 127, 127, stringmode3);

                img_url3 = pic_dfpath + img_url3;
                img_url33 = pic_dfpath + img_url33;

                ht.Add("MobilePicUrl", SqlStringConstructor.GetQuotedString(img_url3));
            }

            ht.Add("CompanyName", SqlStringConstructor.GetQuotedString(CompanyName.Text));
            ht.Add("LogoAlt", SqlStringConstructor.GetQuotedString(LogoAlt.Text));
            ht.Add("ErweimaAlt", SqlStringConstructor.GetQuotedString(ErweimaAlt.Text));
            ht.Add("MobileAlt", SqlStringConstructor.GetQuotedString(MobileAlt.Text));
            ht.Add("Address", SqlStringConstructor.GetQuotedString(Address.Text));
            ht.Add("Tel", SqlStringConstructor.GetQuotedString(Tel.Text));
            ht.Add("Contacts", SqlStringConstructor.GetQuotedString(Contacts.Text));
            ht.Add("Tel400", SqlStringConstructor.GetQuotedString(Tel400.Text));
            ht.Add("Fax", SqlStringConstructor.GetQuotedString(Fax.Text));
            ht.Add("Mobile", SqlStringConstructor.GetQuotedString(Mobile.Text));
            ht.Add("Email", SqlStringConstructor.GetQuotedString(Email.Text));
            ht.Add("WebSite", SqlStringConstructor.GetQuotedString(WebSite.Text));
            ht.Add("RecordNumber", SqlStringConstructor.GetQuotedString(RecordNumber.Text));
            ht.Add("Statistics", SqlStringConstructor.GetQuotedString(Statistics.Text));
            //ht.Add("SiteProfile", SqlStringConstructor.GetQuotedString(FCKeditor1.Value));

            siteConfig.Update(ht);

            Page.Response.Redirect("site_config1.aspx");
            //PicTip.Text = "<div style='border:1px solid #cccccc;padding:6px;'><font color='#FF0000'> 修改站点信息成功！</font></div><div class='blank18'></div>";
            //ClientScriptManager scriptManager = ((Page)System.Web.HttpContext.Current.Handler).ClientScript;
            //scriptManager.RegisterStartupScript(typeof(string), "", "alert('修改站点信息成功!');", true);
        }
    }

    private string UploadPicFile(System.Web.UI.HtmlControls.HtmlInputFile Fupload)
    {
        //文件上传
        try
        {
            if (Fupload.PostedFile.FileName == "")
            {
                return "";
            }
            else
            {
                string dir_to_name = DateTime.Now.ToString("yyyyMMddhhmmss");
                if (!Directory.Exists(Server.MapPath(pic_fpath)))
                {
                    Directory.CreateDirectory(Server.MapPath(pic_fpath));
                    if (!Directory.Exists(Server.MapPath(pic_fpath)))
                        return "";
                }
                Random rd = new System.Random();
                string filename;
                string extname;

                if (Fupload.PostedFile.FileName != "")
                {
                    extname = Fupload.PostedFile.FileName.Substring(Fupload.PostedFile.FileName.LastIndexOf(".") + 1).ToUpper();
                    if ("JPG|GIF|BMP|PNG".IndexOf(extname) == -1)
                    {
                        PicTip.Text = "<div style='border:1px solid #cccccc;padding:6px;'><font color='#FF0000'> 请上传jpg或gif格式图片！</font></div><div class='blank18'></div>";
                        return "tipShow";

                    }
                    else
                    {
                        if (Fupload.PostedFile.ContentLength > 307200)
                        {
                            PicTip.Text = "<div style='border:1px solid #cccccc;color:#ff0000;padding:6px;'><font color='#FF8000'> 上传图片过大，最佳大小300k以内！</font></div><div class='blank18'></div>";
                            return "tipShow";
                        }
                        else
                        {
                            filename = dir_to_name + rd.Next(1000).ToString() + "." + extname;
                            Fupload.PostedFile.SaveAs(Server.MapPath(pic_fpath) + filename);
                            return filename;
                        }
                    }
                }
                return "";
            }

        }
        catch { return ""; }
    }
}