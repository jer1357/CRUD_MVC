using CRUD_MVC_Demo.Models;

public class ShipperRepository : IShipperRepository
{
    private readonly NorthwindContext _context;

    public ShipperRepository(NorthwindContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Shipper>> GetAllAsync()
    {
        return await _context.Shippers.ToListAsync();
    }

    public async Task<Shipper> GetByIdAsync(int id)
    {
        return await _context.Shippers.FindAsync(id);
    }

    public async Task AddAsync(Shipper shipper)
    {
        _context.Shippers.Add(shipper);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Shipper shipper)
    {
        _context.Shippers.Update(shipper);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var shipper = await _context.Shippers.FindAsync(id);
        if (shipper != null)
        {
            _context.Shippers.Remove(shipper);
            await _context.SaveChangesAsync();
        }
    }
}