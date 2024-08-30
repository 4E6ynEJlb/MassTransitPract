using Refit;

namespace MassTransitPract.RefitAPIs
{
    public interface IImageApi
    {
        [Multipart]
        [Post("/SaveImage")]
        public Task<ApiResponse<string>> SaveImage([HeaderCollection] IDictionary<string, string> headers, ByteArrayPart file);
        [Delete("/DeleteImage")]
        public Task<ApiResponse<string>> DeleteImage([HeaderCollection] IDictionary<string, string> headers, string fileName);
    }
}
