using Dapper;
using System.Data;
using System.Xml.Linq;
using Test_Api.Models.Queries;
using Test_Api.Models.ResponseModels;

namespace Test_Api.Services
{
				public class DapperService : IDapperService
				{
								private readonly DapperContext _context;

								public DapperService(DapperContext context)
								{
												_context = context;
								}

								public async Task<QueryServiceResponse> ActionsFromStoredProcedureToModel<T>(StoredProcedureData qData, DynamicParameters parameters,bool hasArray = false)
								{
												string spName = $"{qData.schemaName}.{qData.storedProcedureName}";
												try
												{
																using (IDbConnection connection = _context.CreateConnection(qData.idConnectionString))
																{
																				dynamic response;
																				if (hasArray)
																				{
																								response = await connection.QueryAsync<T>(spName, parameters, commandType: CommandType.StoredProcedure);
																				}
																				else
																				{
																								response = await connection.QueryFirstAsync<T>(spName, parameters, commandType: CommandType.StoredProcedure);
																				}

																				return new QueryServiceResponse
																				{
																								HasError = false,
																								Message = "",
																								Results = response
																				};
																}
												}
												catch (Exception ex)
												{

																return new QueryServiceResponse { HasError = true, Message = ex.Message, Results = null }; ;
												}
								}

								public async Task<QueryServiceResponse> GetDataFromStoredProcedureInJsonString(StoredProcedureData qData, DynamicParameters parameters)
								{
												string sp_Name = $"{qData.schemaName}.{qData.storedProcedureName}";

												try
												{
																using (var connection = _context.CreateConnection(qData.idConnectionString))
																{
																				var dapperReader = await connection.QueryAsync<string>(sp_Name, parameters, commandType: CommandType.StoredProcedure);
																				var jsonResult = string.Join("", dapperReader);

																				return new QueryServiceResponse { HasError = false, Message = null, Results = jsonResult };
																}
												}
												catch (Exception ex)
												{
																return new QueryServiceResponse { HasError = true, Message = ex.Message, Results = null }; ;
												}
								}
				}
}
