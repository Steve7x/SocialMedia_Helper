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
    static class Twitter
    {
        public static NameValueCollection appSettings = ConfigurationManager.AppSettings;
        public static void MyTwitterMethod(FirefoxDriver fireFoxDriver)
        {
            Actions actions = new Actions(fireFoxDriver);
            TimeSpan span = new TimeSpan(0, 0, 0, 20, 0);
            WebDriverWait wait = new WebDriverWait(fireFoxDriver, span);
            string thisClass = "Twitter";
            try
            {
                //Twitter Start
                fireFoxDriver.Navigate().GoToUrl(appSettings["TwitterURL"]);
                Thread.Sleep(500);
                fireFoxDriver.FindElement(By.XPath("//input[contains(@class,'username')]")).SendKeys(appSettings["My_Email"]);
                Thread.Sleep(1000);
                fireFoxDriver.FindElement(By.XPath("//input[contains(@class, 'password')]")).SendKeys(appSettings["Password1"]);
                Thread.Sleep(1000);
                fireFoxDriver.FindElement(By.XPath("//button[contains(., 'Log in')]")).Click();//LoginButton
                Thread.Sleep(1500);
                fireFoxDriver.FindElement(By.XPath("//div[@aria-label='More menu items']")).Click();//MoreOptionsButton
                Thread.Sleep(1500);
                try
                {
                    fireFoxDriver.FindElement(By.XPath("//input[@aria-label='Dark mode']")).Click(); //DarkModeSwitch
                }
                catch (Exception ex){ ExceptionHelper.ExceptionAndLineNumber(ex, thisClass); }

                try
                {
                    fireFoxDriver.FindElement(By.XPath("//div[@title='Display']")).Click(); //DisplayButton
                    Thread.Sleep(1000);
                    fireFoxDriver.FindElement(By.XPath("//input[@aria-label='Orange']")).Click(); //OrangeThemeButton
                    Thread.Sleep(1000);
                    fireFoxDriver.FindElement(By.XPath("//input[@aria-label='Lights out']")).Click(); //BlackThemeButton
                    Thread.Sleep(1000);
                    try
                    {
                        fireFoxDriver.FindElement(By.XPath("//span[contains(., 'Close')]")).Click();
                    }
                    catch (Exception ex)
                    {
                        ExceptionHelper.ExceptionAndLineNumber(ex, thisClass);
                    }
                    fireFoxDriver.FindElement(By.XPath("//span[contains(., 'Done')]")).Click(); //
                }
                catch (Exception ex) { ExceptionHelper.ExceptionAndLineNumber(ex, thisClass); }

                Thread.Sleep(500);
                if (Convert.ToBoolean(appSettings["SendMessage"]) == true)
                {
                    fireFoxDriver.FindElement(By.XPath("//a[@data-testid='AppTabBar_DirectMessage_Link']")).Click();//Messages Button
                    Thread.Sleep(500);
                    fireFoxDriver.FindElement(By.XPath("//span[contains(.,'Emily Brown')]")).Click();//Select Name of recipient
                    Thread.Sleep(500);
                    try
                    {
                        fireFoxDriver.FindElement(By.XPath("//span[contains(., 'Close')]")).Click();
                        Thread.Sleep(500);
                    }
                    catch (Exception ex) { ExceptionHelper.ExceptionAndLineNumber(ex, thisClass); }

                    fireFoxDriver.FindElement(By.XPath("//div[@data-testid='dmComposerTextInput']")).SendKeys(appSettings["TwitterMessage"]);//Finds TextBox for Typing
                    Thread.Sleep(3000);
                    fireFoxDriver.FindElement(By.XPath("//div[@data-testid='dmComposerSendButton']")).Click();//Presses send button
                                                                                                              //Twitter End
                }
            }
            catch (Exception ex) { ExceptionHelper.ExceptionAndLineNumber(ex, thisClass); }
        }
    }
}
