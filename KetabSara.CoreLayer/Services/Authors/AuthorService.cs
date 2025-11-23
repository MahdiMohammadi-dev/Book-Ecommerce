using System.IO.Pipes;
using KetabSara.CoreLayer.DTO.Authors;
using KetabSara.CoreLayer.Utilities;
using KetabSara.DataLayer.Models;
using KetabSara.DataLayer.Repositories.Author;

namespace KetabSara.CoreLayer.Services.Authors;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<OperationResult> Create(CreateAuthorDto authorDto)
    {
        var author = new Author()
        {
            Name = authorDto.Name,
            Family = authorDto.Family,

        };
        await _authorRepository.Create(author);
        return new OperationResult(true, "نویسنده اضافه شد");
    }

    public async Task<OperationResult> Edit(EditAuthorDto authorDto)
    {
        var dto = await _authorRepository.getAuthorById(authorDto.Id);
        if (dto == null)
            return new OperationResult(false, "نویسنده یافت نشد");
        dto.Id = authorDto.Id;
        dto.Name = authorDto.Name;
        dto.Family = authorDto.Family;
       await _authorRepository.Edit(dto);
        return new OperationResult(true, "تغییرات نویسنده انجام شد");
    }

    public async Task<OperationResult> Delete(int id)
    {
        var dto = await _authorRepository.getAuthorById(id);
        if (dto == null)
            return new OperationResult(false, "نویسنده یافت نشد");
       await _authorRepository.Delete(dto.Id);
        return new OperationResult(true, "نویسنده با موفقیت حذف شد");

    }

    public async Task<AuthorDto> GetAuthorById(int id)
    {
        var author = await _authorRepository.getAuthorById(id);
        if (author == null)
            return null;
        var findAuthor = new AuthorDto()
        {
            Name = author.Name,

            Family = author.Family
        };
        return findAuthor;
    }

    public async Task<IEnumerable<AuthorDto>> GetAuthors()
    {
        var searchAuthor =await _authorRepository.GetAllAuthor();
        var result = searchAuthor.Select(author => new AuthorDto()
        {
            Name = author.Name,
            Family = author.Family,
            Id = author.Id
        }).ToList();
        return result;
    }
}
