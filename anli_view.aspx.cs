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

public partial class anli_view : System.Web.UI.Page
{
    public string ProjectName, PicPathBig, ProjectContent;

    protected void Page_Load(object sender, EventArgs e)
    {
          if (!IsPostBack)
        {
            try
            {
                int projectID = -1;
                string strSql = "";
                if (Request.QueryString["ProjectID"] != "")
                    projectID = Convert.ToInt32(Request.QueryString["ProjectID"]);

                ProjectCase projectCase = new ProjectCase();
                projectCase.LoadData(projectID);

                if (projectCase.Exist)
                {
                    //显示工程案例详细内容
                    ProjectName = projectCase.ProjectName;
                    PicPathBig = projectCase.PicPathBig;
                    ProjectContent = projectCase.ProjectContent;

                    Page.DataBind();

                    Random random = new Random(System.Guid.NewGuid().GetHashCode());
                    int r = random.Next();
                    strSql = "select top 3 ProjectID,ProjectName,PicPathSmall from cai_ProjectCase order by rnd(" + (-r) + "*ProjectID)";
                    DataView dvlist = Product2.QueryProducts(strSql);
                    ProductListNew.DataSource = dvlist;
                    ProductListNew.DataBind();
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

}