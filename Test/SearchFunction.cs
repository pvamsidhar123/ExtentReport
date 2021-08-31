using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using NLog;
using AventStack.ExtentReports;


namespace ExtentReport.Test
{
    [TestClass]
    public class SearchFunction
    {

       // private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        protected IWebDriver Driver { get; private set; }
        public TestContext TestContext { get; set; }
        private Screenshottaken Screenshottaken { get; set; }

        public IWebDriver driver;
        public string  url;
        [TestInitialize]
        public void intilization()
        {
            //  Logger.Debug("Test start");
            Reporter.AddTestCaseMetadataToHtmlReport(TestContext);

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            url  = "https://www.google.com/";
            driver.Navigate().GoToUrl(url);
            
            Screenshottaken = new Screenshottaken(driver, TestContext);

        }

        [TestMethod]
        public void TcId1()
        {
            Reporter.LogTestStepForBugLogger(Status.Info, "Home page got loaded succefully");
           
            Assert.IsTrue(driver.Title.Contains("Google"));
        }
        [TestMethod]
        public void TcId2()
        {
            //  Reporter.LogTestStepForBugLogger(Status.Info, "Home page got loaded succefully");

            Reporter.LogPassingTestStepToBugLogger($"following url opened=>{url}");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            var search = driver.FindElement(By.Name("q"));
            search.SendKeys("selenium");
            search.SendKeys(Keys.Enter);
            Assert.IsTrue(driver.Title.Contains("Selenium google search"));
            driver.Close();
        }
        [TestCleanup]
        public void tcid3() 
        {
            driver.Close();

        }

       
    }
}