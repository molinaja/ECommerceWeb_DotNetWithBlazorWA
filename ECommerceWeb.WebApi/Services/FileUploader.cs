
namespace ECommerceWeb.WebApi.Services
{
    public class FileUploader(ILogger<FileUploader> logger, IWebHostEnvironment webHostEnvironment) : IFileUploader
    {
        private readonly ILogger<FileUploader> _logger = logger;
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;
        private readonly string FolderName = "Uploads";

        public async Task<string> UploadFileAsync(string? base64File, string? fileName)
        {
            if (string.IsNullOrEmpty(base64File) || string.IsNullOrEmpty(fileName)) {

                _logger.LogError( "error uploading file: {file}", fileName);
                
                return string.Empty;

            }

			try
			{
                var folder = Path.Combine(_webHostEnvironment.WebRootPath, FolderName);

                if (!Directory.Exists(folder)) { 
                    Directory.CreateDirectory(folder);
                }

                var bytes = Convert.FromBase64String(base64File);

                var completeRoute = Path.Combine(folder, fileName);

                await using var fileStream = new FileStream(completeRoute, FileMode.Create);
                await fileStream.WriteAsync(bytes, 0, bytes.Length);

                return $"/{FolderName}/{fileName}";

			}
			catch (Exception e)
			{
                _logger.LogCritical(e, "error uploading file: {fileName}", fileName);
				return string.Empty;
			}

        }

    }

}
