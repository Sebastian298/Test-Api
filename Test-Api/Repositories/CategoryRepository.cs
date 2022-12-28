using Dapper;
using Google.Cloud.BigQuery.V2;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using Test_Api.Helpers;
using Test_Api.Models.Queries;
using Test_Api.Models.ResponseModels;
using Test_Api.Models.Responses;
using Test_Api.Models.StoreModels;
using Test_Api.Services;
using static Test_Api.Constants.MessageSetting;

namespace Test_Api.Repositories
{
				public class CategoryRepository<T> : ICategoryRepository<T>
				{
								private readonly IConfiguration _configuration;
								private readonly IDapperService _dapperService;
								private readonly IBigqueryService _bigqueryService;
								private readonly MessageErrorBuilder<GenericCrud> messageErrorBuilders = new MessageErrorBuilder<GenericCrud>();

								public CategoryRepository(IConfiguration configuration,IDapperService dapperService,IBigqueryService bigqueryService)
								{
												_configuration = configuration;
												_dapperService = dapperService;
												_bigqueryService = bigqueryService;
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
																GenericResponseData messages = messageErrorBuilders.GetMessageList("Categories", "GetAll", "GeneralException",MessageTypes.danger.ToString(),null,result.Message);

																return new GenericResponse<List<T>>()
																{
																				Success = false,
																				StatusCode = 500,
																				Content = new List<T>(),
																				Messages = messages
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
																if (result.Results is null)
																{
																				GenericResponseData messages = messageErrorBuilders.GetMessageList("Categories", "GetById", "EmptyResponse", MessageTypes.info.ToString(), null, result.Message);

																				return new GenericResponse<T>()
																				{
																								Success = false,
																								StatusCode = 500,
																								Messages = messages
																				};
																}
																return new GenericResponse<T>()
																{
																				Success = true,
																				StatusCode = 200,
																				Content = result.Results
																};
												}
												else
												{

																GenericResponseData messages = messageErrorBuilders.GetMessageList("Categories", "GetById", "GeneralException", MessageTypes.danger.ToString(), null, result.Message);

																return new GenericResponse<T>()
																{
																				Success = false,
																				StatusCode = 200,
																				Messages = messages
																};
												}
								}

								public async Task<GenericResponse<List<T>>> GetCategoriesFromBigQuery()
								{
												StoredProcedureData qData = QueryHelper.GetBigQueryStoredProcedureData(_configuration, "QuerySettings:CategoriesRepository:GetCategoriesBq:Data");

												BigQueryServiceResponse results = await _bigqueryService.ExecuteStoredProcedure(qData, null);

												if (!results.hasError)
												{
																dynamic data = (results.BigQueryResults.TotalRows > 0) ? JsonConvert.DeserializeObject<List<T>>(results.BigQueryResults.FirstOrDefault()[0].ToString()) : new JArray();
																return new GenericResponse<List<T>>()
																{
																				Success = true,
																				StatusCode = 200,
																				Content = data,
																};
												}
												else
												{
																GenericResponseData messages = messageErrorBuilders.GetMessageList("Categories", "GetAllBq", "GeneralException", MessageTypes.danger.ToString(), null, results.message);

																return new GenericResponse<List<T>>()
																{
																				Success = false,
																				StatusCode = 500,
																				Content = new List<T>(),
																				Messages = messages
																};
												}
								}

								public async Task<GenericResponse<T>> CreateCategoryToBigQueryTable(Category category)
								{
												StoredProcedureData qData = QueryHelper.GetBigQueryStoredProcedureData(_configuration, "QuerySettings:CategoriesRepository:InsertCategoryBq:Data");

												List<BigQueryParameter> bqParameters = new();

												bqParameters.Add(new BigQueryParameter("categoryId",BigQueryHelpers.GetDataType("string"),category.CategoryId));
												bqParameters.Add(new BigQueryParameter("name", BigQueryHelpers.GetDataType("string"), category.Name));

												var result = await _bigqueryService.ExecuteStoredProcedure(qData, bqParameters);
												if (!(result.hasError))
												{
																dynamic data = (result.BigQueryResults.TotalRows > 0) ? JsonConvert.DeserializeObject<T>(result.BigQueryResults.FirstOrDefault()[0].ToString()) : null;
																return new GenericResponse<T>()
																{
																				Success = true,
																				StatusCode = 200,
																				Content = data,
																};
												}
												else
												{
																GenericResponseData messages = messageErrorBuilders.GetMessageList("Categories", "InsertToBqTable", "GeneralException", MessageTypes.danger.ToString(), null, result.message);

																return new GenericResponse<T>()
																{
																				Success = false,
																				StatusCode = 500,
																				Messages = messages
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
																GenericResponseData messages = messageErrorBuilders.GetMessageList("Categories", "Create", "GeneralException", MessageTypes.danger.ToString(), null, result.Message);

																return new GenericResponse<List<T>>()
																{
																				Success = false,
																				StatusCode = 500,
																				Content = new List<T>(),
																				Messages = messages
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
																GenericResponseData messages = messageErrorBuilders.GetMessageList("Categories", "Update", "GeneralException", MessageTypes.danger.ToString(), null, result.Message);

																return new GenericResponse<List<T>>()
																{
																				Success = false,
																				StatusCode = 500,
																				Content=new List<T>(),
																				Messages = messages
																};
												}
								}
				}
}
