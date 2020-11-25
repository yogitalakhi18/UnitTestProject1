using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System.IO;
using System;

namespace SeleniumTDD.Reporting
{
    public class HtmlReport : IReports
    {
        private ExtentReports _extent;
        private ExtentTest _test;

        private readonly string _appEnv;
        private readonly string _appUrl;
        private readonly string _appUserName;
        private readonly string _browser;
        private string ReportFolderLocation { get; set; }

        public HtmlReport(string appEnv, string appUrl, string appUserName, string browser, string reportFolderLocation)
        {
            _appEnv = appEnv;
            _appUrl = appUrl;
            _appUserName = appUserName;
            _browser = browser;
            ReportFolderLocation = reportFolderLocation;
        }

        private void CreateReportFolder()
        {
            String reportFolderPath = ReportFolderLocation;
            var todaysdate = DateTime.Now.ToString("dd-MMM-yyyy");
            if (!Directory.Exists(reportFolderPath + "\\" + todaysdate))
            {
                Directory.CreateDirectory(reportFolderPath + "\\" + todaysdate);
            }
            ReportFolderLocation = reportFolderPath + "\\" + todaysdate;
        }

        private string CreateReportFile(string reportFolderPath)
        {
            string reportDateTime = string.Format("{0:ddMMMyyyy-HHmm}", DateTime.Now);
            string reportPath = reportFolderPath + "\\ExeReport" + reportDateTime + ".html";

            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportPath);

            htmlReporter.Config.ReportName = "Automation Report";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;            
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
            _extent.AddSystemInfo("Env", _appEnv);
            _extent.AddSystemInfo("URL", _appUrl);
            _extent.AddSystemInfo("Browser", _browser);
            return reportPath;
        }

        public string StartReport()
        {
            CreateReportFolder();
            string reportPath = CreateReportFile(ReportFolderLocation);
            return reportPath;
        }

        public void StartTest(string testCaseId, string testCaseTitle)
        {
            _test = _extent.CreateTest(testCaseId, testCaseTitle);
        }

        public void StartParentTest(string testName, string testDescription)
        {
            throw new NotImplementedException();
        }

        public void Log(ReportStatus status, string logReport)
        {
            _test.Log(GetLogStatus(status), logReport);
        }

        public void LogInfo(string logReport)
        {
            _test.Log(Status.Info, logReport);
        }

        public void LogRunnerOutput(string logReport)
        {
            _extent.AddTestRunnerLogs(logReport);
        }

        public void LogException(Exception e)
        {
            _test.Log(Status.Fail, e.Message + e);
        }

        public void LogSuccess()
        {
            throw new NotImplementedException();
        }

        public void RemoveTest()
        {
            //_extent.RemoveTest(_test);
        }

        public void EndReport()
        {
            _extent.Flush();
        }

        public void TakeSnapshot(string imageFileLocation)
        {
            _test.Log(Status.Info, "Snapshot below: " + _test.AddScreenCaptureFromPath(imageFileLocation));
        }

        private Status GetLogStatus(ReportStatus result)
        {
            switch (result)
            {
                case ReportStatus.Pass:
                    return Status.Pass;

                case ReportStatus.Fail:
                    return Status.Fail;

                default:
                    return Status.Fail;
            }
        }
    }
}
