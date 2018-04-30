using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WinsAPI.Models;
using WinsAPI.Services.Business;
using System.Collections;
using Newtonsoft.Json;

namespace WinsAPI.Controllers
{
    public class WinsController : ApiController
    {
        
        // GET: api/Wins
        public ArrayList Get()
        {
            WinApiBusinessService service = new WinApiBusinessService();
            return service.getWins();
        }

        // GET: api/Wins/5
        public WinModel Get(int id)
        {
            WinApiBusinessService service = new WinApiBusinessService();
            WinModel win = service.getWinById(id);
            return win;
        }

        // POST: api/Wins
        public void Post([FromBody]WinModel value)
        {
        }

        // PUT: api/Wins/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Wins/5
        public void Delete(int id)
        {
        }
    }
}
