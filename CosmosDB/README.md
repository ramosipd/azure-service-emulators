# Cosmos DB Demo with Azure Functions

This project demonstrates a complete Cosmos DB implementation with a publisher using Azure Functions.

## Overview

The project consists of the following main component:

1. **Cosmos DB Publisher** (`CosmosDBPublisher/Program.cs`): A .NET console application that interacts with a Cosmos DB instance.

## Project Structure

- **`CosmosDBPublisher/`**: Contains the publisher application
    - **`Program.cs`**: Main application that interacts with Cosmos DB
    - **`CosmosDBPublisher.csproj`**: Project file with required dependencies

## Local Cosmos DB Emulator

This project uses the [Azure Cosmos DB Emulator](https://learn.microsoft.com/en-us/azure/cosmos-db/local-emulator) for local development.

### Running the Emulator

1. Start the emulator using the following command:

```powershell
npm run emulator:cosmosdb:start
```

This will start the Cosmos DB emulator with the `--protocol https` flag, exposing the necessary ports.

To stop the emulator, you can simply cancel the running process in the terminal. This is because the emulator is started with the `--rm` flag, which ensures that the container is automatically removed when it stops. 

### Emulator Configuration

The emulator is configured to ignore SSL. Ensure that your application is set to bypass SSL validation when connecting to the emulator. This is achieved using the following code in `CosmosDBPublisher/Program.cs`:

```csharp
var options = new CosmosClientOptions
{
    HttpClientFactory = () => new HttpClient(new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
    }),
    ConnectionMode = ConnectionMode.Gateway
};

using CosmosClient client = new CosmosClient(accountEndpoint, authKeyOrResourceToken, options);
```

## Getting Started

### 1. Install Dependencies

First, install the npm dependencies from the project root:

```powershell
npm install
```

### 2. Start the Cosmos DB Emulator

Run the following command to start the emulator:

```powershell
npm run emulator:cosmosdb:start
```

### 3. Run the Publisher

You can run the publisher using the following command:

```powershell
npm run start:cosmosdb
```

The publisher will interact with the Cosmos DB instance and perform the necessary operations.

### 4. Monitor the Results

You should see log output in the terminal where the publisher is running, indicating the operations performed on the Cosmos DB instance.

## Configuration

### Cosmos DB Publisher

The publisher is configured to connect to the local Cosmos DB emulator. The default emulator credentials are hard-coded in `Program.cs`:

## Available npm Scripts

The project includes the following npm scripts:

- `npm run start:cosmosdb`: Runs the Cosmos DB publisher demo
- `npm run emulator:cosmosdb:start`: Starts the Cosmos DB emulator with the `--protocol https` flag
- `npm run emulator:cosmosdb:stop`: Stops the Cosmos DB emulator

## Notes on the Cosmos DB Emulator

- The emulator runs on port 8081 by default.
- Access the explorer at `https://localhost:1234`
- SSL validation is bypassed for local development.
- Data is stored in memory and will be lost if the emulator is restarted.