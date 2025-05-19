# Service Bus Demo with Azure Functions

This project demonstrates a complete Azure Service Bus implementation with a publisher and receiver using Azure Functions.

## Overview

The project consists of two main components:

1. **Service Bus Publisher** (`ServiceBusPublisher/Program.cs`): A .NET console application that sends messages to a Service Bus queue.
2. **Service Bus Receiver** (`ServiceBusReceiver/ServiceBusTriggerFunction.cs`): An Azure Function that listens for messages from the Service Bus queue and processes them.

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Azure Functions Core Tools](https://learn.microsoft.com/en-us/azure/azure-functions/functions-run-local)
- [Docker](https://www.docker.com/products/docker-desktop/) (for running the Service Bus emulator)

## Project Structure

- **`ServiceBusPublisher/`**: Contains the publisher application
    - **`Program.cs`**: Main application that sends messages to the Service Bus queue
    - **`ServiceBusPublisher.csproj`**: Project file with required dependencies

- **`ServiceBusReceiver/`**: Contains the Azure Function project
    - **`ServiceBusTriggerFunction.cs`**: The Azure Function that processes Service Bus messages
    - **`local.settings.json`**: Configuration settings for local development
    - **`host.json`**: Configuration for the Azure Functions host
    - **`Program.cs`**: Main entry point for the .NET isolated worker process

- **`Emulator/`**: Contains configuration for the Service Bus emulator
    - **`config.json`**: Configuration for queues and topics

## Local Service Bus Emulator

This project uses the official Microsoft Azure Service Bus emulator for local development.

### Running the Emulator

1. Start the emulator using Docker Compose:

```powershell
docker-compose up
```

This will start both the Service Bus emulator and its SQL Edge dependency, mounting the configuration and exposing the necessary ports.

To stop the emulator, run:

```powershell
docker-compose down
```

## Getting Started

### 1. Install Dependencies

First, restore the .NET dependencies for both the publisher and receiver:

```powershell
dotnet restore ServiceBusPublisher/ServiceBusPublisher.csproj
dotnet restore ServiceBusReceiver/ServiceBusReceiver.csproj
```

### 2. Start the Azure Function Receiver

You can start the Azure Function in two ways:

#### Using func CLI directly
From the `ServiceBusReceiver` directory:
```powershell
func start
```

The function will be listening for incoming messages.

### 3. Run the Publisher

Run the publisher to send a message to the Service Bus queue:

```powershell
dotnet run --project ServiceBusPublisher/ServiceBusPublisher.csproj
```

### 4. Monitor the Results

You should see log output in the terminal where the Azure Function is running, indicating that it received and processed the message.

## Configuration

### Service Bus Publisher

The publisher is configured to send messages to the local Service Bus emulator. You can modify the connection string and queue name in `Program.cs`:

```csharp
private const string ServiceBusConnectionString = "Endpoint=sb://localhost;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=SAS_KEY_VALUE;UseDevelopmentEmulator=true;";
private const string QueueName = "queue1";
```

### Service Bus Receiver

The receiver's configuration is stored in `local.settings.json`. Make sure to update the following settings:

```json
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "FUNCTIONS_HTTPWORKER_PORT": "7071",
        "ServiceBusConnection": "Endpoint=sb://localhost;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=SAS_KEY_VALUE;UseDevelopmentEmulator=true;"
    }
}
```

## Local Settings

The `local.settings.json` file is crucial for local development of Azure Functions. This file contains configuration settings that are used when running the function app locally. Here are the key points about local settings:

### Important Notes
- The `local.settings.json` file should never be committed to source control as it may contain sensitive information
- It's recommended to add `local.settings.json` to your `.gitignore` file
- A template file (`local.settings.template.json`) should be provided in source control as a reference

### Required Settings
- `AzureWebJobsStorage`: Connection string for Azure Storage (use "UseDevelopmentStorage=true" for local development)
- `FUNCTIONS_WORKER_RUNTIME`: Specifies the language runtime (dotnet-isolated for .NET isolated process)
- `ServiceBusConnection`: Connection string for Azure Service Bus (points to local emulator in development)

### Optional Settings
- `FUNCTIONS_HTTPWORKER_PORT`: Port number for the HTTP worker (defaults to 7071)
- `IsEncrypted`: Set to false for local development

### Creating Local Settings
1. Copy `local.settings.template.json` to `local.settings.json`
2. Update the values as needed for your local environment
3. Ensure the ServiceBusConnection string matches your emulator configuration

## Notes on the Service Bus Emulator

- The emulator is the official Microsoft Azure Service Bus emulator.
- It requires SQL Edge as a dependency for message persistence.
- The emulator runs on port 5672 for AMQP and 5300 for management.
- Authentication is handled through SAS tokens.
- Messages are persisted in the SQL Edge database.