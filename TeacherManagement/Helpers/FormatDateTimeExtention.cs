using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeacherManagement.Helpers
{
    public static class FormatDateTimeExtention
    {
        public static string FormatDateTime2Date(this HtmlHelper helper,DateTime dateTime)
        {
            return dateTime.ToString("dd-MM-yyy");
        }
    }
}