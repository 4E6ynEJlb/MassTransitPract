using MassTransitPract.Models;
using Refit;

namespace MassTransitPract.RefitAPIs
{
    public interface ITeamApi
    {
        [Get("/GetTeams")]
        public Task<ApiResponse<TeamDtoPageResult>> GetTeams([HeaderCollection] IDictionary<string, string> headers, string? Name, int Page, int PageSize);
        [Get("/Get")]
        public Task<ApiResponse<TeamDto>> Get([HeaderCollection] IDictionary<string, string> headers, int id);
        [Post("/Add")]
        public Task<ApiResponse<TeamDto>> Add([HeaderCollection] IDictionary<string, string> headers, NewTeamDto newTeamDto);
        [Put("/Update")]
        public Task<ApiResponse<TeamDto>> Update([HeaderCollection] IDictionary<string, string> headers, TeamDto teamDto);
        [Delete("/Delete")]
        public Task<ApiResponse<TeamDto>> Delete([HeaderCollection] IDictionary<string, string> headers, int id);
    }
}
