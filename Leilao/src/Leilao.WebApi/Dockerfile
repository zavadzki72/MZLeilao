#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Leilao.WebApi/Leilao.WebApi.csproj", "src/Leilao.WebApi/"]
COPY ["src/Leilao.Domain.Core/Leilao.Domain.Core.csproj", "src/Leilao.Domain.Core/"]
COPY ["src/Leilao.ApplicationService/Leilao.ApplicationService.csproj", "src/Leilao.ApplicationService/"]
RUN dotnet restore "src/Leilao.WebApi/Leilao.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Leilao.WebApi"
RUN dotnet build "Leilao.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Leilao.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Leilao.WebApi.dll"]