using InfinityWorks.TechTest.Model;
using InfinityWorks.TechTest.Test.Resources;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace InfinityWorks.TechTest.Test.Data
{
    internal static class FsaClientTestData
    {
        public static string AuthorityData => ResourceRetriever.ReadResource("Authorities").Result;
        public static string Establishments => ResourceRetriever.ReadResource("Establishments").Result;

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
                    Value = 33.33
                }
            };
        }
    }
}