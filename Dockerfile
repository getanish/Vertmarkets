FROM microsoft/dotnet:2.0-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.0-sdk AS build
WORKDIR /src
COPY VertMarkets/VertMarkets.csproj VertMarkets/
RUN dotnet restore VertMarkets/VertMarkets.csproj
COPY . .
WORKDIR /src/VertMarkets
RUN dotnet build VertMarkets.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish VertMarkets.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "VertMarkets.dll"]
