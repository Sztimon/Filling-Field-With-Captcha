using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //podpięcie drivera
        private IWebDriver GetChromeDriver()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }
        //do testu gita
        [TestMethod]
        public void Test1()
        {
            var driver = GetChromeDriver();
            driver.Navigate().GoToUrl("http://www.qtptutorial.net/automation-practice");

            //Find an element using an id
            driver.FindElement(By.Id("idExample"));
            var idelement = driver.FindElement(By.Id("idExample"));
            idelement.Click();
            driver.Navigate().Back();
        }
    }
}
