namespace NGE.TechTest.Model;

/// <summary>
/// A single rating item.
/// </summary>
public class AuthorityRatingItem
{
    /// <summary>The name of the rating e.g. (One Star)</summary>
    public required string Name { get; set; }

    /// <summary>The distribution percentage of this rating</summary>
    public double Value { get; set; }

    public override string ToString()
    {
        return $"AuthorityRatingItem[{nameof(Name)}='{Name}', {nameof(Value)}={Value}]";
    }
}
