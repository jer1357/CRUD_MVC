using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD_MVC_Demo.Models;

namespace CRUD_MVC_Demo.Services
{
    public interface IShipperService
    {
        Task<IEnumerable<Shipper>> GetAllShippersAsync();

        Task<Shipper> GetShipperByIdAsync(int id);

        Task CreateShipperAsync(Shipper shipper);

        Task<bool> UpdateShipperAsync(Shipper shipper);

        Task DeleteShipperAsync(int id);
    }
}