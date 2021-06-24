using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace lab3
{
    class SearchPage
    {
        private IWebDriver driver;
        WebDriverWait wait;

        public SearchPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public void GoToPage()
        {
            driver.Navigate().GoToUrl("https://mangalib.me/manga-list");
        }

        public void GoToPage(string page_address)
        {
            driver.Navigate().GoToUrl(page_address);
        }

        public void Search( string search_string)
        {

            wait.Until(wdriver => driver.FindElement(By.ClassName("manga-search__input")));
            IWebElement element = driver.FindElement(By.ClassName("manga-search__input"));

            element.SendKeys(search_string);
        }
        public IWebElement GetFirstManga()
        {

            wait.Until(wdriver => driver.FindElement(By.ClassName("media-card")));
            IWebElement element = driver.FindElement(By.ClassName("media-card"));
            return element;
        }
        public void TryLogin(string login, string password)
        {
            wait.Until(wdriver => driver.FindElement(By.ClassName("header__sign-in")));
            IWebElement element = driver.FindElement(By.ClassName("header__sign-in"));
            element.Click();
            wait.Until(wdriver => driver.FindElement(By.XPath("/html/body/div[5]/div[1]/div/div[2]/form/div[2]/div/input[2]")));
            IWebElement elementLogin = driver.FindElement(By.XPath("/html/body/div[5]/div[1]/div/div[2]/form/div[2]/div/input[2]"));
            wait.Until(wdriver => driver.FindElement(By.XPath("/html/body/div[5]/div[1]/div/div[2]/form/div[3]/div[2]/input")));
            IWebElement elementPassword = driver.FindElement(By.XPath("/html/body/div[5]/div[1]/div/div[2]/form/div[3]/div[2]/input"));
            elementLogin.SendKeys(login);
            elementPassword.SendKeys(password);
            wait.Until(wdriver => driver.FindElement(By.ClassName("button_primary")));
            IWebElement button = driver.FindElement(By.ClassName("button_primary"));
            button.Click();
        }
    }
}
