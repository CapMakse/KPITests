using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace lab3
{
    class MangaPage
    {
        private IWebDriver driver;
        WebDriverWait wait;

        public MangaPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public void GoToPage()
        {
            driver.Navigate().GoToUrl("https://mangalib.me/i-alone-level-up");
        }

        public void GoToPage(string page_address)
        {
            driver.Navigate().GoToUrl(page_address);
        }

        public void PressButtonStartRead()
        {

            wait.Until(wdriver => driver.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[1]/div[2]/a")));
            IWebElement element = driver.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[1]/div[2]/a"));
            element.Click();
        }
    }
}
