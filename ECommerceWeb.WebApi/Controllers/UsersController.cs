using Azure;
using ECommerceWeb.DataAccess;
using ECommerceWeb.Dto;
using ECommerceWeb.Dto.Request;
using ECommerceWeb.Dto.Response;
using ECommerceWeb.Entities;
using ECommerceWeb.Repositories.Implementaciones;
using ECommerceWeb.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.SymbolStore;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Net;
using System.Security.Claims;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ECommerceWeb.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<EcommerseIdentity> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ICustomerRepository _customerRepository;

        public UsersController(UserManager<EcommerseIdentity> userManager, IConfiguration configuration, ICustomerRepository customerRepository)
        {

            _userManager = userManager;
            _configuration = configuration;
            _customerRepository = customerRepository;
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginDtoRequest request)
        {
            var response = new LoginDtoResponse();

            try
            {

                var identity = await _userManager.FindByNameAsync(request.UserName);
                if (identity == null)
                {
                    throw new Exception("The user or password are incorrect");
                }

                bool passCheck = await _userManager.CheckPasswordAsync(identity, request.Password);
                if (!passCheck)
                {
                    throw new Exception("The user or password are incorrect");
                }

                DateTime ExpirationDate = DateTime.Now.AddHours(1);

                //Create claims
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, identity.Name), 
                    new Claim(ClaimTypes.Email, identity.Email!),
                    new Claim(ClaimTypes.Expiration, ExpirationDate.ToString()),

                };

                //create jwt 
                SecurityKey key = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(
                        _configuration["Jwt:SecretKey"]!
                        )
                    );

                SigningCredentials credentials = new SigningCredentials(
                    key
                    , SecurityAlgorithms.HmacSha256
                 );//encrypcion algorithm

                JwtHeader header = new JwtHeader(credentials);

                JwtPayload payload = new JwtPayload(
                    _configuration["Jwt:Issuer"]
                    , _configuration["Jwt:Audience"]
                    , claims
                    , DateTime.Now
                    , ExpirationDate
                );

                JwtSecurityToken token = new JwtSecurityToken(
                    header, payload);

                response.Token = new JwtSecurityTokenHandler().WriteToken(token);
                response.Namme = identity.Name;
                response.success = true;

                
            }
            catch (Exception e)
            {
                response.msnError = e.Message;
                response.success = false;
                return BadRequest(response);
            }

            return Ok(response);

        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterUserDtoRequest request)
        {
            var response = new BaseResponse();
            try
            {
                var identity = new EcommerseIdentity
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    Name = request.Name + request.LastName,
                    Address = request.Address,
                    BirthDate = DateOnly.FromDateTime(request.BirthDate),
                    EmailConfirmed = true,

                };

                if (request.Password != request.ConfirmPassword)
                {
                    throw new Exception("The password and confirm password are not equal");
                }

                var result = await _userManager.CreateAsync(identity, request.Password);
                if (!result.Succeeded)
                {
                    var sb = new StringBuilder();
                    foreach (var item in result.Errors)
                    {
                        sb.AppendFormat("{0} ", item.Description);
                    }
                    string error = sb.ToString();
                    sb.Clear();

                    throw new Exception(error);
                }
                
                //if the usre registration was successfuk we asigned the role
                await _userManager.AddToRoleAsync(identity, Statics.ClientRole);

                //If the user registration was successful we create the client(customer)
                var client = new Customer
                {
                    Name = request.Name,
                    LastName = request.LastName,
                    Email = request.Email,
                    BirthDate = DateOnly.FromDateTime( request.BirthDate ),                        

                };

                await _customerRepository.AddAsync(client);              
                response.success = true;
                
                

            }
            catch (Exception e)
            {
                response.success = false;
                response.msnError = e.Message;
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
