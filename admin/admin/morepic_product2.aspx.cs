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

public partial class enet0769_admin_morepic_product2 : System.Web.UI.Page
{
    public int productID;
    public string ProductName, SeoTitle, SeoKeywords, SeoDesc, ProductModel, PicPathSmall, PicPathBig, ProductContent, ProductContent1, ProductContent2, ShowMajorPath, ShowSubClass;
    public string PicPathSmall1, PicPathBig1, PicPathSmall2, PicPathBig2, PicPathSmall3, PicPathBig3, PicPathSmall4, PicPathBig4, PicPathSmall5, PicPathBig5;
    public string pic_fpath = "..\\..\\upimage\\" + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Now.ToString("MM") + "\\" + DateTime.Now.ToString("dd") + "\\";
    public string pic_sfpath = "../../upimage/" + DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("dd") + "/";
    public string pic_dfpath = DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("dd") + "/";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                int productID = -1;
                if (Request.QueryString["ProductID"] != "")
                    productID = Convert.ToInt32(Request.QueryString["ProductID"]);

                Product2 product2 = new Product2();
                product2.LoadData(productID);

                if (product2.exist)
                {
                    //显示产品详细内容
                    //hidProductID.Value = product2.productID.ToString();
                    ProductName = product2.productName;
                    SeoTitle = product2.seoTitle;
                    SeoKeywords = product2.seoKeywords;
                    SeoDesc = product2.seoDesc;
                    ProductModel = product2.productModel;
                    PicPathSmall = product2.picPathSmall;
                    PicPathBig = product2.picPathBig;
                    PicPathSmall1 = product2.picPathSmall1;
                    if (PicPathSmall1.Length > 10)
                    {
                        pimg1.ImageUrl = "/upimage/" + product2.picPathSmall1;
                    }
                    else
                    {
                        pimg1.Visible = false;
                    }
                    PicPathBig1 = product2.picPathBig1;
                    PicPathSmall2 = product2.picPathSmall2;
                    if (PicPathSmall2.Length > 10)
                    {
                        pimg2.ImageUrl = "/upimage/" + product2.picPathSmall2;
                    }
                    else
                    {
                        pimg2.Visible = false;
                    }
                    PicPathBig2 = product2.picPathBig2;
                    PicPathSmall3 = product2.picPathSmall3;
                    if (PicPathSmall3.Length > 10)
                    {
                        pimg3.ImageUrl = "/upimage/" + product2.picPathSmall3;
                    }
                    else
                    {
                        pimg3.Visible = false;
                    }
                    PicPathBig3 = product2.picPathBig3;
                    PicPathSmall4 = product2.picPathSmall4;
                    if (PicPathSmall4.Length > 10)
                    {
                        pimg4.ImageUrl = "/upimage/" + product2.picPathSmall4;
                    }
                    else
                    {
                        pimg4.Visible = false;
                    }
                    PicPathBig4 = product2.picPathBig4;
                    PicPathSmall5 = product2.picPathSmall5;
                    if (PicPathSmall5.Length > 10)
                    {
                        pimg5.ImageUrl = "/upimage/" + product2.picPathSmall5;
                    }
                    else
                    {
                        pimg5.Visible = false;
                    }
                    PicPathBig5 = product2.picPathBig5;
                    ProductContent = product2.productContent;
                    ProductContent1 = product2.productContent1;
                    ProductContent2 = product2.productContent2;

                    Page.DataBind();
                }
                else
                {
                    Response.Write("数据不存在.");
                    Response.End();
                }
            }
            catch
            {
                Response.Write("发生错误.");
                Response.End();
            }
        }
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

    protected void btn1_Ok_Click(object sender, EventArgs e)
    {
        Product2 product2 = new Product2();
        product2.productID = Convert.ToInt32(Request.QueryString["ProductID"]);

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
                pictureSlightly.MakeImage(sourceImage, imageMapth, 276, 207, stringmode);

                img_url = pic_dfpath + img_url;
                img_url1 = pic_dfpath + img_url1;
            }

            ht.Add("PicPathSmall1", SqlStringConstructor.GetQuotedString(img_url1));
            ht.Add("PicPathBig1", SqlStringConstructor.GetQuotedString(img_url));

            product2.Update(ht);

            Page.Response.Redirect("morepic_product2.aspx?ProductID=" + Convert.ToInt32(Request.QueryString["ProductID"]));
        }
    }


    protected void btn2_Ok_Click(object sender, EventArgs e)
    {
        Product2 product2 = new Product2();
        product2.productID = Convert.ToInt32(Request.QueryString["ProductID"]);

        Hashtable ht = new Hashtable();

        string img_url, img_url1, img_url1to, from_img_url, sourceImage, imageMapth, stringmode;
        img_url = UploadPicFile(File2);
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
                pictureSlightly.MakeImage(sourceImage, imageMapth, 276, 207, stringmode);

                img_url = pic_dfpath + img_url;
                img_url1 = pic_dfpath + img_url1;
            }

            ht.Add("PicPathSmall2", SqlStringConstructor.GetQuotedString(img_url1));
            ht.Add("PicPathBig2", SqlStringConstructor.GetQuotedString(img_url));

            product2.Update(ht);

            Page.Response.Redirect("morepic_product2.aspx?ProductID=" + Convert.ToInt32(Request.QueryString["ProductID"]));
        }
    }

    protected void btn3_Ok_Click(object sender, EventArgs e)
    {
        Product2 product2 = new Product2();
        product2.productID = Convert.ToInt32(Request.QueryString["ProductID"]);

        Hashtable ht = new Hashtable();

        string img_url, img_url1, img_url1to, from_img_url, sourceImage, imageMapth, stringmode;
        img_url = UploadPicFile(File3);
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
                pictureSlightly.MakeImage(sourceImage, imageMapth, 276, 207, stringmode);

                img_url = pic_dfpath + img_url;
                img_url1 = pic_dfpath + img_url1;
            }

            ht.Add("PicPathSmall3", SqlStringConstructor.GetQuotedString(img_url1));
            ht.Add("PicPathBig3", SqlStringConstructor.GetQuotedString(img_url));

            product2.Update(ht);

            Page.Response.Redirect("morepic_product2.aspx?ProductID=" + Convert.ToInt32(Request.QueryString["ProductID"]));
        }
    }

    protected void btn4_Ok_Click(object sender, EventArgs e)
    {
        Product2 product2 = new Product2();
        product2.productID = Convert.ToInt32(Request.QueryString["ProductID"]);

        Hashtable ht = new Hashtable();

        string img_url, img_url1, img_url1to, from_img_url, sourceImage, imageMapth, stringmode;
        img_url = UploadPicFile(File4);
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
                pictureSlightly.MakeImage(sourceImage, imageMapth, 276, 207, stringmode);

                img_url = pic_dfpath + img_url;
                img_url1 = pic_dfpath + img_url1;
            }

            ht.Add("PicPathSmall4", SqlStringConstructor.GetQuotedString(img_url1));
            ht.Add("PicPathBig4", SqlStringConstructor.GetQuotedString(img_url));

            product2.Update(ht);

            Page.Response.Redirect("morepic_product2.aspx?ProductID=" + Convert.ToInt32(Request.QueryString["ProductID"]));
        }
    }

    protected void btn5_Ok_Click(object sender, EventArgs e)
    {
        Product2 product2 = new Product2();
        product2.productID = Convert.ToInt32(Request.QueryString["ProductID"]);

        Hashtable ht = new Hashtable();

        string img_url, img_url1, img_url1to, from_img_url, sourceImage, imageMapth, stringmode;
        img_url = UploadPicFile(File5);
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
                pictureSlightly.MakeImage(sourceImage, imageMapth, 276, 207, stringmode);

                img_url = pic_dfpath + img_url;
                img_url1 = pic_dfpath + img_url1;
            }

            ht.Add("PicPathSmall5", SqlStringConstructor.GetQuotedString(img_url1));
            ht.Add("PicPathBig5", SqlStringConstructor.GetQuotedString(img_url));

            product2.Update(ht);

            Page.Response.Redirect("morepic_product2.aspx?ProductID=" + Convert.ToInt32(Request.QueryString["ProductID"]));
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
                        if (Fupload.PostedFile.ContentLength > 512000)
                        {
                            PicTip.Text = "<div style='border:1px solid #cccccc;color:#ff0000;padding:6px;'><font color='#FF8000'> 上传图片过大，最佳大小500k以内！</font></div><div class='blank18'></div>";
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