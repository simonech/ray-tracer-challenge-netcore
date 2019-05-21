dotnet new sln -o src -n ray-tracer-challenge
cd src
dotnet new classlib -o raytracer -n codeclimber.raytracer
dotnet new xunit -o xUnit -n codeclimber.raytracer.xUnit
dotnet sln add **/*.csproj
cd xUnit/
dotnet add reference ../raytracer/codeclimber.raytracer.csproj 
cd ..
dotnet build
dotnet test