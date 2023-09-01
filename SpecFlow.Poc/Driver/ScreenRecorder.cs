using OpenQA.Selenium;

namespace SpecFlow.Poc.Driver;

public class ScreenRecorder : IScreenRecorder
{
    private readonly IWebDriver _driver;

    public ScreenRecorder(IWebDriver driver)
    {
        _driver = driver;
    }

    public void TakeScreenshot(string filePath)
    {
        var screenshot = (ITakesScreenshot)_driver;

        screenshot.GetScreenshot().SaveAsFile(filePath, ScreenshotImageFormat.Png);
    }

    //For your fun, implement this function if you want to attach your screenshot to a file
    public string TakeScreenshotAsBase64()
    {
        throw new NotImplementedException();
    }
}