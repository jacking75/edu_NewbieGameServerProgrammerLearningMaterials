# 도커

#### API Server, Hive Server, Mysql, Redis를 도커 컨테이너로 실행하는 실습입니다.
---
## 실습

## docker-compose.yml

```yaml
---
version: "1.0"

services:
  db:
    image: mydbimage
    container_name: mydb
    build:
      context: ./DB
      dockerfile: Dockerfile
    restart:
      always
    ports:
      - "3306:3306"

  hive:
    image : hiveimage
    container_name: hive
    build:
      context: ./FakeHiveServer/aspnetapp
      dockerfile: Dockerfile
    restart:
      always
    ports:
      - "11501:11501"
    depends_on:
      - db
      - redis

  server:
    image : serverimage
    container_name: server
    build:
      context: ./APIServer/aspnetapp
      dockerfile: Dockerfile
    restart:
      always
    ports:
      - "11500:11500"
    depends_on:
      - db
  
  redis:
    image: redis
    container_name: redis
    restart:
      always
    ports: 
      - "6379:6379"
```
=> docker-compose.yml 파일을 통해 여러 컨테이너를 한번에 실행할 수 있습니다.

## ./DB/Dockefile
```dockerfile
FROM mysql:8.2

ENV MYSQL_ROOT_PASSWORD=password

COPY ./Dump20240126.sql /docker-entrypoint-initdb.d/

EXPOSE 3306

CMD ["mysqld","--character-set-server=utf8", "--collation-server=utf8_general_ci"]
```
=> mysql:8.2 이미지를 기반으로 컨테이너를 생성하며, 초기 데이터베이스를 설정하기 위해 Dump20240126.sql 파일을 복사합니다.

## ./APIServer/Dockerfile
```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /App

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out
EXPOSE 11500

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "APIServer.dll"]
```
=> dotnet sdk:8.0 이미지를 기반으로 컨테이너를 생성하며, dotnet restore, dotnet publish를 통해 빌드합니다.

*.csproj 만 복사하고 dotnet restore을 하는 이유는 csproj 파일이 변경되지 않았을 경우, 캐시를 사용하여 빌드 시간을 단축하기 위함입니다.

## ./APIServer/appsettings.json
``` json
{
  "AllowedHosts": "*",
  "ServerAddress": "http://*:11500",
  "DbConfig": {
    "Redis": "redis",
    "GameDb": "Server=db;Port=3306;user=root;Password=password;Database=game_db;Pooling=true;Min Pool Size=0;Max Pool Size=100;AllowUserVariables=True;"
  }
}

```

=> redis, mysql의 주소를 docker-compose.yml 파일에서 설정한 컨테이너 이름으로 설정할 수 있습니다.