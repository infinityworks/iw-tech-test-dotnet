using InfinityWorks.TechTest.Services;
using InfinityWorks.TechTest.Test.Data;
using InfinityWorks.TechTest.Test.Helpers;
using KellermanSoftware.CompareNetObjects;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace InfinityWorks.TechTest.Test.Services
{
    internal class FsaClientTests
    {
        [TestCase]
        public async Task GetAuthorities_ReturnsA_FsaAuthorityList()
        {
            // Arrange
            var expected = FsaClientTestData.GetAuthorityData();

            IFsaClient fsaClient = new FsaClient(
                MockHttpClientFactory.GetMockHttpClientFactory(
                    FsaClientTestData.AuthorityData).Object);

            // Act
            var actual = await fsaClient.GetAuthorities();

            // Assert
            actual.ShouldCompare(expected);
        }

        [TestCase]
        public async Task GetAuthorityRatingItems_ReturnsAListOf_AuthorityRatingItem()
        {
            // Arrange
            var localAuthorityId = 1;
            var expected = FsaClientTestData.GetExpectedRatingItemData();

            IFsaClient fsaClient = new FsaClient(
                MockHttpClientFactory.GetMockHttpClientFactory(
                    FsaClientTestData.FHRSEstablishments).Object);

            // Act
            var actual = await fsaClient.GetAuthorityRatingItems(localAuthorityId);

            // Assert
            actual.ToList().ShouldCompare(expected);
        }
    }
}