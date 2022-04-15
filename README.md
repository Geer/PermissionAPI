Install project

1. Clone the repository
2. Update dependencies 
	2.1 Using .NET CLI: 'dotnet restore'
	2.1 Using IDE: Right click in "Dependencies" then click in "Update NuGet packages"
3. Open database client and create permissions database
4. Run EF migrations
	4.1 Using .NER CLI: 'dotnet ef database update InitialCreate'
	4.2 Using IDE: open PM console and hit Update-Database
5. Build project
6. Run project.
