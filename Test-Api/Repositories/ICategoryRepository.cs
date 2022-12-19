using Test_Api.Models.ResponseModels;
using Test_Api.Models.Responses;
using Test_Api.Models.StoreModels;

namespace Test_Api.Repositories
{
				public interface ICategoryRepository<T>
				{
								Task<GenericResponse<List<T>>> Create(Category category);
								Task<GenericResponse<List<T>>> Update(Category category);
								Task<GenericResponse<List<T>>> GetAll();
								Task<GenericResponse<T>> GetById(string id);
				}
}