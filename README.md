# Azure Emulator Demos

This repository contains several projects that demonstrate how to use local emulators for various Azure services. Each demo is organized in its own folder and provides a working example of how to develop and test against Azure service emulators locally, without needing access to real Azure resources.

## Available Demos

- **EventGrid**: A complete demo for Azure Event Grid, including a local emulator, publisher, and receiver. See [EventGrid/README.md](./EventGrid/README.md) for details.

## Planned Demos

The following emulator demos are planned and will be added soon:

- **AzureCosmos**: Demo for Azure Cosmos DB Emulator
- **ServiceBus**: Demo for Azure Service Bus Emulator
- **BlobStorage**: Demo for Azure Storage Emulator (Blob)

## How to Use

Each demo contains its own README with setup and usage instructions. To get started, navigate to the demo folder and follow the instructions provided.

## Prerequisites

- [Node.js](https://nodejs.org/) (for npm scripts)
- [Docker](https://www.docker.com/products/docker-desktop/) (for running most emulators)
- [.NET SDK](https://dotnet.microsoft.com/download) (for .NET-based demos)
- [Azure Functions Core Tools](https://learn.microsoft.com/en-us/azure/azure-functions/functions-run-local) (for Azure Functions demos)

---

Contributions and suggestions for additional emulator demos are welcome! 