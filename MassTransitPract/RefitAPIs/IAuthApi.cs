using MassTransitPract.Models;
using Refit;
namespace MassTransitPract.RefitAPIs
{
    public interface IAuthApi
    {
        [Post("/SignUp")]
        [Headers("accept: application/json")]
        public Task<ApiResponse<LoginResult>> SignUp(RegisterUserRequest registerUserRequest);
        [Post("/Change")]
        public Task<ApiResponse<string>> Change([HeaderCollection] IDictionary<string, string> headers, ChangeUserRequest changeUserRequest);
        [Post("/SignIn")]
        [Headers("accept: application/json")]
        public Task<ApiResponse<LoginResult>> SignIn(LoginRequest loginRequest);

    }
}
