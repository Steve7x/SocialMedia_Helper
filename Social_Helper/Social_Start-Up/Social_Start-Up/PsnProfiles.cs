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
    class PsnProfiles
    {
        public static NameValueCollection appSettings = ConfigurationManager.AppSettings;

        public static void MyPsnPorfilesMethod(FirefoxDriver fireFoxDriver)
        {
            Actions actions = new Actions(fireFoxDriver);

            WebDriverWait wait = new WebDriverWait(fireFoxDriver, TimeSpan.FromSeconds(40));
            string thisClass = "PsnProfiles";
            try
            {
                fireFoxDriver.Navigate().GoToUrl("https://psnprofiles.com/");
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(@class, 'button_button--lgX0P intro_acceptAll--23PPA ')]"))).Click();
                fireFoxDriver.FindElement(By.XPath("//a[contains(@class, 'signin button')]")).Click();
                fireFoxDriver.FindElement(By.XPath("//input[contains(@name, 'user')]")).SendKeys(appSettings["PsnUsername"]);
                fireFoxDriver.FindElement(By.XPath("//input[contains(@name, 'password')]")).SendKeys(appSettings["Password2"]);
                fireFoxDriver.FindElement(By.XPath("//a[contains(., 'Login')]")).Click();
                IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".dropdown-toggle > span:nth-child(2)")));
                element.Click();
                fireFoxDriver.FindElement(By.XPath("//a[contains(., 'Your Profile')]")).Click();

                if (Convert.ToBoolean(appSettings["UpdateProfile"]) == true)
                {
                    IWebElement element1 = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".dropdown-toggle > span:nth-child(2)")));
                    element1.Click();
                    fireFoxDriver.FindElement(By.XPath("//a[contains(., 'Update Profile')]")).Click();
                    //wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[contains(., 'Go to steve_14x's profile now')]"))).Click();
                    //fireFoxDriver.FindElement(By.CssSelector("a.light:nth-child(3)")).Click();//Try this code
                    fireFoxDriver.FindElementByTagName("body").SendKeys(Keys.Command + 'r');
                    IWebElement element2 = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a.light:nth-child(3)")));
                    element2.Click();
                }
            }
            catch (Exception ex) { ExceptionHelper.ExceptionAndLineNumber(ex, thisClass); }
        }
    }
}
