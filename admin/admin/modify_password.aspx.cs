using System;
using System.Data;
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

public partial class enet0769_admin_modify_password : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["ENETAdmin"] != null)
        {
            string temp = Convert.ToString(Request.Cookies["ENETAdmin"].Values["AdminAccount"]);     //读全部就用Request.Cookies["ENETAdmin"].Value)
            if (temp == "")
            {
                Response.Write("您还没有登陆！");
                Response.End();
            }
            else
            {
                this.ShowAdminAccount.Text = temp;
            }
        }
        else
        {
            Response.Write("您还没有登陆！");
            Response.End();
        }
    }

    /// <summary>
    /// “修改密码”按钮单击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        Admin admin = new Admin();					//实例化Admin类
        admin.LoadData(Request.Cookies["ENETAdmin"].Values["AdminAccount"].ToString());			    //利用Admin类的LoadData方法，获取用户信息

        if (admin.AdminPassword != Password.Text)
        {
            this.ModifyPasswordResultPanel.Visible = true;
            this.Message.Text = "旧密码输入错误。";
            return;
        }

        if (Password1.Text == "" || Password2.Text == "")
        {
            this.ModifyPasswordResultPanel.Visible = true;
            this.Message.Text = "新密码不能为空。";
            return;
        }

        if (Password1.Text != Password2.Text)
        {
            this.ModifyPasswordResultPanel.Visible = true;
            this.Message.Text = "两次输入的新密码不一致。";
            return;
        }

        Hashtable ht = new Hashtable();
        ht.Add("AdminPassword", SqlStringConstructor.GetQuotedString(Password1.Text));
        string where = " Where AdminAccount = " + SqlStringConstructor.GetQuotedString(admin.AdminAccount);
        Admin.Update(ht, where);
        this.ModifyPasswordPanel.Visible = false;
        this.ModifyPasswordResultPanel.Visible = true;
        this.Message.Text = "修改密码成功，请下次登录时用新密码登录。";
    }
}
