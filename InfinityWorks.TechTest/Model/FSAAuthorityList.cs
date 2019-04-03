using System.Collections.Generic;

namespace InfinityWorks.TechTest.Model
{
    public class FsaAuthorityList {

        public List<FsaAuthority> Authorities { get; set; }

        public override string ToString()
        {
            return $"FSAAuthorityList[{nameof(Authorities)}={Authorities}]";
        }
    }
}
