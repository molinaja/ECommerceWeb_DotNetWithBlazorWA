namespace ECommerceWeb.WebApi.Services
{
    public interface IFileUploader
    {

        Task<string> UploadFileAsync(string? base64File, string? fileName);

    }
}
