#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Fiap/Fiap.csproj", "Fiap/"]
RUN dotnet restore "Fiap/Fiap.csproj"
COPY . .
WORKDIR "/src/Fiap"
RUN dotnet build "Fiap.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Fiap.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fiap.dll"]