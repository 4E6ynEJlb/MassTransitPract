using MassTransitPract.Models;
using MassTransitPract.RefitAPIs;
using Refit;

namespace MassTransitPract
{
    public class WebApiClient
    {
        private readonly IAuthApi _authApi;
        private readonly IEchoApi _echoApi;
        private readonly IImageApi _imageApi;
        private readonly IPlayerApi _playerApi;
        private readonly ITeamApi _teamApi;
        private string? Token;
        private readonly KeyValuePair<string, string> _acceptAny = new KeyValuePair<string, string>("accept", "*/*");
        private readonly KeyValuePair<string, string> _acceptAppJson = new KeyValuePair<string, string>("accept", "application/json");
        private KeyValuePair<string, string> AuthorizationBearer
        {
            get
            {
                return new KeyValuePair<string, string>("Authorization", $"Bearer {Token ?? ""}");
            }
        }
        public WebApiClient()
        {
            _authApi = RestService.For<IAuthApi>("http://dev.trainee.dex-it.ru/api/Auth");
            _echoApi = RestService.For<IEchoApi>("http://dev.trainee.dex-it.ru/api/Echo");
            _imageApi = RestService.For<IImageApi>("http://dev.trainee.dex-it.ru/api/Image");
            _playerApi = RestService.For<IPlayerApi>("http://dev.trainee.dex-it.ru/api/Player");
            _teamApi = RestService.For<ITeamApi>("http://dev.trainee.dex-it.ru/api/Team");
        }
        public async Task<MyResponse<LoginResult>> AuthSignUp(RegisterUserRequest registerUserRequest)
        {
            ApiResponse<LoginResult> response = await _authApi.SignUp(registerUserRequest);
            if (response.IsSuccessStatusCode)
                Token = response.Content.token!;
            return new MyResponse<LoginResult>() { Result = response.Content, IsSuccessful = response.IsSuccessStatusCode, ErrorMessage = response.Error?.Content};
        }
        public async Task<MyResponse<string>> AuthChange(ChangeUserRequest changeUserRequest)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>
            (
                new List<KeyValuePair<string, string>>()
                {
                    _acceptAny,
                    AuthorizationBearer
                }
            );
            ApiResponse<string> response = await _authApi.Change(headers, changeUserRequest);
            return new MyResponse<string>() { Result = response.Content, IsSuccessful = response.IsSuccessStatusCode, ErrorMessage = response.Error?.Content };
        }
        public async Task<MyResponse<LoginResult>> AuthSignIn(LoginRequest loginRequest)
        {
            ApiResponse<LoginResult> response = await _authApi.SignIn(loginRequest);
            if (response.IsSuccessStatusCode)
                Token = response.Content.token!;
            return new MyResponse<LoginResult>() { Result = response.Content, IsSuccessful = response.IsSuccessStatusCode, ErrorMessage = response.Error?.Content };
        }
        public async Task<MyResponse<string>> EchoPing()
        {
            ApiResponse<string> response = await _echoApi.Ping();
            return new MyResponse<string>() { Result = response.Content, IsSuccessful = response.IsSuccessStatusCode, ErrorMessage = response.Error?.Content };
        }
        public async Task<MyResponse<string>> EchoVersion()
        {
            ApiResponse<string> response = await _echoApi.Version();
            return new MyResponse<string>() { Result = response.Content, IsSuccessful = response.IsSuccessStatusCode, ErrorMessage = response.Error?.Content };
        }
        public async Task<MyResponse<string>> ImageSaveImage(ByteArrayPart file)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>
            (
                new List<KeyValuePair<string, string>>()
                {
                    _acceptAppJson,
                    AuthorizationBearer
                }
            );
            ApiResponse<string> response = await _imageApi.SaveImage(headers, file);
            return new MyResponse<string>() { Result = response.Content, IsSuccessful = response.IsSuccessStatusCode, ErrorMessage = response.Error?.Content };
        }
        public async Task<MyResponse<string>> ImageDeleteImage(string fileName)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>
            (
                new List<KeyValuePair<string, string>>()
                {
                    _acceptAny,
                    AuthorizationBearer
                }
            );
            ApiResponse<string> response = await _imageApi.DeleteImage(headers, fileName);
            return new MyResponse<string>() { Result = response.Content, IsSuccessful = response.IsSuccessStatusCode, ErrorMessage = response.Error?.Content };
        }
        public async Task<MyResponse<string[]>> PlayerGetPositions()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>
            (
                new List<KeyValuePair<string, string>>()
                {
                    _acceptAppJson,
                    AuthorizationBearer
                }
            );
            ApiResponse<string[]> response = await _playerApi.GetPositions(headers);
            return new MyResponse<string[]>() { Result = response.Content, IsSuccessful = response.IsSuccessStatusCode, ErrorMessage = response.Error?.Content };
        }
        public async Task<MyResponse<PlayerDtoPageResult>> PlayerGetPlayers(GetPlayersArgs args)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>
            (
                new List<KeyValuePair<string, string>>()
                {
                    _acceptAppJson,
                    AuthorizationBearer
                }
            );
            ApiResponse<PlayerDtoPageResult> response = await _playerApi.GetPlayers(headers, args.Name, args.TeamIds, args.Page, args.PageSize);
            return new MyResponse<PlayerDtoPageResult>() { Result = response.Content, IsSuccessful = response.IsSuccessStatusCode, ErrorMessage = response.Error?.Content };
        }
        public async Task<MyResponse<PlayerTeamNameDto>> PlayerGet(int id)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>
            (
                new List<KeyValuePair<string, string>>()
                {
                    _acceptAppJson,
                    AuthorizationBearer
                }
            );
            ApiResponse<PlayerTeamNameDto> response = await _playerApi.Get(headers, id);
            return new MyResponse<PlayerTeamNameDto>() { Result = response.Content, IsSuccessful = response.IsSuccessStatusCode, ErrorMessage = response.Error?.Content };
        }
        public async Task<MyResponse<PlayerDto>> PlayerAdd(NewPlayerDto newPlayerDto)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>
            (
                new List<KeyValuePair<string, string>>()
                {
                    _acceptAppJson,
                    AuthorizationBearer
                }
            );
            ApiResponse<PlayerDto> response = await _playerApi.Add(headers, newPlayerDto);
            return new MyResponse<PlayerDto>() { Result = response.Content, IsSuccessful = response.IsSuccessStatusCode, ErrorMessage = response.Error?.Content };
        }
        public async Task<MyResponse<PlayerDto>> PlayerUpdate(PlayerDto playerDto)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>
            (
                new List<KeyValuePair<string, string>>()
                {
                    _acceptAppJson,
                    AuthorizationBearer
                }
            );
            ApiResponse<PlayerDto> response = await _playerApi.Update(headers, playerDto);
            return new MyResponse<PlayerDto>() { Result = response.Content, IsSuccessful = response.IsSuccessStatusCode, ErrorMessage = response.Error?.Content };
        }
        public async Task<MyResponse<PlayerDto>> PlayerDelete(int id)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>
            (
                new List<KeyValuePair<string, string>>()
                {
                    _acceptAppJson,
                    AuthorizationBearer
                }
            );
            ApiResponse<PlayerDto> response = await _playerApi.Delete(headers, id);
            return new MyResponse<PlayerDto>() { Result = response.Content, IsSuccessful = response.IsSuccessStatusCode, ErrorMessage = response.Error?.Content };
        }
        public async Task<MyResponse<TeamDtoPageResult>> TeamGetTeams(GetTeamsArgs args)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>
            (
                new List<KeyValuePair<string, string>>()
                {
                    _acceptAppJson,
                    AuthorizationBearer
                }
            );
            ApiResponse<TeamDtoPageResult> response = await _teamApi.GetTeams(headers, args.Name, args.Page, args.PageSize);
            return new MyResponse<TeamDtoPageResult>() { Result = response.Content, IsSuccessful = response.IsSuccessStatusCode, ErrorMessage = response.Error?.Content };
        }
        public async Task<MyResponse<TeamDto>> TeamGet(int id)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>
            (
                new List<KeyValuePair<string, string>>()
                {
                    _acceptAppJson,
                    AuthorizationBearer
                }
            );
            ApiResponse<TeamDto> response = await _teamApi.Get(headers, id);
            return new MyResponse<TeamDto>() { Result = response.Content, IsSuccessful = response.IsSuccessStatusCode, ErrorMessage = response.Error?.Content };
        }
        public async Task<MyResponse<TeamDto>> TeamAdd(NewTeamDto newTeamDto)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>
            (
                new List<KeyValuePair<string, string>>()
                {
                    _acceptAppJson,
                    AuthorizationBearer
                }
            );
            ApiResponse<TeamDto> response = await _teamApi.Add(headers, newTeamDto);
            return new MyResponse<TeamDto>() { Result = response.Content, IsSuccessful = response.IsSuccessStatusCode, ErrorMessage = response.Error?.Content };
        }
        public async Task<MyResponse<TeamDto>> TeamUpdate(TeamDto teamDto)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>
            (
                new List<KeyValuePair<string, string>>()
                {
                    _acceptAppJson,
                    AuthorizationBearer
                }
            );
            ApiResponse<TeamDto> response = await _teamApi.Update(headers, teamDto);
            return new MyResponse<TeamDto>() { Result = response.Content, IsSuccessful = response.IsSuccessStatusCode, ErrorMessage = response.Error?.Content };
        }
        public async Task<MyResponse<TeamDto>> TeamDelete(int id)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>
            (
                new List<KeyValuePair<string, string>>()
                {
                    _acceptAppJson,
                    AuthorizationBearer
                }
            );
            ApiResponse<TeamDto> response = await _teamApi.Delete(headers, id);
            return new MyResponse<TeamDto>() { Result = response.Content, IsSuccessful = response.IsSuccessStatusCode, ErrorMessage = response.Error?.Content };
        }
    }
}
