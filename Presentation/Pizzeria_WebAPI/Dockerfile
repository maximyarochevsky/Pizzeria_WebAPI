FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Presentation/Pizzeria_WebAPI/Pizzeria_WebAPI.csproj", "Presentation/Pizzeria_WebAPI/"]
COPY ["Core/Pizzeria.Application/Pizzeria.Application.csproj", "Core/Pizzeria.Application/"]
COPY ["Core/Pizzeria.Domain/Pizzeria.Domain.csproj", "Core/Pizzeria.Domain/"]
COPY ["Infrastructure/Pizzeria.Infrastructure/Pizzeria.Infrastructure.csproj", "Infrastructure/Pizzeria.Infrastructure/"]
COPY ["Pizzeria.Contracts/Pizzeria.Contracts.csproj", "Pizzeria.Contracts/"]
RUN dotnet restore "Presentation/Pizzeria_WebAPI/Pizzeria_WebAPI.csproj"
COPY . .
WORKDIR "/src/Presentation/Pizzeria_WebAPI"
RUN dotnet build "Pizzeria_WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pizzeria_WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pizzeria_WebAPI.dll"]