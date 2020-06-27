using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model_Classes.Model;

namespace My_API.Controllers
{
    [Route("x/[controller]")]
    [ApiController]
    public class GetTripDetailsController : ControllerBase
    {
        private TripDetailAPIClass _myclass;

        public GetTripDetailsController(TripDetailAPIClass MyClass)
        {
            _myclass = MyClass;
        }
        [HttpGet]
        public IEnumerable<TripDetails> Get()
        {
            IEnumerable<TripDetails> list = _myclass.GetDetails();
            return list;

        }
    }
}
