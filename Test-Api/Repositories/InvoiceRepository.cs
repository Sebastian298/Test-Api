using Newtonsoft.Json.Linq;
using Test_Api.Models.ResponseModels;
using Test_Api.Models.StoreModels;
using Test_Api.Services;

namespace Test_Api.Repositories
{
				public class InvoiceRepository : IInvoiceRepository
				{
								private readonly IConfiguration _configuration;
								private readonly IHttpCrudService _httpCrudService;

								public InvoiceRepository(IConfiguration configuration,IHttpCrudService httpCrudService)
								{
												_configuration = configuration;
												_httpCrudService = httpCrudService;
								}
								public async Task<GenericResponse<List<JObject>>> GetInvoiceByDate(string date)
								{
												string url = $"{_configuration["WebServices:Dalcec:GetFacData:url"]}{date}";

												HttpServiceResponse response = await _httpCrudService.GetAsync<JObject>(url,true);
												if (!response.HasError)
												{
																return new GenericResponse<List<JObject>>()
																{
																				Success = true,
																				StatusCode = 200,
																				Content = response.Results
																};
												}
												else
												{
																return new GenericResponse<List<JObject>>()
																{
																				StatusCode = 500,
																				Description = response.Message
																};
												}
								}
				}
}
