using AutoMapper;
using DatabaseSchemaManager.Models;
using UsedGoodsStoreApp.Shared.Models;
using UsedGoodsStoreApp.Shared.Requests;
using BCrypt.Net;
using System.Security.Cryptography;
using System.Text;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using UsedGoodsStoreApp.Shared;

namespace UsedGoodsStoreApp.Server.Services
{
    public class UserService : IUserService
    {
        private readonly UsedGoodsStoreDbContext _db;
        private readonly IMapper _mapper;

        public UserService(UsedGoodsStoreDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<RequestResult> CreateUser(UserDTO request)
        {
            User user = _mapper.Map<User>(request);
            if(!_db.Users.Where(x => x.Email == request.Email).Any())
            {
                user.PasswordHash = ComputeHash(StringToByte(request.Password));
                await _db.Users.AddAsync(user);
            }
            else
            {
                throw new Exception("Ten email posiada już konto");
            }
            await _db.SaveChangesAsync();
            return RequestResult.Success();
        }
        public async Task<UserDTO> LoginUser(LoginReqeuest reqeuest)
        {
            var user = await _db.Users.Where(x => x.Email == reqeuest.Email).Include(x => x.Permission).FirstOrDefaultAsync();
            if(user != null)
            {
                var hash = ComputeHash(StringToByte(reqeuest.Password));
                var result = VerifyPassword(user.PasswordHash, hash);
                if (result)
                    return _mapper.Map<UserDTO>(user);
            }
            return new UserDTO();
        }
        public byte[] StringToByte(string text)
        {
            return Encoding.UTF8.GetBytes(text);
        }
        public byte[] ComputeHash(byte[] inputBytes)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                return hashBytes;
            }
        }

        public bool VerifyPassword(byte[] inputBytes, byte[] storedHash)
        {
            return CompareByteArrays(inputBytes, storedHash);
        }
        private static bool CompareByteArrays(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }

    }
}
