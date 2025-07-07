# ☁️ Azure Service Emulators

## 📖 Overview
This project contains multiple demos for Azure Service emulators. Each demo showcases a particular Azure service integration, and further instructions are provided in each demo's README file.

## 📁 File Structure
```
azure-service-emulators/
├── API/                   # API emulator demo using WireMock
├── BlobStorage/           # Blob Storage emulator demo using Azurite
├── CosmosDB/              # Cosmos DB emulator demo using cosmos-db emulator
├── EventGrid/             # Event Grid emulator demo using third-party emulator
├── ServiceBus/            # Service Bus emulator demo using Microsoft's emulator
├── SQL/                   # SQL Server emulator demo using Microsoft SQL Server
├── .gitignore             # Git ignore file
├── global.json            # .NET global configuration
├── package.json           # npm package configuration for workspace
├── package-lock.json      # npm lock file
└── README.md              # This file - project documentation
```

Each demo folder contains:
- **README.md** - Specific instructions for that demo
- **Source code** - Implementation files for the demo
- **Configuration files** - Docker, environment, and service configurations

## 🚀 Demos
Each demo project is independent and can be run separately. Please refer to the specific `README.md` in each demo folder for detailed instructions.

- [API](API/README.md) - Demonstrates how to use the API emulator using [WireMock emulator](https://hub.docker.com/r/wiremock/wiremock).
- [BlobStorage](BlobStorage/README.md) - Demonstrates how to use the Blob Storage emulator using [Azurite](https://hub.docker.com/r/microsoft/azure-storage-azurite).
- [CosmosDB](CosmosDB/README.md) - Demonstrates how to use the Cosmos DB emulator using [cosmos-db emulator (linux)](https://learn.microsoft.com/en-us/azure/cosmos-db/emulator-linux).
- [EventGrid](EventGrid/README.md) - Demonstrates how to use the Event Grid emulator using third-party [emulator](https://github.com/workleap/wl-eventgrid-emulator).
- [ServiceBus](ServiceBus/README.md) - Demonstrates how to use the [Service Bus emulator](https://hub.docker.com/r/microsoft/azure-messaging-servicebus-emulator).
- [SQL](SQL/README.md) - Demonstrates how to use the SQL Server emulator using [Microsoft SQL Server](https://hub.docker.com/r/microsoft/mssql-server).

## 🏗️ Build the Projects
Build all projects using the following command:
```bash
npm run build:all
```

## ℹ️ Additional Information

**Dependencies:**
- DotNet SDK 8.0.408+
- npm (v11.4+)
- Docker Engine (28.1.x+)
- Azure Function Core Tools (4.0.7+)