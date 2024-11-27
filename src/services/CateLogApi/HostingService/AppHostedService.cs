
using CateLogApi.Context;

namespace CateLogApi.HostingService
{
    public class AppHostedService : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            CatelogDbSeed.Seed();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
