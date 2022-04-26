using InfinityWorks.TechTest.Model;
using InfinityWorks.TechTest.Test.Resources;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace InfinityWorks.TechTest.Test.Data
{
    internal static class FsaClientTestData
    {
        public static string AuthorityData => ResourceRetriever.ReadResource("Authorities").Result;
        public static string FHRSEstablishments => ResourceRetriever.ReadResource("Establishments").Result;

        public static FsaAuthorityList GetAuthorityData()
        {
            return JsonConvert.DeserializeObject<FsaAuthorityList>(AuthorityData);
        }

        public static IEnumerable<AuthorityRatingItem> GetExpectedRatingItemData()
        {
            return new List<AuthorityRatingItem>
            {
                new AuthorityRatingItem
                {
                    Name = "5",
                    Value = 54.93619879113499
                },
                new AuthorityRatingItem
                {
                    Name = "4",
                    Value = 16.118200134318332
                },
                new AuthorityRatingItem
                {
                    Name = "3",
                    Value = 6.178643384822028
                },
                new AuthorityRatingItem
                {
                    Name = "2",
                    Value = 1.0745466756212223
                },
                new AuthorityRatingItem
                {
                    Name = "1",
                    Value = 0.4029550033579583
                },
                new AuthorityRatingItem
                {
                    Name = "Exempt",
                    Value = 5.507051712558765
                }
            };
        }
    }
}