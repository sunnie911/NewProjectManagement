using System;
using System.ComponentModel.DataAnnotations;

namespace DanaZhangCms.Core.Models
{
    /// <summary>
    /// 站点配置实体类
    /// </summary>
    [Serializable]
    public class SiteXml
    {



        #region 主站基本信息==================================
        /// <summary>
        /// 网站名称
        /// </summary>
        [Display(Name = "网站名称")]
        public string webname { get; set; }
        /// <summary>
        /// 网站域名
        /// </summary>
        [Display(Name = "网站域名")]
        public string weburl { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        [Display(Name = "公司名称")]
        public string webcompany { get; set; }

        /// <summary>
        /// 通讯地址
        /// </summary>
        [Display(Name = "通讯地址")]
        public string webaddress { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [Display(Name = "联系电话")]
        public string webtel { get; set; }


        /// <summary>
        /// 邮箱
        /// </summary>
        [Display(Name = "邮箱")]
        public string webmail { get; set; }

        /// <summary>
        /// 网站备案号
        /// </summary>
        [Display(Name = "网站备案号")]
        public string webcrod { get; set; }

        /// <summary>
        /// Logo
        /// </summary>
        [Display(Name = "Logo")]
        public string logo { get; set; }
        #endregion


        #region Seo

        [Display(Name = "Seo 标题")]
        public string SeoTitle { get; set; }
        [Display(Name = "Seo 关键字")]
        public string SeoKeyword { get; set; }
        [Display(Name = "Seo 描述")]
        public string SeoDescription { get; set; }
        #endregion

        #region 统计代码==================================
        /// <summary>
        /// 网站统计代码
        /// </summary>
        public string webcountcode { get; set; } = "";
        #endregion





        #region 文件上传设置==================================
        /// <summary>
        /// 附件上传目录
        /// </summary>
        public string filepath { get; set; } = "";
        /// <summary>
        /// 附件保存方式
        /// </summary>
        public int filesave { get; set; } = 1;
        /// <summary>
        /// 附件上传类型
        /// </summary>
        public string fileextension { get; set; } = "";
        /// <summary>
        /// 视频上传类型
        /// </summary>
        public string videoextension { get; set; } = "";
        /// <summary>
        /// 文件上传大小
        /// </summary>
        public int attachsize { get; set; } = 0;
        /// <summary>
        /// 视频上传大小
        /// </summary>
        public int videosize { get; set; } = 0;
        /// <summary>
        /// 图片上传大小
        /// </summary>
        public int imgsize { get; set; } = 0;
        /// <summary>
        /// 图片最大高度(像素)
        /// </summary>
        public int imgmaxheight { get; set; } = 0;
        /// <summary>
        /// 图片最大宽度(像素)
        /// </summary>
        public int imgmaxwidth { get; set; } = 0;
        /// <summary>
        /// 生成缩略图高度(像素)
        /// </summary>
        public int thumbnailheight { get; set; } = 0;
        /// <summary>
        /// 生成缩略图宽度(像素)
        /// </summary>
        public int thumbnailwidth { get; set; } = 0;
        /// <summary>
        /// 图片水印类型
        /// </summary>
        public int watermarktype { get; set; } = 0;
        /// <summary>
        /// 图片水印位置
        /// </summary>
        public int watermarkposition { get; set; } = 9;
        /// <summary>
        /// 图片生成质量
        /// </summary>
        public int watermarkimgquality { get; set; } = 80;
        /// <summary>
        /// 图片水印文件
        /// </summary>
        public string watermarkpic { get; set; } = "";
        /// <summary>
        /// 水印透明度
        /// </summary>
        public int watermarktransparency { get; set; } = 10;
        /// <summary>
        /// 水印文字
        /// </summary>
        public string watermarktext { get; set; } = "";
        /// <summary>
        /// 文字字体
        /// </summary>
        public string watermarkfont { get; set; } = "";
        /// <summary>
        /// 文字大小(像素)
        /// </summary>
        public int watermarkfontsize { get; set; } = 12;
        #endregion
    }
}
