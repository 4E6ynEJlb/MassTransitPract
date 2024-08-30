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
    public class Auth : ControllerBase
    {
        private readonly IRequestClient<RegisterUserRequest> _registerUserClient;
        private readonly IRequestClient<ChangeUserRequest> _changeUserClient;
        private readonly IRequestClient<LoginRequest> _loginClient;
        public Auth(IRequestClient<RegisterUserRequest> registerUserClient, IRequestClient<ChangeUserRequest> changeUserClient, IRequestClient<LoginRequest> loginClient)
        {
            _registerUserClient = registerUserClient;
            _changeUserClient = changeUserClient;
            _loginClient = loginClient;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SignUp(RegisterUserRequest registerUserRequest)
        {
            var res = (await _registerUserClient.GetResponse<MyResponse<LoginResult>>(registerUserRequest)).Message;
            if (res.IsSuccessful)
                return Ok(res.Result);
            return BadRequest(res.ErrorMessage);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Change(ChangeUserRequest changeUserRequest)
        {            
            var res = (await _changeUserClient.GetResponse<MyResponse<string>>(changeUserRequest)).Message;
            if(res.IsSuccessful)
            return Ok();
            return BadRequest(res.ErrorMessage);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SignIn(LoginRequest loginRequest)
        {
            var res = (await _loginClient.GetResponse<MyResponse<LoginResult>>(loginRequest)).Message;
            if (res.IsSuccessful)
                return Ok(res.Result);
            return BadRequest(res.ErrorMessage);
        }
    }
}
