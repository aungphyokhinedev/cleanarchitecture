vs code create sln and projects
https://stackoverflow.com/questions/36343223/create-c-sharp-sln-file-with-visual-studio-code

clean architecture ref
https://medium.com/dotnet-hub/clean-architecture-with-dotnet-and-dotnet-core-aspnetcore-overview-introduction-getting-started-ec922e53bb97

migration

dotnet ef migrations add "SampleMigration" --project CleanArchitecture.Core.Repository.Ef --startup-project CleanArchitecture.Core.Api --output-dir Migrations 

dotnet ef database update --project CleanArchitecture.Core.Repository.Ef --startup-project CleanArchitecture.Core.Api 