using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Data.Entities;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstrumentsController : ControllerBase
    {
        private readonly IInstrumentRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public InstrumentsController(IInstrumentRepository repository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet]
        public async Task<ActionResult<InstrumentModel[]>> Get()
        {
            try
            {
                var results = await _repository.GetAllInstrumentsAsync();

                return _mapper.Map<InstrumentModel[]>(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("code/{code}")]
        public async Task<ActionResult<InstrumentModel>> GetByCode(string code)
        {
            try
            {
                var result = await _repository.GetInstrumentAsync(code);

                if (result == null)
                {
                    return NotFound();
                }

                return _mapper.Map<InstrumentModel>(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("{type}")]
        public async Task<ActionResult<InstrumentModel[]>> GetByType(string type)
        {
            try
            {
                var result = await _repository.GetInstrumentsByTypeAsync(type);

                if (result == null)
                {
                    return NotFound();
                }

                return _mapper.Map<InstrumentModel[]>(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpPost]
        public async Task<ActionResult<InstrumentModel>> Post(InstrumentModel model)
        {
            try
            {
                var existing = await _repository.GetInstrumentAsync(model.Code);
                if (existing != null)
                {
                    return BadRequest("Code in use");
                }

                var location = _linkGenerator.GetPathByAction("Get",
                    "Instruments",
                    new { code = model.Code });

                if (string.IsNullOrWhiteSpace(location))
                {
                    return BadRequest("Could not use current name");
                }

                var instrument = _mapper.Map<Instrument>(model);
                _repository.Add(instrument);
                if (await _repository.SaveChangesAsync())
                {
                    return Created("", _mapper.Map<InstrumentModel>(instrument));
                }

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get the Instrument");
            }

            return BadRequest();
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            try
            {
                var instrumentToDelete = await _repository.GetInstrumentAsync(code);
                if (instrumentToDelete == null)
                {
                    return NotFound("Failed to find the instrument to delete");
                }

                _repository.Delete(instrumentToDelete);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Failed to delete instrument");
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
    }
}
