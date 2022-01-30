using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrationTests.POM
{
    public class RegistrationPage
    {
        const string registrationPageText = "text-muted"; //class

        const string usernameLabel = "#registration-form > div:nth-child(2) > label"; //css
        const string usernameInput = "input-username"; //id
        const string usernameDescription = "#registration-form > div:nth-child(2) > div > small"; //css
        const string usernameError = "#registration-form > div:nth-child(2) > div > div > div.text-left.invalid-feedback"; // css
        const string usernameErrorMin = "#registration-form > div:nth-child(2) > div > div > div.text-left.invalid-feedback"; //css

        const string passwordLabel = "#registration-form > div:nth-child(3) > label"; //css
        const string passwordInput = "input-password"; //id
        const string passwordDescription = "#registration-form > div:nth-child(3) > div > small"; //css
        const string passwordError = "#registration-form > div:nth-child(3) > div > div > div.text-left.invalid-feedback"; //css
        const string passwordErrorMin = "#registration-form > div:nth-child(3) > div > div > div.text-left.invalid-feedback"; //css
        
        const string confirmPassLabel = "#registration-form > div:nth-child(4) > label"; // css
        const string confirmPassInput = "input-password-confirm"; //id
        const string confirmPassDescription = "#registration-form > div:nth-child(4) > div > small"; //css
        const string passwordErrorMatch = "#registration-form > div:nth-child(4) > div > div > div.text-left.invalid-feedback"; //css

        const string titleLabel = "#registration-form > div:nth-child(6) > label"; //css
        const string titleMr = "#registration-form > div:nth-child(6) > div > div:nth-child(1) > input"; //css
        const string titleMs = "#registration-form > div:nth-child(6) > div > div:nth-child(2) > input"; //css

        const string firstNameLabel = "#registration-form > div:nth-child(7) > label"; //css
        const string firstNameInput = "input-first-name"; //id
        const string firstNameDescription = "#registration-form > div:nth-child(7) > div > small"; //css
        const string firstNameError = "#registration-form > div:nth-child(7) > div > div > div.text-left.invalid-feedback"; // css

        const string lastNameLabel = "#registration-form > div:nth-child(8) > label"; //css
        const string lastNameInput = "input-last-name"; //id
        const string lastNameDescription = "#registration-form > div:nth-child(8) > div > small"; //css
        const string lastNameError = "#registration-form > div:nth-child(8) > div > div > div.text-left.invalid-feedback"; //css

        const string emailLabel = "#registration-form > div:nth-child(9) > label"; //css
        const string emailInput = "input-email"; //id
        const string emailDescription = "#registration-form > div:nth-child(9) > div > small"; //css
        const string emailError = "#registration-form > div:nth-child(9) > div > div > div.text-left.invalid-feedback"; //css
        const string emailInvalid = "#registration-form > div:nth-child(9) > div > div > div.text-left.invalid-feedback"; //css

        const string dateOfBirthLabel = "#registration-form > div:nth-child(10) > label"; //css
        const string dateOfBirthInput = "input-dob"; //id
        const string calendar = "react-datepicker__month-container"; //class

        const string nationalityLabel = "#registration-form > div:nth-child(11) > label"; //css
        const string nationalityInput = "input-nationality"; //id

        const string terms = "terms"; //id
        const string termsError = "#registration-form > div:nth-child(12) > div.text-left.col-lg > div > div"; //css

        const string submitButton = "#registration-form > div:nth-child(13) > div.text-left.col-lg > button"; //css

        IWebDriver driver;

        public RegistrationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string ChackPage()
        {
            var registrationPageElem = driver.FindElement(By.ClassName(registrationPageText));
            return registrationPageElem.Text;
        }

        public void FirstRegistration(string user, string pass, string confirmPass,string title, string firstName, string lastName, string email, string nationality)
        {
            var usernameInputElement = driver.FindElement(By.Id(usernameInput));
            usernameInputElement.Clear();
            usernameInputElement.SendKeys(user);

            var passwordInputElement = driver.FindElement(By.Id(passwordInput));
            passwordInputElement.Clear();
            passwordInputElement.SendKeys(pass);

            var passwordConfirmElement = driver.FindElement(By.Id(confirmPassInput));
            passwordConfirmElement.Clear();
            passwordConfirmElement.SendKeys(confirmPass);

            
            if (title.Contains("Mr."))
            {
                var titleElement = driver.FindElement(By.CssSelector(titleMr));
                titleElement.Click();
            }
            else
            {
                var titleElement1 = driver.FindElement(By.CssSelector(titleMs));       
                titleElement1.Click();
            }

            var firstNameElement = driver.FindElement(By.Id(firstNameInput));
            firstNameElement.Clear();
            firstNameElement.SendKeys(firstName);

            var lastNameElement = driver.FindElement(By.Id(lastNameInput));
            lastNameElement.Clear();
            lastNameElement.SendKeys(lastName);

            var emailElement = driver.FindElement(By.Id(emailInput));
            emailElement.Clear();
            emailElement.SendKeys(email);

            var dateOfBirthElement = driver.FindElement(By.Id(dateOfBirthInput));
            dateOfBirthElement.Click();
            var calendarElement = driver.FindElement(By.ClassName(calendar));
            var selectedDate = calendarElement.FindElement(By.CssSelector("#registration-form > div:nth-child(10) > div > div > div.react-datepicker__tab-loop > div.react-datepicker-popper > div > div > div.react-datepicker__month-container > div.react-datepicker__month > div:nth-child(5) > div.react-datepicker__day.react-datepicker__day--023.react-datepicker__day--weekend"));
            calendarElement.Click();

            var nationalityElement = driver.FindElement(By.Id(nationalityInput));
            nationalityElement.Click();
            nationalityElement.SendKeys(nationality);


            var termsElement = driver.FindElement(By.Id(terms));
            termsElement.Click();

            var submitButtonElement = driver.FindElement(By.CssSelector(submitButton));
            submitButtonElement.Submit();

        }
        public void RegistrationOnlyRecuiredFields(string user, string pass, string confirmPass, string email)
        {
            var usernameInputElement = driver.FindElement(By.Id(usernameInput));
            usernameInputElement.Clear();
            usernameInputElement.SendKeys(user);

            var passwordInputElement = driver.FindElement(By.Id(passwordInput));
            passwordInputElement.Clear();
            passwordInputElement.SendKeys(pass);

            var passwordConfirmElement = driver.FindElement(By.Id(confirmPassInput));
            passwordConfirmElement.Clear();
            passwordConfirmElement.SendKeys(confirmPass);

            var emailElement = driver.FindElement(By.Id(emailInput));
            emailElement.Clear();
            emailElement.SendKeys(email);

            var termsElement = driver.FindElement(By.Id(terms));
            termsElement.Click();

            var submitButtonElement = driver.FindElement(By.CssSelector(submitButton));
            submitButtonElement.Submit();

        }

        public string getLabel(string label)
        {
            var element = driver.FindElement(By.CssSelector(label));
            return element.Text;
        }
        public string getUsernameLabel()
        {
            return usernameLabel;
        }
        public string getPasswordLabel()
        {
            return passwordLabel;
        }
        public string getConfirmPassLabel()
        {
            return confirmPassLabel;
        }
        public string getTitleLabel()
        {
            return titleLabel;
        }
        public string getFirstNameLabel()
        {
            return firstNameLabel;
        }
        public string getLastNameLabel()
        {
            return lastNameLabel;
        }
        public string getEmailLabel()
        {
            return emailLabel;
        }
        public string getDateOfBirthLabel()
        {
            return dateOfBirthLabel ;
        }
        public string getNationalityLabel()
        {
            return nationalityLabel;
        }

        public string getDescription(string description)
        {
            var element = driver.FindElement(By.CssSelector(description));
            return element.Text;
        }
        public string getUsernameDescription()
        {
            return usernameDescription;
        }
        public string getPasswordDescription()
        {
            return passwordDescription;
        }
        public string getConfirmPasswordDescription()
        {
            return confirmPassDescription;
        }
        public string getFirstNameDescription()
        {
            return firstNameDescription;
        }
        public string getLastNameDescription()
        {
            return firstNameDescription;
        }
        public string getEmailDescription()
        {
            return emailDescription;
        }


        public string getError(string error)
        {
            var submitButtonElement = driver.FindElement(By.CssSelector(submitButton));
            submitButtonElement.Submit();
            var element = driver.FindElement(By.CssSelector(error));
            return element.Text;
        }
        public string getUsernameError()
        {
            return usernameError;
        }
        public string getUsernameErrorMin()
        {
            return usernameErrorMin;
        }
        public string getPasswordError()
        {
            return passwordError;
        }
        public string getPasswordErrorMin()
        {
            return passwordErrorMin;
        }
        public string getPasswordErrorMatch()
        {
            return passwordErrorMatch;
        }
        public string getFirstNameError()
        {
            return firstNameError;
        }
        public string getLastNameError()
        {
            return lastNameError;
        }
        public string getEmailError()
        {
            return emailError;
        }
        public string getEmailInvalid()
        {
            return emailInvalid;
        }
        public string getTermsError()
        {
            return termsError;
        }
        

    }
}
