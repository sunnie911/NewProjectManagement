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

public partial class enet0769_default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 用户单击“登录”按钮事件方法
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        //获取用户在页面上的输入
        string adminAccount = Account.Text;		    //管理员登录名
        string adminPassword = Password.Text;		//管理员密码

        Admin admin = new Admin();					//实例化Admin类
        admin.LoadData(adminAccount);			    //利用Admin类的LoadData方法，获取用户信息

        if (admin.Exist)	                        //如果用户存在
        {
            if (admin.AdminPassword == adminPassword)	        //如果密码正确，转入管理员页面
            {
                //Session.Add("AdminAccount", adminAccount);      //使用Session保存管理员登录名信息
                HttpCookie cookie = new HttpCookie("ENETAdmin");        //定义cookie对象以及名为Info的项
                DateTime dt = DateTime.Now;                             //定义时间对象
                TimeSpan ts = new TimeSpan(1, 0, 0, 0);                 //cookie有效作用时间，具体查msdn
                cookie.Expires = dt.Add(ts);                            //添加作用时间
                cookie.Values.Add("AdminAccount",adminAccount);        //增加属性
                Response.AppendCookie(cookie);                          //确定写入cookie中
                Response.Redirect("admin/admin.aspx"); 
            }
            else		                                        //如果密码错误，给出提示，光标停留在密码框中
            {
                Response.Write("<Script Language=JavaScript>alert(\"密码错误，请重新输入密码！\")</Script>");
            }
        }
        else			                                        //如果用户不存在
        {
            Response.Write("<Script Language=JavaScript>alert(\"对不起，用户不存在！\")</Script>");
        }
    }
}
