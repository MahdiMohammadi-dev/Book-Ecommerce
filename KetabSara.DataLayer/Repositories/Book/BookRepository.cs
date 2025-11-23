using KetabSara.DataLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace KetabSara.DataLayer.Repositories.Book;

    public class BookRepository:IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Models.Book book)
        {
            var entity = book;
           _context.Books.Add(entity);
           await _context.SaveChangesAsync();
        }

        public async Task Edit(Models.Book book)
        {
            var entity = _context.Books.FirstOrDefault(x => x.Id == book.Id);
            if (entity == null)
                return;
            entity.Title = book.Title;
            entity.Description = book.Description;
            entity.Price = book.Price;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = _context.Books.FirstOrDefault(x => x.Id == id);
            if (entity == null)
                return;
            _context.Books.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Models.Book>> getAllBooks()
        {
            return await _context.Books.Include(b => b.Author).ToListAsync();
        }

        public async Task<Models.Book> findBookBy(int id)
        {
            var entity = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                return null;
            return entity;
        }
    }
   