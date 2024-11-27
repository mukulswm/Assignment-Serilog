namespace ClassLibrary1
{
    using Serilog;

    public interface IDemoService
    {
        public void DoSomething();
    }

    public class DemoService : IDemoService
    {
        private readonly ILogger _logger;

        public DemoService()
        {
            _logger = Log.ForContext<IDemoService>();
        }

        public void DoSomething()
        {
            try
            {
                _logger.Information("Do something..");
                throw new InvalidOperationException("throw exception..");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred while doing something");
                throw;
            }
        }
    }
}