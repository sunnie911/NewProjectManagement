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

public partial class enet0769_admin_edit_facpic : System.Web.UI.Page
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
            case "EditFacPic":
                if (!IsPostBack)
                {
                    string strSql = "";
                    strSql = "select PicClassID,PicClassSortID,PicClassName,AddTime From cai_PicClass order by PicClassID";

                    //绑定数据
                    DataView dv = PicClass.QueryPicClass(strSql);
                    PicClassID.DataValueField = dv.Table.Columns[0].Caption.ToString();
                    PicClassID.DataTextField = dv.Table.Columns[2].Caption.ToString();
                    PicClassID.DataSource = dv;
                    PicClassID.DataBind();

                }

                if (!IsPostBack)
                    InitData();
                break;
            case "DeleteFacPic":
                int facPicID = Convert.ToInt32(Request.QueryString["FacPicID"]);
                FacPic facPic = new FacPic();

                facPic.LoadData(facPicID);
                facPic.Delete();
                Response.Redirect("manage_facpic.aspx");

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
        FacPic facPic = new FacPic();
        facPic.facPicID = Convert.ToInt32(Request.QueryString["FacPicID"]);

        Hashtable ht = new Hashtable();
        ht.Add("IsRecommended", "1");

        facPic.Update(ht);

        Response.Redirect(Request.UrlReferrer.ToString());
    }

    /// <summary>
    /// 更新一条数据，设为不推荐
    /// </summary>
    private void NoRecommend()
    {
        FacPic facPic = new FacPic();
        facPic.facPicID = Convert.ToInt32(Request.QueryString["FacPicID"]);

        Hashtable ht = new Hashtable();
        ht.Add("IsRecommended", "0");

        facPic.Update(ht);

        Response.Redirect(Request.UrlReferrer.ToString());
    }

    /// <summary>
    /// 初始化页面数据
    /// </summary>
    private void InitData()
    {
        int facPicID = Convert.ToInt32(Request.QueryString["FacPicID"]);

        FacPic facPic = new FacPic();
        facPic.LoadData(facPicID);

        FacPicTitle.Text = facPic.facPicTitle;
        PicClassID.Text = facPic.picClassID.ToString();
        if (facPic.picPathSmall != "" && facPic.picPathSmall != null && facPic.picPathSmall != "nopic1.jpg")
        {
            FacPic.ImageUrl = "/upimage/" + facPic.picPathSmall;
        }
        else
        {
            FacPic.Visible = false;
        }
        SeoTitle.Text = facPic.seoTitle;
        SeoKeywords.Text = facPic.seoKeywords;
        SeoDesc.Text = facPic.seoDesc;
        content1.Value = facPic.facPicContent;

    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        FacPic facPic = new FacPic();
        facPic.facPicID = Convert.ToInt32(Request.QueryString["FacPicID"]);

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
                if (Convert.ToInt32(PicClassID.Text) == 10)
                {
                    pictureSlightly.MakeImage(sourceImage, imageMapth, 360, 270, stringmode);
                }
                else if (Convert.ToInt32(PicClassID.Text) == 12)
                {
                    pictureSlightly.MakeImage(sourceImage, imageMapth, 360, 270, stringmode);
                }
                else if (Convert.ToInt32(PicClassID.Text) == 13)
                {
                    pictureSlightly.MakeImage(sourceImage, imageMapth, 360, 270, stringmode);
                }
                else
                {
                    pictureSlightly.MakeImage(sourceImage, imageMapth, 360, 270, stringmode);
                }

                img_url = pic_dfpath + img_url;
                img_url1 = pic_dfpath + img_url1;

                ht.Add("PicPathSmall", SqlStringConstructor.GetQuotedString(img_url1));
                ht.Add("PicPathBig", SqlStringConstructor.GetQuotedString(img_url));
            }

            ht.Add("FacPicTitle", SqlStringConstructor.GetQuotedString(FacPicTitle.Text));
            ht.Add("PicClassID", SqlStringConstructor.GetQuotedString(PicClassID.SelectedItem.Value));
            ht.Add("SeoTitle", SqlStringConstructor.GetQuotedString(SeoTitle.Text));
            ht.Add("SeoKeywords", SqlStringConstructor.GetQuotedString(SeoKeywords.Text));
            ht.Add("SeoDesc", SqlStringConstructor.GetQuotedString(SeoDesc.Text));
            ht.Add("FacPicContent", SqlStringConstructor.GetQuotedString(content1.Value));

            facPic.Update(ht);

            Page.Response.Redirect("manage_facpic.aspx");
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