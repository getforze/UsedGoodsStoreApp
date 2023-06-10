using UsedGoodsStoreApp.Shared.Requests;
using UsedGoodsStoreApp.Shared;
using UsedGoodsStoreApp.Shared.Models;

namespace UsedGoodsStoreApp.Server.Services
{
    public interface IUserService
    {
        Task<UserDTO> LoginUser(LoginReqeuest reqeuest);
        Task<RequestResult> CreateUser(UserDTO request);
    }
}
