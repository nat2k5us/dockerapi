FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY QuoteApi/QuoteApi.csproj QuoteApi/
COPY Quote.DataAccess/Quote.DataAccess.csproj Quote.DataAccess/
RUN dotnet restore "QuoteApi/QuoteApi.csproj"
COPY . .
WORKDIR "/src/QuoteApi"
RUN dotnet build "QuoteApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "QuoteApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QuoteApi.dll"]
