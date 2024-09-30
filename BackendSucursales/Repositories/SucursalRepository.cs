using BackendSucursales.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace BackendSucursales.Repositories
{
    public class SucursalRepository : ISucursalRepository
    {
        private readonly DbaQualaContext _context;

        public SucursalRepository(DbaQualaContext context)
        {
            _context = context;
        }

        public async Task<List<Sucursale>> GetSucursalesAsync()
        {
            return await _context.Sucursales.ToListAsync();
        }

        public async Task<Sucursale> GetSucursalByIdAsync(int id)
        {
            return await _context.Sucursales.FindAsync(id);
        }

        public async Task<Sucursale> AddSucursalAsync(Sucursale sucursal)
        {
            _context.Sucursales.Add(sucursal);
            await _context.SaveChangesAsync();
            return sucursal;
        }

        public async Task<Sucursale> UpdateSucursalAsync(Sucursale sucursal)
        {
            _context.Entry(sucursal).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return sucursal;
        }

        public async Task<bool> DeleteSucursalAsync(int id)
        {
            var sucursal = await _context.Sucursales.FindAsync(id);
            if (sucursal == null)
                return false;

            _context.Sucursales.Remove(sucursal);
            await _context.SaveChangesAsync();
            return true;
        }
    }


}
