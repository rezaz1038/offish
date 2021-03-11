using System;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Http;
using static SoftIran.Insfrastrcture.Utilities;

namespace SoftIran.Insfrastrcture
{
    public static class ExtensionMethods
    {
        public static string GetUserId(this HttpContext context)
        {
            return context.User == null ? string.Empty : context.User.Claims.Single(x => x.Type == "id").Value;
        }

        public static string ToShamsi(this DateTime dateTime)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(dateTime).ToString("0000") + "/" +
                   pc.GetMonth(dateTime).ToString("00") + "/" +
                   pc.GetDayOfMonth(dateTime).ToString("00");


        }

        public static string FileUrl(this string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return "";
            var config = Singleton.Instance.Configuration;
            var context = Singleton.Instance.httpContextAccessor.HttpContext;
            return
                $"{context.Request.Scheme}://{context.Request.Host}{context.Request.PathBase}/{config["Slug"]}/thumbnail/{fileName}";
        }

    }
}