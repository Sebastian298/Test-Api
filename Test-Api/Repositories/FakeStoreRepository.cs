using Test_Api.Models.ResponseModels;
using Test_Api.Models.StoreModels;
using Test_Api.Services;

namespace Test_Api.Repositories
{
				public class FakeStoreRepository : IFakeStoreRepository
				{
								private readonly IConfiguration _configuration;
								private readonly IHttpCrudService _httpCrudService;

								public FakeStoreRepository(IConfiguration configuration,IHttpCrudService httpCrudService)
								{
											  _configuration = configuration;
												_httpCrudService = httpCrudService;
								}

								public async Task<GenericResponse<List<Product>>> GetAllProducts()
								{
												string url = _configuration["WebServices:FakeStoreApi:GetAllProducts:url"];
												HttpServiceResponse reponse = await _httpCrudService.GetAsync<Product>(url,true);
												if (!reponse.HasError)
												{
																return new GenericResponse<List<Product>>()
																{
																				Success = true,
																				StatusCode = 200,
																				Content = reponse.Results
																};
												}
												else
												{
																return new GenericResponse<List<Product>>()
																{
																				StatusCode = 500,
																				Description = reponse.Message
																};
												}
								}

								public async Task<GenericResponse<dynamic>> GetProductById(int id)
								{
												string url = $"{_configuration["WebServices:FakeStoreApi:GetAllProducts:url"]}/{id}";
												HttpServiceResponse response = await _httpCrudService.GetAsync(url);
												if (!response.HasError)
												{
																return new GenericResponse<dynamic>()
																{
																				Success = true,
																				StatusCode = 200,
																				Content = response.Results
																};
												}
												else
												{
																return new GenericResponse<dynamic>()
																{
																				StatusCode = 500,
																				Description = response.Message
																};
												}
								}

								public async Task<GenericResponse<dynamic>> AddProduct(Product product)
								{
												string url = _configuration["WebServices:FakeStoreApi:AddProduct:url"];
												HttpServiceResponse response = await _httpCrudService.PostAsync(url, product, "application/json");
												if (!response.HasError)
												{
																return new GenericResponse<dynamic>()
																{
																				Success = true,
																				StatusCode = 200,
																				Content = response.Results
																};
												}
												else
												{
																return new GenericResponse<dynamic>()
																{
																				StatusCode = 500,
																				Description = response.Message
																}; 
												}
								}

								public async Task<GenericResponse<dynamic>> UpdateProduct(int productId, Product product)
								{
												string url = $"{_configuration["WebServices:FakeStoreApi:UpdateProduct:url"]}/{productId}";

												HttpServiceResponse response = await _httpCrudService.PutAsync(url, product, "application/json");
												if (!response.HasError)
												{
																return new GenericResponse<dynamic>()
																{
																				Success = true,
																				StatusCode = 200,
																				Content = response.Results
																};
												}
												else
												{
																return new GenericResponse<dynamic>()
																{
																				StatusCode = 500,
																				Description = response.Message
																};
												}
								}

								public async Task<GenericResponse<dynamic>> DeleteProduct(int productId)
								{
												string url = $"{_configuration["WebServices:FakeStoreApi:DeleteProduct:url"]}/{productId}";

												HttpServiceResponse response = await _httpCrudService.DeleteAsync(url);
												if (!response.HasError)
												{
																return new GenericResponse<dynamic>()
																{
																				Success = true,
																				StatusCode = 200,
																				Content = response.Results
																};
												}
												else
												{
																return new GenericResponse<dynamic>()
																{
																				StatusCode = 500,
																				Description = response.Message
																};
												}
								}
				}
}
