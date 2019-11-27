using System;
using System.Collections.Generic;
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

    class LinkedIn
    {
        public static NameValueCollection appSettings = ConfigurationManager.AppSettings;

        public static void myLinkedInMethod(FirefoxDriver fireFoxDriver)
        {
            string thisClass = "LinkedIn";
            try
            {
                fireFoxDriver.Navigate().GoToUrl("https://www.linkedin.com/login?trk=guest_homepage-basic_nav-header-signin");
                fireFoxDriver.FindElement(By.XPath("//input[contains(@id, 'user')]")).SendKeys(appSettings["My_Email"]);
                fireFoxDriver.FindElement(By.XPath("//input[contains(@id, 'pass')]")).SendKeys(appSettings["Password2"]);
                fireFoxDriver.FindElement(By.XPath("//button[contains(., 'Sign in')]")).Click();
            }
            catch (Exception ex) { ExceptionHelper.ExceptionAndLineNumber(ex, thisClass); }
        }
    }
}
