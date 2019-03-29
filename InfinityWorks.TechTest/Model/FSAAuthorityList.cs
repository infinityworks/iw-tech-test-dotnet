using System.Collections.Generic;

namespace InfinityWorks.TechTest.Model
{
    public class FSAAuthorityList {

        public List<FSAAuthority> Authorities { get; set; }

        public override string ToString()
        {
            return $"FSAAuthorityList[{nameof(Authorities)}={Authorities}]";
        }
    }
}
