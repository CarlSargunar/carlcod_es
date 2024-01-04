## Delete the old backup in docker

    docker exec -it sql_server_2019 rm /var/opt/mssql/data/carlcod_es.bak

## Do a full db backup in docker

Exec the SQL

    use master
    BACKUP DATABASE [carlcod_es] TO DISK = N'/var/opt/mssql/data/carlcod_es.bak' WITH NOFORMAT, NOINIT, NAME = 'carlcod_es', SKIP, NOREWIND, NOUNLOAD, STATS = 10;
    GO

## Copy Backup Back

    docker cp sql_server_2019:/var/opt/mssql/data/carlcod_es.bak "database/carlcod_es.bak"
