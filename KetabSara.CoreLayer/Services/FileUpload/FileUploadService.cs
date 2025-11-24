using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace KetabSara.CoreLayer.Services.FileUpload;

public class FileUploadService:IFileUploadService
{
    private readonly string _storagePath;

    public FileUploadService(IConfiguration configuration)
    {
        _storagePath = configuration["FileUpload:StoragePath"];
    }

    public async Task<string> UploadFileAsync(IFormFile file)
    {
        if (!Directory.Exists(_storagePath))
        {
            Directory.CreateDirectory(_storagePath);
        }

        if (file == null || file.Length == 0)
        {
            throw new ArgumentException("فایل نباید خالی باشد");
        }

        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        var fullPath = Path.Combine(_storagePath, fileName);
        using (var steam = new FileStream(fullPath,FileMode.Create))
        {
            await file.CopyToAsync(steam);
        }

        return fileName;
    }
}