using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace InfinityWorks.TechTest.Controllers
{
    [Route("api/")]
    [ApiController]
    public class RatingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RatingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // GET api/values
        [HttpGet]
        public async Task<JsonResult> GetAsync()
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("x-api-version", "2");

            var serializer = new DataContractJsonSerializer(typeof(FSAAuthorityList));
            var streamTask = client.GetStreamAsync("http://api.ratings.food.gov.uk/Authorities");
            var fsaAuthorities = serializer.ReadObject(await streamTask) as FSAAuthorityList;

            var authorityList = new List<Authority>();
            foreach(FSAAuthority fsaAuthority in fsaAuthorities.AuthorityList)
            {
                authorityList.Add(new Authority(fsaAuthority.Id, fsaAuthority.Name));
            }

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
                ratings.Add(new AuthorityRatingItem("5-star", 22.41));
                ratings.Add(new AuthorityRatingItem("4-star", 43.13));
                ratings.Add(new AuthorityRatingItem("3-star", 12.97));
                ratings.Add(new AuthorityRatingItem("2-star", 1.54));
                ratings.Add(new AuthorityRatingItem("1-star", 17.84));
                ratings.Add(new AuthorityRatingItem("Exempt", 2.11));
            }
            else
            {
                ratings.Add(new AuthorityRatingItem("5-star", 50));
                ratings.Add(new AuthorityRatingItem("4-star", 0));
                ratings.Add(new AuthorityRatingItem("3-star", 0));
                ratings.Add(new AuthorityRatingItem("2-star", 0));
                ratings.Add(new AuthorityRatingItem("1-star", 25));
                ratings.Add(new AuthorityRatingItem("Exempt", 25));
            }

            return Json(ratings);
        }
    }
}