# Changing the environment variable

You can only create EFCore migrations when set to Staging. This is due to the DB connection string defined in the appsettings.staging.json file only.

Open Package Manager Console, Set Default project dropdown to NuGetRestore.WepAPI, and run the applicable command:

Development: `$Env:ASPNETCORE_ENVIRONMENT = "Development"`

Staging: `$Env:ASPNETCORE_ENVIRONMENT = "Staging"`

Production: `$Env:ASPNETCORE_ENVIRONMENT = "Production"`


Then, you can use migration to create an initial database:

`Add-Migration InitialCreate`

Now apply the migration to the database to create the schema:

`PM> Update-Database`
