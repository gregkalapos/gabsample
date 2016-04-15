This is a sample application presented in Linz during the Global Azure Bootcamp.

A blogpost with the content of the talk can be found here: 
http://kalapos.azurewebsites.net/


In order to use it you need to update:
-The connection string to the database:
Gab.NotesService/web.config
-The Application Insights Instrumentation key 
ConsoleApplicationSample/Program.cs
Gab.WebFrontend/ApplicationInsights.config
Gab.WebFrontend/Views/Shared/_Layout.cshtml
Gab.Uwp/App.xaml.cs

-The address of the service:
Gab.WebFrontend\NotesController.cs
Gab.Uwp/MainPage.xaml.cs
