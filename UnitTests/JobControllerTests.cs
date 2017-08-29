using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Http.Internal;
using SiegeApi.Controllers;
using SiegeApi.Data;
using Xunit;

namespace UnitTests
{
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:ElementsMustBeDocumented",
        Justification = "Test Suites do not need XML Documentation.")]
    public class JobControllerTests
    {
        [Fact]
        public void Post_Should_StoreJob_When_GivenAValidJob()
        {
            // Arrange
            var job = new Job();
            job.AddUrl("http://localhost");

            var controller = new JobController();

            // Act
            var id = controller.Post(job);
            var storedJob = controller.Get().FirstOrDefault(x => x.Id == id);

            // Assert
            Assert.NotNull(storedJob);
        }
    }
}
