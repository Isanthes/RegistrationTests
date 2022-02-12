using NUnit.Framework;
using OpenQA.Selenium;
using RegistrationTests.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using static RegistrationTests.Utilities.Browser;

namespace RegistrationTests.Tests
{
    class BaseTest
    {
        public IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = Browser.GetDriver();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
