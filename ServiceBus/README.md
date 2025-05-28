# ServiceBus Project

This project demonstrates how to use the Service Bus emulator.

## Scripts
- `build:servicebus`: Build the ServiceBus emulator using Docker Compose.
- `emulator:servicebus:start`: Start ServiceBus emulator using Docker Compose.
- `emulator:servicebus:stop`: Stop ServiceBus emulator using Docker Compose.
- `start:servicebus`: Run the ServiceBus project using Azure Functions (via func start).
- `trigger:servicebus`: Trigger ServiceBus events using .NET.

example:
```bash
npm run start:servicebus
```

note: ensure to run the emulator first.

## Dependencies
- .NET SDK 8.0.408+
- Docker Engine
- Azure Functions Core Tools

## Additional Information
- [DockerHub](https://hub.docker.com/r/microsoft/azure-messaging-servicebus-emulator)
- [Documentation](https://learn.microsoft.com/en-us/azure/service-bus-messaging/service-bus-emulator)