FROM mcr.microsoft.com/dotnet/framework/sdk:4.8 AS build
WORKDIR /app
COPY *.sln .
COPY WebApi/*.csproj ./WebApi/
COPY WebApi/*.config ./WebApi/
RUN nuget restore
COPY WebApi/. ./WebApi/
RUN msbuild /p:Configuration=Release -r:False
FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2019
WORKDIR /inetpub/wwwroot
COPY --from=build /app/WebApi/. ./
