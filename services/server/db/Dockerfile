# base image
FROM mcr.microsoft.com/mssql/server:2019-latest

# Copy all files to the container.
COPY create.sql create.sql
COPY entrypoint.sh entrypoint.sh
COPY import-data.sh import-data.sh
# Run as root and ensure the scripts are executable.
USER root
RUN chmod +x entrypoint.sh
RUN chmod +x import-data.sh
# Run as mssql, and launch the entry point.
USER mssql
CMD ["./entrypoint.sh"]
