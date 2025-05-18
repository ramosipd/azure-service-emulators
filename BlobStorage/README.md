# Blob Storage Demo with Azure Storage Emulator

This project demonstrates a complete Blob Storage implementation with a publisher and receiver using the Azure Storage Emulator.

## Overview

The project consists of two main components:

1. **Blob Storage Publisher** (`BlobStoragePublisher/Program.cs`): A .NET console application that uploads files to a blob container.
2. **Blob Storage Receiver** (`BlobStorageReceiver/Program.cs`): A .NET console application that downloads files from a blob container.

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/products/docker-desktop/) (for running the Azure Storage Emulator)

## Project Structure

- **`BlobStoragePublisher/`**: Contains the publisher application
    - **`Program.cs`**: Main application that uploads files to blob storage
    - **`BlobStoragePublisher.csproj`**: Project file with required dependencies

- **`BlobStorageReceiver/`**: Contains the receiver application
    - **`Program.cs`**: Main application that downloads files from blob storage
    - **`BlobStorageReceiver.csproj`**: Project file with required dependencies

- **`docker-compose.yml`**: Configuration for the Azure Storage Emulator

## Local Azure Storage Emulator

This project uses the [Azurite](https://github.com/Azure/Azurite) emulator for local development. This is the official Microsoft emulator that provides a local development experience similar to Azure Storage.

### Running the Emulator

1. Start the emulator using Docker Compose:

```powershell
docker-compose up -d
```

This will start the Azure Storage emulator using Docker Compose, exposing the following ports:
- Blob Service: 5050
- Queue Service: 10001
- Table Service: 10002

To stop the emulator, run:

```powershell
docker-compose down
```

## Getting Started

### 1. Start the Azure Storage Emulator

From the BlobStorage directory:
```powershell
docker-compose up -d
```

### 2. Run the Publisher

You can run the publisher in two ways:

#### Using npm (recommended)
From the project root directory:
```powershell
npm run trigger:blobstorage
```

#### Using dotnet directly
From the BlobStoragePublisher directory:
```powershell
dotnet run
```

The publisher will create a sample text file and upload it to the blob container.

### 3. Run the Receiver

You can run the receiver in two ways:

#### Using npm (recommended)
From the project root directory:
```powershell
npm run receive:blobstorage
```

#### Using dotnet directly
From the BlobStorageReceiver directory:
```powershell
dotnet run
```

The receiver will download all files from the blob container to a local "downloads" directory.

## Configuration

### Blob Storage Publisher

The publisher is configured to connect to the local Azure Storage emulator. The connection string in `Program.cs` is set to:

```csharp
string blobStorageConnectionString = "DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;BlobEndpoint=http://127.0.0.1:5050/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1";
```

### Blob Storage Receiver

The receiver uses the same connection string to connect to the local Azure Storage emulator.

## Development

To modify the file being uploaded, update the `fileContent` variable in `BlobStoragePublisher/Program.cs`:

```csharp
string fileContent = "Your custom content here";
```

To modify how files are downloaded, update the download logic in `BlobStorageReceiver/Program.cs`.

## Available npm Scripts

The project includes the following npm scripts:

- `npm run trigger:blobstorage`: Runs the Blob Storage publisher demo
- `npm run receive:blobstorage`: Runs the Blob Storage receiver demo

## Notes on the Azure Storage Emulator

- The emulator is official and provided by Microsoft
- It supports all Azure Storage services (Blob, Queue, Table)
- The emulator runs on the following ports by default:
  - Blob Service: 5050
  - Queue Service: 10001
  - Table Service: 10002
- Authentication is simplified in the emulator (using the default development storage account)
- Data is stored in memory and will be lost if the emulator is restarted
- The emulator supports all standard Azure Storage operations 