#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["IAMServer/IAMServer.csproj", "IAMServer/"]
RUN dotnet restore "IAMServer/IAMServer.csproj"
COPY . .
WORKDIR "/src/IAMServer"
RUN dotnet build "IAMServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IAMServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IAMServer.dll"]