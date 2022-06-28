using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class webApiController : ApiController
    {
        DataAccess dAccess = new DataAccess();

        // GET api/webApi/5
        [Route("Api/GetAssets")]
        [HttpGet]
        public List<assets> GetAssets()
        {
            return dAccess.GetAssets();
        }
               
    }
}
