namespace Assignment_3.Utilities
{
    public class PictureHelper
    {
        public static string UploadNewImage(IWebHostEnvironment environment,
        IFormFile file)
        {
            string guid = Guid.NewGuid().ToString();

            string ext = Path.GetExtension(file.FileName);

            string shortPath = Path.Combine("images", guid + ext);

            string path = Path.Combine(environment.WebRootPath, shortPath);

            using (var fs = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fs);
            }

            shortPath = Path.Combine("\\", shortPath);
            return shortPath;
        }
    }
}
