using Microsoft.AspNetCore.Mvc;
using Test_Api.Models.ResponseModels;

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

												var res = new GenericResponse<string>();
												res.Success = false;
												res.StatusCode = 400;
												res.Description = errorSerialized;
												return new BadRequestObjectResult(res);
								}
				}
}
