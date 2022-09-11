FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
RUN apt-get update && apt-get install -y nodejs
COPY ["Applications/StackOverflow.Web/StackOverflow.Web.csproj", "Applications/StackOverflow.Web/"]
COPY ["Libraries/StackOverflow.Membership/StackOverflow.Membership.csproj", "Libraries/StackOverflow.Membership/"]
COPY ["Libraries/StackOverflow.Infrastructure/StackOverflow.Infrastructure.csproj", "Libraries/StackOverflow.Infrastructure/"]
RUN dotnet restore "Applications/StackOverflow.Web/StackOverflow.Web.csproj"
COPY . .
WORKDIR "/src/Applications/StackOverflow.Web"
RUN dotnet build "StackOverflow.Web.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "StackOverflow.Web.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StackOverflow.Web.dll"]