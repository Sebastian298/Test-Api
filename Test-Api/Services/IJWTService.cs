using Test_Api.Models.Authentications;

namespace Test_Api.Services
{
				public interface IJWTService
				{
								public OnlineTokenData ValidateToken(string token,string secretKeyId);
				}
}
