using Newtonsoft.Json.Linq;
using System;
using Test_Api.Models.Dalcec;
using Test_Api.Models.ResponseModels;
using Test_Api.Models.Responses;
using Test_Api.Services;

namespace Test_Api.Repositories
{
				public class DalcecRepository : IDalcecRepository
				{
								private readonly IDalcecService _dalcecService;

								public DalcecRepository(IDalcecService dalcecService)
								{
												_dalcecService = dalcecService;
								}
								public async Task<GenericResponse<List<JObject>>> GetFacturasByFacData(string facData)
								{
												string endpointKey = "WebServices:Dalcec:GetFacData";
												DalcecResponse result = await _dalcecService.GetRowsByFacData(facData,endpointKey);

												if (!result.HasError)
												{
																return new GenericResponse<List<JObject>>()
																{
																				Success = true,
																				StatusCode = 200,
																				Content = result.Results
																};
												}
												else
												{
																return new GenericResponse<List<JObject>>()
																{
																				StatusCode = 500,
																				Description = result.Message
																};
												}
								}
				}
}
