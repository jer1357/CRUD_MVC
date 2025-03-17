using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD_MVC_Demo.Models;

namespace CRUD_MVC_Demo.Repositories
{
    public interface IShipperRepository
    {
        Task<IEnumerable<Shipper>> GetAllAsync();

        Task<Shipper> GetByIdAsync(int id);

        Task AddAsync(Shipper shipper);

        Task<bool> UpdateAsync(Shipper shipper);

        Task DeleteAsync(int id);
    }
}