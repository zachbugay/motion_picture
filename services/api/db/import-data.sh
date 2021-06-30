#!/bin/bash

# Try up to 50 times to run the create.sql command.

for i in {1..50};
do
    /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Your_password123 -d master -i create.sql
    if [ $? -eq 0 ]
    then
        echo "create.sql completed"
        break
    else
        echo "not ready yet..."
        sleep 1
    fi
done
