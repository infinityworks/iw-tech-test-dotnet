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
    }
}
