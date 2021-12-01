using InfinityWorks.TechTest.Services;
using InfinityWorks.TechTest.Test.Data;
using InfinityWorks.TechTest.Test.Helpers;
using KellermanSoftware.CompareNetObjects;
using NUnit.Framework;
using System.Threading.Tasks;

namespace InfinityWorks.TechTest.Test.Services
{
    internal class FsaClientTests
    {
        private CompareLogic comparer;

        [SetUp]
        public void Setup()
        {
            comparer = new CompareLogic();
        }

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
            Assert.IsTrue(comparer.Compare(expected, actual).AreEqual);
        }

        [TestCase]
        public async Task GetAuthorityRatingItems_ReturnsAListOf_AuthorityRatingItem()
        {
            // Arrange
            var localAuthorityId = 1;
            var expected = FsaClientTestData.GetExpectedRatingItemData();

            IFsaClient fsaClient = new FsaClient(
                MockHttpClientFactory.GetMockHttpClientFactory(
                    FsaClientTestData.Establishments).Object);

            // Act
            var actual = await fsaClient.GetAuthorityRatingItems(localAuthorityId);

            // Assert
            Assert.IsTrue(comparer.Compare(expected, actual).AreEqual);
        }
    }
}