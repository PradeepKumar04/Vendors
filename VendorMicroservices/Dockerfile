#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["VendorMicroservices/VendorMicroservices.csproj", "VendorMicroservices/"]
RUN dotnet restore "VendorMicroservices/VendorMicroservices.csproj"
COPY . .
WORKDIR "/src/VendorMicroservices"
RUN dotnet build "VendorMicroservices.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VendorMicroservices.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VendorMicroservices.dll"]