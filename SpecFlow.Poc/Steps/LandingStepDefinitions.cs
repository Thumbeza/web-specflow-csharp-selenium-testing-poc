using FluentAssertions;
using SpecFlow.Poc.Hooks;
using SpecFlow.Poc.PageObjects;
using TechTalk.SpecFlow;

namespace SpecFlow.Poc.Steps;

[Binding]
public sealed class LandingStepDefinitions
{
    private readonly LandingPage _landingPage;
    
    private readonly ScenarioContext _scenarioContext;
    
    public LandingStepDefinitions(ScenarioContext scenarioContext)
    {
        _landingPage = new LandingPage(TestInitialise.Driver);

        _scenarioContext = scenarioContext;
    }
    
    [Then(@"the landing page must be visible")]
    public void ThenTheLandingPageMustBeVisible()
    {
        _landingPage.Visible.Should().BeTrue();
    }
}