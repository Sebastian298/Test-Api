using Test_Api.Models.ResponseModels;
using Test_Api.Models.StoreModels;

namespace Test_Api.Services
{
				public interface IHttpCrudService
				{
								Task<HttpServiceResponse> GetAsync<T>(string url,bool hasArray=false,string accessToken = "");
								Task<HttpServiceResponse> GetAsync(string url, string accessToken = "");
								Task<HttpServiceResponse> PostAsync(string url,dynamic objRequest,string type,string accessToken = "");
								Task<HttpServiceResponse> PutAsync(string url, dynamic objRequest, string type, string accessToken = "");
								Task<HttpServiceResponse> DeleteAsync(string url, string accessToken="");
				}
}
