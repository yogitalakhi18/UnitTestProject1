using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using System;

namespace SeleniumTDD.Browser
{
    public class InternetExplorerBrowserDriver : AbstractBrowserDriver
    {
        override
        public IWebDriver CreateWebDriver()
        {
            InternetExplorerOptions options = new InternetExplorerOptions
            {
                IgnoreZoomLevel = true,
                EnableNativeEvents = false,
                EnablePersistentHover = false,
                AcceptInsecureCertificates = true
            };
            IWebDriver webDriver = null;
            bool isRemotDriver = false;
            //TODO: Pick value from config file 
            if (!isRemotDriver)//Boolean.parseBoolean(XiomateConfiguration.getInstance().getValue("xiomate.test.remote"))
            {
                webDriver = LaunchGridDriver(options, new Uri("uri"));//XiomateConfiguration.getInstance().getValue("xiomate.test.grid.url"
            }
            else
            {
                webDriver = new InternetExplorerDriver(options);
            }
            return webDriver;
        }
    }
}
