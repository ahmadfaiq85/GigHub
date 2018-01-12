using System.Security.Claims;
using System.Security.Principal;
using System.Web.Mvc;
using Moq;
using System.Web;

namespace GigHub.IntegrationTests.Extensions
{
    public static class ControllerExtensions
    {
        public static void MockCurrentUser(this Controller controller, string userId, string username)
        {
            var identity = new GenericIdentity(username);
            identity.AddClaim(
                new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", username));
            identity.AddClaim(
                new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", userId));

            var principal = new GenericPrincipal(identity, null);

            var mockHttpContext = new Mock<HttpContextBase>();
            mockHttpContext.SetupGet(c => c.User).Returns(principal);

            var mockControllercontext = new Mock<ControllerContext>();
            mockControllercontext.SetupGet(c => c.HttpContext).Returns(mockHttpContext.Object);

            controller.ControllerContext = mockControllercontext.Object; 
        }
    }
}
