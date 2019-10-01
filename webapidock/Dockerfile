FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
    WORKDIR /src
    COPY . .
    RUN dotnet restore "webapidock.csproj"
    WORKDIR "/src/webapidock"
    RUN dotnet build "/src/webapidock.csproj" -c Release -o /app

    FROM build AS publish
    WORKDIR "/src/webapidock"
    RUN dotnet publish "webapidock.csproj" -c Release -o /app

    FROM base AS final
    WORKDIR /app
    COPY --from=publish /app .
    ENTRYPOINT ["dotnet", "webapidock.dll", "--server.urls", "http://0.0.0.0:5000"]