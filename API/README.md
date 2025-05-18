# API Demo with WireMock

This project demonstrates a simple API emulation using WireMock and a .NET console application to simulate GET and POST requests.

## Overview

The project consists of two main components:

1. **WireMock Emulator**: A lightweight HTTP server for mocking API endpoints.
2. **APIPublisher**: A .NET console application that simulates GET and POST requests to the WireMock emulator.

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/products/docker-desktop/) (for running the WireMock emulator)

## Project Structure

- **`docker-compose.yml`**: Configuration for running the WireMock emulator.
- **`Emulator/stubs.json`**: WireMock stubs defining GET and POST endpoints with dummy responses.
- **`APIPublisher/Program.cs`**: Console application to simulate API requests.

## Getting Started

### 1. Start the WireMock Emulator

Run the following command from the `API` directory to start the WireMock emulator:

```powershell
docker-compose up
```

This will start the emulator on `http://localhost:5000`.

### 2. Run the Console Application

Navigate to the `APIPublisher` directory and run the console application:

```powershell
dotnet run
```

The application will:
- Send a GET request to `/api/resource`.
- Send a POST request to `/api/resource` with a JSON payload.

### 3. Verify the Responses

You should see the following responses in the console output:

- **GET Response**:
  ```json
  {
    "message": "GET response from WireMock"
  }
  ```

- **POST Response**:
  ```json
  {
    "message": "POST response from WireMock"
  }
  ```

## Notes

- The WireMock emulator is configured to listen on port 5000.
- The `stubs.json` file defines the API endpoints and their responses.