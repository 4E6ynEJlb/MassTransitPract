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
    public class Player : ControllerBase
    {
        private readonly IRequestClient<GetPositionsRequest> _getPositionsClient;
        private readonly IRequestClient<GetPlayersArgs> _getPlayersClient;
        private readonly IRequestClient<GetPlayerRequest> _getPlayerClient;
        private readonly IRequestClient<NewPlayerDto> _addPlayerClient;
        private readonly IRequestClient<PlayerDto> _updatePlayerClient;
        private readonly IRequestClient<DeletePlayerRequest> _deletePlayerClient;
        public Player(IRequestClient<GetPositionsRequest> getPositionsClient, IRequestClient<GetPlayersArgs> getPlayersClient, 
            IRequestClient<GetPlayerRequest> getPlayerClient, IRequestClient<NewPlayerDto> addPlayerClient, 
            IRequestClient<PlayerDto> updatePlayerClient, IRequestClient<DeletePlayerRequest> deletePlayerClient)
        {
            _addPlayerClient = addPlayerClient;
            _deletePlayerClient = deletePlayerClient;
            _getPlayerClient = getPlayerClient;
            _getPlayersClient = getPlayersClient;
            _getPositionsClient = getPositionsClient;
            _updatePlayerClient = updatePlayerClient;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetPositions()
        {
            var res = (await _getPositionsClient.GetResponse<MyResponse<string[]>>(new GetPositionsRequest())).Message;
            if (res.IsSuccessful)
                return Ok(res.Result);
            return BadRequest(res.ErrorMessage);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetPlayers(string Name, int[] TeamIds, int Page, int PageSize)
        {
            GetPlayersArgs args = new GetPlayersArgs() { Name = Name, Page = Page, PageSize = PageSize, TeamIds = TeamIds };
            var res = (await _getPlayersClient.GetResponse<MyResponse<PlayerDtoPageResult>>(args)).Message;
            if (res.IsSuccessful)
                return Ok(res.Result);
            return BadRequest(res.ErrorMessage);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Get(int id)
        {
            var res = (await _getPlayerClient.GetResponse<MyResponse<PlayerTeamNameDto>>(new GetPlayerRequest(id))).Message;
            if (res.IsSuccessful)
                return Ok(res.Result);
            return BadRequest(res.ErrorMessage);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Add(NewPlayerDto newPlayerDto)
        {            
            var res = (await _addPlayerClient.GetResponse<MyResponse<PlayerDto>>(newPlayerDto)).Message;
            if (res.IsSuccessful)
                return Ok(res.Result);
            return BadRequest(res.ErrorMessage);
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update(PlayerDto playerDto)
        {
            var res = (await _updatePlayerClient.GetResponse<MyResponse<PlayerDto>>(playerDto)).Message;
            if (res.IsSuccessful)
                return Ok(res.Result);
            return BadRequest(res.ErrorMessage);
        }
        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = (await _deletePlayerClient.GetResponse<MyResponse<PlayerDto>>(new DeletePlayerRequest(id))).Message;
            if (res.IsSuccessful)
                return Ok(res.Result);
            return BadRequest(res.ErrorMessage);
        }
    }
}
