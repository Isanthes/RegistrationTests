using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RegistrationTests.POM;
using RegistrationTests.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace RegistrationTests.Tests
{
    class FirstRegistrationTests : BaseTest
    {
        
        string url = Utils.GetUrl();

        private static IEnumerable<TestCaseData> GetRegistationData()
        {
            yield return new TestCaseData("Hitsugayat", "Conquer.1234", "Conquer.1234", "Mr.","Andrei","Greuceanu","test@btrl.ro","American");
            yield return new TestCaseData("Atena", "Olimp.1234", "Olimp.1234", "Ms.", "Andreea", "Greuceanu", "test@btrl.ro", "American");
            yield return new TestCaseData("Aphrodita", "Roma.2345", "Roma.2345", "Ms.", "Bianca", "Andreescu", "test@btrl.ro", "Canadian");
            yield return new TestCaseData("Apolo", "Conquer.1234", "Conquer.1234", "Mr.", "Adrian", "Elcian", "test@btrl.ro", "Romanian");
        }
        private static IEnumerable<TestCaseData> GetRegistationDataCsv()
        {
            foreach (var values in Utils.GetGenericData("TestData\\registrationData.csv"))
            {
                yield return new TestCaseData(values);
            }
        }
        private static IEnumerable<TestCaseData> GetOnlyRequiredDataCsv()
        {
            foreach (var values in Utils.GetGenericData("TestData\\onlyRequiredData.csv"))
            {
                yield return new TestCaseData(values);
            }
        }
        private static IEnumerable<TestCaseData> GetRegistationDataCsv1()
        {
            var csvData = Utils.GetDataTableFromCsv("TestData\\registrationData.csv");
            for (int i = 0; i < csvData.Rows.Count; i++)
            {
                yield return new TestCaseData(csvData.Rows[i].ItemArray);
            }
        }
        private static IEnumerable<TestCaseData> GetRegistationDataExcel()
        {
            var excelData = Utils.GetDataTableFromExcel("TestData\\RegistrationData.xlsx");
            for (int i = 1; i < excelData.Rows.Count; i++)
            {
                yield return new TestCaseData(excelData.Rows[i].ItemArray);
            }
        }
        private static IEnumerable<TestCaseData> GetRegistationDataJson()
        {
            var regData = Utils.JsonRead<DataModels.Registration>("TestData\\registrationData.json");
            yield return new TestCaseData(regData.User, regData.Pass, regData.ConfirmPass, regData.Title, regData.FirstName, regData.LastName, regData.Email, regData.Nationality);
        }
        private static IEnumerable<TestCaseData> GetRegistationDataXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(DataModels.Registration));
            foreach (var file in Utils.GetAllFilesInFolderExt("TestData\\", "*.xml"))
            {
                Console.WriteLine("Testing with file: " + file);
                using (Stream reader = new FileStream(file, FileMode.Open))
                {
                    var regData = (DataModels.Registration)serializer.Deserialize(reader);
                    yield return new TestCaseData(regData.User, regData.Pass, regData.ConfirmPass, regData.Title, regData.FirstName, regData.LastName, regData.Email, regData.Nationality);
                }
            }
        }

        [Test, TestCaseSource("GetRegistationDataXml")]
        public void RegistrationHappyFlow(string user, string pass, string confirmPass, string title, string firstName, string lastName, string email, string nationality)
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
            happyFlow.FirstRegistration(user,pass,confirmPass,title,firstName,lastName,email,nationality);
           
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

        [Test, TestCaseSource("GetOnlyRequiredDataCsv")]
        public void OnlyRequired(string user, string pass, string confirmPass, string email)
        {
            driver.Navigate().GoToUrl(url + "registration");
            RegistrationPage or = new RegistrationPage(driver);
            Assert.AreEqual("Registration", or.ChackPage());
            or.RegistrationOnlyRecuiredFields(user,pass,confirmPass,email);
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
