using Microsoft.AspNetCore.Mvc;
using Test_Api.Helpers;
using Test_Api.Models.ResponseModels;
using static Test_Api.Constants.MessageSetting;

namespace Test_Api.Attributes
{
				public class ModelStateValidator
				{
								public static ActionResult ValidateModelState(ActionContext context)
								{
												var modelStateEntries = context.ModelState.Where(x => x.Value.Errors.Count > 0);
												
												string errorSerialized = "";

												if (modelStateEntries.Count() > 0)
												{
																errorSerialized = string.Join(" | ", modelStateEntries.Select(x => x.Value.Errors.First().ErrorMessage).ToList());
												}
												MessageErrorBuilder<bool> messageErrorBuilders = new();

												var error = messageErrorBuilders.GetGenericErrorResponse(400, "ModelStateValidator", "ValidationModelState", "GeneralException", MessageTypes.warning.ToString(), null, (errorSerialized != "") ? errorSerialized : null);

												return new BadRequestObjectResult(error);
								}
				}
}
