using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrationTests.Utilities
{
    class Browser
    {
        public enum WebBrowsers
        {
            Chrome,
            Firefox,
            Edge
        }

        public static IWebDriver GetDriver(WebBrowsers browsersType)
        {
            switch (browsersType)
            {
                case WebBrowsers.Chrome:
                    {
                        var chromeOptions = new ChromeOptions();

                        if (FrameworkConstants.startMaximized)
                        {
                            chromeOptions.AddArgument("--start-maximized");
                        }
                        if (FrameworkConstants.startHeadless)
                        {
                            chromeOptions.AddArgument("headless");
                        }
                        if (FrameworkConstants.ignoreCertErr)
                        {
                            chromeOptions.AddArgument("ignore-certificate-errors");
                        }

                        var proxy = new Proxy
                        {
                            HttpProxy = FrameworkConstants.browserProxy,
                            IsAutoDetect = false
                        }; 
                        if (FrameworkConstants.useProxy)
                        {
                            chromeOptions.Proxy = proxy;
                        }
                        return new ChromeDriver(chromeOptions);
                    }
                case WebBrowsers.Firefox:
                    {
                        var firefoxOptions = new FirefoxOptions();
                        List<string> optionList = new List<string>();
                        if (FrameworkConstants.startHeadless)
                        {
                            optionList.Add("--headless");
                        }
                        if (FrameworkConstants.ignoreCertErr)
                        {
                            optionList.Add("--ignore-certificate-errors");
                        }

                        firefoxOptions.AddArguments(optionList);
                        FirefoxProfile fProfile = new FirefoxProfile();

                        if (FrameworkConstants.startWithExtension)
                        {
                            fProfile.AddExtension(FrameworkConstants.GetExtensionName(browsersType));
                        }
                        firefoxOptions.Profile = fProfile;

                        return new FirefoxDriver(firefoxOptions);
                    }
                case WebBrowsers.Edge:
                    {
                        var edgeOptions = new EdgeOptions();

                        if (FrameworkConstants.startMaximized)
                        {
                            edgeOptions.AddArgument("--start-maximized");
                        }
                        if (FrameworkConstants.startHeadless)
                        {
                            edgeOptions.AddArgument("--headless");
                        }
                        if (FrameworkConstants.startWithExtension)
                        {
                            edgeOptions.AddExtension(FrameworkConstants.GetExtensionName(browsersType));
                        }
                        //edgeOptions.AddArgument("headless");
                        return new EdgeDriver(edgeOptions);
                    }
                default:
                    {
                        throw new BrowserTypeException(browsersType.ToString());
                    }
            }
        }

        public static IWebDriver GetDriver()
        {
            WebBrowsers cfgBrowsers;
            switch (FrameworkConstants.configBrowser.ToUpper())
            {
                case "FIREFOX":
                    {
                        cfgBrowsers = WebBrowsers.Firefox;
                        break;
                    }
                case "CHROME":
                    {
                        cfgBrowsers = WebBrowsers.Chrome;
                        break;
                    }
                case "EDGE":
                    {
                        cfgBrowsers = WebBrowsers.Edge;
                        break;
                    }
                default:
                    {
                        throw new BrowserTypeException(String.Format("Browser {0} not supported", FrameworkConstants.configBrowser));
                    }

            }
            return GetDriver(cfgBrowsers);
        }
    }
}
