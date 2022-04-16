namespace DanaZhangCms.Core.Models
{
    public class PageModel
    {
        public int code{get;set;}
        public bool @is { get; set; }

        public string msg { get; set; }

        public object data { get; set; }

        public int count{get;set;}
     public static object Result(object data,bool success=true,int count=0)
        {
            return  new { code =0, tip = "操作成功！", msg="",@is=true, count=count,data=data };
        }
    }
}