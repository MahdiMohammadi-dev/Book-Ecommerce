namespace KetabSara.DataLayer.Repositories.Book;

public interface IBookRepository
{
    Task Create(Models.Book book);
    Task Edit(Models.Book book);
    Task Delete(int id);
    Task<IEnumerable<Models.Book>> getAllBooks();
    Models.Book findBookBy(int id);
}