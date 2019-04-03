namespace InfinityWorks.TechTest.Model
{
    public class FsaAuthority
    {
        public int LocalAuthorityId { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"FSAAuthority[id={LocalAuthorityId}, name='{Name}']";
        }
    }
}
