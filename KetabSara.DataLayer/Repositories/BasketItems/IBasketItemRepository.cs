using KetabSara.DataLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace KetabSara.DataLayer.Repositories.BasketItems
{
    public interface IBasketItemRepository
    {
        Task<IEnumerable<Models.BasketItems>> GetAllBasketItems();

        Task Create(Models.BasketItems basketItems);
        Task Delete(int id);
    }

    public class BasketItemRepository : IBasketItemRepository
    {
        private readonly AppDbContext _context;

        public BasketItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Models.BasketItems>> GetAllBasketItems()
        {
            return await _context.BasketItems.ToListAsync();
        }

        public async Task Create(Models.BasketItems basketItems)
        {
             _context.BasketItems.Add(basketItems);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.BasketItems.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                return;
            _context.BasketItems.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
