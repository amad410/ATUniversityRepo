using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture16_Parallelism.BrowserFactory
{
    public static class BrowserFactory
    {
        public static IWebDriver InitDriver(BrowserType type)
        {
            switch (type)
            {
                case BrowserType.Chrome:
                    return new ChromeDriver();
                
                case BrowserType.Firefox:
                    return new FirefoxDriver();
                case BrowserType.Edge:
                    return new EdgeDriver();

                default:
                    throw new Exception("No Browser Type implementation");
            }
        }
    }

    public enum BrowserType
    {
        Chrome,
        Firefox,
        Edge
    }
}
