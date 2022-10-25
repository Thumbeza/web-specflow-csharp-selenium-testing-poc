using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using WebDriverManager.DriverConfigs.Impl;

namespace SpecFlow.Poc.Driver;

public static class BrowserFactory
{
    public static IWebDriver GetDriver(Browser browser)
    {
        return browser switch
        {
            Browser.Chrome => GetChrome(),
            Browser.Edge => GetEdge(),
            _ => throw new InvalidOperationException("Invalid browser: please pass 'Browser.Chrome' or 'Browser.Edge'")
        };
    }

    private static IWebDriver GetChrome()
    {
        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());

        return new ChromeDriver();
    }

    private static IWebDriver GetEdge()
    {
        new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());

        return new EdgeDriver();
    }
}