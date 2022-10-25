using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SpecFlow.Poc.PageObjects;

public class BasePage
{
    private readonly IWebDriver? _driver;
    
    private const int _defaultWait = 10;

    protected BasePage(IWebDriver? driver)
    {
        _driver = driver;
    }

    public bool Visible;

    protected bool WaitForElementClickable(By by, int waitTimeInSeconds = _defaultWait)
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(waitTimeInSeconds));
            
        try
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            return true;
        }
        catch
        {
            return false;
        }
    }

    protected bool WaitForElementVisible(By by, int waitTimeInSeconds = _defaultWait)
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(waitTimeInSeconds));
        try
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            return true;
        }
        catch
        {
            return false;
        }
    }

    protected void ClickElement(By by)
    {
        WaitForElementClickable(by);
        
        _driver.FindElement(by).Click();
    }

    protected void InsertText(By by, string inputText)
    {
        WaitForElementVisible(by);
        
        _driver.FindElement(by).Clear();
        _driver.FindElement(by).SendKeys(inputText);
    }

    protected string GetElementText(By by)
    {
        WaitForElementVisible(by);
        return _driver.FindElement(by).Text;
    }
}