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
				}
}
