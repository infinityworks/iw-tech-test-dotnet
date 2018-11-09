using System.Runtime.Serialization;

namespace InfinityWorks.TechTest.Controllers
{
    [DataContract]
    public class FSAAuthority
    {
        [DataMember(Name="LocalAuthorityId")]
        public int Id { get; set; }

        [DataMember(Name="Name")]
        public string Name { get; set; }

        public override string ToString()
        {
            return "FSAAuthority{" +
                    "id=" + this.Id +
                    ", name='" + this.Name + '\'' +
                    '}';
        }
    }
}
