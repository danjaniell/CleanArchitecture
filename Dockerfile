# Base image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 8443

# Build image
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /src
COPY . ./
RUN dotnet restore CleanArchitecture.sln
RUN dotnet build CleanArchitecture.sln -c Release -o /app/build

# Publish image
FROM build AS publish
RUN dotnet publish CleanArchitecture.sln -c Release -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS final

# Add certs
COPY /certs/ /usr/local/share/ca-certificates/
RUN apk add --no-cache ca-certificates && update-ca-certificates

# Create non-root user
RUN addgroup -g 1000 -S clean-architecture-api \
    && adduser -u 1000 -G clean-architecture-api -S clean-architecture-api
USER 1000:1000

WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "CleanArchitecture.Api.dll"]