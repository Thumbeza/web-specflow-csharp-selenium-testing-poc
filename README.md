# specflow-csharp-poc
this a dotnet project created to demonstrate how selenium can be used in conjunction with specflow to generate Behavioural Driven Design (BDD) tests.

# steps to generate living document report
On your terminal run the following commands to install dependencies:
- npm install SpecFlow.Plus.LivingDocPlugin 
- dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI

Run the tests using your IDE's test explorer or run the following command:
- dotnet test

TestExecution.json will be generated after the tests finish running in the following folder './specflow-selenium-csharp-poc/SpecFlow.Poc/bin/Debug/net6.0', 
in order to generate the report navigate to this folder and run the command to generate the report:
- cd  C:\{disc-location}\specflow-selenium-csharp-poc\SpecFlow.Poc\bin\Debug\net6.0
- livingdoc test-assembly SpecFlow.Poc.dll -t TestExecution.json

LivingDocument.html report will be generated in the same location as above