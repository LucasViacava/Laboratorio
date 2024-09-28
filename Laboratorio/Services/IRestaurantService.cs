using Laboratorio.DTOs;

namespace Laboratorio.Services
{
    public interface IRestaurantService
    {
        Task<bool> CreateOrderAsync(CreateOrderDTO orderRequest);
    }
}
