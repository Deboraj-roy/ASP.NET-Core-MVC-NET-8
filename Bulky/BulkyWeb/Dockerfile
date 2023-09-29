#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BulkyWeb/BulkyBookWeb.csproj", "BulkyWeb/"]
COPY ["Bulky.DataAccess/BulkyBook.DataAccess.csproj", "Bulky.DataAccess/"]
COPY ["Bulky.Models/BulkyBook.Models.csproj", "Bulky.Models/"]
COPY ["Bulky.Utility/BulkyBook.Utility.csproj", "Bulky.Utility/"]
RUN dotnet restore "BulkyWeb/BulkyBookWeb.csproj"
COPY . .
WORKDIR "/src/BulkyWeb"
RUN dotnet build "BulkyBookWeb.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "BulkyBookWeb.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BulkyBookWeb.dll"]