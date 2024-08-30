using MassTransit;
using MassTransitPract.Models;
using MassTransitPract.RefitAPIs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Refit;
using System.Xml.Linq;

namespace MassTransitPract.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Team : ControllerBase
    {
        private readonly IRequestClient<GetTeamsArgs> _getTeamsClient;
        private readonly IRequestClient<GetTeamRequest> _getTeamClient;
        private readonly IRequestClient<NewTeamDto> _addTeamClient;
        private readonly IRequestClient<TeamDto> _updateTeamClient;
        private readonly IRequestClient<DeleteTeamRequest> _deleteTeamClient;
        public Team(IRequestClient<GetTeamsArgs> getTeamsClient, IRequestClient<GetTeamRequest> getTeamClient, 
            IRequestClient<NewTeamDto> addTeamClient, IRequestClient<TeamDto> updateTeamClient, 
            IRequestClient<DeleteTeamRequest> deleteTeamClient)
        {
            _getTeamsClient = getTeamsClient;
            _getTeamClient = getTeamClient;
            _addTeamClient = addTeamClient;
            _updateTeamClient = updateTeamClient;
            _deleteTeamClient = deleteTeamClient;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetTeams(string Name, int Page, int PageSize)
        {
            GetTeamsArgs args = new GetTeamsArgs() { PageSize = PageSize, Page = Page, Name = Name };
            var res = (await _getTeamsClient.GetResponse<MyResponse<TeamDtoPageResult>>(args)).Message;
            if (res.IsSuccessful)
                return Ok(res.Result);
            return BadRequest(res.ErrorMessage);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Get(int id)
        {            
            var res = (await _getTeamClient.GetResponse<MyResponse<TeamDto>>(new GetTeamRequest(id))).Message;
            if (res.IsSuccessful)
                return Ok(res.Result);
            return BadRequest(res.ErrorMessage);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Add(NewTeamDto newTeamDto)
        {            
            var res = (await _addTeamClient.GetResponse<MyResponse<TeamDto>>(newTeamDto)).Message;
            if (res.IsSuccessful)
                return Ok(res.Result);
            return BadRequest(res.ErrorMessage);
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update(TeamDto teamDto)
        {
            var res = (await _updateTeamClient.GetResponse<MyResponse<TeamDto>>(teamDto)).Message;
            if (res.IsSuccessful)
                return Ok(res.Result);
            return BadRequest(res.ErrorMessage);
        }
        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> Delete(int id)
        {            
            var res = (await _deleteTeamClient.GetResponse<MyResponse<TeamDto>>(new DeleteTeamRequest(id))).Message;
            if (res.IsSuccessful)
                return Ok(res.Result);
            return BadRequest(res.ErrorMessage);
        }
    }
}
