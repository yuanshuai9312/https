using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using OwinSelfhostSample.models;

namespace OwinSelfhostSample.controllers
{
    public class ValuesController : ApiController
    {
        //http://localhost:9000/api/Values/time
        //api/valuses/time
        [HttpGet]
        [HttpPost]
        public timeResult time()
        {
            return new timeResult()
            {
                id = DateTime.Now.Ticks,
                time = DateTime.Now,
                remark = DateTime.Now.ToString()
            };
        }

        //http://localhost:9000/api/Values/Sleep?sleep=1
        [HttpGet]
        [HttpPost]
        public dynamic Sleep(int sleep)
        {
            if (sleep < 1 || sleep>10)
                sleep = 1;
            sleep *= 1000;

            var begionTime = DateTime.Now.ToString("HH:mm:ss");
            System.Threading.Thread.Sleep(sleep);
            var endTime = DateTime.Now.ToString("HH:mm:ss");
            return new 
            {
                sleep = sleep,
                begionTime = begionTime,
                endTime = endTime
            };
        }

        //http://localhost:9000/api/Values/get
        // GET api/values 
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5 
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values 
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5 
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5 
        public void Delete(int id)
        {
        } 
    }
}
