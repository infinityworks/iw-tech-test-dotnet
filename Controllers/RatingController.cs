using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace InfinityWorks.TechTest.Controllers
{
    [Route("api/")]
    [ApiController]
    public class RatingController : Controller
    {
        // GET api/values
        [HttpGet]
        public JsonResult Get()
        {
            var authorityList = new List<Authority>();
            var dummyAuthority = new Authority(999, "My dummy authority");
            authorityList.Add(dummyAuthority);
            return Json(authorityList);
        }
    }
}
