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
    class Program : NewTab
    {
        public static NameValueCollection appSettings = ConfigurationManager.AppSettings;
        static void Main(string[] args)
        {
            FirefoxOptions options = new FirefoxOptions();
            options.SetPreference("dom.webnotifications.enabled", false);
            FirefoxDriver fireFoxDriver = new FirefoxDriver(options);
            Actions actions = new Actions(fireFoxDriver);
            TimeSpan span = new TimeSpan(0, 0, 0, 20, 0);
            WebDriverWait wait = new WebDriverWait(fireFoxDriver, span);

            int numberOfHours = Convert.ToInt32(appSettings["Hours"]) * 3400;

            Twitter.MyTwitterMethod(fireFoxDriver);
            OpenNewTab(fireFoxDriver);
            PsnProfiles.MyPsnPorfilesMethod(fireFoxDriver);
            OpenNewTab(fireFoxDriver);
            Hotmail.MyHotmailMethod(fireFoxDriver);
            OpenNewTab(fireFoxDriver);
            Facebook.MyFacebookMethod(fireFoxDriver);
            OpenNewTab(fireFoxDriver);
            Slack.MySlackMethod(fireFoxDriver);
            OpenNewTab(fireFoxDriver);
            YouTube.MyYouTubeMethod(fireFoxDriver);
            OpenNewTab(fireFoxDriver);
            LinkedIn.myLinkedInMethod(fireFoxDriver);
            OpenNewTab(fireFoxDriver);
            SpeedTest.MySpeedTestMethod(fireFoxDriver);
            OpenNewTab(fireFoxDriver);
            BriefMeNow.MyBriefMeNowMethod(fireFoxDriver);

            for (int i = 0; i < numberOfHours; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine(i);
            }
            LogOut.LogOutMethod(fireFoxDriver);
        }
    }
}

