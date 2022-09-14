#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ProcessaDeposito.Worker/ProcessaDeposito.Worker.csproj", "ProcessaDeposito.Worker/"]
RUN dotnet restore "ProcessaDeposito.Worker/ProcessaDeposito.Worker.csproj"
COPY . .
WORKDIR "/src/ProcessaDeposito.Worker"
RUN dotnet build "ProcessaDeposito.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProcessaDeposito.Worker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProcessaDeposito.Worker.dll"]