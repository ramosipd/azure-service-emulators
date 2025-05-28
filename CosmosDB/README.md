# CosmosDB Project

## Overview
This project demonstrates how to use the CosmosDB emulator.

## Scripts
- `emulator:cosmosdb:start`: Start CosmosDB emulator using Docker.
- `start:cosmosdb`: Run the CosmosDB console project using .NET.

## Example
```bash
npm run start:cosmosdb
```

Note: Ensure to run the emulator first.

## Dependencies
- .NET runtime
- Docker Engine

## Additional Information
- [Documentation](https://learn.microsoft.com/en-us/azure/cosmos-db/emulator-linux)

The emulator does not use a docker-compose file. Instead, it uses a start script that automatically discards the container with the `--rm` flag. If you want to keep the container, remove the `--rm` flag from the script.

This approach is working that work without the need to install certificates for local development. You will need to ignore SSL errors in the code.