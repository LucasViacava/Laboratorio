using Laboratorio.DTOs;

namespace Laboratorio.Services
{
    public interface IRestaurantService
    {
        Task<bool> CreateOrderAsync(CreateOrderDTO orderRequest);
        Task<List<ComandaDTO>> GetPendingOrdersForEmployeeAsync(int empleadoId);
        Task<bool> UpdateOrderStatusToInPreparationAsync(int comandaId);
        Task<string> GetOrderPreparationTimeAsync(int mesaId, int ordenId);
        Task<List<OrdenInfoDTO>> GetOrderDetailsWithDelaysAsync();
    }

}
