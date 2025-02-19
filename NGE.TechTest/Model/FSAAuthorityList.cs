namespace NGE.TechTest.Model;

using System.Text.Json.Serialization;

public class FsaAuthorityList
{

    [JsonPropertyName("authorities")]
    public required List<FsaAuthority> Authorities { get; set; }

    public override string ToString()
    {
        return $"FSAAuthorityList[{nameof(Authorities)}={Authorities}]";
    }
}
