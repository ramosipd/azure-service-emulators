// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}

using System;
using Azure.Messaging;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace EventGridReceiver
{
    public class EventGridTriggerFunction
    {
        private readonly ILogger<EventGridTriggerFunction> _logger;

        public EventGridTriggerFunction(ILogger<EventGridTriggerFunction> logger)
        {
            _logger = logger;
        }

        [Function(nameof(EventGridTriggerFunction))]
        public void Run([EventGridTrigger] CloudEvent cloudEvent)
        {
            _logger.LogInformation("Event type: {type}, Event subject: {subject}", cloudEvent.Type, cloudEvent.Subject);
            _logger.LogInformation("Event data: {data}", cloudEvent.Data);
        }
    }
}
