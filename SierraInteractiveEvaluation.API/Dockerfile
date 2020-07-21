FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["SierraInteractiveEvaluation.API/SierraInteractiveEvaluation.API.csproj", "SierraInteractiveEvaluation.API/"]
COPY ["SierraInteractiveEvaluation.Models/SierraInteractiveEvaluation.Models.csproj", "SierraInteractiveEvaluation.Models/"]
COPY ["SierraInteractiveEvaluation.Services/SierraInteractiveEvaluation.Services.csproj", "SierraInteractiveEvaluation.Services/"]
COPY ["SierraInteractiveEvaluation.Utilities/SierraInteractiveEvaluation.Utilities.csproj", "SierraInteractiveEvaluation.Utilities/"]
#COPY ["SierraInteractiveEvaluation.API/SierraInteractiveEvaluation.API.csproj", "SierraInteractiveEvaluation.API/"]
RUN dotnet restore "SierraInteractiveEvaluation.API/SierraInteractiveEvaluation.API.csproj"
COPY . .
WORKDIR "/src/SierraInteractiveEvaluation.API"
RUN dotnet build "SierraInteractiveEvaluation.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SierraInteractiveEvaluation.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SierraInteractiveEvaluation.API.dll"]