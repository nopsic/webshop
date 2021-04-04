using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class InstrumentsController : ControllerBase
    {
        public object Get()
        {
            return new { Name = "Tuba" };
        }
    }
}
