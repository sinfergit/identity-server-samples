FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MyTestWebAPI/MyTestWebAPI.csproj", "MyTestWebAPI/"]
RUN dotnet restore "MyTestWebAPI/MyTestWebAPI.csproj"
COPY . .
WORKDIR "/src/MyTestWebAPI"
RUN dotnet build "MyTestWebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyTestWebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyTestWebAPI.dll"]
