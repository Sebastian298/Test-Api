namespace Test_Api.Models.ResponseModels
{
				public class GenericResponseData
				{
								public string Type { get; set; }
								public string Title { get; set; }
								public string Message { get; set; }
								public string InnerException { get; set; }
				}

				public class GenericResponse<T>
				{
								public bool Success { get; set; }
								public int StatusCode { get; set; }
								public T Content { get; set; }
								public GenericResponseData Messages { get; set; }
				}
}
