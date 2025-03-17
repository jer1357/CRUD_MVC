using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD_MVC_Demo.Models;
using CRUD_MVC_Demo.Repositories;

namespace CRUD_MVC_Demo.Services
{
    public class ShipperService : IShipperService
    {
        private readonly IShipperRepository _shipperRepository;

        public ShipperService(IShipperRepository shipperRepository)
        {
            _shipperRepository = shipperRepository;
        }

        public async Task<IEnumerable<Shipper>> GetAllShippersAsync()
        {
            return await _shipperRepository.GetAllAsync();
        }

        public async Task<Shipper> GetShipperByIdAsync(int id)
        {
            return await _shipperRepository.GetByIdAsync(id);
        }

        public async Task CreateShipperAsync(Shipper shipper)
        {
            await _shipperRepository.AddAsync(shipper);
        }

        public async Task<bool> UpdateShipperAsync(Shipper shipper)
        {
            return await _shipperRepository.UpdateAsync(shipper);
        }

        public async Task DeleteShipperAsync(int id)
        {
            await _shipperRepository.DeleteAsync(id);
        }
    }
}