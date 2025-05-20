# EventGrid Project

## Scripts
- `emulator:eventgrid:start`: Start EventGrid emulator using Docker Compose.
- `emulator:eventgrid:stop`: Stop EventGrid emulator using Docker Compose.
- `start:eventgrid`: Run the EventGrid project using Azure Functions (via func start).
- `trigger:eventgrid`: Trigger EventGrid events using .NET.

example:
```bash
npm run start:eventgrid
```

note: ensure to run the emulator first.

## Dependencies
- Azure Functions Core Tools
- .NET runtime 
- Docker Desktop 

## Additional Information
- [DockerHub](https://hub.docker.com/r/workleap/eventgridemulator)
- [Github](https://github.com/workleap/wl-eventgrid-emulator)
