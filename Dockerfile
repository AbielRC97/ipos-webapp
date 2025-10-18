# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiar csproj y restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar todo el proyecto
COPY . ./
# Publicar la aplicación
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copiar archivos publicados
COPY --from=build /app/publish ./

# Carpeta para SQLite persistente
VOLUME /app/Data

ENTRYPOINT ["dotnet", "ipos.dll"]
