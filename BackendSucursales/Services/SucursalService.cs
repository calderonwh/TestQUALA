using BackendSucursales.Entities;
using BackendSucursales.Repositories;
using BackendSucursales.DTOs;
using AutoMapper;

namespace BackendSucursales.Services
{
    public class SucursalService : ISucursalService
    {
        private readonly ISucursalRepository _sucursalRepository;
        private readonly IMapper _mapper;

        public SucursalService(ISucursalRepository sucursalRepository, IMapper mapper)
        {
            _sucursalRepository = sucursalRepository;
            _mapper = mapper;
        }

        public async Task<List<SucursalDto>> GetSucursalesAsync()
        {
            var sucursales = await _sucursalRepository.GetSucursalesAsync();
            return _mapper.Map<List<SucursalDto>>(sucursales);
        }

        public async Task<SucursalDto> GetSucursalByIdAsync(int id)
        {
            var sucursal = await _sucursalRepository.GetSucursalByIdAsync(id);
            return _mapper.Map<SucursalDto>(sucursal);
        }

        public async Task<SucursalDto> AddSucursalAsync(SucursalDto sucursalDto)
        {
            var sucursal = _mapper.Map<Sucursale>(sucursalDto);
            var newSucursal = await _sucursalRepository.AddSucursalAsync(sucursal);
            return _mapper.Map<SucursalDto>(newSucursal);
        }

        public async Task<SucursalDto> UpdateSucursalAsync(SucursalDto sucursalDto)
        {
            var sucursal = _mapper.Map<Sucursale>(sucursalDto);
            var updatedSucursal = await _sucursalRepository.UpdateSucursalAsync(sucursal);
            return _mapper.Map<SucursalDto>(updatedSucursal);
        }

        public async Task<bool> DeleteSucursalAsync(int id)
        {
            return await _sucursalRepository.DeleteSucursalAsync(id);
        }
    }

}
