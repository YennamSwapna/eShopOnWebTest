using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowTests.Steps
{
   public class LoginPage
    {
        public IWebDriver WebDriver { get; }

        public LoginPage(IWebDriver webDriver)
        {
            this.WebDriver = webDriver;
        }

        public IWebElement LnkLogin => WebDriver.FindElement(By.XPath("//a[contains(text(),'Login')]"));
        public IWebElement TxtEmail => WebDriver.FindElement(By.Id("Input_Email"));
        public IWebElement TxtPassword => WebDriver.FindElement(By.Id("Input_Password"));
        public IWebElement ButtonLogin => WebDriver.FindElement(By.XPath("//button[contains(text(),'Log in')]"));
        public IWebElement LnkeShop => WebDriver.FindElement(By.XPath("//header/div[1]/article[1]/section[1]/a[1]/img[1]"));

        public IWebElement InValid => WebDriver.FindElement(By.XPath("//li[contains(text(),'Invalid login attempt.')]"));



        public void ClickLogin() => LnkLogin.Click();

        public void Login(String Email,  String Password)
        {
            TxtEmail.SendKeys(Email);
            TxtPassword.SendKeys(Password);
        }

        public void ClickLoginButton() => ButtonLogin.Submit();

        public bool IsEshopHomePage() => LnkeShop.Displayed;

        public bool IsEshopLoginPage() => InValid.Displayed;
    }
}
