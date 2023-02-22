#A simple library for running background tasks at predetermined times

##Create sample reccuring task

```
    public class SendNewEmailsSchedulingService : IScheduledTask
    {
        private readonly ILogger<SendNewEmailsSchedulingService> _logger;
        private readonly IServiceProvider _serviceProvider;

        public SendNewEmailsSchedulingService(ILogger<SendNewEmailsSchedulingService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public string Schedule => "* * * * 1-5";
        public void ExecuteAsync(CancellationToken cancellationToken)
        {
            var serviceScopeFactory = _serviceProvider.GetRequiredService<IServiceScopeFactory>();
            using var scope = serviceScopeFactory.CreateScope();
            try
            {
                _logger.LogInformation($"Running {nameof(SendNewEmailsSchedulingService)}");
                var service = scope.ServiceProvider.GetRequiredService<ISendNewEmailsService>();
                service.SendPendingMessages();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }
    }
```

##Configuration for .NET 5.0

In file Startup.cs find method :
public void ConfigureServices(IServiceCollection services)

```
	...

    public void ConfigureServices(IServiceCollection services)
	services.AddSingleton<IScheduledTask, TimeRecordAutoApprovalSchedulingService>();
	
    ...
```