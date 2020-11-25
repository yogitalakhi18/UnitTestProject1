using SeleniumTDD.Browser;
using OpenQA.Selenium;
using System;

namespace SeleniumTDD.Core
{
    public class SeleniumToolsFactory : IToolsFactory
    {
        public IWebDriver webDriver;

        public SeleniumToolsFactory()
        {
            //this.config = XiomateConfiguration.getInstance();            
        }

        // override
        public void CreateInstance()
        {
            AbstractBrowserDriver driver = null;

            switch ("CHROME")//TODO: Pick from config file
            {
                case "FIREFOX":
                    driver = new FirefoxBrowserDriver();
                    break;
                case "CHROME":
                    driver = new ChromeBrowserDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerBrowserDriver();
                    break;
            }
            webDriver = driver.GetDriver();
        }

        public T GetInstance<T>()
        {
            return (T)this.webDriver;
        }

        // override
        public void CloseInstance()
        {
            this.webDriver.Close();
            if ("IE".Equals("browserName"))//Pick from config file
            {
                try
                {
                    webDriver.Quit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
