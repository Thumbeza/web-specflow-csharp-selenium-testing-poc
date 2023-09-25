namespace SpecFlow.Poc.Driver;

public interface IScreenRecorder
{
    void TakeScreenshot(string filePath);
    string TakeScreenshotAsBase64();
}
