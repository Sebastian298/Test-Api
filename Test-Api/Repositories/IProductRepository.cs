using Test_Api.Models.ResponseModels;
using Test_Api.Models.StoreModels;

namespace Test_Api.Repositories
{
				public interface IProductRepository<T> where T : class
				{
								Task<GenericResponse<List<T>>> Create(Category category);
								Task<GenericResponse<List<T>>> Update(Category category);
								Task<GenericResponse<List<T>>> GetAll();
								Task<GenericResponse<List<T>>> GetById(string id);
				}
}
