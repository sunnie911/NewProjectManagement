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

public partial class enet0769_admin_send_job : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        ht.Add("JobPosition", SqlStringConstructor.GetQuotedString(JobPosition.Text));
        ht.Add("JobDepartment", SqlStringConstructor.GetQuotedString(JobDepartment.Text));
        ht.Add("WorkAddress", SqlStringConstructor.GetQuotedString(WorkAddress.Text));
        ht.Add("AttermTime", SqlStringConstructor.GetQuotedString(AttermTime.Text));
        ht.Add("JobDemand", SqlStringConstructor.GetQuotedString(JobDemand.Text));

        Jobs job = new Jobs();
        job.Add(ht);

        Response.Redirect("send_job_prs.aspx");
    }
}
