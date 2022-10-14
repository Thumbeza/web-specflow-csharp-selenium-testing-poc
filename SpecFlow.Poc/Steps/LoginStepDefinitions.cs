using FluentAssertions;
using SpecFlow.Poc.Driver;
using SpecFlow.Poc.PageObjects;
using TechTalk.SpecFlow;

namespace SpecFlow.Poc.Steps;

[Binding]
public class LoginStepDefinitions
{
    private readonly LoginPage _loginPage;
    private readonly LandingPage _landingPage;
    
    public LoginStepDefinitions()
    {
        var driver = BrowserFactory.GetDriver(Browser.Chrome);
        driver.Manage().Window.Maximize();
        
        _loginPage = new LoginPage(driver);
        _landingPage = new LandingPage(driver);
    }

    [Given(@"swag labs website is launched")]
    public void GivenSwagLabsWebsiteIsLaunched()
    {
        _loginPage.Visible.Should().BeTrue();
    }

    [When(@"the username is ""(.*)""")]
    public void WhenTheUsernameIs(string username)
    {
        _loginPage.EnterUsername(username);
    }
    
    [When(@"the password is ""(.*)""")]
    public void WhenThePasswordIs(string password)
    {
        _loginPage.EnterPassword(password);
    }
    
    [When(@"attempting to log in")]
    public void WhenAttemptingToLogIn()
    {
        _loginPage.Login();
    }

    [Then(@"the landing page must be visible")]
    public void ThenTheLandingPageMustBeVisible()
    {
        _landingPage.Visible.Should().BeTrue();
    }

    [Then(@"the error message must contain ""(.*)""")]
    public void ThenTheErrorMessageMustContain(string errorMessage)
    {
        var _errorMessage = _loginPage.GetErrorMessage();

        _errorMessage.Should().Contain(errorMessage);
    }
}