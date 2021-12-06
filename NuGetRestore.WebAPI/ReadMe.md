# Changing the environment variable

You can only create EFCore migrations when set to Staging. This is due to the DB connection string defined in the appsettings.staging.json file only.

Development: `$Env:ASPNETCORE_ENVIRONMENT = "Development"`

Staging: `$Env:ASPNETCORE_ENVIRONMENT = "Staging"`

Production: `$Env:ASPNETCORE_ENVIRONMENT = "Production"`
