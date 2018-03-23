Pencil Code Kata by Robert Baxter

To build: 
 1) load Developer Command Prompt for Visual Studio
 2) navigate to root directory of project - this contains PencilKata.sln
 3) run MSBuild /t:restore to generate nuget packages
 4) run command MSBuild
 
To Run Unit Tests
 1) load Developer Command Prompt for Visual Studio
 2) navigate here > PencilKata\PencilKataUnitTests\bin\Debug
 3) run command vstest.console.exe PencilKataUnitTests.dll