using OpenQA.Selenium;

namespace SpecFlow.Poc.PageObjects;

public class LandingPage : BasePage
{
    private readonly IWebDriver _driver;

    public LandingPage(IWebDriver driver) : base(driver)
    {
        _driver = driver;

        Visible = IsPageVisible();
    }
    
    private static By ProductsLabel => By.XPath("//span[@class='title']");

    private bool IsPageVisible()
    {
        return WaitForElementVisible(ProductsLabel);
    }
}