using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowTests.Steps
{
    [Binding]
    public class LoginSteps
    {
        LoginPage loginPage = null;
        [Given(@"I launch the application")]
        public void GivenILaunchTheApplication()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://localhost:44315/");
            loginPage = new LoginPage(webDriver);
        }

        [Given(@"I click on Login link")]
        public void GivenIClickOnLoginLink()
        {
            loginPage.ClickLogin();
        }

        [Given(@"I enter the following details")]
        public void GivenIEnterTheFollowingDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            loginPage.Login((String)data.Email, (String)data.Password);
        }

        [When(@"I click on Login Button")]
        public void WhenIClickOnLoginButton()
        {
            loginPage.ClickLoginButton();
        }

        [Then(@"the dashboard screen is displayed")]
        public void ThenTheDashboardScreenIsDisplayed()
        {
            Assert.That(loginPage.IsEshopHomePage(), Is.True);
        }

    }
}
