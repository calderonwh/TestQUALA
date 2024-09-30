using BackendSucursales.DTOs;
namespace BackendSucursales.Services
{
    public interface ISucursalService
    {
        Task<List<SucursalDto>> GetSucursalesAsync();
        Task<SucursalDto> GetSucursalByIdAsync(int id);
        Task<SucursalDto> AddSucursalAsync(SucursalDto sucursalDto);
        Task<SucursalDto> UpdateSucursalAsync(SucursalDto sucursalDto);
        Task<bool> DeleteSucursalAsync(int id);
    }

}
