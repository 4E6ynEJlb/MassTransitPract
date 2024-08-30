using MassTransitPract.Models;
using Refit;

namespace MassTransitPract.RefitAPIs
{
    public interface IEchoApi
    {
        [Get("/Ping")]
        [Headers("accept: */*")]
        public Task<ApiResponse<string>> Ping();
        [Get("/Version")]
        [Headers("accept: */*")]
        public Task<ApiResponse<string>> Version();
    }
}
