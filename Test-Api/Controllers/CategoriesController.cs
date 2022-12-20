using Microsoft.AspNetCore.Mvc;
using Test_Api.Models.ResponseModels;
using Test_Api.Models.Responses;
using Test_Api.Models.StoreModels;
using Test_Api.Repositories;

namespace Test_Api.Controllers
{
				[ApiController]
				[Route("api/categories")]
				public class CategoriesController : ControllerBase
				{
								private readonly ICategoryRepository<GenericCrud> _categoryRepository;
								private readonly ICategoryRepository<Category> _categoryRepositoryGet;

								public CategoriesController(ICategoryRepository<GenericCrud> categoryRepository,ICategoryRepository<Category> categoryRepositoryGet)
								{
												_categoryRepository = categoryRepository;
												_categoryRepositoryGet = categoryRepositoryGet;
								}
							
								[HttpPost("Create")]
								public async Task<ActionResult> CreateCategory([FromBody] Category category)
								{
												object res = new();
												try
												{
																var result = await _categoryRepository.Create(category);
																res = result;
																return StatusCode(result.StatusCode,res);
												}
												catch (Exception ex)
												{
																var badResult = new GenericResponse<string>();
																badResult.Success = false;
																badResult.StatusCode = 500;
																badResult.Description = ex.Message;
																return StatusCode(500, badResult);
												}
								}

								[HttpPut("Update")]
								public async Task<ActionResult> UpdateCategory([FromBody] Category category)
								{
												object res = new();
												try
												{
																var result = await _categoryRepository.Update(category);
																res = result;
																return StatusCode(result.StatusCode, res);
												}
												catch (Exception ex)
												{
																var badResult = new GenericResponse<string>();
																badResult.Success = false;
																badResult.StatusCode = 500;
																badResult.Description = ex.Message;
																return StatusCode(500, badResult);
												}
								}

								[HttpGet]
								public async Task<ActionResult> Categories()
								{
												object res = new();
												try
												{
																var result = await _categoryRepositoryGet.GetAll();
																res = result;
																return StatusCode(result.StatusCode, res);
												}
												catch (Exception ex)
												{
																var badResult = new GenericResponse<string>();
																badResult.Success = false;
																badResult.StatusCode = 500;
																badResult.Description = ex.Message;
																return StatusCode(500, badResult);
												}
								}

								[HttpGet("JsonFromBigQuery")]
								public async Task<ActionResult> CategoriesFromBigQuery()
								{
												object res = new();
												try
												{
																var result = await _categoryRepositoryGet.GetCategoriesFromBigQuery();
																res = result;
																return StatusCode(result.StatusCode, res);
												}
												catch (Exception ex)
												{
																var badResult = new GenericResponse<string>();
																badResult.Success = false;
																badResult.StatusCode = 500;
																badResult.Description = ex.Message;
																return StatusCode(500, badResult);
												}
								}


								[HttpGet("{id}")]
								public async Task<ActionResult> CategoriesById(string id)
								{
												object res = new();
												try
												{
																var result = await _categoryRepositoryGet.GetById(id);
																res = result;
																return StatusCode(result.StatusCode, res);
												}
												catch (Exception ex)
												{
																var badResult = new GenericResponse<string>();
																badResult.Success = false;
																badResult.StatusCode = 500;
																badResult.Description = ex.Message;
																return StatusCode(500, badResult);
												}
								}

				}
}
