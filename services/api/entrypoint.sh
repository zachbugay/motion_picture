#!/bin/bash
echo "Waiting for SqlServer..."

while ! nc -z db 1433; do
  sleep 0.1
done

echo "SqlServer started"

dotnet api.dll
