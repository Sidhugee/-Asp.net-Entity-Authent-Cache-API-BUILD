using AllInOneWithAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AllInOneWithAuthentication.Controllers
{
    [CacheFilter(TimeDuration = 30)]
    [RoutePrefix("api/employee")]
    [BasicAuthentication]
    public class EmployeeController : ApiController
    {
        
        Entities db = new Entities();

        //Get Data
        public IEnumerable<employee> GetValues()
        {
            var result = db.employees.ToList();
            return (result);
        }
       
    }
}
