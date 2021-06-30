#!/bin/bash
echo "Running Sql Create Commands..."

# Start the mssql server, and import data. Lastly, sleep forever so the container does not shut down.
/opt/mssql/bin/sqlservr & ./import-data.sh & sleep infinity
