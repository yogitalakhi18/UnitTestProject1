using OpenQA.Selenium.Remote;
using System.Threading;
using OpenQA.Selenium;
using System;

namespace SeleniumTDD.Browser
{
    public abstract class AbstractBrowserDriver
    {
        private ThreadLocal<IWebDriver> _driverContainer = new ThreadLocal<IWebDriver>();
        private DriverOptions driverOptions = null;

        public AbstractBrowserDriver()
        {
            SetDriver();
        }

        private void SetDriver()
        {
            _driverContainer.Value = CreateWebDriver();
        }

        public IWebDriver GetDriver()
        {
            return _driverContainer.Value;
        }

        public abstract IWebDriver CreateWebDriver();

        public DriverOptions GetCapabilities()
        {
            return driverOptions;
        }

        public void SetCapabilities(string capabilityName, object capabilityValue)
        {
            this.driverOptions.AddAdditionalCapability(capabilityName, capabilityValue);
        }

        protected IWebDriver LaunchGridDriver(DriverOptions options, Uri uri)
        {
            try
            {
                return new RemoteWebDriver(uri, options.ToCapabilities(), TimeSpan.FromSeconds(600));
            }
            catch (WebDriverException) //Need to check exception type
            {
                throw new WebDriverException("Unable to connect to the grid url");
            }
        }

    }
}
