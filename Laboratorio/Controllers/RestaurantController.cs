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
        [HttpGet("GetPendingProductsForEmployee/{empleadoId}")]
        public async Task<IActionResult> GetPendingProductsForEmployee(int empleadoId)
        {
            var productosPendientes = await _restaurantService.GetPendingProductsForEmployeeAsync(empleadoId);
            if (productosPendientes == null || !productosPendientes.Any())
            {
                return NotFound($"No se encontraron productos pendientes para el empleado con ID {empleadoId}.");
            }

            return Ok(productosPendientes);
        }

        [HttpPut("UpdateProductStatus/{comandaId}")]
        public async Task<IActionResult> UpdateProductStatus(int comandaId, [FromBody] string estado)
        {
            if (string.IsNullOrEmpty(estado))
            {
                return BadRequest("El estado no puede estar vacío.");
            }

            var result = await _restaurantService.UpdateProductStatusAsync(comandaId, estado);
            if (!result)
            {
                return StatusCode(500, "No se pudo actualizar el estado del producto.");
            }

            return Ok($"El estado del producto con comanda ID {comandaId} se actualizó a '{estado}'.");
        }
        [HttpPost("UpdateMesaStatus/{mesaId}")]
        public async Task<IActionResult> UpdateMesaStatus(int mesaId)
        {
            try
            {
                var result = await _restaurantService.UpdateMesaStatusForReadyOrdersAsync(mesaId);
                if (!result)
                {
                    return BadRequest("No se pudieron actualizar los estados de las órdenes.");
                }
                return Ok("El estado de las órdenes se ha actualizado a 'Finalizado' correctamente.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
