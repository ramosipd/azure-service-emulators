# Event Grid Demo with Azure Functions

This project demonstrates a complete Event Grid implementation with a publisher and receiver using Azure Functions.

## Overview

The project consists of two main components:

1. **Event Grid Publisher** (`EventGridPublisher/Program.cs`): A .NET console application that publishes events to an Event Grid topic.
2. **Event Grid Receiver** (`EventGridReceiver/EventGridTriggerFunction.cs`): An Azure Function that listens for events from the Event Grid topic and processes them.

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Azure Functions Core Tools](https://learn.microsoft.com/en-us/azure/azure-functions/functions-run-local)
- [Azure CLI](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli)
- [Node.js](https://nodejs.org/) (which includes npm)
- [Docker](https://www.docker.com/products/docker-desktop/) (for running the Event Grid emulator)

## Project Structure

- **`EventGridPublisher/`**: Contains the publisher application
    - **`Program.cs`**: Main application that publishes events to Event Grid
    - **`EventGridPublisher.csproj`**: Project file with required dependencies

- **`EventGridReceiver/`**: Contains the Azure Function project
    - **`EventGridTriggerFunction.cs`**: The Azure Function that processes Event Grid events
    - **`local.settings.json`**: Configuration settings for local development
    - **`host.json`**: Configuration for the Azure Functions host
    - **`Program.cs`**: Main entry point for the .NET isolated worker process

- **`Emulator/`**: Contains configuration for the Event Grid emulator
    - **`applicationsettings.json`**: Configuration for topics and webhooks

## Local Event Grid Emulator

This project uses the [Workleap Azure Event Grid Emulator](https://github.com/workleap/wl-eventgrid-emulator) for local development. This is an unofficial emulator that provides a local development experience similar to Azure Event Grid.

### Running the Emulator

1. Start the emulator using Docker Compose:

```powershell
npm run emulator:eventgrid:start
```

This will start the Event Grid emulator using Docker Compose, mounting the configuration and exposing port 6500. (The docker-compose.yml file is now located in the EventGrid directory.)

To stop the emulator, run:

```powershell
npm run emulator:eventgrid:stop
```

## Emulator Configuration

The emulator is configured using `Emulator/applicationsettings.json`. This file defines the topics and their associated webhooks:

```json
{
    "Topics": {
        "topic1": [
            "http://host.docker.internal:7071/runtime/webhooks/EventGrid?functionName=EventGridTriggerFunction"
        ]
    }
}
```

In this configuration:
- `topic1` is the name of the topic
- The webhook URL points to the local Azure Function endpoint
- `host.docker.internal` is used to allow the emulator to reach the webhook on your host machine

## Getting Started

### 1. Install Dependencies

First, install the npm dependencies from the project root:

```powershell
npm install
```

### 2. Start the Azure Function Receiver

You can start the Azure Function in two ways:

#### Using npm (recommended)
From the project root directory:
```powershell
npm run start:eventgrid
```

#### Using func CLI directly
From the EventGridReceiver directory:
```powershell
func start
```

The function will be listening for incoming events at: `http://localhost:7071/runtime/webhooks/EventGrid?functionName=EventGridTriggerFunction`

### 3. Run the Publisher

You can run the publisher in two ways:

#### Using npm (recommended)
From the project root directory:
```powershell
npm run trigger:eventgrid
```

#### Using dotnet directly
From the EventGridPublisher directory:
```powershell
dotnet run
```

The publisher will send a sample event to the Event Grid topic, which will trigger the Azure Function.

### 4. Monitor the Results

You should see log output in the terminal where the Azure Function is running, indicating that it received and processed the event. For example:

```
[<timestamp>] Executing 'Functions.EventGridTriggerFunction' (Reason='EventGrid trigger fired at <timestamp>', Id=<id>)
[<timestamp>] Event type: MyEvent, Event subject: test
[<timestamp>] Event data: {"Message":"Hello from Event Grid Publisher!","Timestamp":"2024-XX-XX..."}
[<timestamp>] Executed 'Functions.EventGridTriggerFunction' (Succeeded, Id=<id>, Duration=<duration>ms)
```

## Configuration

### Event Grid Publisher

The publisher is configured to send events to the local Event Grid emulator. You can modify the endpoint URL and access key in `Program.cs`:

```csharp
var client = new EventGridPublisherClient(
    new Uri("http://127.0.0.1:6500/topic1/api/events"),
    new AzureKeyCredential("fakeAccessKey"));
```

### Event Grid Receiver

The receiver's configuration is stored in `local.settings.json`. Make sure to update the following settings:

```json
{
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated"
    }
}
```

## Development

To modify the event data being sent, update the `data` object in `EventGridPublisher/Program.cs`:

```csharp
var data = new
{
    Message = "Hello from Event Grid Publisher!",
    Timestamp = DateTime.UtcNow
};
```

To modify how events are processed, update the `Run` method in `EventGridReceiver/EventGridTriggerFunction.cs`.

## Available npm Scripts

The project includes the following npm scripts:

- `npm run start:eventgrid`: Starts the Azure Function receiver for the Event Grid demo
- `npm run trigger:eventgrid`: Runs the Event Grid publisher demo
- `npm run emulator:eventgrid:start`: Starts the Event Grid emulator using Docker Compose (from EventGrid/docker-compose.yml)
- `npm run emulator:eventgrid:stop`: Stops the Event Grid emulator (from EventGrid/docker-compose.yml)

## Notes on the Event Grid Emulator

- The emulator is unofficial and provided by Workleap
- It supports both push and pull delivery models
- The emulator runs on port 6500 by default
- Authentication is ignored by the emulator (you can use any access key)
- Events are stored in memory and will be lost if the emulator is restarted
- The emulator supports both EventGridEvents and CloudEvents formats
