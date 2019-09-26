FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS base


FROM base AS build
WORKDIR /webapidock/webapidock/
RUN ls -R
COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet build -c Release -o out

#RUN ls -R
# COPY webapidock/webapidock/webapidock.csproj /app
# COPY webapidock/App.DAL/App.DAL.csproj /app
# #RUN pwd
# #RUN ls -R
# RUN dotnet restore App.DAL.csproj
# RUN dotnet build  App.DAL.csproj --no-restore -c Release -o /app
# RUN dotnet restore webapidock.csproj 
# RUN dotnet build  --no-restore -c Release -o /app




#RUN dotnet build -c Release -o /app
# Copy the test project files
#COPY test/*/*.csproj ./
#RUN for file in $(ls *.csproj); do mkdir -p test/${file%.*}/ && mv $file test/${file%.*}/; done

# RUN dotnet restore

# COPY . ./
# RUN dotnet build -c Release -o /app

# FROM build AS publish
# RUN dotnet publish -c Release -o /app

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app .

# FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
# WORKDIR /app
# EXPOSE 80
# COPY --from=build-env /app/out .
# ENTRYPOINT ["dotnet", "webapidock.dll"]