#!/bin/bash

echo "Waiting SQL Server..."

sleep 30

/opt/mssql-tools18/bin/sqlcmd \
-S localhost \
-U sa \
-P "$MSSQL_SA_PASSWORD" \
-C \
-i /scripts/01_CreaBaseDatos.sql

/opt/mssql-tools18/bin/sqlcmd \
-S localhost \
-U sa \
-P "$MSSQL_SA_PASSWORD" \
-C \
-i /scripts/02_CreaTablas.sql

/opt/mssql-tools18/bin/sqlcmd \
-S localhost \
-U sa \
-P "$MSSQL_SA_PASSWORD" \
-C \
-i /scripts/03_CreaStoredProcedures.sql

echo "Database initialized"