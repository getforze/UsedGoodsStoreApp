using UsedGoodsStoreApp.Shared;
using UsedGoodsStoreApp.Shared.Models;
using UsedGoodsStoreApp.Shared.Requests;

namespace UsedGoodsStoreApp.Client.Services
{
    public interface IUserService
    {
        Task<UserDTO> UserLogin(LoginReqeuest loginReqeuest);
        Task<RequestResult> CreateUser(UserDTO user);
    }
}
