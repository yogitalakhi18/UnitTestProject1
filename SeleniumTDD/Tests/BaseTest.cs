using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumTDD.Reporting;
using SeleniumTDD.Pages;
using SeleniumTDD.Core;
using OpenQA.Selenium;
using System;

namespace SeleniumTDD.Tests
{
    [TestClass]
    public class BaseTest
    {
        public static IWebDriver Driver;
        public static HtmlReport report;
        public static TestContext _testContext { get; set; }
        
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            string url = Convert.ToString(context.Properties["SiteUrl"]);

            RunSettingsHelper.ReadRunSettings(context);
            report = new HtmlReport("Selenium Tests", RunSettingsHelper.SiteUrl, "", "Google Chrome", RunSettingsHelper.ScreenshotPath);
            report.StartReport();
            _testContext = context;
        }

        public BaseTest()
        {
            SeleniumToolsFactory toolsFactory = new SeleniumToolsFactory();
            toolsFactory.CreateInstance();
            ExecutorFactory.RegisterToolFactory(toolsFactory);
            Driver = (IWebDriver)ExecutorFactory.GetToolFactory().GetInstance<IWebDriver>();
            Driver.Navigate().GoToUrl(RunSettingsHelper.SiteUrl);
        }

        public static HomePage IsLandingPageLoadedSucessfully()
        {
            return new HomePage();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            try
            {
                if (_testContext.CurrentTestOutcome == UnitTestOutcome.Passed)
                    report.Log(ReportStatus.Pass, "'" + _testContext.TestName + "'" + " Test Passed.");
                else
                    report.Log(ReportStatus.Fail, "'" + _testContext.TestName + "'" + " Test failed.");
            }
            catch (Exception e)
            {
                report.Log(ReportStatus.Fail, "'" + _testContext.TestName + "'" + " Test failed in with exception.");
                report.LogException(e);
            }

            report.EndReport();

            if (Driver != null)
            {
                Driver.Quit();
                Driver = null;
            }
        }
    }
}
