FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base

RUN apk add -U tzdata
ENV TZ=America/Asuncion
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN cp /usr/share/zoneinfo/America/Asuncion /etc/localtime

RUN apk add --no-cache \
        icu-data-full \
        icu-libs

RUN apk update && apk upgrade && \
        apk add --no-cache \
        busybox \
        libcrypto3 \
        libssl3 \
        ssl_client

WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["WebApi/WebApi.csproj", "WebApi/"]
COPY ["Core/Core.csproj", "Core/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]

RUN dotnet restore "WebApi/WebApi.csproj"

COPY . .

WORKDIR "/src/WebApi"
RUN dotnet build "WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .
COPY ["WebApi/appsettings.json", "appsettings.json"]

ENTRYPOINT ["dotnet", "WebApi.dll"]