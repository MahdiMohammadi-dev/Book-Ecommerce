using KetabSara.CoreLayer.DTO.Books;
using KetabSara.CoreLayer.Utilities;
using KetabSara.DataLayer.Models;
using KetabSara.DataLayer.Repositories.Book;

namespace KetabSara.CoreLayer.Services.Books;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<OperationResult> Create(CreateBookDto createBookDto)
    {
        var bookDto = new Book()
        {
            Title = createBookDto.Title,
            Description = createBookDto.Description,
            Price = createBookDto.Price,
        };
        await _bookRepository.Create(bookDto);
        return new OperationResult(true, "کتاب با موفقیت اضافه شد");
    }

    public async Task<OperationResult> Edit(EditBookDto editBookDto)
    {
        var book =await _bookRepository.findBookBy(editBookDto.Id);
        if (book == null)
            return new OperationResult(false, "کتابی برابر با مقدار انتخاب شده وجود ندارد");
        book.Title = editBookDto.Title;
        book.Description = editBookDto.Title;
        book.Price = editBookDto.Price;
        await _bookRepository.Edit(book);
        return new OperationResult(true, "کتاب با موفقیت ویرایش شد");
    }

    public async Task<OperationResult> Delete(int id)
    {
        var book =await _bookRepository.findBookBy(id);
        if (book == null)
            return new OperationResult(false, "کتابی برابر با مقدار انتخاب شده وجود ندارد");
        _bookRepository.Delete(book.Id);
        return new OperationResult(true, "کتاب با موفقیت حذف شد");
    }

    public async Task<BookDto> GetBookById(int id)
    {
        var book =await _bookRepository.findBookBy(id);
        if (book == null)
            return null;
        var bookDto = new BookDto()
        {
            Title = book.Title,
            Description = book.Description,
            Price = book.Price,
            Id = book.Id
        };
        return bookDto;
    }

    public async Task<IEnumerable<BookDto>> GetBooks()
    {
        var books = await _bookRepository.getAllBooks();
        var result = books.Select(book => new BookDto()
        {
            Title = book.Title,
            Description = book.Description,
            Price = book.Price,
        }).ToList();
        return result;
    }
}