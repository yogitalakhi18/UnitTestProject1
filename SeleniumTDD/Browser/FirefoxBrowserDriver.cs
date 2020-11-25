using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;

namespace SeleniumTDD.Browser
{
    public class FirefoxBrowserDriver : AbstractBrowserDriver
    {
        override
    public IWebDriver CreateWebDriver()
        {
            FirefoxOptions options = new FirefoxOptions
            {
                AcceptInsecureCertificates = true
            };
            IWebDriver webDriver = null;
            bool isRemotDriver = false;
            //Pick value from config file 
            if (!isRemotDriver)//Boolean.parseBoolean(XiomateConfiguration.getInstance().getValue("xiomate.test.remote"))
            {
                webDriver = LaunchGridDriver(options, new Uri("uri"));//XiomateConfiguration.getInstance().getValue("xiomate.test.grid.url"
            }
            else
            {
                webDriver = new FirefoxDriver(options);
            }
            return webDriver;
        }
    }
}
