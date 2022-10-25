using OpenQA.Selenium;

namespace SpecFlow.Poc.Driver;

public class BrowserHelpers
{
    private readonly IWebDriver _driver;

    public BrowserHelpers(IWebDriver driver)
    {
        _driver = driver;
    }

    public void TakeScreenshot(string filePath)
    {
        var screenshot = (ITakesScreenshot)_driver;

        screenshot.GetScreenshot().SaveAsFile(filePath, ScreenshotImageFormat.Png);
    }
}