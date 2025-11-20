using KetabSara.CoreLayer.DTO.Books;
using KetabSara.CoreLayer.Utilities;

namespace KetabSara.CoreLayer.Services.Books;

public interface IBookService
{
    Task<OperationResult> Create(CreateBookDto createBookDto);
    Task<OperationResult> Edit(EditBookDto editBookDto);
    Task<OperationResult> Delete(int id);
    Task<BookDto> GetBookById(int id);
    Task<IEnumerable<BookDto>> GetBooks();
}