# Azure Emulator Demos

This repository contains several projects that demonstrate how to use local emulators for various Azure services. Each demo is organized in its own folder and provides a working example of how to develop and test against Azure service emulators locally, without needing access to real Azure resources.

## Available Demos

- **EventGrid**: A demo for Azure Event Grid, including a local emulator, publisher, and receiver. See [EventGrid/README.md](./EventGrid/README.md) for details.
- **API**: A demo for API Emulation using WireMock, including a local emulator and a console application. See [API/README.md](./API/README.md) for details.
- **ServiceBus**: A demo for Azure Service Bus, including the official Microsoft emulator, publisher, and receiver. See [ServiceBus/README.md](./ServiceBus/README.md) for details.
- **BlobStorage**: A demo for Azure Storage Emulator (Blob), including a publisher and receiver console application. See [BlobStorage/README.md](./BlobStorage/README.md) for details.

## Planned Demos

The following emulator demos are planned and will be added soon:

- **AzureCosmos**: Demo for Azure Cosmos DB Emulator

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

2. Available scripts for each demo:

### EventGrid Demo
```powershell
npm run start:eventgrid        # Start the EventGrid receiver
npm run trigger:eventgrid      # Run the EventGrid publisher
npm run emulator:eventgrid:start  # Start the EventGrid emulator
npm run emulator:eventgrid:stop   # Stop the EventGrid emulator
```

### BlobStorage Demo
```powershell
npm run trigger:blobstorage    # Run the BlobStorage publisher
npm run receive:blobstorage    # Run the BlobStorage receiver
npm run emulator:blobstorage:start  # Start the BlobStorage emulator
npm run emulator:blobstorage:stop   # Stop the BlobStorage emulator
```

### ServiceBus Demo
```powershell
npm run start:servicebus       # Start the ServiceBus receiver
npm run trigger:servicebus     # Run the ServiceBus publisher
npm run emulator:servicebus:start  # Start the ServiceBus emulator
npm run emulator:servicebus:stop   # Stop the ServiceBus emulator
```

### API Demo
```powershell
npm run start:api             # Start the API emulator
npm run trigger:api           # Run the API client
```

For more details about each demo, please refer to their respective README files.

---

Contributions and suggestions for additional emulator demos are welcome! 