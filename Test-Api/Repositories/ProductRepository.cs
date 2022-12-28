using Test_Api.Helpers;
using Test_Api.Models.ResponseModels;
using Test_Api.Models.Responses;
using Test_Api.Models.StoreModels;
using Test_Api.Services;
using static Test_Api.Constants.MessageSetting;

namespace Test_Api.Repositories
{
				public class ProductRepository : IProductRepository
				{
								private readonly IConfiguration _configuration;
								private readonly IHttpCrudService _httpCrudService;
								private readonly MessageErrorBuilder<GenericCrud> messageErrorBuilders = new MessageErrorBuilder<GenericCrud>();

								public ProductRepository(IConfiguration configuration, IHttpCrudService httpCrudService)
								{
												_configuration = configuration;
												_httpCrudService = httpCrudService;
								}

								public async Task<GenericResponse<List<Product>>> GetAllProducts()
								{
												string url = _configuration["WebServices:FakeStoreApi:GetAllProducts:url"];
												HttpServiceResponse response = await _httpCrudService.GetAsync<Product>(url, true);
												if (!response.HasError)
												{
																return new GenericResponse<List<Product>>()
																{
																				Success = true,
																				StatusCode = 200,
																				Content = response.Results
																};
												}
												else
												{
																GenericResponseData messages = messageErrorBuilders.GetMessageList("Products", "GetAll", "GeneralException", MessageTypes.danger.ToString(), null, response.Message);

																return new GenericResponse<List<Product>>()
																{
																				Success = false,
																				StatusCode = 500,
																				Content = new List<Product>(),
																				Messages = messages
																};
												}
								}

								public async Task<GenericResponse<dynamic>> GetProductById(int id)
								{
												string url = $"{_configuration["WebServices:FakeStoreApi:GetAllProducts:url"]}/{id}";
												HttpServiceResponse response = await _httpCrudService.GetAsync(url);
												if (!response.HasError)
												{
																if (response.Results is not null)
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
																				GenericResponseData messages = messageErrorBuilders.GetMessageList("Products", "GetById", "EmptyResponse", MessageTypes.info.ToString(), null, response.Message);

																				return new GenericResponse<dynamic>()
																				{
																								Success = false,
																								StatusCode = 200,
																								Messages = messages
																				};
																}
																
												}
												else
												{
																GenericResponseData messages = messageErrorBuilders.GetMessageList("Products", "GetById", "GeneralException", MessageTypes.danger.ToString(), null, response.Message);

																return new GenericResponse<dynamic>()
																{
																				Success = false,
																				StatusCode = 500,
																				Messages = messages
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
																GenericResponseData messages = messageErrorBuilders.GetMessageList("Products", "Add", "GeneralException", MessageTypes.danger.ToString(), null, response.Message);

																return new GenericResponse<dynamic>()
																{
																				Success = false,
																				StatusCode = 500,
																				Messages = messages
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
																GenericResponseData messages = messageErrorBuilders.GetMessageList("Products", "Update", "GeneralException", MessageTypes.danger.ToString(), null, response.Message);

																return new GenericResponse<dynamic>()
																{
																				Success = false,
																				StatusCode = 500,
																				Messages = messages
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
																GenericResponseData messages = messageErrorBuilders.GetMessageList("Products", "Delete", "GeneralException", MessageTypes.danger.ToString(), null, response.Message);

																return new GenericResponse<dynamic>()
																{
																				Success = false,
																				StatusCode = 500,
																				Messages = messages
																};
												}
								}
				}
}
