# Movie Store API

## Starting SQL Server - [DID NOT WORK] on Apple Silicon Chip (ie Macbook Air - M2 Chip)

```powershell
$sa_password = "[SA PASSWORD HERE]"
sudo docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$sa_password" -p 1433:1433 --name sql1 --hostname sql1 -d mcr.microsoft.com/mssql/server:2022-latest
```

## Setting the connection string to secret manager

```powershell
$sa_password = "[SA PASSWORD HERE]"
dotnet user-secrets set "ConnectionStrings:MovieStoreContext" "server=localhost;database=sql_movie_store;user=root;password=$sa_password;"
```
