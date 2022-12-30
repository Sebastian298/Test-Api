namespace Test_Api.Models.Authentications
{
				public class ValidateTokenResult
				{
								public string UserId { set; get; }
								public string UserName { set; get; }
								public string Email { set; get; }
				}

				public class OnlineTokenData
				{
								public string SessionId { set; get; }
								public string Ip { set; get; }
								public string UserAgent { set; get; }
								public string UserId { set; get; }
				}

				public class AuthTokenResponse
				{
								public string Token { set; get; }
								public DateTime Expiration { set; get; }
				}
}
