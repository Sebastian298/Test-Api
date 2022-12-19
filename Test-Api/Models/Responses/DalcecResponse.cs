namespace Test_Api.Models.Responses
{
				public class DalcecResponse
				{
								public bool HasError { get; set; } = false;
								public string Message { get; set; }
								public dynamic Results { get; set; }
				}
}
