using System;

namespace SeleniumTDD.Reporting
{
    public interface IReports
    {
        string StartReport();
        void StartTest(string testCaseId, string testCaseTitle);
        void StartParentTest(string testName, string testDescription);
        void Log(ReportStatus status, string logReport);
        void LogInfo(string logReport);
        void LogRunnerOutput(string logReport);
        void LogException(Exception e);
        void LogSuccess();
        void RemoveTest();
        void EndReport();
        void TakeSnapshot(string imageFileLocation);
    }
}
