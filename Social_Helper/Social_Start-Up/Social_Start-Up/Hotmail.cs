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
    class Hotmail
    {
        public static NameValueCollection appSettings = ConfigurationManager.AppSettings;

        public static void MyHotmailMethod(FirefoxDriver fireFoxDriver)
        {
            Actions actions = new Actions(fireFoxDriver);
            TimeSpan span = new TimeSpan(0, 0, 0, 20, 0);
            WebDriverWait wait = new WebDriverWait(fireFoxDriver, span);
            string thisClass = "Hotmail";
            try
            {
                //Hotmail Start
                fireFoxDriver.Navigate().GoToUrl("https://www.outlook.com");
                fireFoxDriver.FindElement(By.XPath("//a[contains(., 'Sign in')]")).Click();
                fireFoxDriver.FindElement(By.XPath("//input[contains(@placeholder, 'Email')]")).SendKeys(appSettings["My_Email"]);
                Thread.Sleep(2000);
                fireFoxDriver.FindElement(By.XPath("//input[@value = 'Next']")).Click();//Next button, to move onto password entry screen
                Thread.Sleep(3000);//Gives time for password slider
                fireFoxDriver.FindElement(By.XPath("//input[contains(@placeholder, 'Password')]")).SendKeys(appSettings["Password2"]);
                fireFoxDriver.FindElement(By.XPath("//input[@value = 'Sign in']")).Click();//Sign in button
                                                                                           //Hotmail End
            }
            catch (Exception ex) { ExceptionHelper.ExceptionAndLineNumber(ex, thisClass); }
        }
    }
}
