#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5000
EXPOSE 5001

#FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY WeddingApp/WeddingApp.csproj WeddingApp/
RUN dotnet restore "WeddingApp/WeddingApp.csproj"
COPY . .
WORKDIR "/src/WeddingApp"
RUN dotnet build "WeddingApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WeddingApp.csproj" -c Release -o /app/publish

#FROM base AS final
FROM mcr.microsoft.com/dotnet/sdk:5.0
ENV ASPNETCORE_ENVIRONMENT=Development
WORKDIR /app
COPY --from=publish /app/publish ./
ENTRYPOINT ["dotnet", "WeddingApp.dll"]
