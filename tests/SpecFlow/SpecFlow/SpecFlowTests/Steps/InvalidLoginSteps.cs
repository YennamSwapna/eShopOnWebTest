using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowTests.Steps
{
    [Binding]
    public class InvalidLoginSteps
    {
        LoginPage loginPage = null;
        [Given(@"Launch the application")]
        public void GivenLaunchTheApplication()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://localhost:44315/");
            loginPage = new LoginPage(webDriver);
        }
        
        [Given(@"Click on Login link")]
        public void GivenClickOnLoginLink()
        {
            loginPage.ClickLogin();
        }
        
        [Given(@"Enter the following details")]
        public void GivenEnterTheFollowingDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            loginPage.Login((String)data.Email, (String)data.Password);
        }
        
        [When(@"I click Login Button")]
        public void WhenIClickLoginButton()
        {
            loginPage.ClickLoginButton();
        }

        [Then(@"Invalid message is displayed")]
        public void ThenInvalidMessageIsDisplayed()
        {
            Assert.That(loginPage.IsEshopLoginPage(), Is.True);
        }
    }
}
