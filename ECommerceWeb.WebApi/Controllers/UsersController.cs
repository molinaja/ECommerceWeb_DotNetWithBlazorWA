using ECommerceWeb.DataAccess;
using ECommerceWeb.Dto.Request;
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

namespace ECommerceWeb.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<EcommerseIdentity> _userManager;
        private readonly IConfiguration _configuration;
        public UsersController(UserManager<EcommerseIdentity> userManager, IConfiguration configuration)
        {

            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginDtoRequest request)
        {
            LoginDtoResponse loginDtoResponse = new LoginDtoResponse();

            var identity = new EcommerseIdentity()
            {

                UserName = request.UserName,
                Name = request.UserName,
                Email = "some@gmail.com",
                Address = "asdasd",
            };

            try
            {
                //var identity = await _userManager.FindByNameAsync(request.UserName);
                //if (identity == null)
                //{
                //    throw new Exception("The user or password are incorrect");
                //}

                //bool passCheck = await _userManager.CheckPasswordAsync(identity, request.Password);
                //if (!passCheck)
                //{
                //    throw new Exception("The user or password are incorrect");
                //}

                //test
                
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
                 );//encrypcion Algorit
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

                loginDtoResponse.Token = new JwtSecurityTokenHandler().WriteToken( token );
                loginDtoResponse.Namme = identity.Name;


                return Ok(loginDtoResponse);
            }
            catch (Exception)
            {
                return BadRequest();
            }


        }
    }
}
