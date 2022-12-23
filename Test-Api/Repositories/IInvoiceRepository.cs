using Newtonsoft.Json.Linq;
using Test_Api.Models.ResponseModels;

namespace Test_Api.Repositories
{
				public interface IInvoiceRepository
				{
								Task<GenericResponse<List<JObject>>> GetInvoiceByDate(string date);
				}
}
