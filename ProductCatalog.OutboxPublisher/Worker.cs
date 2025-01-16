//using Framework.OutboxPublisher;
using ProductCatalog.DomainContract.Event.Product;
using System.Reflection;
using System.Timers;

namespace ProductCatalog.OutboxPublisher
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

       // OutboxManager _outboxManager;
        public Worker(ILogger<Worker> logger/*, OutboxManager outboxManager*/)
        {
            _logger = logger;
          //  _outboxManager = outboxManager;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            //aTimer.Elapsed += new ElapsedEventHandler(CheckOutBox);
            //aTimer.Interval = 5000;
            //aTimer.Enabled = true;

            CheckOutBox(default(object), default(ElapsedEventArgs));
        }

        private void CheckOutBox(object? sender, ElapsedEventArgs e)
        {
            var contractAssembies = new Assembly[] { typeof(ProductCreatedEvent).Assembly };
          //  _outboxManager.Start(contractAssembies);
        }
    }
}