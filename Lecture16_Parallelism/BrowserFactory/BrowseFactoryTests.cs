using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture16_Parallelism.BrowserFactory
{
    [TestFixture]
    public class BrowseFactoryTests
    {
        [Test]
        public void InitializeMultipleDrivers()
        {
            IWebDriver edgeDriver = BrowserFactory.InitDriver(BrowserType.Edge);
            IWebDriver chromeDriver = BrowserFactory.InitDriver(BrowserType.Chrome);
            

            chromeDriver.Navigate().GoToUrl("http://google.com");
            edgeDriver.Navigate().GoToUrl("http://yahoo.com");

            chromeDriver.Quit();
            edgeDriver.Quit();
        }

    }
}
