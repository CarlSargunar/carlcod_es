# Building Carlcod_es

## Install Umbraco

Using https://psw.codeshare.co.uk/ generate a script for a clean Umbraco install. I used the following settings:

![Installation Settings](media/psw.png)

Which results in the following install script

    # Ensure we have the latest Umbraco templates
    dotnet new -i Umbraco.Templates::10.3.2

    # Create solution/project
    dotnet new sln --name "CarlCod_es"
    dotnet new umbraco -n "CarlCod_es" --friendly-name "Carl" --email "carl@sargunar.com" --password "Pa55word!!" --development-database-type LocalDB
    dotnet sln add "CarlCod_es"

    dotnet run --project "CarlCod_es"
    #Running

Once you've verified the project works, we'll add a new .NET 6 Class library project. 

    dotnet new classlib -n "CarlCod_es.Core" --framework net6.0
    dotnet add "CarlCod_es.Core" package Umbraco.Cms.Core
    dotnet add "CarlCod_es.Core" package Umbraco.Cms.Infrastructure
    dotnet sln add "CarlCod_es.Core"

Add the uSync project to the website, and configure it for Content Mode

    dotnet add "CarlCod_es" package uSync 

Disable uSync Content Mode by adding the following to appsettings

    "uSync": {
        "Settings": {
            // See https://github.com/KevinJump/uSync/issues/232
            "ExportOnSave": "Settings" 
        }
    }
