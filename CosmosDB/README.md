# CosmosDB Project

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
- Docker Desktop

## Additional Information
- [Documentation](https://learn.microsoft.com/en-us/azure/cosmos-db/emulator-linux)

The start script of the emulator automatically discards the container with the `--rm` flag. If you want to keep the container, remove the `--rm` flag from the script.