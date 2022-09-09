FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RentXApi/RentX/RentX.csproj", "RentX/"]
RUN dotnet restore "RentX/RentX.csproj"
COPY . .
WORKDIR "/src/RentX"
RUN dotnet build "RentX.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RentX.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RentX.dll"]