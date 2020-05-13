using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
namespace WebApi
{
   public class HomeController:ApiController
    {
        [HttpGet]
        public List<People> GetPeoples()
        {
            List<People> peoples = new List<People>();
            peoples.Add(new People() { Id = 01, Name = "张三", Age = "18", ClassId = "001" });
            peoples.Add(new People() { Id = 02, Name = "李四", Age = "18", ClassId = "001" });
            peoples.Add(new People() { Id = 03, Name = "王二", Age = "19", ClassId = "003" });
            peoples.Add(new People() { Id = 04, Name = "麻子", Age = "20", ClassId = "002" });
            return peoples;
        }

        [HttpPost]
        public void PostPeople(People people)
        {
            Console.WriteLine("调用修改成功！"+people.Name); 
        }
    }
}
