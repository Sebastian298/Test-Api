using Google.Cloud.BigQuery.V2;
using Test_Api.Models.Queries;
using Test_Api.Models.ResponseModels;

namespace Test_Api.Services
{
				public interface IBigqueryService
				{
								BigQueryClientResponse GetBigqueryClient(string key, string projectId);
								Task<BigQueryServiceResponse> ExecuteStoredProcedure(StoredProcedureData qData, List<BigQueryParameter> bqParameters);
								Task<BigQueryServiceResponse> ExecuteStoredProcedureDirectMode(StoredProcedureData qData, List<BigQueryParameter> bqParameters);
				}
}
