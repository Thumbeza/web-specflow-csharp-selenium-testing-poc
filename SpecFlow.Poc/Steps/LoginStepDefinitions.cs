﻿using FluentAssertions;
using SpecFlow.Poc.Hooks;
using SpecFlow.Poc.PageObjects;
using TechTalk.SpecFlow;

namespace SpecFlow.Poc.Steps;

[Binding]
public sealed class LoginStepDefinitions
{
    private readonly LoginPage _loginPage;
    
    //to bo used to manage test state
    private readonly ScenarioContext _scenarioContext;
    
    public LoginStepDefinitions(ScenarioContext scenarioContext)
    {
        _loginPage = new LoginPage(TestInitialise.Driver);

        _scenarioContext = scenarioContext;
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

    [Then(@"the error message must contain ""(.*)""")]
    public void ThenTheErrorMessageMustContain(string errorMessage)
    {
        var _errorMessage = _loginPage.GetErrorMessage();

        _errorMessage.Should().Contain(errorMessage);
    }
}