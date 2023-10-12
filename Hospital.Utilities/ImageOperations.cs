using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Hospital.Utilities;
public class ImageOperations
{
    IWebHostEnvironment _env;
    public ImageOperations(IWebHostEnvironment env)
    {
        _env = env;
    }

    public string ImageUpload(IFormFile file)
    {
        string fileName = null;
        if (fileName is not null)
        {
            string fileDirectory = Path.Combine(_env.WebRootPath, "Images");
            fileName = Guid.NewGuid() + "-" + file.FileName;
            string filePath = Path.Combine(fileDirectory, fileName);
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                file.CopyToAsync(fs);
            }
        }
        return fileName;
    }
}
