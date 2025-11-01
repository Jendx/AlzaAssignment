# Start SQL Server in background
/opt/mssql/bin/sqlservr &

# Wait for SQL Server to be up
echo "Waiting for SQL Server to start..."
sleep 15

# Run initialization scripts
for f in /docker-entrypoint-initdb.d/*.sql
do
  echo "Running $f"
  /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P "$SA_PASSWORD" -C -d master -i "$f"
done

# Keep SQL Server running
wait