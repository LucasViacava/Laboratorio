using Laboratorio.DTOs;
using Laboratorio.Entities;
using Laboratorio.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder(CreateOrderDTO orderRequest)
        {
            var result = await _restaurantService.CreateOrderAsync(orderRequest);
            if (result)
            {
                return Ok("Orden creada exitosamente.");
            }
            return BadRequest("No se pudo crear la orden.");
        }

        [HttpGet("GetPendingOrders/{empleadoId}")]
        public async Task<IActionResult> GetPendingOrders(int empleadoId)
        {
            var comandasPendientes = await _restaurantService.GetPendingOrdersForEmployeeAsync(empleadoId);
            return Ok(comandasPendientes);
        }

        [HttpPut("SetOrderInPreparation/{comandaId}")]
        public async Task<IActionResult> SetOrderInPreparation(int comandaId)
        {
            var result = await _restaurantService.UpdateOrderStatusToInPreparationAsync(comandaId);
            if (result)
            {
                return Ok("El pedido ahora está en preparación.");
            }
            return BadRequest("No se pudo actualizar el estado del pedido.");
        }

        [HttpGet("GetPreparationTime/{mesaId}/{ordenId}")]
        public async Task<IActionResult> GetPreparationTime(int mesaId, int ordenId)
        {
            var tiempoTotal = await _restaurantService.GetOrderPreparationTimeAsync(mesaId, ordenId);
            return Ok(tiempoTotal);
        }
        [HttpGet("GetOrdersWithDelays")]
        public async Task<IActionResult> GetOrdersWithDelays()
        {
            var result = await _restaurantService.GetOrderDetailsWithDelaysAsync();
            return Ok(result);
        }

    }
}
