using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowTests.Steps
{
    public class OrderPage
    {
        public IWebDriver webDriver { get; }

        public OrderPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }        
        
        //Select a Brand 
        public IWebElement DdBrand => webDriver.FindElement(By.Id("CatalogModel_BrandFilterApplied")).FindElement(By.CssSelector("option[value='5']"));
        public void ClickBrand() => DdBrand.Click();

        //Select a Type 
        public IWebElement DdType => webDriver.FindElement(By.Id("CatalogModel_TypesFilterApplied")).FindElement(By.CssSelector("//body/div[1]/section[2]/div[1]/form[1]/label[2]/select[1]/option[1]"));
        public void ClickType() => DdType.Click();

        //Click Arrow Right
        public IWebElement ButtonArrowRight => webDriver.FindElement(By.XPath("//body/div[1]/section[2]/div[1]/form[1]/input[1]"));
        public void ClickArrowRight() => ButtonArrowRight.Click();

        //Click Add to Basket
        public IWebElement ButtonAddBasket => webDriver.FindElement(By.XPath("//body[1]/div[1]/div[1]/div[2]/div[2]/form[1]/input[1]"));
        public void ClickAddBasket() => ButtonAddBasket.Click();

        //Click Add to Basket
        public IWebElement TxtQty => webDriver.FindElement(By.XPath("//body/div[1]/div[1]/form[1]/div[1]/article[1]/div[1]/section[4]/input[2]"));
        public void Qty(int Quantity)
        {
            TxtQty.Clear();
            TxtQty.SendKeys(Quantity.ToString());
        }

        //Click Checkout
        public IWebElement ButtonChkOut=> webDriver.FindElement(By.CssSelector("div.esh-app-wrapper:nth-child(1) div.container form:nth-child(1) div.esh-catalog-items.row:nth-child(2) div.row section.esh-basket-item.col-xs-push-7.col-xs-4:nth-child(2) > a.btn.esh-basket-checkout:nth-child(2)"));
        public void ClickChkOut() => ButtonChkOut.Click();

        //Click PayNow
        public IWebElement ButtonPayNow => webDriver.FindElement(By.CssSelector("div.esh-app-wrapper:nth-child(1) div.container form:nth-child(2) div.esh-catalog-items.row:nth-child(2) div.row section.esh-basket-item.col-xs-push-7.col-xs-4.text-right:nth-child(2) > input.btn.esh-basket-checkout"));
        public void ClickPayNow() => ButtonPayNow.Click();

        //Confirmation Message
        public IWebElement MsgThnks => webDriver.FindElement(By.CssSelector("body:nth-child(2) div.esh-app-wrapper:nth-child(1) div.container > h1:nth-child(1)"));
        public bool IsMsgThnks() => MsgThnks.Displayed;
    }
}
