
using JWTApi.Models;

namespace JWTApi.Data
{
    public interface IAuthenService
    {
        UserModel AuthenticateUser(UserModel login);
        string GennerateJSONWebToken(UserModel userinfo);
    }
}