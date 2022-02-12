using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RegistrationTests.POM;
using RegistrationTests.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrationTests.Tests
{
    class FirstRegistrationTests : BaseTest
    {
        
        string url = Utils.GetUrl();
   
        [Test]
        public void RegistrationHappyFlow()
        {
            driver.Navigate().GoToUrl(url + "registration");
            RegistrationPage happyFlow = new RegistrationPage(driver);
            Assert.AreEqual("Registration", happyFlow.ChackPage());
            Assert.AreEqual("Username", happyFlow.getLabel(happyFlow.getUsernameLabel()));         
            Assert.AreEqual("Password", happyFlow.getLabel(happyFlow.getPasswordLabel()));
            Assert.AreEqual("Confirm password", happyFlow.getLabel(happyFlow.getConfirmPassLabel()));
            Assert.AreEqual("Title", happyFlow.getLabel(happyFlow.getTitleLabel()));
            Assert.AreEqual("First name", happyFlow.getLabel(happyFlow.getFirstNameLabel()));
            Assert.AreEqual("Last name", happyFlow.getLabel(happyFlow.getLastNameLabel()));
            Assert.AreEqual("Email", happyFlow.getLabel(happyFlow.getEmailLabel()));
            Assert.AreEqual("Date of birth", happyFlow.getLabel(happyFlow.getDateOfBirthLabel()));
            Assert.AreEqual("Nationality", happyFlow.getLabel(happyFlow.getNationalityLabel()));
            Assert.AreEqual("4 to 35 letters, numbers or underscore.", happyFlow.getDescription(happyFlow.getUsernameDescription()));
            happyFlow.FirstRegistration("Isanthes","password123","password123","Mr.","Verde","Crud","verdecrud@gmail.com","American");
           
        }

        [Test]
        public void DescriptionMessages()
        {
            driver.Navigate().GoToUrl(url + "registration");
            RegistrationPage descriptionMessage = new RegistrationPage(driver);
            Assert.AreEqual("Registration", descriptionMessage.ChackPage());
            Assert.AreEqual("4 to 35 letters, numbers or underscore.", descriptionMessage.getDescription(descriptionMessage.getUsernameDescription()));
            Assert.AreEqual("Minimum of 8 characters.", descriptionMessage.getDescription(descriptionMessage.getPasswordDescription()));
            Assert.AreEqual("Must match the password.", descriptionMessage.getDescription(descriptionMessage.getConfirmPasswordDescription()));
            Assert.AreEqual("2 to 35 letters and '-' only.", descriptionMessage.getDescription(descriptionMessage.getFirstNameDescription()));
            Assert.AreEqual("2 to 35 letters and '-' only.", descriptionMessage.getDescription(descriptionMessage.getLastNameDescription()));
            Assert.AreEqual("We promise we won't spam you.", descriptionMessage.getDescription(descriptionMessage.getEmailDescription()));
        }

        [Test]
        public void ErrorMessage()
        {
            driver.Navigate().GoToUrl(url + "registration");
            RegistrationPage errorMessage = new RegistrationPage(driver);
            Assert.AreEqual("Registration", errorMessage.ChackPage());
            Assert.AreEqual("Username is required!", errorMessage.getError(errorMessage.getUsernameError()));
            Assert.AreEqual("Password is required!", errorMessage.getError(errorMessage.getPasswordError()));
            Assert.AreEqual("Email is required!", errorMessage.getError(errorMessage.getEmailError()));
            Assert.AreEqual("You need to accept our T&C!", errorMessage.getError(errorMessage.getTermsError()));
        }

        [Test]
        public void OnlyRequired()
        {
            driver.Navigate().GoToUrl(url + "registration");
            RegistrationPage or = new RegistrationPage(driver);
            Assert.AreEqual("Registration", or.ChackPage());
            or.RegistrationOnlyRecuiredFields("Hitsugayat", "123asdfg", "123assdf", "test@gmail.com");
        }
        
        [Test]
        public void InvalidInsertValues()
        {
            driver.Navigate().GoToUrl(url + "registration");
            RegistrationPage invalid = new RegistrationPage(driver);
            Assert.AreEqual("Registration", invalid.ChackPage());
            invalid.FirstRegistration("a", "b", "1", "c", "d", "e", "@yahoo", "Afghan");
            Assert.AreEqual("Minimum of 4 characters is required!", invalid.getError(invalid.getUsernameErrorMin()));
            Assert.AreEqual("Minimum of 8 characters is required!", invalid.getError(invalid.getPasswordErrorMin()));
            Assert.AreEqual("Passwords do not match!", invalid.getError(invalid.getPasswordErrorMatch()));
            Assert.AreEqual("Minimum of 2 characters is required!", invalid.getError(invalid.getFirstNameError()));
            Assert.AreEqual("Minimum of 2 characters is required!", invalid.getError(invalid.getLastNameError()));
            Assert.AreEqual("Invalid email address!", invalid.getError(invalid.getEmailInvalid()));

        }

    }
}
