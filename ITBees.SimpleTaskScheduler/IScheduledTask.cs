using System.Threading;

namespace ITBees.SimpleTaskScheduler
{
    public interface IScheduledTask
    {
        string Schedule { get; }

        void ExecuteAsync(CancellationToken cancellationToken);
    }
}