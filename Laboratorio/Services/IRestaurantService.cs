using Laboratorio.DTOs;
using Laboratorio.Entities;

namespace Laboratorio.Services
{
    public interface IRestaurantService
    {
        Task<int> CreateOrderAsync(CreateOrderDTO orderRequest, int empleadoId);
        Task<List<ComandaDTO>> GetPendingOrdersForEmployeeAsync(int empleadoId);
        Task<bool> UpdateOrderStatusToInPreparationAsync(int comandaId);
        Task<string> GetOrderPreparationTimeAsync(int ordenId);
        Task<List<OrdenInfoDTO>> GetOrderDetailsWithDelaysAsync();
        Task<List<ComandaDTO>> GetPendingProductsForEmployeeAsync(int empleadoId);
        Task<string> UpdateProductStatusAsync(int ordenId);
        Task<bool> UpdateMesaStatusForReadyOrdersAsync(int mesaId);
        Task<List<MesaEstadoDTO>> GetMesasWithStatusAsync();
        Task<bool> CobrarCuentaAsync(int ordenId, string metodoPago);
    }

}
