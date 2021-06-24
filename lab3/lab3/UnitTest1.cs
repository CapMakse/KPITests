using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace lab3
{
    public class Tests
    {
        [Test, Timeout(2000000)]
        public void TestSearch()
        {
            Thread.Sleep(3500);
            IWebDriver webDr = new OperaDriver(@"..\..\..\operadriver_win64");
            WebDriverWait wait = new WebDriverWait(webDr, System.TimeSpan.FromSeconds(300));
            SearchPage search = new SearchPage(webDr, wait);
            IWebElement manga = null;
            IWebElement mangaTitle = null;

            search.GoToPage();
            Thread.Sleep(3500);

            search.Search( "Поднятие уровня в одиночку\n");
            manga = search.GetFirstManga();
            mangaTitle = manga.FindElement(By.ClassName("media-card__title"));

            Assert.True(mangaTitle.Text.ToUpper().Contains("Поднятие уровня в одиночку".ToUpper()));
            webDr.Close();
        }
        
        [Test, Timeout(2000000)]
        public void TestStartRead()
        {
            Thread.Sleep(3500);
            IWebDriver webDr = new OperaDriver(@"..\..\..\operadriver_win64");
            WebDriverWait wait = new WebDriverWait(webDr, System.TimeSpan.FromSeconds(300));
            MangaPage manga = new MangaPage(webDr, wait);

            manga.GoToPage();
            Thread.Sleep(3500);

            manga.PressButtonStartRead();

            Assert.True(webDr.Url == "https://mangalib.me/i-alone-level-up/v1/c0?page=1");
            webDr.Close();
        }
        
        [Test, Timeout(2000000)]
        public void TestNavigation()
        {
            Thread.Sleep(3500);
            IWebDriver webDr = new OperaDriver(@"..\..\..\operadriver_win64");
            WebDriverWait wait = new WebDriverWait(webDr, System.TimeSpan.FromSeconds(300));
            SearchPage search = new SearchPage(webDr, wait);

            search.GoToPage();
            Thread.Sleep(3500);

            string forum;
            string FAQ;
            string mangalist;
            IWebElement element;
            wait.Until(wdriver => webDr.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div/div[3]/a")));
            element = webDr.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div/div[3]/a"));
            element.Click();
            forum = webDr.Url;
            
            wait.Until(wdriver => webDr.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div/div[4]/a")));
            element = webDr.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div/div[4]/a"));
            element.Click();
            FAQ = webDr.Url;
            
            wait.Until(wdriver => webDr.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div/div[1]/span")));
            element = webDr.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div/div[1]/span"));
            element.Click();
            wait.Until(wdriver => webDr.FindElement(By.XPath("/html/body/div[9]/div/div/div/a[8]")));
            element = webDr.FindElement(By.XPath("/html/body/div[9]/div/div/div/a[8]"));
            element.Click();
            mangalist = webDr.Url;

            Assert.True(forum == "https://mangalib.me/forum/?category=all&title&user_id&subscription=0&page=1&sort=newest");
            Assert.True(FAQ == "https://mangalib.me/faq?section=1");
            Assert.True(mangalist == "https://mangalib.me/manga-list");
            webDr.Close();
        }

        [Test, Timeout(2000000)]
        public void TestIncorectLogin()
        {
            Thread.Sleep(3500);
            IWebDriver webDr = new OperaDriver(@"..\..\..\operadriver_win64");
            WebDriverWait wait = new WebDriverWait(webDr, System.TimeSpan.FromSeconds(300));
            SearchPage search = new SearchPage(webDr, wait);

            search.GoToPage();
            Thread.Sleep(3500);

            search.TryLogin("ddd", "asda");
            
            try
            {
                webDr.FindElement(By.ClassName("header__sign-in"));
            }
            catch (System.Exception)
            {
                Assert.True(false);
            }
            webDr.Close();
        }

        [Test, Timeout(2000000)]
        public void TestСorectLogin()
        {
            Thread.Sleep(3500);
            IWebDriver webDr = new OperaDriver(@"..\..\..\operadriver_win64");
            WebDriverWait wait = new WebDriverWait(webDr, System.TimeSpan.FromSeconds(300));
            SearchPage search = new SearchPage(webDr, wait);

            search.GoToPage();
            Thread.Sleep(3500);

            search.TryLogin("correctLogin", "correctPassword");

            Thread.Sleep(3500);


            try
            {
                webDr.FindElement(By.ClassName("header-right-menu__avatar"));
            }
            catch (System.Exception)
            {
                Assert.True(false);
            }
            webDr.Close();
        }
    }
}
