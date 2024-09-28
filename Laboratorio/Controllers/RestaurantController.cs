using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Laboratorio.DTOs;
using Laboratorio.Services;

namespace Laboratorio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpPost("CreateOrderWithDetails")]
        public async Task<IActionResult> CreateOrderWithDetails([FromBody] CreateOrderDTO orderRequest)
        {
            try
            {
                var response = await _restaurantService.CreateOrderAsync(orderRequest);
                if (response)
                    return Ok("Orden y comanda creadas con éxito");

                return BadRequest("No se pudo crear la orden y la comanda");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
