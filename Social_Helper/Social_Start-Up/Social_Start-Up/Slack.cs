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
    class Slack
    {
        public static NameValueCollection appSettings = ConfigurationManager.AppSettings;

        public static void MySlackMethod(FirefoxDriver fireFoxDriver)
        {
            Actions actions = new Actions(fireFoxDriver);
            TimeSpan span = new TimeSpan(0, 0, 0, 20, 0);
            WebDriverWait wait = new WebDriverWait(fireFoxDriver, span);
            string thisClass = "Slack";
            try
            {
                //Slack Start
                fireFoxDriver.Navigate().GoToUrl("https://www.slack.com/");
                fireFoxDriver.FindElement(By.XPath("//a[contains(., 'Sign in')]")).Click();
                fireFoxDriver.FindElement(By.XPath("//input[@placeholder = 'your-workspace-url']")).SendKeys("thecodingden");
                fireFoxDriver.FindElement(By.XPath("//button[@data-gtm-click='submit_team_domain']")).Click();
                fireFoxDriver.FindElement(By.XPath("//input[@placeholder='you@example.com']")).SendKeys(appSettings["My_Email"]);
                fireFoxDriver.FindElement(By.XPath("//input[@placeholder='password']")).SendKeys(appSettings["Password2"]);
                fireFoxDriver.FindElement(By.XPath("//button[@id='signin_btn']")).Click();
                fireFoxDriver.FindElement(By.XPath("//button[@id='signin_btn']")).Click();//Duplicate code above to counter highlighted button
                                                                                          //Slack End
            }
            catch (Exception ex) { ExceptionHelper.ExceptionAndLineNumber(ex, thisClass); }
        }
    }
}
