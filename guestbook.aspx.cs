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
using System.Net.Mail;

using EnterpriseNET.BusinessLogicLayer;
using EnterpriseNET.DataAccessHelper;

public partial class guestbook : System.Web.UI.Page
{
    public string mailContent;

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["MUID"] = 6;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //利用session验证
        if (String.Compare(Session["CheckCode"].ToString(), this.ValidaCode.Text, true) == 0)
        {
            Hashtable ht = new Hashtable();
            ht.Add("GuestName", SqlStringConstructor.GetQuotedString(GuestName.Text));
            ht.Add("GuestPosition", SqlStringConstructor.GetQuotedString(GuestPosition.Text));
            ht.Add("Sex", SqlStringConstructor.GetQuotedString(Sex.Text));
            ht.Add("CompanyName", SqlStringConstructor.GetQuotedString(CompanyName.Text));
            ht.Add("Tel", SqlStringConstructor.GetQuotedString(Tel.Text));
            ht.Add("Email", SqlStringConstructor.GetQuotedString(Email.Text));
            ht.Add("WebSite", SqlStringConstructor.GetQuotedString(WebSite.Text));
            ht.Add("GuestContent", SqlStringConstructor.GetQuotedString(GuestContent.Text));

            Guestbook guestbook = new Guestbook();
            guestbook.Add(ht);

            Sendmail();

            Response.Redirect("guestbook_prs.aspx");
        }
        else
        {
            //Response.Write("<Script Language=JavaScript>alert(\"验证码输入错误！\")</Script>");
            this.ShowTipMessage.Text = "&nbsp;&nbsp;验证码输入错误，请重新输入验证码！";
        }
    }

    public MailMessage InitMail(string Address)
    {
        mailContent = "姓名：" + this.GuestName.Text + "<br />职位：" + this.GuestPosition.Text + "<br />性别：" + this.Sex.SelectedValue + "<br />公司名称：" + this.CompanyName.Text;
        mailContent = mailContent + "<br />联系电话：" + this.Tel.Text + "<br />电子邮箱：" + this.Email.Text + "<br />网址：" + this.WebSite.Text + "<br />留言内容：" + this.GuestContent.Text;

        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(Address);   //发件人
        mail.To.Add(new MailAddress("42805021@qq.com"));  //收件人
        mail.Subject = "长原连接器客户留言，来自：" + this.GuestName.Text;    //主题
        mail.Body = mailContent; //内容
        mail.SubjectEncoding = System.Text.Encoding.UTF8;   //邮件主题编码格式
        mail.BodyEncoding = System.Text.Encoding.UTF8;      //正文编码格式
        mail.IsBodyHtml = true; //邮件正文是Html编码
        mail.Priority = MailPriority.High;  //优先级
        //mail.Bcc.Add(Address);  //密件抄送收件人
        //mail.CC.Add(Address); //抄送收件人
        return mail;
    }

    public bool Sendmail()
    {       
        SmtpClient client = new SmtpClient();
        client.Credentials = new System.Net.NetworkCredential("13728403827", "dzydqeudfmtmisvx");  //这个地方需要填写自己申请的用户名和密码
        client.Port =25;    //邮箱端口
        client.Host = "smtp.163.com";
        client.EnableSsl = true;    //经过ssl加密
        try
        {
            client.Send(InitMail("13728403827@163.com"));
            return true;
        }
        catch
        {
            return false;
        }
    } 
}
