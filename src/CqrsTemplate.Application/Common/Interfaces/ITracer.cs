using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace CqrsTemplate.Application.Common.Interfaces
{
    public interface ITracer
    {
        Activity? StartActivity(string name, ActivityKind kind = ActivityKind.Internal);
        void SetError(Exception ex, ILogger? logger = null);
    }
}