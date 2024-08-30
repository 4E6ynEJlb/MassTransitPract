using MassTransitPract.Models;
using Refit;

namespace MassTransitPract.RefitAPIs
{
    public interface IPlayerApi
    {
        [Get("/GetPositions")]
        public Task<ApiResponse<string[]>> GetPositions([HeaderCollection] IDictionary<string, string> headers);
        [Get("/GetPlayers")]
        public Task<ApiResponse<PlayerDtoPageResult>> GetPlayers([HeaderCollection] IDictionary<string, string> headers, string? Name, int[]? TeamIds, int Page, int PageSize);
        [Get("/Get")]
        public Task<ApiResponse<PlayerTeamNameDto>> Get([HeaderCollection] IDictionary<string, string> headers, int id);
        [Post("/Add")]
        public Task<ApiResponse<PlayerDto>> Add([HeaderCollection] IDictionary<string, string> headers, NewPlayerDto newPlayerDto);
        [Put("/Update")]
        public Task<ApiResponse<PlayerDto>> Update([HeaderCollection] IDictionary<string, string> headers, PlayerDto playerDto);
        [Delete("/Delete")]
        public Task<ApiResponse<PlayerDto>> Delete([HeaderCollection] IDictionary<string, string> headers, int id);
    }
}
