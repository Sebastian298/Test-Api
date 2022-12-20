using Google.Cloud.BigQuery.V2;

namespace Test_Api.Helpers
{
				public class BigQueryHelpers
				{
								public static BigQueryDbType GetDataType(string type)
								{
												switch (type.ToLower().Trim())
												{
																case "string":
																				return BigQueryDbType.String;
																case "integer":
																case "int":
																case "int32":
																case "int64":
																				return BigQueryDbType.Int64;
																case "float":
																case "float32":
																case "float64":
																				return BigQueryDbType.Float64;
																case "Bytes":
																				return BigQueryDbType.Bytes;
																case "boolean":
																case "bool":
																case "bit":
																				return BigQueryDbType.Bool;
																case "date":
																				return BigQueryDbType.Date;
																case "datetime":
																				return BigQueryDbType.DateTime;
																case "numeric":
																				return BigQueryDbType.Numeric;
																case "time":
																				return BigQueryDbType.Time;
																case "timestamp":
																				return BigQueryDbType.Timestamp;
																case "geography":
																				return BigQueryDbType.Geography;
																case "struct":
																				return BigQueryDbType.Struct;
																case "array":
																				return BigQueryDbType.Array;
																default:
																				return BigQueryDbType.String;
												}
								}

								public static string ConcatParameterValues(List<string> values)
								{
												string valuesConcat = "";
												foreach (string value in values)
												{
																valuesConcat += $"|{value}";
												}
												return valuesConcat.Remove(0, 1);
								}
				}
}
