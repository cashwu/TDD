using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SeleniumSample.Controllers
{
    public class EchoController : ApiController
    {
        // GET: api/Echo
        public string Get()
        {
            return "Merry Xmas";
        }
    }
}