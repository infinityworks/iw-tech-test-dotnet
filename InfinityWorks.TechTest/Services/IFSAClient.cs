using InfinityWorks.TechTest.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfinityWorks.TechTest.Services
{
    public interface IFsaClient
    {
        Task<FsaAuthorityList> GetAuthorities();

        Task<IEnumerable<AuthorityRatingItem>> GetAuthorityRatingItems(int localAuthorityId);
    }
}