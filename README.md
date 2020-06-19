# PROJECT TRANG THÔNG TIN ĐẤU GIÁ

## Prerequisites

- Docker (or you can start your own MSSQL Server)
- Visual Studio (for migrating database using Entity framework)
- VSCode (or other code editor)
- Node Package Manager (npm or yarn) *(Make sure you installed node version 10.21.0 or lower)*

## Start MSSQL using Docker

*If you already have MSSQL installed on your computer, you can skip this step*

If this is the first time you start MSSQL, run the following command:
```
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=yourStrong(!)Password' -p 1433:1433 --name mssql -d mcr.microsoft.com/mssql/server:2017-latest
```

To check whether mssql container has been started, run the following command:
```
docker ps

// Expected result will be something similar to:
CONTAINER ID        IMAGE                                        COMMAND                  CREATED             STATUS              PORTS                    NAMES
58edfa17e4a0        mcr.microsoft.com/mssql/server:2017-latest   "/opt/mssql/bin/nonr…"   4 weeks ago         Up 3 minutes        0.0.0.0:1433->1433/tcp   mssql
```

The next time, you just need to run:
```
docker container start mssql
```

## Run migrations for DB

*You should only run this step once schemas have been changed. Otherwise, make sure to drop the database before running this step*

- Open aspnet-core project on Visual Studio, go to View -> Other Windows -> Package Manager Console
- In Package Manager Console, select Default Project to GSoft.AbpZeroTemplate.EntityFrameworkCore
- Run the following command:
```
update-database
```

## Start the API Server

- Right-click on GSoft.AbpZeroTemplate.Web.Host -> Set as StartUp Project
- Hit Ctrl + F5 or go to Debug -> Start Without Debugging
- The Swagger should be opened on your web browser

## Start the admin page

- Open angular project on VSCode
- Install packages:
```
npm install

// or

yarn
```
- Start your project
```
npm run start

// or

yarn start
```

- Login (for the first time):
  - Username: admin
  - Password: 123qwe
