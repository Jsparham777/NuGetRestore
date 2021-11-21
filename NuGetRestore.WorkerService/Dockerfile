#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["NuGetRestore.WorkService/NuGetRestore.WorkService.csproj", "NuGetRestore.WorkService/"]
RUN dotnet restore "NuGetRestore.WorkService/NuGetRestore.WorkService.csproj"
COPY . .
WORKDIR "/src/NuGetRestore.WorkService"
RUN dotnet build "NuGetRestore.WorkService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NuGetRestore.WorkService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NuGetRestore.WorkService.dll"]