using System;
using System.Data;
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
            driver.Navigate().GoToUrl("http://www.ultimateqa.com/filling-out-forms/");   
            
            var locator = By.Id("et_pb_contact_name_1");
            var nameField = driver.FindElements(locator);
            nameField[1].Clear();
            nameField[1].SendKeys("Przykładowa nazwa");

            var locator1 = By.Id("et_pb_contact_message_1");
            var messageField = driver.FindElements(locator1);
            messageField[1].Clear();
            messageField[1].SendKeys("Przykładowy tekst");

           
            var locator2 = By.ClassName("et_pb_contact_captcha_question");
            var captcha = driver.FindElement(locator2);
            var table = new DataTable();
            var captchaAnswer = (int)table.Compute(captcha.Text,"");

            //wpisanie captcha do okienka
            var captchaTextBox = driver.FindElement(By.XPath("//*[@class='input et_pb_contact_captcha']"));
            captchaTextBox.SendKeys(captchaAnswer.ToString());

            driver.FindElements(By.XPath("//*[@class='et_pb_contact_submit et_pb_button']"))[1].Submit();


        }
    }
}
