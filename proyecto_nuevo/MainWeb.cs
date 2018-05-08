using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace proyecto_nuevo
{
    class MainWeb
    {
        private IWebDriver driver;
        private string baseURL;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            baseURL = "https://account.measureup.com/login";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void Loging()
        {
            try
            {
                string expectedtitle = "Learning Locke";
                driver.Navigate().GoToUrl(baseURL);
                driver.FindElement(By.Name("name")).Click();
                driver.FindElement(By.Name("name")).SendKeys("mdgarcia");
                Console.WriteLine("He introducido el user.");
                driver.FindElement(By.Name("password")).Click();
                driver.FindElement(By.Name("password")).SendKeys("MUP.Pr0d");
                Console.WriteLine("He introducido el password");
                driver.FindElement(By.XPath("//*[@id='loginTab']/div/form/button")).Click();
                Console.WriteLine("Pulso el botón de Submit");
                string title = driver.Title;
                Assert.AreEqual(expectedtitle, title);
                Console.WriteLine("Logado con éxito :)");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        [OneTimeTearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

    }
}
