using Test_Api.Models.ResponseModels;
using Test_Api.Models.StoreModels;

namespace Test_Api.Repositories
{
				public interface IFakeStoreRepository
				{
								Task<GenericResponse<List<Product>>> GetAllProducts();
								Task<GenericResponse<dynamic>> GetProductById(int id);
								Task<GenericResponse<dynamic>> AddProduct(Product product);
								Task<GenericResponse<dynamic>> UpdateProduct(int productId,Product product);
								Task<GenericResponse<dynamic>> DeleteProduct(int productId);
				}
}
