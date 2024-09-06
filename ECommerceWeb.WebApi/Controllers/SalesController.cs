using ECommerceWeb.Dto.Request;
using ECommerceWeb.Dto.Response;
using ECommerceWeb.Entities;
using ECommerceWeb.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Security.Claims;

namespace ECommerceWeb.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController(ISalesRepository salesRepository, ILogger<SalesController> logger, ICustomerRepository customerRepository) : Controller
    {
        private readonly ISalesRepository _salesRepository = salesRepository;
        private readonly ILogger<SalesController> _logger = logger;
        private readonly ICustomerRepository _customerRepository = customerRepository;

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(SaleDto request) {

            var response = new BaseResponse();
            try
            {
                var email = HttpContext.User.Claims.First(e => e.Type == ClaimTypes.Email).Value;
                var client = await _customerRepository.GetCustomerByEmail(email);
                if (client == null) { 
                    response.msnError = $"The user with email {email} is not a client";
                    return BadRequest(response);
                }
                var sale = new Sale { CustomerId = client.Id };
                sale.TotalSale = request.Total;
                sale.SaleDetail = request.SaleDetail.Select( 
                    p => new SaleDetail() {
                        ProductId = p.productID,
                        Quantity = p.queantity,
                        UnitPrice = p.Price, 
                        Total = p.Total,
                        Sale = sale
                    }
                ).ToList();
                await _salesRepository.CreateTransactionAsync();
                await _salesRepository.AddAsync( sale );
                await _salesRepository.ConfirmTransactionAsync();
                _logger.LogInformation("Transaction succesfully");
                response.success = true;
                return Ok(response);


            }
            catch (Exception ex)
            {
                response.msnError = "Error to preocess the transaction";
                await _salesRepository.ResetTransactionAsync();
                _logger.LogCritical(ex, "{msnError} {msn}", response.msnError, ex.Message);
                return BadRequest(response);
            }

        }
    }
}
