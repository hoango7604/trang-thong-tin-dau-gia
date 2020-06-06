# PROJECT TRANG THÔNG TIN ĐẤU GIÁ

## Prerequisites

- Docker (or you can start your own MSSQL Server)
- Visual Studio (for migrating database using Entity framework)
- VSCode (or other code editor)
- Node Package Manager (npm or yarn)

## Start MSSQL using Docker

```
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=yourStrong(!)Password' -p 1433:1433 --name mssql -d mcr.microsoft.com/mssql/server:2017-latest
```

##
