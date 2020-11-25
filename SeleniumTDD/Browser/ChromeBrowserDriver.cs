using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace SeleniumTDD.Browser
{
    public class ChromeBrowserDriver : AbstractBrowserDriver
    {
        override
        public IWebDriver CreateWebDriver()
        {
            ChromeOptions option = new ChromeOptions
            {
                AcceptInsecureCertificates = true,
                UseSpecCompliantProtocol = true
            };
            option.AddArguments("test-type", "start-maximized", "no-default-browser-check", "--disable-extensions");
            IWebDriver webDriver = null;
            bool isRemotDriver = false;
            //Pick value from config file 
            //if (!isRemotDriver)//Boolean.parseBoolean(XiomateConfiguration.getInstance().getValue("xiomate.test.remote"))
            //{
            //    webDriver = LaunchGridDriver(option, new Uri("uri"));//XiomateConfiguration.getInstance().getValue("xiomate.test.grid.url"
            //}
            //else
            //{
            //    webDriver = new ChromeDriver(option);
            //}

            webDriver = new ChromeDriver(option);

            return webDriver;
        }
    }
}
