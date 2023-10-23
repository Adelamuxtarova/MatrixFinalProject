using Serilog.Core;
using Serilog.Events;

namespace FinalProjectMatrix
{
    public class RemoteIPEnricher : ILogEventEnricher
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public RemoteIPEnricher(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext is null)
            {
                return;
            }

#pragma warning disable CS8601 // Possible null reference assignment.
            var httpContextModel = new HttpContextModel
            {

                Method = httpContext.Request.Method,
                RemoteIPAddress = httpContext.Connection.RemoteIpAddress?.ToString() // Get client's IP address
            };
#pragma warning restore CS8601 // Possible null reference assignment.

            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("HttpContext", httpContextModel, true));
        }
    }
    public class HttpContextModel
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Method { get; init; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string RemoteIPAddress { get; init; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }

}