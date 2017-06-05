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
            driver.Navigate().GoToUrl("http://www.ultimateqa.com");
            Assert.AreEqual("Home - Ultimate QA", driver.Title);
            driver.Navigate().GoToUrl("http://www.ultimateqa.com/automation");
            Assert.AreEqual("Automation Practice - Ultimate QA", driver.Title);
            var locator = By.XPath(".//*[@href='/complicated-page']");
            var element = driver.FindElement(locator);
            element.Click();
            Assert.AreEqual("Complicated Page - Ultimate QA", driver.Title);
            driver.Navigate().Back();
            Assert.AreEqual("Automation Practice - Ultimate QA", driver.Title);

            //find an element using link text
            //var linktextelement = driver.findelement(by.linktext("Click Me"));
            //linktextelement.click();
            //driver.navigate().back();
        }
    }
}
