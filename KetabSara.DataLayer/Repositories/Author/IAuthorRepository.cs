
namespace KetabSara.DataLayer.Repositories.Author;
    

    public interface IAuthorRepository
    {
        Task Create(Models.Author author);
        Task Edit(Models.Author author);
        Task<Models.Author> getAuthorById(int id);
        Task<IEnumerable<Models.Author>> GetAllAuthor();
        Task Delete(int id);
        

    }