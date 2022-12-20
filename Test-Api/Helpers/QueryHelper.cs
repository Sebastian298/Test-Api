using Test_Api.Models.Queries;

namespace Test_Api.Helpers
{
				public class QueryHelper
				{
								public static StoredProcedureData GetConfigurationStoredProcedure(IConfiguration configuration,string repositoryKey,string office=null)
								{
												string connectionID = configuration[$"{repositoryKey}:SQLConnectionID"];
												StoredProcedureData storedProcedureData = new StoredProcedureData();
												storedProcedureData.idConnectionString = connectionID;
												storedProcedureData.dataSetName = configuration[$"{repositoryKey}:SQLDatabaseName"];
												storedProcedureData.schemaName = configuration[$"{repositoryKey}:SQLSchemaName"];
												storedProcedureData.storedProcedureName = configuration[$"{repositoryKey}:SQLStoredProcedureName"];
												storedProcedureData.jsonRowsColumnName = configuration[$"{repositoryKey}:JsonRowsColumnName"];
												storedProcedureData.optionParameter = configuration[$"{repositoryKey}:OptionParameter"];
												storedProcedureData.defaultParameter = configuration[$"{repositoryKey}:defaultParameter"];
												return storedProcedureData;
								}

								public static StoredProcedureData GetBigQueryStoredProcedureData(IConfiguration _configuration, string queryId)
								{
												string connectionID = _configuration[$"{queryId}:BigQueryConnectionID"];

												StoredProcedureData queryData = new StoredProcedureData();
												queryData.idProject = _configuration[$"ConnectionStrings:BigQuerySettings:JsonKeys:{connectionID}:IdProyect"];
												queryData.key = _configuration[$"ConnectionStrings:BigQuerySettings:JsonKeys:{connectionID}:key"];
												queryData.dataSetName = _configuration[$"{queryId}:BigQueryDatabaseName"];
												queryData.storedProcedureName = _configuration[$"{queryId}:BigQueryStoredProcedureName"];
												queryData.jsonRowsColumnName = _configuration[$"{queryId}:JsonRowsColumnName"];
												queryData.optionParameter = _configuration[$"{queryId}:OptionParameter"];
												queryData.defaultParameter = _configuration[$"{queryId}:defaultParameter"];
												return queryData;
								}
				}
}
