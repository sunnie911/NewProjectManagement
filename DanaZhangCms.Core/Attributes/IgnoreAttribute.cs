using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DanaZhangCms.Core.Attributes
{
    public class IgnoreAttribute:Attribute, IFilterMetadata
    {
    }
}
