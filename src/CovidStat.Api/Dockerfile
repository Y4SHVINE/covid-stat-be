##See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#
FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Install cultures (same approach as Alpine SDK image)
RUN apk add --no-cache icu-libs

# Disable the invariant mode (set in base image)
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["src/CovidStat.Api/CovidStat.Api.csproj", "src/CovidStat.Api/"]
COPY ["src/CovidStat.Application/CovidStat.Application.csproj", "src/CovidStat.Application/"]
COPY ["src/CovidStat.Domain/CovidStat.Domain.csproj", "src/CovidStat.Domain/"]
COPY ["src/CovidStat.Domain.Core/CovidStat.Domain.Core.csproj", "src/CovidStat.Domain.Core/"]
COPY ["src/CovidStat.Infrastructure/CovidStat.Infrastructure.csproj", "src/CovidStat.Infrastructure/"]
COPY . .
WORKDIR "/src/src/CovidStat.Api"

FROM build AS publish
RUN dotnet publish "CovidStat.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CovidStat.Api.dll"]