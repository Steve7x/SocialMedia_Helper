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
    class BriefMeNow
    {
        public static NameValueCollection appSettings = ConfigurationManager.AppSettings;

        public static void MyBriefMeNowMethod(FirefoxDriver fireFoxDriver)
        {
            Actions actions = new Actions(fireFoxDriver);

            TimeSpan span = new TimeSpan(0, 0, 0, 20, 0);
            WebDriverWait wait = new WebDriverWait(fireFoxDriver, span);
            string thisClass = "BriefMeNow";
            try
            {
                fireFoxDriver.Navigate().GoToUrl("https://www.briefmenow.org/microsoft/");
                fireFoxDriver.FindElement(By.XPath("//input[contains(@placeholder,'Enter your email address')]")).SendKeys("myemail@hotmail.com");
                fireFoxDriver.FindElement(By.XPath("//button[contains(., 'CODE')]")).Click();
                fireFoxDriver.FindElement(By.XPath("//i[contains(@class, 'icon-close')]")).Click();
                //fireFoxDriver.FindElements(By.XPath("//span/a[contains(.,'70-483')]"))[fireFoxDriver.FindElements(By.XPath("//span/a[contains(.,'70-483')]")).Count-1].Click();
                //ReadOnlyCollection<IWebElement> myelem = fireFoxDriver.FindElements(By.XPath("//span/a[contains(.,'70-483')]"));
                ReadOnlyCollection<IWebElement> myelem = fireFoxDriver.FindElements(By.XPath("//span/a[contains(.,'70-761')]"));
                Console.WriteLine("g");
                myelem.Last().Click();
            }
            catch (Exception ex) { ExceptionHelper.ExceptionAndLineNumber(ex, thisClass); }
        }
    }
}
