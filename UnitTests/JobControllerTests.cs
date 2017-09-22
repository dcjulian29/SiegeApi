using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
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
        public readonly JobContext _context;

        public JobControllerTests()
        {
            var builder = new DbContextOptionsBuilder<JobContext>()
                .UseInMemoryDatabase("SiegeApi");

            _context = new JobContext(builder.Options);
        }

        [Fact]
        public void Post_Should_SetJobStatusQueued_When_InitialluPosted()
        {
            // Arrange
            var job = new Job();
            job.AddUrl("http://localhost");

            var controller = new JobController(_context);

            // Act
            var id = controller.Post(job).Result;
            var storedJob = controller.Get(id).Result;

            // Assert
            Assert.Equal(JobStatus.Queued, storedJob.JobStatus);
        }

        [Fact]
        public void Post_Should_StoreJob_When_GivenAValidJob()
        {
            // Arrange
            var job = new Job();
            job.AddUrl("http://localhost");

            var controller = new JobController(_context);

            // Act
            var id = controller.Post(job).Result;
            var storedJob = controller.Get(id).Result;

            // Assert
            Assert.Equal(id, storedJob.Id);
        }
    }
}
