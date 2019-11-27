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
    class LogOut
    {
        public static NameValueCollection appSettings = ConfigurationManager.AppSettings;

        public static void LogOutMethod(FirefoxDriver fireFoxDriver)
        {
            NewTab.OpenNewTab(fireFoxDriver);
            string thisClass = "LogOut";
            try
            {
                if (Convert.ToBoolean(appSettings["TwitterLogOut"]) == true)
                {
                    List<string> handles = fireFoxDriver.WindowHandles.ToList();
                    if (handles.Count > 1)
                    {
                        ITargetLocator locator = fireFoxDriver.SwitchTo();
                        locator.Window(handles.First());
                    }
                    fireFoxDriver.FindElement(By.XPath("//div[@aria-label='More menu items']")).Click();//MoreOptionsButton
                    Thread.Sleep(1500);
                    fireFoxDriver.FindElement(By.XPath("//span[contains(., 'Log out')]")).Click();
                    Thread.Sleep(2000);
                    try
                    {
                        fireFoxDriver.FindElement(By.XPath("//span[contains(., 'Close')]")).Click();
                        Thread.Sleep(500);
                    }
                    catch (Exception ex) { ExceptionHelper.ExceptionAndLineNumber(ex, thisClass); }
                    fireFoxDriver.FindElement(By.XPath("//div[@data-testid='confirmationSheetConfirm']")).Click();
                    fireFoxDriver.Manage().Cookies.DeleteAllCookies();
                    fireFoxDriver.Close();
                }
                if (Convert.ToBoolean(appSettings["EmailLogOut"]) == true)
                {
                    List<string> handles = fireFoxDriver.WindowHandles.ToList();
                    Thread.Sleep(1500);
                    if (handles.Count > 1)
                    {
                        ITargetLocator locator = fireFoxDriver.SwitchTo();
                        locator.Window(handles.First());
                    }
                    Thread.Sleep(1500);
                    fireFoxDriver.FindElement(By.XPath("//img[contains(@alt, 'SK')]")).Click();
                    fireFoxDriver.FindElement(By.XPath("//a[contains(., 'Sign out')]")).Click();
                    fireFoxDriver.Close();
                }
                if (Convert.ToBoolean(appSettings["FacebookLogOut"]) == true)
                {
                    List<string> handles = fireFoxDriver.WindowHandles.ToList();
                    Thread.Sleep(1500);
                    if (handles.Count > 1)
                    {
                        ITargetLocator locator = fireFoxDriver.SwitchTo();
                        locator.Window(handles.First());
                    }
                    Thread.Sleep(2000);
                    fireFoxDriver.FindElement(By.XPath("//div[contains(@id, 'logoutMenu')]")).Click();
                    Thread.Sleep(2000);
                    fireFoxDriver.FindElement(By.XPath("//a[contains(., 'Log Out')]")).Click();
                    Thread.Sleep(3000);
                    fireFoxDriver.FindElement(By.XPath("//a[contains(@id, 'u_0_g')]")).Click();
                    fireFoxDriver.Manage().Cookies.DeleteAllCookies();
                    fireFoxDriver.Close();
                }
                if (Convert.ToBoolean(appSettings["SlackLogOut"]) == true)
                {
                    List<string> handles = fireFoxDriver.WindowHandles.ToList();
                    Thread.Sleep(1500);
                    if (handles.Count > 1)
                    {
                        ITargetLocator locator = fireFoxDriver.SwitchTo();
                        locator.Window(handles.First());
                    }
                    fireFoxDriver.FindElement(By.XPath("//button[contains(@aria-label, 'Team Menu')]")).Click();
                    fireFoxDriver.FindElement(By.XPath("//div[contains(@data-qa, 'sign-out-wrapper')]")).Click();
                    fireFoxDriver.Close();
                }
                if (Convert.ToBoolean(appSettings["YouTubeLogOut"]) == true)
                {
                    List<string> handles = fireFoxDriver.WindowHandles.ToList();
                    Thread.Sleep(1500);
                    if (handles.Count > 1)
                    {
                        ITargetLocator locator = fireFoxDriver.SwitchTo();
                        locator.Window(handles.First());
                    }
                    fireFoxDriver.FindElement(By.XPath("//button[contains(@id, 'avatar-btn')]")).Click();
                    fireFoxDriver.FindElement(By.XPath("//a[contains(., 'Sign out')]")).Click();
                    fireFoxDriver.Close();
                }
                if (Convert.ToBoolean(appSettings["LinkedInLogOut"]) == true)
                {
                    List<string> handles = fireFoxDriver.WindowHandles.ToList();
                    Thread.Sleep(1500);
                    if (handles.Count > 1)
                    {
                        ITargetLocator locator = fireFoxDriver.SwitchTo();
                        locator.Window(handles.First());
                    }
                    fireFoxDriver.FindElement(By.XPath("//img[contains(@alt, 'Stephen Keenan')]")).Click();
                    fireFoxDriver.FindElement(By.XPath("//a[contains(., 'Sign out')]")).Click();
                    fireFoxDriver.Close();
                }
                fireFoxDriver.Dispose();
                fireFoxDriver.Navigate().GoToUrl(appSettings["FacebookURL"]);

            }
            catch (Exception ex) { ExceptionHelper.ExceptionAndLineNumber(ex, thisClass); }

        }
    }
}

