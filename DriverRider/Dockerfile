FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
#EXPOSE 5004 3306

#ENV ASPNETCORE_URLS=http://+:5004

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["rideServer.csproj", "./"]
RUN dotnet restore "rideServer.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "rideServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "rideServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "rideServer.dll"]
