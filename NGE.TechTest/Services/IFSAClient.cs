using NGE.TechTest.Model;

namespace NGE.TechTest.Services
{
    public interface IFsaClient
    {
        Task<FsaAuthorityList> GetAuthorities();
    }
}