# Database
Dev database is mslocaldb (sqlserver)

## Migrations
Database is managed using EF migration
###Add migration:
`Add-Migration {migrationName}` (ex: `Add-Migration Init`)
###Update dev database
`Update-database -ProjectName ContosoConsultancy.DataAccess`