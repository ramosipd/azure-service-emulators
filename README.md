# Azure Service Emulators

## Overview
This project contains multiple demos for Azure Service emulators. Each demo showcases a particular Azure service integration, and further instructions are provided in each demo's README file.

## Demos
- [API](API/README.md) - Demonstrates how to use the API emulator using [WireMock emulator](https://hub.docker.com/r/wiremock/wiremock).
- [BlobStorage](BlobStorage/README.md) - Demonstrates how to use the Blob Storage emulator using [Azurite](https://hub.docker.com/r/microsoft/azure-storage-azurite).
- [CosmosDB](CosmosDB/README.md) - Demonstrates how to use the Cosmos DB emulator using [cosmos-db emulator (linux)](https://learn.microsoft.com/en-us/azure/cosmos-db/emulator-linux).
- [EventGrid](EventGrid/README.md) - Demonstrates how to use the Event Grid emulator using third-party [emulator](https://github.com/workleap/wl-eventgrid-emulator).
- [ServiceBus](ServiceBus/README.md) - Demonstrates how to use the [Service Bus emulator](https://hub.docker.com/r/microsoft/azure-messaging-servicebus-emulator).

## Build the Projects
Build all projects using the following command:
```bash
npm run build:all
```
Please refer to the specific README in each demo folder for detailed instructions.

## Additional Information

This project uses npm (v11.4+), Docker Deskt
For more information, please check the individual demo documentation.