# SQL Project

## Overview
This project demonstrates how to use the SQL Server emulator with Microsoft SQL Server Docker container.

## Scripts
- `emulator:sql:start`: Start SQL Server emulator using Docker Compose.
- `emulator:sql:stop`: Stop SQL Server emulator using Docker Compose.
- `start:sql:publisher`: Run the Publisher console project using .NET.
- `start:sql:receiver`: Run the Receiver console project using .NET.

## Example
```bash
npm run start:sql:publisher
```

Note: Ensure to run the emulator first.

## Dependencies
- .NET SDK 8.0.408+
- Docker Engine

## Connection Details
- **Server**: localhost,1433
- **Username**: sa
- **Password**: YourStrong@Passw0rd
- **Database**: SampleDB

## Additional Information
- [DockerHub](https://hub.docker.com/r/microsoft/mssql-server)
- [Documentation](https://learn.microsoft.com/en-us/sql/linux/sql-server-linux-docker-container-deployment) 