using KetabSara.DataLayer.Context;
using KetabSara.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace KetabSara.DataLayer.Repositories.Author;

public class AuthorRepository : IAuthorRepository
{
    private readonly AppDbContext _context;

    public AuthorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Create(Models.Author author)
    {
        var model = author;
        _context.Authors.Add(model);
        await _context.SaveChangesAsync();
    }

    public async Task Edit(Models.Author author)
    {
        var entity = await _context.Authors.FindAsync(author.Id);
        if (entity == null)
            return;
        entity.Name = author.Name;
        entity.Family = author.Family;
        await _context.SaveChangesAsync();
    }

    public async Task<Models.Author> getAuthorById(int id)
    {
        var entity =await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null)
            return null;
        var model = new Models.Author()
        {
            Name = entity.Name,
            Family = entity.Family
        };
        return model;
    }

    public async Task<IEnumerable<Models.Author>> GetAllAuthor()
    {
        return await _context.Authors.ToListAsync();
    }

    public async Task Delete(int id)
    {
        var entity = _context.Authors.FirstOrDefault(x => x.Id == id);
        if (entity == null)
            return;

        _context.Authors.Remove(entity);

        await _context.SaveChangesAsync();
    }
}