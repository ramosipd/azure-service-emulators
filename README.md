# Azure Emulator Demos

This repository contains several projects that demonstrate how to use local emulators for various Azure services. Each demo is organized in its own folder and provides a working example of how to develop and test against Azure service emulators locally, without needing access to real Azure resources.

## Available Demos

- **EventGrid**: A demo for Azure Event Grid, including a local emulator, publisher, and receiver. See [EventGrid/README.md](./EventGrid/README.md) for details.
- **API**: A demo for API Emulation using WireMock, including a local emulator and a console application. See [API/README.md](./API/README.md) for details.
- **ServiceBus**: A demo for Azure Service Bus, including the official Microsoft emulator, publisher, and receiver. See [ServiceBus/README.md](./ServiceBus/README.md) for details.
- **BlobStorage**: A demo for Azure Storage Emulator (Blob), including a publisher and receiver console application. See [BlobStorage/README.md](./BlobStorage/README.md) for details.
- **CosmosDB**: A demo for Azure Cosmos DB Emulator, including a publisher application. See [CosmosDB/README.md](./CosmosDB/README.md) for details.

## How to Use

Each demo contains its own README with setup and usage instructions. To get started, navigate to the demo folder and follow the instructions provided.

## Prerequisites
- Node.js 20.x
- Docker Desktop
- .NET 8.0 SDK
- Azure Functions Core Tools 4.x

## Using npm Scripts

This repository uses npm scripts to simplify running the demos. After cloning the repository, follow these steps:

1. Install dependencies:
```powershell
npm install
```

2. Build the demos:
```powershell
npm run build:all           # Build all demos
npm run build:eventgrid     # Build EventGrid demo
npm run build:api          # Build API demo
npm run build:servicebus   # Build ServiceBus demo
npm run build:blobstorage  # Build BlobStorage demo
```

3. Available scripts for each demo:

### EventGrid Demo
```