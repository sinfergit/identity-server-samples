FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["IdentityServer4/IdentityServer4.csproj", "IdentityServer4/"]
RUN dotnet restore "IdentityServer4/IdentityServer4.csproj"
COPY . .
WORKDIR "/src/IdentityServer4"
RUN dotnet build "IdentityServer4.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityServer4.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdentityServer4.dll"]
