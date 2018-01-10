using Microsoft.VisualStudio.TestTools.UnitTesting;
using GigHub.Controllers.Api;
using GigHub.Tests.Extensions;
using Moq;
using GigHub.Core;
using GigHub.Core.Repositories;
using FluentAssertions;
using System.Web.Http.Results;

namespace GigHub.Tests.Controllers.Api
{
    [TestClass]
    public class GigsControllerTests
    {
        private GigHub.Controllers.Api.GigsController _controller;
        public GigsControllerTests()
        {
            var mockRepository = new Mock<IGigRepository>();

            var mockUoW = new Mock<IUnitOfWork>();

            mockUoW.SetupGet(u => u.Gigs).Returns(mockRepository.Object);

            _controller = new GigsController(mockUoW.Object);
            _controller.MockCurrentUser("1", "user1@domain.com"); 
        }
        
        [TestMethod]
        public void Cancel_NoGigWithGivenIdExists_ShouldReturnNotFound()
        {
            var result = _controller.Cancel(1);
            result.Should().BeOfType<NotFoundResult>();
        }
    }
}
