#definições da instancia base[container]
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS base
WORKDIR /app
RUN apk add --no-cache icu-libs icu-data-full
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
#fim das definiçoes da instancia

#definições da intancia de build
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["LojinhaAPI.csproj","./"]
RUN dotnet restore "LojinhaAPI.csproj"
COPY . .
WORKDIR /src/.

RUN dotnet build "LojinhaAPI.csproj" -c Release -o /app/build
#fim definições da intancia de build

#efetua a publicação
FROM build AS publish
RUN dotnet publish "LojinhaAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false
#fim

FROM base AS final
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5000
COPY --from=publish /app/publish .
RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf
ENTRYPOINT ["dotnet","LojinhaAPI.dll"]

