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

public partial class enet0769_admin_add_news : System.Web.UI.Page
{
    public string pic_fpath = "..\\..\\upimage\\" + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Now.ToString("MM") + "\\" + DateTime.Now.ToString("dd") + "\\";
    public string pic_sfpath = "../../upimage/" + DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("dd") + "/";
    public string pic_dfpath = DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("dd") + "/";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string strSql = "";
            strSql = "select ClassID,ClassSortID,ClassName,AddWho,AddTime From cai_NewsClass order by ClassID";

            //绑定数据
            DataView dv = NewsClass.QueryNewsClass(strSql);
            ClassID.DataValueField = dv.Table.Columns[0].Caption.ToString();
            ClassID.DataTextField = dv.Table.Columns[2].Caption.ToString();
            ClassID.DataSource = dv;
            ClassID.DataBind();

            
        }
    }

    protected void btn_Ok_Click(object sender, EventArgs e)
    {
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
                }

                Hashtable ht = new Hashtable();
                ht.Add("NewsTitle", SqlStringConstructor.GetQuotedString(NewsTitle.Text));
                ht.Add("ClassID", SqlStringConstructor.GetQuotedString(ClassID.Text));
                ht.Add("PicPathSmall", SqlStringConstructor.GetQuotedString(img_url1));
                ht.Add("PicPathBig", SqlStringConstructor.GetQuotedString(img_url));
                ht.Add("SeoTitle", SqlStringConstructor.GetQuotedString(SeoTitle.Text));
                ht.Add("SeoKeywords", SqlStringConstructor.GetQuotedString(SeoKeywords.Text));
                ht.Add("SeoDesc", SqlStringConstructor.GetQuotedString(SeoDesc.Text));
                ht.Add("NewsContent", SqlStringConstructor.GetQuotedString(content1.Value));
                ht.Add("ReleaseTime", SqlStringConstructor.GetQuotedString(ReleaseTime.Value));

                News news = new News();
                news.Add(ht);

                Response.Redirect("add_news_prs.aspx");
            }
        }

    private string UploadPicFile(System.Web.UI.HtmlControls.HtmlInputFile Fupload)
    {
        //文件上传
        try
        {
            if (Fupload.PostedFile.FileName == "")
            {
                PicTip.Text = "<div style='border:1px solid #cccccc;padding:6px;'><font color='#FF0000'> 请选择jpg或gif格式图片！</font></div><div class='blank18'></div>";
                return "";
            }
            else
            {
                //string dir = DateTime.Now.ToString("yyyyMMddhhmmss");
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
                    if ("JPG|GIF|JPEG|png".IndexOf(extname) == -1)
                    {
                        PicTip.Text = "<div style='border:1px solid #cccccc;padding:6px;'><font color='#FF0000'> 请上传jpg或gif格式图片！</font></div><div class='blank18'></div>";
                        return "tipShow";
                    }
                    else
                    {
                        if (Fupload.PostedFile.ContentLength > 307200)
                        {
                            PicTip.Text = "<div style='border:1px solid #cccccc;color:#ff0000;padding:6px;'><font color='#FF0000'> 上传图片过大，最佳大小300k以内！</font></div><div class='blank18'></div>";
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
