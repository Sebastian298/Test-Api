using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Test_Api.Models.Authentications;

namespace Test_Api.Services
{
				public class JWTService : IJWTService
				{
								private readonly IConfiguration _configuration;

								public JWTService(IConfiguration configuration)
								{
												_configuration = configuration;
								}
								public OnlineTokenData ValidateToken(string token, string secretKeyId)
								{
												if (token is null)
																return null;

												var tokenHandler = new JwtSecurityTokenHandler();
												var key = Encoding.ASCII.GetBytes(_configuration[$"JWT:{secretKeyId}"]);

												try
												{
																tokenHandler.ValidateToken(token, new TokenValidationParameters
																{
																				ValidateIssuerSigningKey = true,
																				IssuerSigningKey = new SymmetricSecurityKey(key),
																				ValidateIssuer = false,
																				ValidateAudience = false,
																				ClockSkew = TimeSpan.Zero
																}, out SecurityToken validatedToken);

																var jwtToken = (JwtSecurityToken)validatedToken;

																OnlineTokenData tokenResult = new();
																tokenResult.SessionId = jwtToken.Claims.First(x => x.Type == "sessionId").Value;
																tokenResult.Ip = jwtToken.Claims.First(x => x.Type == "ip").Value;
																tokenResult.UserAgent = jwtToken.Claims.First(x => x.Type == "userAgent").Value;

																// return user id from JWT token if validation successful
																return tokenResult;
												}
												catch
												{
																// return null if validation fails
																return null;
												}
								}
				}
}
