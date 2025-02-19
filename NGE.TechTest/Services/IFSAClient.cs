namespace NGE.TechTest.Services;

using NGE.TechTest.Model;

public interface IFsaClient
{
    Task<FsaAuthorityList> GetAuthorities();
}