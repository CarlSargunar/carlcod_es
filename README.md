# Building Carlcod_es

## Install Umbraco

Using https://psw.codeshare.co.uk/ generate a script for a clean Umbraco install. I used the following settings:

![Installation Settings](media/psw.png)

Which results in the following install script

    # Ensure we have the latest Umbraco templates
    dotnet new -i Umbraco.Templates

    # Create solution/project
    dotnet new sln --name "CarlCod_es"
    dotnet new umbraco -n "CarlCod_es" 
    dotnet sln add "CarlCod_es"

    dotnet run --project "CarlCod_es"
    #Running

Once you've verified the project works, we'll add a new .NET 6 Class library project. 

    dotnet new classlib -n "CarlCod_es.Core" 
    dotnet add "CarlCod_es.Core" package Umbraco.Cms.Core
    dotnet add "CarlCod_es.Core" package Umbraco.Cms.Infrastructure
    dotnet sln add "CarlCod_es.Core"

Add a reference to the new project in the main project

    dotnet add "CarlCod_es" reference "CarlCod_es.Core"

Add the uSync project to the website, and configure it for Content Mode

    dotnet add "CarlCod_es" package uSync 

Disable uSync Content Mode by adding the following to appsettings. Reference : https://docs.jumoo.co.uk/usync/uSync/reference/config

  "uSync": {
    "Settings": {
        "ImportAtStartup": "None",
        "ExportAtStartup": "None",
        "ExportOnSave": "Settings",
        "UiEnabledGroups": "Settings"
    }
  }

To run the main project run

    dotnet run --project "CarlCod_es"

To backup the datababase on the MSSql Database, run the following command