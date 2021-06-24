using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowTests.Steps
{
    [Binding]
    public class OrderProductSteps
    {
        LoginPage loginPage = null;
        OrderPage orderPage = null;

        [Given(@"launch the application")]
        public void GivenLaunchTheApplication()
        {
            IWebDriver webDriver = new ChromeDriver();            
            webDriver.Navigate().GoToUrl("https://localhost:44315/");
            Screenshot ss = ((ITakesScreenshot)webDriver).GetScreenshot();
            ss.SaveAsFile("Test.png",
            ScreenshotImageFormat.Png);
            loginPage = new LoginPage(webDriver);
            orderPage = new OrderPage(webDriver);
        }
        
        [Given(@"click on Login link")]
        public void GivenClickOnLoginLink()
        {
            loginPage.ClickLogin();
        }
        
        [Given(@"enter the following details")]
        public void GivenEnterTheFollowingDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            loginPage.Login((String)data.Email, (String)data.Password);
        }
        
        [Given(@"click Login Button")]
        public void GivenClickLoginButton()
        {
            loginPage.ClickLoginButton();
        }
        
        [Given(@"select a brand Other from the Catalog page")]
        public void GivenSelectABrandOtherFromTheCatalogPage()
        {
            orderPage.ClickBrand(); 
        }

        [Given(@"click the arrow right")]
        public void GivenClickTheArrowRight()
        {
            orderPage.ClickArrowRight();
        }

        [Given(@"select a product")]
        public void GivenSelectAProduct()
        {
            orderPage.ClickAddBasket();
        }       
        
        [Given(@"provide valid quantity")]
        public void GivenProvideValidQuantity(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            orderPage.Qty((int)data.Quantity);
        }
        
        [Given(@"click Checkout")]
        public void GivenClickCheckout()
        {
            orderPage.ClickChkOut();
        }
        
        [When(@"click PayNow")]
        public void WhenClickPayNow()
        {
            orderPage.ClickPayNow();
        }
        
        [Then(@"confirmation message is displayed")]
        public void ThenConfirmationMessageIsDisplayed()
        {
            Assert.That(orderPage.IsMsgThnks(), Is.True);
        }
    }
}
