# Use the official ASP.NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj files and restore as distinct layers
COPY ["src/MyDddProject.WebApi/MyDddProject.WebApi.csproj", "src/MyDddProject.WebApi/"]
COPY ["src/MyDddProject.Application/MyDddProject.Application.csproj", "src/MyDddProject.Application/"]
COPY ["src/MyDddProject.Domain/MyDddProject.Domain.csproj", "src/MyDddProject.Domain/"]
COPY ["src/MyDddProject.Infrastructure/MyDddProject.Infrastructure.csproj", "src/MyDddProject.Infrastructure/"]
COPY ["src/MyDddProject.SharedKernel/MyDddProject.SharedKernel.csproj", "src/MyDddProject.SharedKernel/"]

RUN dotnet restore "src/MyDddProject.WebApi/MyDddProject.WebApi.csproj"

# Copy everything else and build
COPY . .
WORKDIR "/src/src/MyDddProject.WebApi"
RUN dotnet build "MyDddProject.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyDddProject.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage/image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyDddProject.WebApi.dll"]
