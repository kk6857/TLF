using Castle.Core.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportForLondon.RoadStatusChecker;
using TransportForLondon.RoadStatusChecker.Model;
using TransportForLondon.RoadStatusChecker.Services;
using Xunit;

namespace TransportForLondon.RoadStatusCheckerE2E.Tests
{
    public class RoadStatusCheckerTests
    {
        private IServiceProvider CreateServiceProvider()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var apiSettings = configuration.GetSection("TflApiSettings").Get<TflApiSettings>();

            var services = new ServiceCollection();

            // Register services
            services.AddScoped<RoadInfoProvider>();
            services.AddSingleton(apiSettings);
            services.AddHttpClient<ITflApiService, TflApiService>();

            // Build the service provider
            return services.BuildServiceProvider();
        }

        [Fact]
        public async Task Main_SuccessfulExecution()
        {
            // Arrange
            var serviceProvider = CreateServiceProvider();

            // Act
            var exitCode = await ExecuteMainAsync(serviceProvider, new string[] { "A2" });

            // Assert
            Assert.Equal(0, exitCode);
        }

        [Fact]
        public async Task Main_RoadNotFoundExecution()
        {
            // Arrange
            var serviceProvider = CreateServiceProvider();

            // Act
            var exitCode = await ExecuteMainAsync(serviceProvider, new string[] { "A233" });

            // Assert
            Assert.Equal(1, exitCode);
        }

        private async Task<int> ExecuteMainAsync(IServiceProvider serviceProvider, string[] args)
        {
            using var scope = serviceProvider.CreateScope();
            var roadStatusChecker = scope.ServiceProvider.GetRequiredService<RoadInfoProvider>();

            return await roadStatusChecker.RunAsync(args);
        }
    }
}
