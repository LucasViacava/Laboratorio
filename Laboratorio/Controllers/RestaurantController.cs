using Laboratorio.DTOs;
using Laboratorio.Entities;
using Laboratorio.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService ?? throw new ArgumentNullException(nameof(restaurantService));
        }

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder(CreateOrderDTO orderRequest)
        {
            if (orderRequest == null)
                return new JsonResult(new { error = "La solicitud de orden no puede ser nula." });

            var result = await _restaurantService.CreateOrderAsync(orderRequest);
            if (result != null)
            {
                return new JsonResult (new { message = $"Orden {result} creada exitosamente.", orderId = result });
            }
            return new JsonResult(new { error = "No se pudo crear la orden." });
        }

        [HttpGet("GetPendingOrders/{empleadoId}")]
        public async Task<IActionResult> GetPendingOrders(int? empleadoId)
        {
            if (empleadoId == null)
                return new JsonResult(new { error = "El ID del empleado no puede ser nulo." });

            var comandasPendientes = await _restaurantService.GetPendingOrdersForEmployeeAsync(empleadoId.Value);
            return comandasPendientes != null ? new JsonResult(comandasPendientes) : NotFound();
        }

        [HttpPut("SetOrderInPreparation/{comandaId}")]
        public async Task<IActionResult> SetOrderInPreparation(int? comandaId)
        {
            if (comandaId == null)
                return new JsonResult(new { error = "El ID de la comanda no puede ser nulo." });

            var result = await _restaurantService.UpdateOrderStatusToInPreparationAsync(comandaId.Value);
            return result ? new JsonResult("El pedido ahora está en preparación.") : new JsonResult("No se pudo actualizar el estado del pedido.");
        }

        [HttpGet("GetPreparationTime/{mesaId}/{ordenId}")]
        public async Task<IActionResult> GetPreparationTime(int mesaId, int ordenId)
        {
            var tiempoTotal = await _restaurantService.GetOrderPreparationTimeAsync(mesaId, ordenId);
            return tiempoTotal != null ? new JsonResult(tiempoTotal) : new JsonResult(new
            {
                error = "Tiempo de preparación no encontrado."
            });
        }

        [HttpGet("GetOrdersWithDelays")]
        public async Task<IActionResult> GetOrdersWithDelays()
        {
            var result = await _restaurantService.GetOrderDetailsWithDelaysAsync();
            return result != null ? new JsonResult(result) : new JsonResult(new
            {
                error = "No se encontraron órdenes con retrasos."
            });
        }

        [HttpGet("GetPendingProductsForEmployee/{empleadoId}")]
        public async Task<IActionResult> GetPendingProductsForEmployee(int? empleadoId)
        {
            if (empleadoId == null)
                return new JsonResult(new { error = "El ID del empleado no puede ser nulo." });

            var productosPendientes = await _restaurantService.GetPendingProductsForEmployeeAsync(empleadoId.Value);
            if (productosPendientes == null || !productosPendientes.Any())
            {
                return new JsonResult(new
                {
                    error = $"No se encontraron productos pendientes para el empleado con ID {empleadoId}."
                });
            }

            return new JsonResult(productosPendientes);
        }

        [HttpPut("UpdateOrdenStatus/{ordenId}")]
        public async Task<IActionResult> UpdateProductStatus(int? ordenId)
        {
            if (ordenId == null)
                return new JsonResult(new { error = "El ID de la orden no puede ser nulo." });

            var result = await _restaurantService.UpdateProductStatusAsync(ordenId.Value);
            return result ? new JsonResult($"El estado de la orden con ID {ordenId} se actualizó a 'En Preparación'.") : new JsonResult(500, "No se pudo actualizar el estado del producto.");
        }

        [HttpPost("UpdateMesaStatus/{mesaId}")]
        public async Task<IActionResult> UpdateMesaStatus(int? mesaId)
        {
            if (mesaId == null)
                return new JsonResult(new { error = "El ID de la mesa no puede ser nulo." });

            try
            {
                var result = await _restaurantService.UpdateMesaStatusForReadyOrdersAsync(mesaId.Value);
                return result ? new JsonResult("El estado de las órdenes se ha actualizado a 'Finalizado' correctamente.") : new JsonResult("No se pudieron actualizar los estados de las órdenes.");
            }
            catch (Exception ex)
            {
                return new JsonResult(new { error = ex.Message });
            }
        }

        [HttpGet("GetMesasWithStatus")]
        public async Task<IActionResult> GetMesasWithStatus()
        {
            try
            {
                var mesasConEstado = await _restaurantService.GetMesasWithStatusAsync();
                return mesasConEstado != null ? new JsonResult(mesasConEstado) : new JsonResult(new
                {
                    error = "No se encontraron mesas con estados."
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { error = ex.Message });
            }
        }

        [HttpPost("CobrarCuenta")]
        public async Task<IActionResult> CobrarCuenta([FromQuery] int? ordenId, [FromQuery] string metodoPago)
        {
            if (ordenId == null || string.IsNullOrEmpty(metodoPago))
                return new JsonResult(new { error = "El ID de la orden y el método de pago no pueden ser nulos o vacíos." });

            try
            {
                var result = await _restaurantService.CobrarCuentaAsync(ordenId.Value, metodoPago);
                return result ? new JsonResult("La cuenta ha sido cobrada exitosamente y la orden se ha finalizado.") : new JsonResult ("No se pudo procesar el cobro.");
            }
            catch (Exception ex)
            {
                return new JsonResult(new { error = ex.Message });
            }
        }
    }
}
