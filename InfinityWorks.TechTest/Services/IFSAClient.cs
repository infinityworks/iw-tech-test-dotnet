using InfinityWorks.TechTest.Model;
using System.Threading.Tasks;

namespace InfinityWorks.TechTest.Services
{
    public interface IFsaClient
    {
        Task<FsaAuthorityList> GetAuthorities();
    }
}