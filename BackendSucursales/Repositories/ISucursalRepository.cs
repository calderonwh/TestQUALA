using BackendSucursales.Entities;

namespace BackendSucursales.Repositories
{
    public interface ISucursalRepository
    {
        Task<List<Sucursale>> GetSucursalesAsync();
        Task<Sucursale> GetSucursalByIdAsync(int id);
        Task<Sucursale> AddSucursalAsync(Sucursale sucursal);
        Task<Sucursale> UpdateSucursalAsync(Sucursale sucursal);
        Task<bool> DeleteSucursalAsync(int id);
    }

}
