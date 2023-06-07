using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;


namespace EndPoint.FinderProject.HelpService.UploadImage
{
    public interface IUploadImage
    {
        public string UploadFile(IFormFile file, string subjectImage);
    }
    public  class UploadImage:IUploadImage
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UploadImage(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnvironment = webHostEnvironment;
        }
        public string UploadFile(IFormFile file,string subjectImage)
        {
            if (file == null) return null;
            var path = _webHostEnvironment.WebRootPath + $"\\Images\\{subjectImage}\\" + file.FileName;
            using var systemIo = System.IO.File.Create(path);
            file.CopyTo(systemIo);
            path = path.Split("wwwroot")[1];
            return file.FileName;
        }
    }
}
