# BlobStorage Project

## Overview
This project demonstrates how to use the Blob Storage emulator with Azurite.

## Scripts
- `emulator:blobstorage:start`: Start BlobStorage emulator using Docker Compose.
- `emulator:blobstorage:stop`: Stop BlobStorage emulator using Docker Compose.
- `start:blobstorage:publisher`: Run the Publisher console project using .NET.
- `start:blobstorage:receiver`: Run the Azure Function receiver using `func start`.

## Example
```bash
npm run start:blobstorage:publisher
```

Note: Ensure to run the emulator first.

## Dependencies
- .NET SDK 8.0.408+
- Docker Engine
- Azure Functions Core Tools

## Additional Information
- [DockerHub](https://hub.docker.com/r/microsoft/azure-storage-azurite)
- [Documentation](https://learn.microsoft.com/en-us/azure/storage/common/storage-use-azurite?tabs=visual-studio%2Cblob-storage)