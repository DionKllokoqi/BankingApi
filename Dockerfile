FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5070

ENV ASPNETCORE_URLS=http://+:5070

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release

WORKDIR /src

COPY src/Core/Contracts/Contracts.csproj Core/Contracts/
COPY src/Core/Domain/Domain.csproj Core/Domain/
COPY src/Core/Application.Abstractions/Application.Abstractions.csproj Core/Application.Abstractions/
COPY src/Core/Application/Application.csproj Core/Application/
COPY src/Infrastructure/Persistence/Persistence.csproj Infrastructure/Persistence/
COPY src/Infrastructure/Presentation/Presentation.csproj Infrastructure/Presentation/

COPY src/WebApi/WebApi.csproj WebApi/

WORKDIR /
RUN dotnet restore "src/WebApi/WebApi.csproj"
COPY . .
RUN dotnet build "src/WebApi/WebApi.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
WORKDIR /src/WebApi
RUN dotnet publish "WebApi.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.dll"]
