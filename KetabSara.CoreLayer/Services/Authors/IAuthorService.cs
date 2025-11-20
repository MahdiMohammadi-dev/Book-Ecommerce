using KetabSara.CoreLayer.DTO.Authors;
using KetabSara.CoreLayer.Utilities;

namespace KetabSara.CoreLayer.Services.Authors;

public interface IAuthorService
{
    Task<OperationResult> Create(CreateAuthorDto authorDto);
    Task<OperationResult> Edit(EditAuthorDto authorDto);
    Task<OperationResult> Delete(int id);
    Task<AuthorDto> GetAuthorById(int id);
    Task<IEnumerable<AuthorDto>> GetAuthors();

}