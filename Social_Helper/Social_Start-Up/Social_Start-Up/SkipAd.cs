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
    class SkipAd
    {
        public static void SkipAdvert(FirefoxDriver firefoxDriver)
        {
            TimeSpan span = new TimeSpan(0, 0, 0, 20, 0);
            WebDriverWait wait = new WebDriverWait(firefoxDriver, span);
            string thisClass = "SkipAd";
            string theURL = firefoxDriver.Url;

            if (theURL.Contains("https://www.youtube.com/watch?v="))
            {
                theURL = "https://www.youtube.com/watch?v=";
            }

            switch (theURL)
            {
                case "https://www.youtube.com/watch?v=":
                    try
                    {
                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button/div[contains(., 'Skip Ad')]"))).Click();
                    }
                    catch (Exception ex)
                    {

                        ExceptionHelper.ExceptionAndLineNumber(ex, thisClass);
                    }
                    break;
                case "https://twitter.com/home":
                    try
                    {
                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(., 'Close')]"))).Click();
                    }
                    catch (Exception ex)
                    {
                        ExceptionHelper.ExceptionAndLineNumber(ex, thisClass);
                    }
                    break;
                case "https://www.facebook.com/":
                    try
                    {
                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button/div[contains(., 'Skip Ad')]"))).Click();
                    }
                    catch (Exception ex)
                    {

                        ExceptionHelper.ExceptionAndLineNumber(ex, thisClass);
                    }
                    break;
                default:
                    Console.WriteLine("No url found");
                    break;
            }




            //try
            //{
            //    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button/div[contains(., 'Skip Ad')]"))).Click();
            //}
            //catch (Exception ex)
            //{

            //    ExceptionHelper.ExceptionAndLineNumber(ex, thisClass);
            //}
            //if (firefoxDriver.Url == appSettings["Song"])
            //{
            //    try
            //    {
            //        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button/div[contains(., 'Skip Ad')]"))).Click();
            //    }
            //    catch (Exception ex)
            //    {

            //        ExceptionHelper.ExceptionAndLineNumber(ex, thisClass);
            //    }
            //}
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
//    class SkipAd
//    {
//        public static void SkipAdvert(FirefoxDriver fireFoxDriver)
//        {
//            TimeSpan span = new TimeSpan(0, 0, 0, 20, 0);
//            WebDriverWait wait = new WebDriverWait(fireFoxDriver, span);
//            string thisClass = "SkipAd";
//            try
//            {
//                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button/div[contains(., 'Skip Ad')]"))).Click();
//            }
//            catch (Exception ex)
//            {

//                ExceptionHelper.ExceptionAndLineNumber(ex, thisClass);
//            }
//            //fireFoxDriver.FindElement(By.XPath("//button/div[contains(., 'Skip Ad')]")).Click();
//        }
//    }
//}
