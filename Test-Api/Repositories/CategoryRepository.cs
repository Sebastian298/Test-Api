using Dapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using Test_Api.Helpers;
using Test_Api.Models.Queries;
using Test_Api.Models.ResponseModels;
using Test_Api.Models.Responses;
using Test_Api.Models.StoreModels;
using Test_Api.Services;

namespace Test_Api.Repositories
{
				public class CategoryRepository<T> : ICategoryRepository<T>
				{
								private readonly IConfiguration _configuration;
								private readonly IDapperService _dapperService;

								public CategoryRepository(IConfiguration configuration,IDapperService dapperService)
								{
												_configuration = configuration;
												_dapperService = dapperService;
								}

								public async Task<GenericResponse<List<T>>> GetAll()
								{

												StoredProcedureData Qdata = QueryHelper.GetConfigurationStoredProcedure(_configuration, "QuerySettings:CategoriesRepository:GetAll:Data");

												DynamicParameters dapperParams = new DynamicParameters();
												QueryServiceResponse result = await _dapperService.ActionsFromStoredProcedureToModel<T>(Qdata, dapperParams,true);
												if (!result.HasError)
												{
																return new GenericResponse<List<T>>()
																{
																				Success = true,
																				StatusCode = 200,
																				Content = result.Results
																};
												}
												else
												{
																return new GenericResponse<List<T>>()
																{
																				StatusCode = 500,
																				Description = result.Message
																};
												}
								}

								public async Task<GenericResponse<T>> GetById(string id)
								{
												StoredProcedureData Qdata = QueryHelper.GetConfigurationStoredProcedure(_configuration, "QuerySettings:CategoriesRepository:GetById:Data");

												DynamicParameters dapperParams = new DynamicParameters();

												dapperParams.Add("@CategoryId", id, DbType.String);
												QueryServiceResponse result = await _dapperService.ActionsFromStoredProcedureToModel<T>(Qdata, dapperParams);

												if (!result.HasError)
												{
																return new GenericResponse<T>()
																{
																				Success = true,
																				StatusCode = 200,
																				Content = result.Results
																};
												}
												else
												{
																return new GenericResponse<T>()
																{
																				StatusCode = 500,
																				Description = result.Message
																};
												}
								}

								public async Task<GenericResponse<List<T>>> Create(Category category)
								{
												StoredProcedureData Qdata = QueryHelper.GetConfigurationStoredProcedure(_configuration, "QuerySettings:CategoriesRepository:Create:Data");

												DynamicParameters dapperParams = new DynamicParameters();

												dapperParams.Add("@CategoryId", category.CategoryId, DbType.String);
												dapperParams.Add("@Name", category.Name, DbType.String);
												QueryServiceResponse result = await _dapperService.GetDataFromStoredProcedureInJsonString(Qdata, dapperParams);
												if (!result.HasError)
												{
																string ResultString = $"{{\"Success\": true,\"StatusCode\":200, \"Content\":{result.Results}, \"Description\":\"Successful operation\"}}";

																return JsonConvert.DeserializeObject<GenericResponse<List<T>>>(ResultString);
												}
												else
												{
																return new GenericResponse<List<T>>()
																{
																				StatusCode = 500,
																				Description = result.Message
																};
												}
								}

								public async Task<GenericResponse<List<T>>> Update(Category category)
								{
												StoredProcedureData Qdata = QueryHelper.GetConfigurationStoredProcedure(_configuration, "QuerySettings:CategoriesRepository:Update:Data");

												DynamicParameters dapperParams = new DynamicParameters();

												dapperParams.Add("@CategoryId", category.CategoryId, DbType.String);
												dapperParams.Add("@Name", category.Name, DbType.String);
												QueryServiceResponse result = await _dapperService.GetDataFromStoredProcedureInJsonString(Qdata, dapperParams);
												if (!result.HasError)
												{
																string ResultString = $"{{\"Success\": true,\"StatusCode\":200, \"Content\":{result.Results}, \"Description\":\"Successful operation\"}}";

																return JsonConvert.DeserializeObject<GenericResponse<List<T>>>(ResultString);
												}
												else
												{
																return new GenericResponse<List<T>>()
																{
																				StatusCode = 500,
																				Description = result.Message
																};
												}
								}

				}
}
