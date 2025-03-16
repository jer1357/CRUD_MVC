using CRUD_MVC_Demo.Models;

public interface IShipperService
{
    Task<IEnumerable<Shipper>> GetAllShippersAsync();

    Task<Shipper> GetShipperByIdAsync(int id);

    Task AddShipperAsync(Shipper shipper);

    Task UpdateShipperAsync(Shipper shipper);

    Task DeleteShipperAsync(int id);
}