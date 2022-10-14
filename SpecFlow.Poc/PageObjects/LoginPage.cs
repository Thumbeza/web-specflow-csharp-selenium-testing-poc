using OpenQA.Selenium;
using SpecFlow.Poc.TestData;

namespace SpecFlow.Poc.PageObjects;

public class LoginPage : BasePage
{
    private readonly IWebDriver _driver;

    public LoginPage(IWebDriver driver) : base(driver)
    {
        _driver = driver;

        Visible = IsPageVisible();
    }
    
    private static By UsernameInput => By.Id("user-name");
    private static By PasswordInput => By.Id("password");
    private static By LoginButton => By.Id("login-button");
    private static By ErrorPopUp => By.XPath("//div[@class='error-message-container error']");

    private bool IsPageVisible()
    {
        if(!_driver.Url.Equals(Url.SwagLabs))
            _driver.Navigate().GoToUrl(Url.SwagLabs);
            
        return WaitForElementVisible(UsernameInput);
    }
    
    public void EnterUsername(string username)
    {
        InsertText(UsernameInput, username);
    }

    public void EnterPassword(string password)
    {
        InsertText(PasswordInput, password);
    }

    public void Login()
    {
        ClickElement(LoginButton);
    }

    public string GetErrorMessage()
    {
        return GetElementText(ErrorPopUp);
    }
}