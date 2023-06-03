FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /   
COPY . .
RUN dotnet publish "TripPlanner.Hostel/TripPlanner.Hostel.csproj" -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "TripPlanner.Hostel.dll"]