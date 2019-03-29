using InfinityWorks.TechTest.Controllers;
using InfinityWorks.TechTest.Model;
using InfinityWorks.TechTest.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfinityWorks.TechTest.Test.Controllers
{
    class RatingControllerTests
    {
        [Test]
        public async Task GetAsync_ReturnsAllAuthorities()
        {
            // Arrange
            var authorityList = new FSAAuthorityList();
            authorityList.Authorities = new List<FSAAuthority>
            {
                new FSAAuthority { Name = "authority1", LocalAuthorityId = 1 },
                new FSAAuthority { Name = "authority2", LocalAuthorityId = 2 }
            };

            var fsaClient = new Mock<IFSAClient>();
            fsaClient.Setup(c => c.GetAuthorities()).ReturnsAsync(authorityList);
            var controller = new RatingController(fsaClient.Object);

            // Act
            var jsonResult = await controller.GetAsync();

            // Assert
            Assert.IsInstanceOf<IEnumerable<Authority>>(jsonResult.Value);
            var authorities = (jsonResult.Value as IEnumerable<Authority>).ToArray();
            Assert.AreEqual(authorities.Length, 2);
            Assert.AreEqual(authorities[0].Name, "authority1");
            Assert.AreEqual(authorities[0].Id, 1);
            Assert.AreEqual(authorities[1].Name, "authority2");
            Assert.AreEqual(authorities[1].Id, 2);
        }
    }
}
