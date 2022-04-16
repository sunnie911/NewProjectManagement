using System;

namespace DanaZhangCms.Controllers.Filters
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ControllerDescriptionAttribute : Attribute
    {

        public string Name { get; set; }

        public string Description { get; set; } = null;
    }
    [AttributeUsage(AttributeTargets.Method)]
    public class ActionDescriptionAttribute : Attribute
    {
        public string Name { get; set; }

        public string Description { get; set; } = null;
    }
}