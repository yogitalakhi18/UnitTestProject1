using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SeleniumTDD.Core
{
    public class RunSettingsHelper
    {
        public static string SiteUrl;
        public static string UserId;
        public static string Password;
        public static string ItemName;
        public static string Keyword;
        public static string ScreenshotPath;

        public static void ReadRunSettings(TestContext context)
        {
            SiteUrl = Convert.ToString(context.Properties["SiteUrl"]);
            UserId = Convert.ToString(context.Properties["UserId"]);
            Password = Convert.ToString(context.Properties["Password"]);
            ItemName = Convert.ToString(context.Properties["ItemName"]);
            Keyword = Convert.ToString(context.Properties["Keyword"]);
            ScreenshotPath = Convert.ToString(context.Properties["ScreenshotPath"]);
        }
    }
}
