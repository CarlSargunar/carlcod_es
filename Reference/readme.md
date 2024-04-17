# Ensure we have the version specific Umbraco templates
dotnet new -i Umbraco.Templates::10.8.5 --force

dotnet new umbraco --force -n "UmbRef" --friendly-name "Administrator" --email "admin@example.com" --password "1234567890" --development-database-type SQLite

#Add starter kit
dotnet add "UmbRef" package clean --version 3.1.4

dotnet run --project "UmbRef"
#Running