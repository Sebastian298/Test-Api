using Microsoft.IdentityModel.Tokens;
using Test_Api.Services;

namespace Test_Api.Middlewares
{
				public class JwtMiddleware
				{
								private readonly RequestDelegate _requestDelegate;

								public JwtMiddleware(RequestDelegate requestDelegate)
								{
												_requestDelegate = requestDelegate;
								}

								public async Task Invoke(HttpContext context,IJWTService jWTService)
								{
												var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

												if (token is not null)
												{
																var validateTokenResult = jWTService.ValidateToken(token, "WdxCapSecret");
																if (validateTokenResult is not null)
																{
																				if (validateTokenResult.SessionId is not null)
																				{
																								//attach user to context on successful jwt validation
																								context.Items["sessionId"] = validateTokenResult.SessionId;
																								context.Items["ip"] = validateTokenResult.Ip;
																								context.Items["userAgent"] = validateTokenResult.UserAgent;
																								//context.Items["userId"] = validateTokenResult.userId;
																				}
																}
																
												}

												await _requestDelegate(context);
								}
				}
}
