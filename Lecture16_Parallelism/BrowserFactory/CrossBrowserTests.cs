using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture16_Parallelism.BrowserFactory
{    
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(EdgeDriver))]
    public  class CrossBrowserTests<CustomWebDriver> where CustomWebDriver : IWebDriver, new()
    {
        private IWebDriver? driver;
        
        [Test]
        public void MyTestWithAllBrowsers()
        {
            driver = new CustomWebDriver();
            driver.Navigate().GoToUrl("http://www.google.com");
        }

        [TearDown]
        public void Clean()
        {
            if (driver != null)
            {
                driver.Close();
            }
        }
    }
}
