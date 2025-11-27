using KetabSara.DataLayer.Context;
using KetabSara.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace KetabSara.DataLayer.Repositories.Basket;

public class BasketRepository : IBasketRepository
{
    private readonly AppDbContext _context;

    public BasketRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Create(Models.Basket basket)
    {
        _context.Baskets.Add(basket);
        await _context.SaveChangesAsync();

    }

    public async Task Edit(Models.Basket basket)
    {
        var entity = await _context.Baskets.FirstOrDefaultAsync(x => x.Id == basket.Id);
        if (entity == null)
            return;
        entity.Id = basket.Id;
        entity.Address = basket.Address;
        entity.BasketItemsList = basket.BasketItemsList;
        entity.Status = basket.Status;
        entity.UserId = basket.UserId;
        entity.User = basket.User;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var entity = await _context.Baskets.FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null)
            return;
        _context.Baskets.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Models.Basket>> getAllBaskets()
    {
        return await _context.Baskets.ToListAsync();
    }

    public async Task<Models.Basket> findBasketBy(int id)
    {
        var entity = await _context.Baskets.FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null)
            return null;
        return entity;
    }
}