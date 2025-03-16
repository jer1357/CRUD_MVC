using CRUD_MVC_Demo.Models;

public class ShipperService : IShipperService
{
    private readonly IShipperRepository _repository;

    public ShipperService(IShipperRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Shipper>> GetAllShippersAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Shipper> GetShipperByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddShipperAsync(Shipper shipper)
    {
        await _repository.AddAsync(shipper);
    }

    public async Task UpdateShipperAsync(Shipper shipper)
    {
        await _repository.UpdateAsync(shipper);
    }

    public async Task DeleteShipperAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}