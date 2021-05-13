using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Data.Entities;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IInstrumentRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        private readonly IConfiguration _configuration;

        public OrdersController(IInstrumentRepository repository, IMapper mapper, LinkGenerator linkGenerator, IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("{email}/{numberOfInstruments}")]
        public async Task<ActionResult<Order[]>> Post([FromRoute] string email, [FromRoute] int numberOfInstruments, [FromBody] dynamic data)
        {
            try
            {
                List<Order> orders = new List<Order>();
                List<Instrument> instruments = new List<Instrument>();

                var user = await _repository.GetRegisteredUserAsync(email);

                if (user == null)
                {
                    return NotFound();
                }

                for (int i = 0;  i < numberOfInstruments; i++)
                {
                    instruments.Add(JsonConvert.DeserializeObject<Instrument>(data[i].ToString()));
                }

                string addressData = data[numberOfInstruments].ToString();

               var splittedData = addressData.Split(";");

                for (int i = 0; i < instruments.Count; i++)
                {
                    Order order = new Order();
                    order.FirstName = user.FirstName;
                    order.LastName = user.LastName;
                    order.Email = user.Email;
                    order.InstrumentName = instruments[i].Name;
                    order.Code = instruments[i].Code;
                    order.Price = instruments[i].Price;
                    order.Quantity = instruments[i].Quantity;
                    order.BillingCity = splittedData[0];
                    order.BillingState = splittedData[1];
                    order.BillingPostalCode = splittedData[2];
                    order.BillingAddress = splittedData[3];
                    order.Date = DateTime.Now;

                    orders.Add(order);
                }

                foreach (var item in orders)
                {
                    _repository.Add(item);
                }

                if (await _repository.SaveChangesAsync())
                {
                    return Created("", _mapper.Map<OrderModel[]>(orders));
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to save the orders");
            }

            return BadRequest();
        }
    }
}
