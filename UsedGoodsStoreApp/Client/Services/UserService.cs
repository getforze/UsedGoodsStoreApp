using MudBlazor;
using UsedGoodsStoreApp.Shared;
using UsedGoodsStoreApp.Shared.Models;
using UsedGoodsStoreApp.Shared.Requests;

namespace UsedGoodsStoreApp.Client.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpService _httpService;
        private readonly ISnackbar _snackbar;

        public UserService(IHttpService httpService, ISnackbar snackbar)
        {
            _httpService = httpService;
            _snackbar = snackbar;
        }
        public async Task<UserDTO> UserLogin(LoginReqeuest loginReqeuest)
        {
            var result = await _httpService.Post<UserDTO>($"{Routes.MainModuleRoute}/User/LoginUser", loginReqeuest);
            if (result.UserId == 0)
                _snackbar.Add("Bład logowania", Severity.Error);
            else
                _snackbar.Add("Logowanie powiodło się", Severity.Success);
            return result;
        }
        public async Task<RequestResult> CreateUser(UserDTO user)
        {
            var result = await _httpService.Post<RequestResult>($"{Routes.MainModuleRoute}/User/CreateUser", user);
            if (result.Failed)
                _snackbar.Add(result.ErrorCode, Severity.Error);
            else
                _snackbar.Add(result.SuccessCode, Severity.Success);
            return result;
        }
    }
}
