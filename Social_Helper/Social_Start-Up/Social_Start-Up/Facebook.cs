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
    class Facebook
    {
        public static NameValueCollection appSettings = ConfigurationManager.AppSettings;

        public static void MyFacebookMethod(FirefoxDriver fireFoxDriver)
        {
            Actions actions = new Actions(fireFoxDriver);
            TimeSpan span = new TimeSpan(0, 0, 0, 20, 0);
            WebDriverWait wait = new WebDriverWait(fireFoxDriver, span);
            string thisClass = "Facebook";
            try
            {
                //Facebook Start
                fireFoxDriver.Navigate().GoToUrl("https://www.facebook.com/");
                fireFoxDriver.FindElement(By.XPath("//input[@name = 'email']")).SendKeys(appSettings["My_Email"]);
                fireFoxDriver.FindElement(By.XPath("//input[@name = 'pass']")).SendKeys(appSettings["Password1"]);

                try
                {
                    fireFoxDriver.FindElement(By.XPath("//button[@name = 'login']")).Click();
                }
                catch (Exception ex) { ExceptionHelper.ExceptionAndLineNumber(ex, thisClass); }

                try
                {
                    fireFoxDriver.FindElement(By.XPath("//input[@aria-label = 'Log In']")).Click();
                }
                catch (Exception ex) { ExceptionHelper.ExceptionAndLineNumber(ex, thisClass); }
                //Facebook End
            }
            catch (Exception ex) { ExceptionHelper.ExceptionAndLineNumber(ex, thisClass); }
        }
    }
}



//using System;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.Configuration;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Firefox;
//using OpenQA.Selenium.Interactions;
//using OpenQA.Selenium.Support.UI;
//using SeleniumExtras.WaitHelpers;

//namespace Social_Start_Up
//{
//    class Facebook
//    {
//        public static NameValueCollection appSettings = ConfigurationManager.AppSettings;

//        public static void MyFacebookMethod(FirefoxDriver fireFoxDriver)
//        {
//            Actions actions = new Actions(fireFoxDriver);
//            TimeSpan span = new TimeSpan(0, 0, 0, 20, 0);
//            WebDriverWait wait = new WebDriverWait(fireFoxDriver, span);
//            string thisClass = "Facebook";
//            try
//            {
//                //Facebook Start
//                fireFoxDriver.Navigate().GoToUrl("https://www.facebook.com/");
//                fireFoxDriver.FindElement(By.XPath("//input[@data-testid = 'royal_email']")).SendKeys(appSettings["My_Email"]);
//                fireFoxDriver.FindElement(By.XPath("//input[@data-testid = 'royal_pass']")).SendKeys(appSettings["Password1"]);
//                fireFoxDriver.FindElement(By.XPath("//input[@data-testid = 'royal_login_button']")).Click();
//                //Facebook End
//            }
//            catch (Exception ex) { ExceptionHelper.ExceptionAndLineNumber(ex, thisClass); }
//        }
//    }
//}
