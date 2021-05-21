using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Common;
using WebAPI.Data;
using WebAPI.Data.Entities;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IInstrumentRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        private readonly IConfiguration _configuration;

        public CustomersController(IInstrumentRepository repository, IMapper mapper, LinkGenerator linkGenerator, IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
            _configuration = configuration;
        }

        [HttpGet, Authorize]
        public IEnumerable<string> Get()
        {
            return new string[] { "Test Elek", "Still Works" };
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] LoginModel user)
        {
            var userData = await _repository.GetRegisteredUserAsync(user.Email);

            if (userData == null)
            {
                return NotFound("Failed to find the user with this email and password");
            }

            var decryptedPassword = CommonMethods.DecryptPassword(userData.Password);

            if (user.Email == userData.Email && user.Password == decryptedPassword)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["ApplicationSettings:JWT_Secret"].ToString()));
                var signingCreditials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                    issuer: _configuration["ApplicationSettings:Server_URL"].ToString(),
                    audience: _configuration["ApplicationSettings:Server_URL"].ToString(),
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: signingCreditials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString });
            }

            return Unauthorized();
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<UserDataModel>> GetByEmail(string email)
        {
            try
            {
                var result = await _repository.GetRegisteredUserAsync(email);

                if (result == null)
                {
                    return NotFound();
                }

                return _mapper.Map<UserDataModel>(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Post(UserDataModel model)
        {
            try
            {
                var existing = await _repository.GetRegisteredUserAsync(model.Email);
                if (existing != null)
                {
                    return BadRequest("Email in use");
                }

                var location = _linkGenerator.GetPathByAction("GetByEmail",
                    "Customers",
                    new { email = model.Email });

                if (string.IsNullOrWhiteSpace(location))
                {
                    return BadRequest("Could not use current email");
                }

                var userData = _mapper.Map<UserData>(model);

                var plainText = userData.Password;

                var encryptedPassword = CommonMethods.EncryptPassword(plainText);

                userData.Password = encryptedPassword;

                _repository.Add(userData);
                if (await _repository.SaveChangesAsync())
                {
                    return Created("", _mapper.Map<UserDataModel>(userData));
                }

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get the user");
            }

            return BadRequest();
        }

        [HttpDelete("{email}"), Authorize]
        public async Task<IActionResult> Delete(string email)
        {
            try
            {
                var userDataToDelete = await _repository.GetRegisteredUserAsync(email);
                if (userDataToDelete == null)
                {
                    return NotFound("Failed to find the user to delete");
                }

                _repository.Delete(userDataToDelete);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Failed to delete user");
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
    }
}
