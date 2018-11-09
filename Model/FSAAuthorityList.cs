using System.Collections.Generic;
using System.Runtime.Serialization;

namespace InfinityWorks.TechTest.Controllers
{
    [DataContract]
    public class FSAAuthorityList {

        [DataMember(Name="authorities")]
        public List<FSAAuthority> AuthorityList { get; set; }

        public override string ToString()
        {
            return "FSAAuthorityList{" +
                    "fsaAuthorityList=" + this.AuthorityList +
                    '}';
        }
    }
}
