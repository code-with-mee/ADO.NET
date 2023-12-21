# ADO.NET
ADO.NET (Access Database Object)

# EF CODE FIRST
Step 1
	add entity framework to project
	NuGet\Install-Package EntityFramework -Version 6.4.4
Step 2
	create model class
Step 3 
	Add DbSet
Step 4
	Add connection string
Step 5 
	Init connection string in DBContext
Step 6
	enable-migrations
Step 7
	add-migration migration_name
Step 8
	update-database

  <connectionStrings>
    <add name="iPosConnection" connectionString="data source =DESKTOP-S6RGHFC\MSSQLSERVERDEV19;initial catalog = iPOSCodeFirst;integrated security=SSPI" providerName="System.Data.SqlClient"/>
  </connectionStrings>

# EF CODE FIRST EXISTING DATABASE 
step 1 
	generate class from db
Step 2	
	enable-migrations
Step 3
	add-migration InitModel -IgnoreChanges -Force
Step 4 
	update-database
Step 5
	add new model
Step 6
	Add DbSet
Step 7
	add-migration
Step 8 
	update-database

 

