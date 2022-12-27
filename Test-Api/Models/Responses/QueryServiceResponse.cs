using Google.Cloud.BigQuery.V2;

namespace Test_Api.Models.ResponseModels
{
				public class QueryServiceResponse
				{
								public bool HasError { get; set; } = false;
								public string Message { get; set; }
								public dynamic Results { get; set; }
				}

				public class BigQueryServiceResponse
				{
								public bool hasError { get; set; } = false;
								public string message { get; set; }
								public BigQueryResults BigQueryResults { get; set; }
				}

				public class BigQueryClientResponse
				{
								public bool hasError { get; set; } = false;
								public string message { get; set; }
								public BigQueryClient BigQueryClient { get; set; }
				}

				public class HttpServiceResponse
				{
								public bool HasError { get; set; }
								public string Message { get; set; }
								public dynamic Results { get; set; }
				}
}
