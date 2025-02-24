namespace NGE.TechTest.Controllers;

using NGE.TechTest.Model;
using NGE.TechTest.Services;

[Route("api/")]
[ApiController]
public class RatingController(IFsaClient fSaClient) : Controller
{
    private readonly IFsaClient _fSaClient = fSaClient;

    /// <summary>
    /// Produces a list of authorities, for the select dropdown
    /// </summary>
    /// <returns>
    /// List of authorities
    /// </returns>
    [HttpGet]
    public async Task<JsonResult> GetAsync()
    {
        var fsaAuthorities = await _fSaClient.GetAuthorities();
        var authorityList = fsaAuthorities.Authorities.Select(authority => new Authority { Id = authority.LocalAuthorityId, Name = authority.Name });
        return Json(authorityList);
    }

    /// <summary>
    /// Produces the ratings for a specific authority for the table
    /// </summary>
    /// <param name="authorityId">The authority to calculate ratings for</param>
    /// <returns>
    /// The ratings to display
    /// </returns>
    [HttpGet("{authorityId}")]
    public JsonResult Get(int authorityId)
    {
        //This is just sample data to demonstrate the contract of the API
        var ratings = new List<AuthorityRatingItem>();
        if (authorityId == 1)
        {
            ratings.Add(new AuthorityRatingItem { Name = "5-star", Value = 22.41 });
            ratings.Add(new AuthorityRatingItem { Name = "4-star", Value = 43.13 });
            ratings.Add(new AuthorityRatingItem { Name = "3-star", Value = 12.97 });
            ratings.Add(new AuthorityRatingItem { Name = "2-star", Value = 1.54 });
            ratings.Add(new AuthorityRatingItem { Name = "1-star", Value = 17.84 });
            ratings.Add(new AuthorityRatingItem { Name = "Exempt", Value = 2.11 });
        }
        else
        {
            ratings.Add(new AuthorityRatingItem { Name = "5-star", Value = 50 });
            ratings.Add(new AuthorityRatingItem { Name = "4-star", Value = 0 });
            ratings.Add(new AuthorityRatingItem { Name = "3-star", Value = 0 });
            ratings.Add(new AuthorityRatingItem { Name = "2-star", Value = 0 });
            ratings.Add(new AuthorityRatingItem { Name = "1-star", Value = 25 });
            ratings.Add(new AuthorityRatingItem { Name = "Exempt", Value = 25 });
        }

        return Json(ratings);
    }
}