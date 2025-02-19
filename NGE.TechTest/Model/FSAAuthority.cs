namespace NGE.TechTest.Model;

public class FsaAuthority
{
    public int LocalAuthorityId { get; set; }

    public required string Name { get; set; }

    public override string ToString()
    {
        return $"FSAAuthority[id={LocalAuthorityId}, name='{Name}']";
    }
}