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

public partial class enet0769_admin_edit_product2 : System.Web.UI.Page
{
    public string Action;
    public string pic_fpath = "..\\..\\upimage\\" + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Now.ToString("MM") + "\\" + DateTime.Now.ToString("dd") + "\\";
    public string pic_sfpath = "../../upimage/" + DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("dd") + "/";
    public string pic_dfpath = DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("dd") + "/";

    protected void Page_Load(object sender, EventArgs e)
    {
        Action = Convert.ToString(Request.QueryString["Action"]);

        if (!IsPostBack)
        {
            //绑定数据
            DataView dv = MajorClass.QueryMajorClass();
            MajorID.DataValueField = dv.Table.Columns[0].Caption;
            MajorID.DataTextField = dv.Table.Columns[2].Caption;
            MajorID.DataSource = dv;
            MajorID.DataBind();
        }

        switch (Action)
        {
            case "EditProduct2":
                if (!IsPostBack)
                    InitData();
                break;
            case "DeleteProduct2":
                int productID = Convert.ToInt32(Request.QueryString["ProductID"]);
                Product2 product2 = new Product2();

                product2.LoadData(productID);
                product2.Delete();

                Response.Redirect("manage_product2.aspx");

                break;
            case "IsRecommended":
                IsRecommend();
                break;
            case "NoRecommended":
                NoRecommend();
                break;

            default:
                break;
        }
    }

    /// <summary>
    /// 更新一条数据，设为推荐
    /// </summary>
    private void IsRecommend()
    {
        Product2 product2 = new Product2();
        product2.productID = Convert.ToInt32(Request.QueryString["ProductID"]);

        Hashtable ht = new Hashtable();
        ht.Add("IsRecommended", "1");

        product2.Update(ht);

        Response.Redirect(Request.UrlReferrer.ToString());
    }

    /// <summary>
    /// 更新一条数据，设为不推荐
    /// </summary>
    private void NoRecommend()
    {
        Product2 product2 = new Product2();
        product2.productID = Convert.ToInt32(Request.QueryString["ProductID"]);

        Hashtable ht = new Hashtable();
        ht.Add("IsRecommended", "0");

        product2.Update(ht);

        Response.Redirect(Request.UrlReferrer.ToString());
    }

    /// <summary>
    /// 初始化页面数据
    /// </summary>
    private void InitData()
    {
        int productID = Convert.ToInt32(Request.QueryString["ProductID"]);
        Product2 product2 = new Product2();
        product2.LoadData(productID);

        ProductName.Text = product2.productName;
        //ProductNameEn.Text = product2.productNameEn;
        ProductModel.Text = product2.productModel;
        HomeOrder.Text = product2.homeOrder.ToString();
        MajorID.Text = product2.majorID.ToString();

        int majorID = -1;
        if (product2.majorID.ToString() != "")
            majorID = Convert.ToInt32(product2.majorID.ToString());

        if (product2.picPathSmall != "" && product2.picPathSmall != null && product2.picPathSmall != "nopic1.jpg")
        {
            NewsPic.ImageUrl = "/upimage/" + product2.picPathSmall;
        }
        else
        {
            NewsPic.Visible = false;
        }
        SeoTitle.Text = product2.seoTitle;
        SeoKeywords.Text = product2.seoKeywords;
        SeoDesc.Text = product2.seoDesc;
        //SeoTitleEn.Text = product2.seoTitleEn;
        //SeoKeywordsEn.Text = product2.seoKeywordsEn;
        //SeoDescEn.Text = product2.seoDescEn;
        content1.Value = product2.productContent;
        //FCKeditor2.Value = product2.productContent1;
        content2.Value = product2.productContent2;
        //FCKeditor4.Value = product2.productContentEn;
        //FCKeditor5.Value = product2.productContentEn1;

    }

    protected void btn_Update_Click(object sender, EventArgs e)
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
                pictureSlightly.MakeImage(sourceImage, imageMapth, 360, 270, stringmode);

                img_url = pic_dfpath + img_url;
                img_url1 = pic_dfpath + img_url1;

                ht.Add("PicPathSmall", SqlStringConstructor.GetQuotedString(img_url1));
                ht.Add("PicPathBig", SqlStringConstructor.GetQuotedString(img_url));
            }

            ht.Add("ProductName", SqlStringConstructor.GetQuotedString(ProductName.Text));

            ht.Add("ProductModel", SqlStringConstructor.GetQuotedString(ProductModel.Text));
            ht.Add("HomeOrder", SqlStringConstructor.GetQuotedString(HomeOrder.Text));
            ht.Add("MajorID", SqlStringConstructor.GetQuotedString(MajorID.SelectedItem.Value));
            ht.Add("SeoTitle", SqlStringConstructor.GetQuotedString(SeoTitle.Text));
            ht.Add("SeoKeywords", SqlStringConstructor.GetQuotedString(SeoKeywords.Text));
            ht.Add("SeoDesc", SqlStringConstructor.GetQuotedString(SeoDesc.Text));
            ht.Add("ProductContent", SqlStringConstructor.GetQuotedString(content1.Value));
            ht.Add("ProductContent2", SqlStringConstructor.GetQuotedString(content2.Value));

            product2.Update(ht);

            Page.Response.Redirect("manage_product2.aspx");
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
