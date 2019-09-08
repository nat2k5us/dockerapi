FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj ./DockerApi/
WORKDIR /app/DockerApi
RUN dotnet restore

# copy and publish app and libraries
WORKDIR /app/
COPY . ./DockerApi/
WORKDIR /app/DockerApi
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app
COPY --from=build-env /app/DockerApi/out ./
ENTRYPOINT ["dotnet", "DockerApi.dll"]