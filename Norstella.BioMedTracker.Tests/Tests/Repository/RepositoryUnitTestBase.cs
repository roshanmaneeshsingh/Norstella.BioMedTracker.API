using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BioMedTracker.Repository;
using BioMedTracker.Repository.Interfaces;
using Moq;

namespace BioMedTracker.Test.Repository
{
    public abstract class RepositoryUnitTestBase
    {
        protected readonly IServiceCollection _services;
        protected ServiceProvider _serviceProvider;
        protected Mock<BioMedTrackerDbContext> MockContext;
        protected Mock<DatabaseFacade> _databaseMock;
        protected Mock<IBioMedTrackerRepository> MockBioMedTrackerBaseRepository;
        protected Mock<IConfiguration> MockIConfiguration;
        protected IBioMedTrackerRepository _clientBaseRepository;

        protected RepositoryUnitTestBase()
        {
            InitializeMocks();
            _services = new ServiceCollection();
            ConfigureServices(_services);
            _serviceProvider = _services.BuildServiceProvider();
            _clientBaseRepository = Resolve<IBioMedTrackerRepository>();
        }

        protected void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(p => MockContext.Object);
            services.AddScoped(cp => MockBioMedTrackerBaseRepository.Object);
            services.AddScoped<IBioMedTrackerRepository, BioMedTrackerRepository>();
        }
        protected virtual T Resolve<T>()
        {
            return (T)_serviceProvider.GetService(typeof(T));
        }
        private void InitializeMocks()
        {
            MockContext = new Mock<BioMedTrackerDbContext>();
            MockBioMedTrackerBaseRepository = new Mock<IBioMedTrackerRepository>();
            MockIConfiguration = new Mock<IConfiguration>();
        }
    }
}
