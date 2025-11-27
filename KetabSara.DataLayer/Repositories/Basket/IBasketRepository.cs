using System.Linq.Expressions;

namespace KetabSara.DataLayer.Repositories.Basket
{
    public interface IBasketRepository
    {
        Task Create(Models.Basket basket);
        Task Edit(Models.Basket basket);
        Task Delete(int id);
        Task<IEnumerable<Models.Basket>> getAllBaskets();
        Task<Models.Basket> findBasketBy(int id);
    }
}
