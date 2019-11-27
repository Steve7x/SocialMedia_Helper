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
    class YouTube
    {
        public static NameValueCollection appSettings = ConfigurationManager.AppSettings;

        public static void MyYouTubeMethod(FirefoxDriver fireFoxDriver)
        {
            Actions actions = new Actions(fireFoxDriver);

            TimeSpan span = new TimeSpan(0, 0, 0, 20, 0);
            WebDriverWait wait = new WebDriverWait(fireFoxDriver, span);
            string thisClass = "YouTube";
            try
            {
                //Youtube Start
                fireFoxDriver.Navigate().GoToUrl("https://www.youtube.com/");
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(.,'Sign in')]"))).Click();
                Thread.Sleep(3500);//Partial xpath below
                fireFoxDriver.FindElement(By.XPath("//input[contains(@aria-label, 'Email')]")).SendKeys(appSettings["My_Email"]);
                fireFoxDriver.FindElement(By.XPath("//span[contains(., 'Next')]")).Click();
                Thread.Sleep(3000);
                fireFoxDriver.FindElement(By.XPath("//input[contains(@aria-label, 'password')]")).SendKeys(appSettings["Password2"]);
                fireFoxDriver.FindElement(By.XPath("//span[contains(., 'Next')]")).Click();
                Thread.Sleep(2000);
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[contains(@id, 'search')]"))).SendKeys(appSettings["Song"]);
                //actions.SendKeys(Keys.Enter);
                fireFoxDriver.FindElement(By.XPath("//button[@aria-label='Search']")).Click();
                ReadOnlyCollection<IWebElement> arrayOfSongs = fireFoxDriver.FindElements(By.XPath("//a[contains(@id, 'video-title')]"));
                arrayOfSongs[0].Click();
                SkipAd.SkipAdvert(fireFoxDriver);
                if (Convert.ToBoolean(appSettings["RepeatSong"]) == true)
                {
                    //Right click on video
                    IWebElement myEle = fireFoxDriver.FindElement(By.XPath("//*[@id='player']"));
                    actions.MoveToElement(myEle).Perform();
                    actions.ContextClick().Perform();
                    fireFoxDriver.FindElement(By.XPath("//div[text()[contains(., 'Loop')]]")).Click();
                }
                //Youtube End
            }
            catch (Exception ex) { ExceptionHelper.ExceptionAndLineNumber(ex, thisClass); }
        }
    }
}
