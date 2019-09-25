RIENGLM008:webapidock nbontha$ docker build -t webapidock .
Sending build context to Docker daemon  1.068MB
Step 1/11 : FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
 ---> f13ac9d68148
Step 2/11 : WORKDIR /app
 ---> Using cache
 ---> 914a29dfa0ab
Step 3/11 : COPY *.csproj ./
 ---> b9574c22151c
Step 4/11 : RUN dotnet restore
 ---> Running in 946d70aca74f
  Restore completed in 2.15 sec for /app/webapidock.csproj.
Removing intermediate container 946d70aca74f
 ---> 5756a9ec2402
Step 5/11 : COPY . ./
 ---> 954e91fa964c
Step 6/11 : RUN dotnet publish -c Release -o out
 ---> Running in 46fb056db34c
Microsoft (R) Build Engine version 16.2.32702+c4012a063 for .NET Core
Copyright (C) Microsoft Corporation. All rights reserved.

  Restore completed in 711.05 ms for /app/webapidock.csproj.
  webapidock -> /app/bin/Release/netcoreapp2.2/webapidock.dll
  webapidock -> /app/out/
Removing intermediate container 46fb056db34c
 ---> c0fa797efb12
Step 7/11 : FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
 ---> 45c933779d5c
Step 8/11 : WORKDIR /app
 ---> Using cache
 ---> 0d2772d8bc15
Step 9/11 : EXPOSE 80
 ---> Using cache
 ---> d5aff3fa398d
Step 10/11 : COPY --from=build-env /app/out .
 ---> 0375bcd39052
Step 11/11 : ENTRYPOINT ["dotnet", "webapidock.dll"]
 ---> Running in bfd5a7fd641d
Removing intermediate container bfd5a7fd641d
 ---> 5a94c9e5271f
Successfully built 5a94c9e5271f
Successfully tagged webapidock:latest
RIENGLM008:webapidock nbontha$ docker ps
CONTAINER ID        IMAGE               COMMAND             CREATED             STATUS              PORTS               NAMES
RIENGLM008:webapidock nbontha$ docker run -d -p 8080:80 --name app webapidock
7baec38453ee4e6ab3d71244126972e5634962d55baeb51f433d1706a090ab1b

=> Publish to Docker Hub
docker push nat2k5us/webapidock

RIENGLM008:webapidock nbontha$ touch docker-compose.yaml
RIENGLM008:webapidock nbontha$ docker-compose up -d
Creating network "webapidock_default" with the default driver
Pulling sql-server-db (microsoft/mssql-server-linux:2017-latest)...
2017-latest: Pulling from microsoft/mssql-server-linux
59ab41dd721a: Pull complete
57da90bec92c: Pull complete
06fe57530625: Pull complete
5a6315cba1ff: Pull complete
739f58768b3f: Pull complete
0b751601bca3: Pull complete
bcf04a22644a: Pull complete
6b5009e4f470: Pull complete
a9dca2f6722a: Pull complete
Digest: sha256:9b700672670bb3db4b212e8aef841ca79eb2fce7d5975a5ce35b7129a9b90ec0
Status: Downloaded newer image for microsoft/mssql-server-linux:2017-latest
Creating sql-server-db ... done

# Run the sql server image
sudo docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Password12" -p 1433:1433 --name sql1 -d microsoft/mssql-server-linux:2017-latest
# Error
Bind for 0.0.0.0:1433 failed: port is already allocated.
# Check ports in use
netstat | grep 1433?
>> Result : no output
$docker-compose down
Stopping sql-server-db ... done
Removing sql-server-db ... done
Removing network webapidock_default
$ docker-compose up -d
Creating network "webapidock_default" with the default driver
Creating sql-server-db ... done
# see the port and hhost of the container
RIENGLM008:webapidock nbontha$ docker port b1cd94146e7d     
1433/tcp -> 0.0.0.0:1433

# copy an existing database into the docker container
docker cp d:\AdventureWorksDW2012_Data.mdf nifty_golick:/var/opt/mssql/data/AdventureWorksDW2012_Data.mdf

# Open a Bash shell in a Docker Container without SSH
We can run a Bash shell in our running container. Using the following command, you can start to explore the filesystem.
docker exec -it <name> bash
nbontha$ docker exec -it c3a2a0d5fcb1f1372bb3e35fae63da5040c1403ae7377840b011169e7b14c650 /bin/sh -c "[ -e /bin/bash ] && /bin/bash || /bin/sh"
# get out of the docker container shell
$ exit

# Execute SQL commands on bash 
https://www.quackit.com/sql_server/mac/install_sql-cli_on_a_mac.cfm
$ sudo install -g sql-cli

# Show . extension files on macos - In a mac Terminal enter below command and relaunch
$ defaults write com.apple.finder AppleShowAllFiles YES

# push to docker hub
docker build -t nat2k5us/webapidock .
docker run -d -p 8080:80 --name app nat2k5us/webapidock
docker push nat2k5us/webapidock

docker-compose up -d