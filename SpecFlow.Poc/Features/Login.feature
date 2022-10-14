Feature: Login
  In order to avoid unauthorised access to the system
  when a user uses the system
  I want to facilitate who gets access to features through some login screen
  
  @LoginWithNoCredentials
  Scenario: Login without inserting a username and password
    Given swag labs website is launched
    When the username is ""
    And the password is ""
    When attempting to log in
    Then the error message must contain "Username is required"

  @LoginWithNoPassword
  Scenario: Login without inserting a password
    Given swag labs website is launched
    When the username is "standard_user"
    And the password is ""
    When attempting to log in
    Then the error message must contain "Password is required"

  @LoginWithAnIncorrectPassword
  Scenario: Login with an incorrect password
    Given swag labs website is launched
    When the username is "standard_user"
    And the password is "wrong_password"
    When attempting to log in
    Then the error message must contain "Username and password do not match any user in this service"

  @LoginWithNoCredentials
  Scenario: Login with a correct username and password
    Given swag labs website is launched
    When the username is "standard_user"
    And the password is "secret_sauce"
    When attempting to log in
    Then the landing page must be visible