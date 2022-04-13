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

public partial class enet0769_admin_edit_news : System.Web.UI.Page
{
    public string Action;
    public string pic_fpath = "..\\..\\upimage\\" + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Now.ToString("MM") + "\\" + DateTime.Now.ToString("dd") + "\\";
    public string pic_sfpath = "../../upimage/" + DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("dd") + "/";
    public string pic_dfpath = DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("dd") + "/";

    protected void Page_Load(object sender, EventArgs e)
    {
        Action = Convert.ToString(Request.QueryString["Action"]);
        switch (Action)
        {
            case "EditNews":
                if (!IsPostBack)
                {
                    string strSql = "";
                    strSql = "select ClassID,ClassSortID,ClassName,AddTime From cai_NewsClass order by ClassID";

                    //绑定数据
                    DataView dv = NewsClass.QueryNewsClass(strSql);
                    ClassID.DataValueField = dv.Table.Columns[0].Caption.ToString();
                    ClassID.DataTextField = dv.Table.Columns[2].Caption.ToString();
                    ClassID.DataSource = dv;
                    ClassID.DataBind();

                }

                if (!IsPostBack)
                    InitData();
                break;
            case "DeleteNews":
                int newsID = Convert.ToInt32(Request.QueryString["NewsID"]);
                News news = new News();

                news.LoadData(newsID);
                news.Delete();
                Response.Redirect("manage_news.aspx");

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
        int newsID = Convert.ToInt32(Request.QueryString["NewsID"]);
        News news = new News();
        news.LoadData(newsID);

        NewsTitle.Text = news.newsTitle;
        ClassID.Text = news.classID.ToString();
        if (news.picPathSmall != "" && news.picPathSmall != null && news.picPathSmall != "nopic1.jpg")
        {
            NewsPic.ImageUrl = "/upimage/" + news.picPathSmall;
        }
        else
        {
            NewsPic.Visible = false;
        }
        SeoTitle.Text = news.seoTitle;
        SeoKeywords.Text = news.seoKeywords;
        SeoDesc.Text = news.seoDesc;
        content1.Value = news.newsContent;
        ReleaseTime.Value = news.releaseTime.ToString();

    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        News news = new News();
        news.newsID = Convert.ToInt32(Request.QueryString["NewsID"]);

        Hashtable ht = new Hashtable();

        string img_url, img_url1, img_url1to, from_img_url, sourceImage, imageMapth, stringmode;
        img_url = UploadPicFile(myfileAdd);
        if (img_url == "tipShow")
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
                pictureSlightly.MakeImage(sourceImage, imageMapth, 380, 250, stringmode);

                img_url = pic_dfpath + img_url;
                img_url1 = pic_dfpath + img_url1;

                ht.Add("PicPathSmall", SqlStringConstructor.GetQuotedString(img_url1));
                ht.Add("PicPathBig", SqlStringConstructor.GetQuotedString(img_url));
            }

            ht.Add("NewsTitle", SqlStringConstructor.GetQuotedString(NewsTitle.Text));
            ht.Add("ClassID", SqlStringConstructor.GetQuotedString(ClassID.SelectedItem.Value));
            ht.Add("SeoTitle", SqlStringConstructor.GetQuotedString(SeoTitle.Text));
            ht.Add("SeoKeywords", SqlStringConstructor.GetQuotedString(SeoKeywords.Text));
            ht.Add("SeoDesc", SqlStringConstructor.GetQuotedString(SeoDesc.Text));
            ht.Add("NewsContent", SqlStringConstructor.GetQuotedString(content1.Value));
            ht.Add("ReleaseTime", SqlStringConstructor.GetQuotedString(ReleaseTime.Value));

            news.Update(ht);

            Page.Response.Redirect("manage_news.aspx");
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
