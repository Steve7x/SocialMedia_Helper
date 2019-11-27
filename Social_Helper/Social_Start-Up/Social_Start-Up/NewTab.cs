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
    class NewTab
    {
        static public void OpenNewTab(FirefoxDriver fireFoxDriver)
        {
            Actions actions = new Actions(fireFoxDriver);

            ((IJavaScriptExecutor)fireFoxDriver).ExecuteScript("window.open();");
            List<string> handles = fireFoxDriver.WindowHandles.ToList();
            if (handles.Count > 1)
            {
                ITargetLocator locator = fireFoxDriver.SwitchTo();
                locator.Window(handles.Last());
            }
        }
    }
}
