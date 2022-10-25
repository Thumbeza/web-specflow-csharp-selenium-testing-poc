using OpenQA.Selenium;
using SpecFlow.Poc.Driver;
using TechTalk.SpecFlow;

namespace SpecFlow.Poc.Hooks;

[Binding]
public sealed class TestInitialise
{
    public static IWebDriver? Driver;
    
    //You can also do bindings for following options [BeforeFeature] and [BeforeTestRun]
    
    [BeforeScenario]
    public static void BeforeScenario()
    {
        Console.Write("Starting a new test scenario: ");
        
        Driver = BrowserFactory.GetDriver(Browser.Edge);
        Driver?.Manage().Window.Maximize();
    }

    [AfterScenario]
    public static void AfterScenario()
    {
        Console.Write("Ending a test scenario: ");
        
        Driver?.Quit();
        Driver?.Dispose();
    }
}