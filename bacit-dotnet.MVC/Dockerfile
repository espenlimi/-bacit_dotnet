#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["bacit-dotnet.MVC", "bacit-dotnet.MVC/"]
RUN ls /src
WORKDIR "/src/bacit-dotnet.MVC/"
RUN ls "/src/bacit-dotnet.MVC/"
RUN dotnet restore 
RUN dotnet build -c Release  --no-restore

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish  --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "bacit-dotnet.MVC.dll"]