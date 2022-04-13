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

public partial class enet0769_admin_order_detail : System.Web.UI.Page
{
    public string Action;
    public string OrderSubject, OrderDesc, CompanyName, Manager, Address, ZipCode, Tel, Fax, Mobile, WebSite, Email, AddTime;

    protected void Page_Load(object sender, EventArgs e)
    {
        Action = Convert.ToString(Request.QueryString["Action"]);
        switch (Action)
        {
            case "ViewOrder":
                if (!IsPostBack)
                    InitData();
                break;
            case "DeleteOrder":
                int orderID = Convert.ToInt32(Request.QueryString["OrderID"]);
                Order order = new Order();

                order.LoadData(orderID);
                order.Delete();

                Response.Redirect("manage_order.aspx");

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
        int orderID = Convert.ToInt32(Request.QueryString["OrderID"]);
        Order order = new Order();

        order.LoadData(orderID);
        OrderSubject = order.orderSubject;
        OrderDesc = order.orderDesc;
        CompanyName = order.companyName;
        Manager = order.manager;
        Address = order.address;
        ZipCode = order.zipCode;
        Tel = order.tel;
        Fax = order.fax;
        Mobile = order.mobile;
        WebSite = order.webSite;
        Email = order.email;
        AddTime = order.addTime.ToLongDateString();

        Page.DataBind();
    }
}
