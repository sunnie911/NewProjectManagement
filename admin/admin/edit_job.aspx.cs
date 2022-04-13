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

public partial class enet0769_admin_edit_job : System.Web.UI.Page
{
    public string Action;

    protected void Page_Load(object sender, EventArgs e)
    {
        Action = Convert.ToString(Request.QueryString["Action"]);

        switch (Action)
        {
            case "EditJob":
                if (!IsPostBack)
                    InitData();
                break;
            case "DeleteJob":
                int jobID = Convert.ToInt32(Request.QueryString["JobID"]);
                Jobs job = new Jobs();

                job.LoadData(jobID);
                job.Delete();
                Response.Redirect("manage_job.aspx");

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
        int jobID = Convert.ToInt32(Request.QueryString["JobID"]);
        Jobs job = new Jobs();
        job.LoadData(jobID);

        JobPosition.Text = job.jobPosition;
        JobDepartment.Text = job.jobDepartment;
        WorkAddress.Text = job.workAddress;
        AttermTime.Text = job.attermTime;
        JobDemand.Text = job.jobDemand;

    }


    protected void Button1_Update_Click(object sender, EventArgs e)
    {
        Jobs job = new Jobs();
        job.jobID = Convert.ToInt32(Request.QueryString["JobID"]);

        Hashtable ht = new Hashtable();
        ht.Add("JobPosition", SqlStringConstructor.GetQuotedString(JobPosition.Text));
        ht.Add("JobDepartment", SqlStringConstructor.GetQuotedString(JobDepartment.Text));
        ht.Add("WorkAddress", SqlStringConstructor.GetQuotedString(WorkAddress.Text));
        ht.Add("AttermTime", SqlStringConstructor.GetQuotedString(AttermTime.Text));
        ht.Add("JobDemand", SqlStringConstructor.GetQuotedString(JobDemand.Text));

        job.Update(ht);

        Page.Response.Redirect("manage_job.aspx");
    }
}
