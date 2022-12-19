using Test_Api.Models.Responses;

namespace Test_Api.Services
{
				public interface IDalcecService
				{
								Task<DalcecResponse> GetRowsByFacData(string facData);
				}
}
