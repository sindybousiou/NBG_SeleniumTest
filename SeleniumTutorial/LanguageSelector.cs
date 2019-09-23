﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTutorial
{
    class LanguageSelector
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver("C:\\Users\\spsetup\\Documents\\Visual Studio 2012\\Projects\\SeleniumTutorial\\.nuget\\selenium.chrome.webdriver.76.0.0\\driver");
        }

        [Test]
        public void CheckSelectorTextInEnglishRootSite()
        {
            driver.Navigate().GoToUrl("http://spsetup:p@ssw0rd@vm-sp2013/el");
            IWebElement ls = driver.FindElement(By.XPath("//*[@id='ctl00_PlaceHolderCustomHeader_PlaceHolderCustomHeaderTop_ctl00_ctl00_LangSwitchButton']"));
            string displayText = ls.Text;
            Assert.AreEqual("EN", displayText);            
        }

        [Test]
        public void CheckLanguageChangeFriendlyURLs()
        {
            driver.Navigate().GoToUrl("http://spsetup:p@ssw0rd@vm-sp2013/en");
            IWebElement ls = driver.FindElement(By.XPath("//*[@id='ctl00_PlaceHolderCustomHeader_PlaceHolderCustomHeaderTop_ctl00_ctl00_LangSwitchButton']"));
            string displayText = ls.Text;
            Assert.AreEqual("EL", displayText);
            ls.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            wait.Until(ExpectedConditions.UrlContains("el"));
            ls = driver.FindElement(By.XPath("//*[@id='ctl00_PlaceHolderCustomHeader_PlaceHolderCustomHeaderTop_ctl00_ctl00_LangSwitchButton']"));
            Assert.AreEqual("EN", ls.Text);
            Assert.IsTrue(driver.Url.Contains("/el"));
        }

        [Test]
        public void CheckLanguageChangeNormalURLs()
        {
            driver.Navigate().GoToUrl("http://spsetup:p@ssw0rd@vm-sp2013/english/Pages/Default.aspx");
            IWebElement ls = driver.FindElement(By.XPath("//*[@id='ctl00_PlaceHolderCustomHeader_PlaceHolderCustomHeaderTop_ctl00_ctl00_LangSwitchButton']"));
            string displayText = ls.Text;
            Assert.AreEqual("EL", displayText);
            ls.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            wait.Until(ExpectedConditions.UrlContains("/greek"));
            ls = driver.FindElement(By.XPath("//*[@id='ctl00_PlaceHolderCustomHeader_PlaceHolderCustomHeaderTop_ctl00_ctl00_LangSwitchButton']"));
            Assert.AreEqual("EN", ls.Text);
            Assert.IsTrue(driver.Url.Contains("/greek"));
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
