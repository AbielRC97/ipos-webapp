## Generar un build docker
```bash
docker build -t ipos-webapp .  
```

## Levantar build docker
```bash
docker run -d -p 8080:8080  ipos-webapp
```

## Ejecutar Local
```bash
dotnet run
```