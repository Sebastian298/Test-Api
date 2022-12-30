using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Test_Api.Helpers;
using Test_Api.Models.ResponseModels;
using static Test_Api.Constants.MessageSetting;

namespace Test_Api.Attributes.Authorization
{
				public class AuthorizeAttribute : Attribute, IAsyncAuthorizationFilter
				{
								public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
								{
												MessageErrorBuilder<GenericResponse<bool>> messageErrorBuilders = new MessageErrorBuilder<GenericResponse<bool>>();

												try
												{
																// skip authorization if action is decorated with [AllowAnonymous] attribute
																var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();

																if (allowAnonymous)
																{
																				return;
																}

																// authorization
																var user = (string)context.HttpContext.Items["sessionId"];

																if (string.IsNullOrEmpty(user))
																{
																				var messages = messageErrorBuilders.GetMessageList("AuthorizeAttribute", "OnAuthorization", "InvalidToken", MessageTypes.danger.ToString(), null, null);
																				context.Result = new BadRequestObjectResult(messages);
																				return;
																}

																return;
												}
												catch (Exception ex)
												{

																var messages = messageErrorBuilders.GetMessageList("AuthorizeAttribute", "OnAuthorization", "GeneralException", MessageTypes.danger.ToString(), null, ex.Message);
																context.Result = new BadRequestObjectResult(messages);
																return;
												}
								}
				}
}
