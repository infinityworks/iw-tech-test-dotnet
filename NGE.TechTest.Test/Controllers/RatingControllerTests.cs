using NGE.TechTest.Controllers;
using NGE.TechTest.Model;
using NGE.TechTest.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGE.TechTest.Test.Controllers
{
    class RatingControllerTests
    {
        [Test]
        public async Task GetAsync_ReturnsAllAuthorities()
        {
            // Arrange
            var authorityList = new FsaAuthorityList
            {
                Authorities = new List<FsaAuthority>
                {
                    new FsaAuthority { Name = "authority1", LocalAuthorityId = 1 },
                    new FsaAuthority { Name = "authority2", LocalAuthorityId = 2 }
                }
            };

            var fsaClient = new Mock<IFsaClient>();
            fsaClient.Setup(c => c.GetAuthorities()).ReturnsAsync(authorityList);
            var controller = new RatingController(fsaClient.Object);

            // Act
            var jsonResult = await controller.GetAsync();

            // Assert
            Assert.That(jsonResult.Value, Is.InstanceOf<IEnumerable<Authority>>());
            var authorities = ((IEnumerable<Authority>)jsonResult.Value).ToArray();
            Assert.That(authorities.Length, Is.EqualTo(2));
            Assert.That(authorities[0].Name, Is.EqualTo("authority1"));
            Assert.That(authorities[0].Id, Is.EqualTo(1));
            Assert.That(authorities[1].Name, Is.EqualTo("authority2"));
            Assert.That(authorities[1].Id, Is.EqualTo(2));
        }
    }
}
