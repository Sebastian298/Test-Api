using Google.Apis.Auth.OAuth2;
using Google.Cloud.BigQuery.V2;
using System.Xml.Linq;
using Test_Api.Models.Queries;
using Test_Api.Models.ResponseModels;

namespace Test_Api.Services
{
				public class BigQueryService : IBigqueryService
				{

								public BigQueryClientResponse GetBigqueryClient(string key, string projectId)
								{
												BigQueryClientResponse clientResponse = new BigQueryClientResponse();
												try
												{
																GoogleCredential credential = GoogleCredential.FromJson(key);
																clientResponse.hasError = false;
																clientResponse.BigQueryClient = BigQueryClient.Create(projectId, credential);
												}
												catch (Exception ex)
												{
																clientResponse.hasError = true;
																clientResponse.message = ex.Message;
												}
												return clientResponse;
								}

								public async Task<BigQueryServiceResponse> ExecuteStoredProcedure(StoredProcedureData qData, List<BigQueryParameter> bqParameters)
								{
												BigQueryServiceResponse serviceResponse = new BigQueryServiceResponse();
												try
												{
																var bqClient = GetBigqueryClient(qData.key, qData.idProject);
																if (!(bqClient.hasError))
																{
																				string paramaters = "";
																				if (bqParameters is not null)
																				{
																								foreach (BigQueryParameter param in bqParameters)
																								{
																												paramaters += $",@{param.Name}";
																								}
																								paramaters = paramaters.Remove(0, 1);
																				}

																				string query = $"CALL `{qData.idProject}.{qData.dataSetName}.{qData.storedProcedureName}`({paramaters})";

																				BigQueryJob job = await bqClient.BigQueryClient.CreateQueryJobAsync(sql: query, parameters: bqParameters, options: new QueryOptions { UseQueryCache = false });

																				BigQueryResults data = await job.GetQueryResultsAsync();
																				await job.PollUntilCompletedAsync();
																				serviceResponse.hasError = false;
																				serviceResponse.BigQueryResults = data;
																}
																else
																{
																				serviceResponse.hasError = true;
																				serviceResponse.message = bqClient.message;
																}
												}
												catch (Exception ex)
												{
																serviceResponse.hasError = true;
																serviceResponse.message = ex.Message;
												}
												return serviceResponse;
								}

								public async Task<BigQueryServiceResponse> ExecuteStoredProcedureDirectMode(StoredProcedureData qData, List<BigQueryParameter> bqParameters)
								{
												BigQueryServiceResponse serviceResponse = new BigQueryServiceResponse();
												try
												{
																var bqClient = GetBigqueryClient(qData.key, qData.idProject);
																if (!(bqClient.hasError))
																{
																				string paramaters = "";
																				if (bqParameters is not null)
																				{
																								foreach (BigQueryParameter param in bqParameters)
																								{
																												paramaters += $",@{param.Name}";
																								}
																								paramaters = paramaters.Remove(0, 1);
																				}

																				string query = $"CALL `{qData.idProject}.{qData.dataSetName}.{qData.storedProcedureName}`({paramaters})";

																				var data = await bqClient.BigQueryClient.ExecuteQueryAsync(query, parameters: bqParameters);

																				serviceResponse.hasError = false;
																				serviceResponse.BigQueryResults = data;
																}
																else
																{
																				serviceResponse.hasError = true;
																				serviceResponse.message = bqClient.message;
																}
												}
												catch (Exception ex)
												{
																serviceResponse.hasError = true;
																serviceResponse.message = ex.Message;
												}

												return serviceResponse;
								}
				}
}
