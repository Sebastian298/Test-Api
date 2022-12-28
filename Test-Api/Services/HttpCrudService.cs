using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Test_Api.Models.ResponseModels;
using Test_Api.Models.Responses;
using Microsoft.AspNetCore.Authentication;
using System.Text;

namespace Test_Api.Services
{
				public class HttpCrudService : IHttpCrudService
				{
								private readonly HttpClient _httpClient;

								public HttpCrudService(HttpClient httpClient)
								{
												_httpClient = httpClient;
								}

								public async Task<HttpServiceResponse> GetAsync<T>(string url, bool hasArray = false, string accessToken = "")
								{
												try
												{
																if (!(string.IsNullOrEmpty(accessToken)))
																{
																				_httpClient.DefaultRequestHeaders.Clear();
																				_httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", accessToken);
																}

															 HttpResponseMessage response = await _httpClient.GetAsync(url);
																if (response.IsSuccessStatusCode)
																{
																				var results = await response.Content.ReadAsStringAsync();
																				dynamic json;
																				if (hasArray)
																								json = JsonConvert.DeserializeObject<List<T>>(results);
																				else
																								json = JsonConvert.DeserializeObject<T>(results);

																				return new HttpServiceResponse
																				{
																								HasError = false,
																								Message = "",
																								Results = json
																				};
																}
																else
																{
																				var results = $"EndPoint: {url}, StatusCode: {response.StatusCode}, Message: {await response.Content.ReadAsStringAsync()}";
																				return new HttpServiceResponse { HasError = true, Message = results };
																}
												}
												catch (Exception ex)
												{

																return new HttpServiceResponse { HasError = true, Message = ex.Message, Results = null }; ;
												}
								}

								public async Task<HttpServiceResponse> GetAsync(string url, string accessToken = "")
								{
												try
												{
																if (!(string.IsNullOrEmpty(accessToken)))
																{
																				_httpClient.DefaultRequestHeaders.Clear();
																				_httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", accessToken);
																}

																HttpResponseMessage response = await _httpClient.GetAsync(url);
																if (response.IsSuccessStatusCode)
																{
																				var results = await response.Content.ReadAsStringAsync();
																				
																				dynamic json = JsonConvert.DeserializeObject(results);

																				return new HttpServiceResponse
																				{
																								HasError = false,
																								Message = "",
																								Results = json
																				};
																}
																else
																{
																				var results = $"EndPoint: {url}, StatusCode: {response.StatusCode}, Message: {await response.Content.ReadAsStringAsync()}";
																				return new HttpServiceResponse { HasError = true, Message = results };
																}
												}
												catch (Exception ex)
												{

																return new HttpServiceResponse { HasError = true, Message = ex.Message, Results = null }; ;
												}
								}

								public async Task<HttpServiceResponse> PostAsync(string url,dynamic objRequest, string type, string accessToken = "")
								{
												try
												{
																if (!(string.IsNullOrEmpty(accessToken)))
																{
																				_httpClient.DefaultRequestHeaders.Clear();
																				_httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", accessToken);
																}
																objRequest = JsonConvert.SerializeObject(objRequest);
																var httpContent = new StringContent(objRequest, Encoding.UTF8, type);
																HttpResponseMessage response = await _httpClient.PostAsync(url, httpContent);
																if (response.IsSuccessStatusCode)
																{
																				var results = await response.Content.ReadAsStringAsync();

																				dynamic json = JsonConvert.DeserializeObject(results);

																				return new HttpServiceResponse
																				{
																								HasError = false,
																								Message = "",
																								Results = json
																				};
																}
																else
																{
																				var results = $"EndPoint: {url}, StatusCode: {response.StatusCode}, Message: {await response.Content.ReadAsStringAsync()}";
																				return new HttpServiceResponse { HasError = true, Message = results };
																}
												}
												catch (Exception ex)
												{
																return new HttpServiceResponse { HasError = true, Message = ex.Message, Results = null }; ;
												}
								}
								 
								public async Task<HttpServiceResponse> PutAsync(string url, dynamic objRequest, string type, string accessToken = "")
								{
												try
												{
																if (!(string.IsNullOrEmpty(accessToken)))
																{
																				_httpClient.DefaultRequestHeaders.Clear();
																				_httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", accessToken);
																}

																objRequest = JsonConvert.SerializeObject(objRequest);
																var httpContent = new StringContent(objRequest, Encoding.UTF8, type);
																HttpResponseMessage response = await _httpClient.PutAsync(url, httpContent);
																if (response.IsSuccessStatusCode)
																{
																				var results = await response.Content.ReadAsStringAsync();

																				dynamic json = JsonConvert.DeserializeObject(results);

																				return new HttpServiceResponse
																				{
																								HasError = false,
																								Message = "",
																								Results = json
																				};
																}
																else
																{
																				var results = $"EndPoint: {url}, StatusCode: {response.StatusCode}, Message: {await response.Content.ReadAsStringAsync()}";
																				return new HttpServiceResponse { HasError = true, Message = results };
																}

												}
												catch (Exception)
												{

																throw;
												}
								}

								public async Task<HttpServiceResponse> DeleteAsync(string url, string accessToken="")
								{
												try
												{
																if (!(string.IsNullOrEmpty(accessToken)))
																{
																				_httpClient.DefaultRequestHeaders.Clear();
																				_httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", accessToken);
																}

																HttpResponseMessage response = await _httpClient.DeleteAsync(url);
																if (response.IsSuccessStatusCode)
																{
																				var results = await response.Content.ReadAsStringAsync();
																				dynamic json = JsonConvert.DeserializeObject(results);
																				return new HttpServiceResponse
																				{
																								HasError = false,
																								Message = "",
																								Results = json
																				};
																}
																else
																{
																				var results = $"EndPoint: {url}, StatusCode: {response.StatusCode}, Message: {await response.Content.ReadAsStringAsync()}";
																				return new HttpServiceResponse { HasError = true, Message = results };
																}
												}
												catch (Exception ex)
												{

																return new HttpServiceResponse { HasError = true, Message = ex.Message, Results = null }; ;
												}
								}
				}
}