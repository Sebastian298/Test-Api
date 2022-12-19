namespace Test_Api.Models.Queries
{
				public class QueryConfigurationData
				{
								public string idConnectionString { set; get; }
								public string server { set; get; }
								public string idProject { set; get; }
								public string key { set; get; }
								public string dataSetName { set; get; }
								public string schemaName { set; get; }
								public string jsonRowsColumnName { set; get; }
								public string optionParameter { set; get; }
								public string defaultParameter { set; get; }
				}

				public class StoredProcedureData : QueryConfigurationData
				{
								public string storedProcedureName { set; get; }
				}

				public class QueryData : QueryConfigurationData
				{
								public string QueryString { set; get; }
				}
}
