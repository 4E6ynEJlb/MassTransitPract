using MassTransit;
using MassTransitPract.Models;
using MassTransitPract.RefitAPIs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace MassTransitPract.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Echo : ControllerBase
    {
        private readonly IRequestClient<PingRequest> _pingClient;
        private readonly IRequestClient<VersionRequest> _versionClient;
        public Echo(IRequestClient<PingRequest> pingClient, IRequestClient<VersionRequest> versionClient) 
        {
            _pingClient = pingClient;
            _versionClient = versionClient;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Ping()
        {
            var res = (await _pingClient.GetResponse<MyResponse<string>>(new PingRequest())).Message;
            if (res.IsSuccessful)
            return Ok(res.Result);
            return BadRequest(res.ErrorMessage);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Version()
        {
            var res = (await _versionClient.GetResponse<MyResponse<string>>(new VersionRequest())).Message;
            if (res.IsSuccessful)
                return Ok(res.Result);
            return BadRequest(res.ErrorMessage);
        }
    }
}
