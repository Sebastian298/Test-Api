using Dapper;
using Google.Cloud.BigQuery.V2;
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
								private readonly IBigqueryService _bigqueryService;

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

								public async Task<GenericResponse<List<T>>> GetCategoriesFromBigQuery()
								{
												StoredProcedureData qData = QueryHelper.GetBigQueryStoredProcedureData(_configuration, "QuerySettings:CategoriesRepository:GetCategoriesBq:Data");

												BigQueryServiceResponse[] results = new BigQueryServiceResponse[2];
												var res = await _bigqueryService.ExecuteStoredProcedure(qData, null);
												results[0] = res;
												results[1] = new BigQueryServiceResponse() { hasError = false };

												if (!results[0].hasError && !results[1].hasError)
												{
																dynamic data = (results[0].BigQueryResults.TotalRows > 0) ? JsonConvert.DeserializeObject<List<T>>(results[0].BigQueryResults.FirstOrDefault()[0].ToString()) : new JArray();
																return new GenericResponse<List<T>>()
																{
																				Success = true,
																				StatusCode = 200,
																				Content = data,
																};
												}
												else
												{
																return new GenericResponse<List<T>>()
																{
																				Success = false,
																				StatusCode = 500
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
																return new GenericResponse<T>()
																{
																				Success = false,
																				StatusCode = 500
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
