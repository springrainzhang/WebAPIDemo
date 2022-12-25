#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["/MVCAPIDemo.csproj", "MVCAPIDemo/"]
RUN dotnet restore "MVCAPIDemo/MVCAPIDemo.csproj"
COPY . .
WORKDIR "/src/MVCAPIDemo"
RUN dotnet build "MVCAPIDemo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MVCAPIDemo.csproj" -c Release -o /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MVCAPIDemo.dll"]