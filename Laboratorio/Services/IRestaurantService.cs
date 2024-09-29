using Laboratorio.DTOs;
using Laboratorio.Entities;

namespace Laboratorio.Services
{
    public interface IRestaurantService
    {
        Task<bool> CreateOrderAsync(CreateOrderDTO orderRequest);
        Task<List<ComandaDTO>> GetPendingOrdersForEmployeeAsync(int empleadoId);
        Task<bool> UpdateOrderStatusToInPreparationAsync(int comandaId);
        Task<string> GetOrderPreparationTimeAsync(int mesaId, int ordenId);
        Task<List<OrdenInfoDTO>> GetOrderDetailsWithDelaysAsync();
        Task<List<ComandaDTO>> GetPendingProductsForEmployeeAsync(int empleadoId);
        Task<bool> UpdateProductStatusAsync(int comandaId, string estado);
        Task<bool> UpdateMesaStatusForReadyOrdersAsync(int mesaId);
        Task<List<MesaEstadoDTO>> GetMesasWithStatusAsync();
        Task<bool> CobrarCuentaAsync(int ordenId, string metodoPago);
    }

}
