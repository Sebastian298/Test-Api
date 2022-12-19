using Dapper;
using Test_Api.Models.Queries;
using Test_Api.Models.ResponseModels;

namespace Test_Api.Services
{
				public interface IDapperService
				{
								Task <QueryServiceResponse> ActionsFromStoredProcedureToModel<T>(StoredProcedureData qData,DynamicParameters parameters,bool hasArray=false);
								Task<QueryServiceResponse> GetDataFromStoredProcedureInJsonString(StoredProcedureData qData, DynamicParameters parameters);
				}
}
