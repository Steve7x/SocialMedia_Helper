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
    
    class SocialMediaLogin
    {
        public static NameValueCollection appSettings = ConfigurationManager.AppSettings;

        //FirefoxOptions options = new FirefoxOptions();
        FirefoxDriver fireFoxDriver = new FirefoxDriver();
        Actions actions = new Actions(fireFoxDriver);
        TimeSpan span = new TimeSpan(0, 0, 0, 20, 0);
        WebDriverWait wait = new WebDriverWait(fireFoxDriver, span);
        public SocialMediaLogin()
        {
            fireFoxDriver = new FirefoxDriver();
        }

        public void Twitter(string url, string userName, string password)
        {
            //Twitter Start
            fireFoxDriver.Navigate().GoToUrl(url);
            Thread.Sleep(1000);
            IWebElement firstLogin = fireFoxDriver.FindElement(By.CssSelector(".StaticLoggedOutHomePage-input"));
            firstLogin.Click();
            fireFoxDriver.FindElement(By.CssSelector(".js-username-field")).SendKeys(userName);

            IWebElement ele = fireFoxDriver.FindElement(By.CssSelector(".js-password-field"));
            //Checking if Textbox is there;
            if (!ele.Size.IsEmpty)
            {
                ele.Click();
                ele.SendKeys(password);
            }
            fireFoxDriver.FindElement(By.CssSelector("button.submit")).Click();
            IWebElement element = fireFoxDriver.FindElement(By.CssSelector("#global-nav-home > a:nth-child(1) > span:nth-child(3)"));
            ((IJavaScriptExecutor)fireFoxDriver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Click();
            Thread.Sleep(500);
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#user-dropdown-toggle"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[2]/div[1]/div[3]/div/div/div[3]/ul/li[1]/div/ul/li/a[contains(.,'Dark')]"))).Click();
            fireFoxDriver.FindElement(By.CssSelector(".global-dm-nav > span:nth-child(2)")).Click();
            Thread.Sleep(20000);

            IWebElement messages = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[8]/div/div[2]/div[2]/div[2]/div/div[1]/ul/li[1]/div/div[2]/b[contains(.,'Emily Brown')]")));

            while (messages.Size.IsEmpty)
            {
                fireFoxDriver.FindElement(By.XPath("/html/body/div[8]/div/div[2]/div[2]/div[2]/div/div[1]/ul/li[1]/div/div[2]/b[contains(.,'Emily Brown')]"));
            }
            messages.Click();
            IWebElement dmMessage = fireFoxDriver.FindElement(By.CssSelector("#tweet-box-dm-conversation"));
            dmMessage.Click();

            dmMessage.SendKeys("Tell her your boyfriend is one LOL... so shes just batshit crazy");

            Thread.Sleep(2500);
            IWebElement sendDmButton = fireFoxDriver.FindElement(By.CssSelector(".messaging-text"));
            sendDmButton.Click();
            fireFoxDriver.FindElement(By.CssSelector(".DMConversation > div:nth-child(1) > div:nth-child(3) > button:nth-child(2) > span:nth-child(1)")).Click();
            //Twitter End
        }
    }
}
