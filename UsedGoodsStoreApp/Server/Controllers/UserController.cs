using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using UsedGoodsStoreApp.Server.Services;
using UsedGoodsStoreApp.Shared;
using UsedGoodsStoreApp.Shared.Models;
using UsedGoodsStoreApp.Shared.Requests;

namespace Gotec.GoWell.GRecipe.Server;

[ApiController]
[Route($"{Routes.MainModuleRoute}/[controller]/[action]")]
public class UserController : ControllerBase
{
    private readonly IUserService _user;
    public UserController(IUserService user)
    {
        _user = user;
    }

    [HttpPost]
    public async Task<RequestResult> CreateUser(UserDTO request)
    {

        return await Handle(() => _user.CreateUser(request));
    }
    [HttpPost]
    public async Task<UserDTO> LoginUser(LoginReqeuest request)
    {

        return await _user.LoginUser(request);
    }
    private async Task<RequestResult> Handle(Func<Task> taskFunc)
    {
        try
        {
            await taskFunc.Invoke();
            return RequestResult.Success();
        }
        catch (Exception ex)
        {
            return RequestResult.Failure(ex.Message);
        }
    }
}
