using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.AspNetCore.Http;

namespace DanaZhangCms.Core.Helpers
{
    public class CommonHelper
    {
        private static Random rnd = new Random();

        private static readonly int __staticMachine = ((0x00ffffff & Environment.MachineName.GetHashCode()) +
#if NETSTANDARD1_5 || NETSTANDARD1_6
			1
#else
                                                       AppDomain.CurrentDomain.Id
#endif
                                                      ) & 0x00ffffff;
        private static readonly int __staticPid = Process.GetCurrentProcess().Id;
        private static int __staticIncrement = rnd.Next();

        /// <summary>
        /// 生成类似Mongodb的ObjectId有序、不重复Guid
        /// </summary>
        /// <returns></returns>
        public static Guid NewMongodbId()
        {
            var now = DateTime.Now;
            var uninxtime = (int) now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            var increment = Interlocked.Increment(ref __staticIncrement) & 0x00ffffff;
            var rand = rnd.Next(0, int.MaxValue);
            var guid =
                $"{uninxtime.ToString("x8").PadLeft(8, '0')}{__staticMachine.ToString("x8").PadLeft(8, '0').Substring(2, 6)}{__staticPid.ToString("x8").PadLeft(8, '0').Substring(6, 2)}{increment.ToString("x8").PadLeft(8, '0')}{rand.ToString("x8").PadLeft(8, '0')}";
            return Guid.Parse(guid);
        }

        /// <summary>
        /// 获取日期差
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string GetDateDiff(DateTime src)
        {
            string result = null;

            var currentSecond = (long)(DateTime.Now - src).TotalSeconds;

            long minSecond = 60;                //60s = 1min  
            var hourSecond = minSecond * 60;   //60*60s = 1 hour  
            var daySecond = hourSecond * 24;   //60*60*24s = 1 day  
            var weekSecond = daySecond * 7;    //60*60*24*7s = 1 week  
            var monthSecond = daySecond * 30;  //60*60*24*30s = 1 month  
            var yearSecond = daySecond * 365;  //60*60*24*365s = 1 year  

            if (currentSecond >= yearSecond)
            {
                var year = (int)(currentSecond / yearSecond);
                result = $"{year}年前";
            }
            else if (currentSecond < yearSecond && currentSecond >= monthSecond)
            {
                var month = (int)(currentSecond / monthSecond);
                result = $"{month}个月前";
            }
            else if (currentSecond < monthSecond && currentSecond >= weekSecond)
            {
                var week = (int)(currentSecond / weekSecond);
                result = $"{week}周前";
            }
            else if (currentSecond < weekSecond && currentSecond >= daySecond)
            {
                var day = (int)(currentSecond / daySecond);
                result = $"{day}天前";
            }
            else if (currentSecond < daySecond && currentSecond >= hourSecond)
            {
                var hour = (int)(currentSecond / hourSecond);
                result = $"{hour}小时前";
            }
            else if (currentSecond < hourSecond && currentSecond >= minSecond)
            {
                var min = (int)(currentSecond / minSecond);
                result = $"{min}分钟前";
            }
            else if (currentSecond < minSecond && currentSecond >= 0)
            {
                result = "刚刚";
            }
            else
            {
                result = src.ToString("yyyy/MM/dd HH:mm:ss");
            }
            return result;
        }

        /// <summary>
        /// 获得类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type GetTypeByString(string type)
        {
            switch (type.ToLower())
            {
                case "system.boolean":
                    return Type.GetType("System.Boolean", true, true);
                case "system.byte":
                    return Type.GetType("System.Byte", true, true);
                case "system.sbyte":
                    return Type.GetType("System.SByte", true, true);
                case "system.char":
                    return Type.GetType("System.Char", true, true);
                case "system.decimal":
                    return Type.GetType("System.Decimal", true, true);
                case "system.double":
                    return Type.GetType("System.Double", true, true);
                case "system.single":
                    return Type.GetType("System.Single", true, true);
                case "system.int32":
                    return Type.GetType("System.Int32", true, true);
                case "system.uint32":
                    return Type.GetType("System.UInt32", true, true);
                case "system.int64":
                    return Type.GetType("System.Int64", true, true);
                case "system.uint64":
                    return Type.GetType("System.UInt64", true, true);
                case "system.object":
                    return Type.GetType("System.Object", true, true);
                case "system.int16":
                    return Type.GetType("System.Int16", true, true);
                case "system.uint16":
                    return Type.GetType("System.UInt16", true, true);
                case "system.string":
                    return Type.GetType("System.String", true, true);
                case "system.datetime":
                case "datetime":
                    return Type.GetType("System.DateTime", true, true);
                case "system.guid":
                    return Type.GetType("System.Guid", true, true);
                default:
                    return Type.GetType(type, true, true);
            }
        }

        /// <summary>
        /// 文件大小
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string FormatByteSize(double bytes)
        {
            string[] SizeSuffixes = { "bytes", "KB", "MB", "GB" };

            int index = 0;
            if (bytes > 1023)
            {
                do
                {
                    bytes /= 1024;
                    index++;
                } while (bytes >= 1024 && index < 3);
            }

            return $"{bytes:0.00} {SizeSuffixes[index]}";
        }

        /// <summary>
        /// 截取字符串一定个数
        /// </summary>
        /// <param name="title"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GetSubString(string title, int length)
        {
            var result = "";
            if (!string.IsNullOrEmpty(title))
            {
                result = title;
                if (title.Length > length)
                {
                    result = title.Substring(0, length) + "...";
                }

            }
            return result;
        }

        ///   <summary>   
        ///    去除HTML标记   
        ///   </summary>   
        ///   <param    name="NoHTML">包括HTML的源码   </param>   
        ///   <returns>已经去除后的文字</returns>   
        public static string NoHTML(string Htmlstring)
        {
            Htmlstring = Htmlstring ?? "";

            //删除脚本   
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML   
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");

            //Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            return Htmlstring;



        }

    }
}
