using Microsoft.AspNetCore.Http;

namespace KetabSara.CoreLayer.Services.FileUpload
{
    public interface IFileUploadService
    {
        Task<string> UploadFileAsync(IFormFile file);

    }
}
