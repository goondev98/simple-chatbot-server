# Use the official .NET 9 SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:9.0.304 AS build

WORKDIR /app

# Copy project and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0.8 AS runtime

WORKDIR /app
COPY --from=build /app/out .

# for production run in port 5000
#EXPOSE 5000

# for development run in port 6000
EXPOSE 5050

ENTRYPOINT ["dotnet", "simple-netcore-chatbot.dll"]
