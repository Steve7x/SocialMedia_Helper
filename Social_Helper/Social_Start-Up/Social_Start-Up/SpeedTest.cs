using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Social_Start_Up
{
    class SpeedTest
    {
        public static NameValueCollection appSettings = ConfigurationManager.AppSettings;

        public static void MySpeedTestMethod(FirefoxDriver fireFoxDriver)
        {
            string thisClass = "SpeedTest";
            fireFoxDriver.Navigate().GoToUrl("https://speedof.me/");
            try
            {
                fireFoxDriver.FindElement(By.XPath("//a[contains(., 'ACCEPT')]")).Click();
            }
            catch (Exception ex) { ExceptionHelper.ExceptionAndLineNumber(ex, thisClass); }

            fireFoxDriver.FindElement(By.XPath("//button[contains(., 'START')]")).Click();
            WebDriverWait wait = new WebDriverWait(fireFoxDriver, TimeSpan.FromSeconds(60));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".result-retry-icon")));
            IWebElement SpeedData = fireFoxDriver.FindElement(By.CssSelector("text.progress-download-color:nth-child(1)"));
            Console.WriteLine(SpeedData.GetAttribute("innerHTML"));
            //fireFoxDriver.Dispose();
        }
    }
}
