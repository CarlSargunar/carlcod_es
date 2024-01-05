## Delete the old backup in docker

    docker exec -it sql_server_2019 rm /var/opt/mssql/data/carlcod_es.bak

## Do a full db backup in docker

Exec the SQL

    use master
    BACKUP DATABASE [carlcod_es] TO DISK = N'/var/opt/mssql/data/carlcod_es.bak' WITH NOFORMAT, NOINIT, NAME = 'carlcod_es', SKIP, NOREWIND, NOUNLOAD, STATS = 10;
    GO

You can also use the tool microsoft.sqlpackage to export a bacpac of the database. 

    sqlpackage /Action:Export /scs:"Server=localhost;Database=carlcod_es;User Id=sa;Password=SQL_password123;TrustServerCertificate=true;" /tf:database/carlcod_es.bacpac


## Copy Backup Back

    docker cp sql_server_2019:/var/opt/mssql/data/carlcod_es.bak "database/carlcod_es.bak"
