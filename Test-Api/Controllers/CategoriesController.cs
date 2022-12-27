using Microsoft.AspNetCore.Mvc;
using Test_Api.Helpers;
using Test_Api.Models.ResponseModels;
using Test_Api.Models.Responses;
using Test_Api.Models.StoreModels;
using Test_Api.Repositories;
using static Test_Api.Constants.MessageSetting;

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
												MessageErrorBuilder<GenericCrud> messageErrorBuilder = new();
												try
												{
																var result = await _categoryRepository.Create(category);
																object res = result;
																return StatusCode(result.StatusCode,res);
												}
												catch (Exception ex)
												{
																var error = messageErrorBuilder.GetGenericErrorResponse(500, "Categories", "Create", "GeneralException", MessageTypes.danger.ToString(), null, ex.Message);

																return StatusCode(error.StatusCode, error);
												}
								}
								
								[HttpPost("CreateCategoryInBigQuery")]
								public async Task<ActionResult> CreateCategoryToBigQuery([FromBody] Category category)
								{
												MessageErrorBuilder<GenericCrud> messageErrorBuilder = new();
												try
												{
																var result = await _categoryRepository.CreateCategoryToBigQueryTable(category);
																object res = result;
																return StatusCode(result.StatusCode, res);
												}
												catch (Exception ex)
												{
																var error = messageErrorBuilder.GetGenericErrorResponse(500, "Categories", "InsertToBqTable", "GeneralException", MessageTypes.danger.ToString(), null, ex.Message);

																return StatusCode(error.StatusCode, error);
												}
								}

								[HttpPut("Update")]
								public async Task<ActionResult> UpdateCategory([FromBody] Category category)
								{
												MessageErrorBuilder<GenericCrud> messageErrorBuilder = new();
												try
												{
																var result = await _categoryRepository.Update(category);
																object res = result;
																return StatusCode(result.StatusCode, res);
												}
												catch (Exception ex)
												{
																var error = messageErrorBuilder.GetGenericErrorResponse(500, "Categories", "Update", "GeneralException", MessageTypes.danger.ToString(), null, ex.Message);

																return StatusCode(error.StatusCode, error);
												}
								}

								[HttpGet]
								public async Task<ActionResult> Categories()
								{
												MessageErrorBuilder<Category> messageErrorBuilder = new();
												try
												{
																var result = await _categoryRepositoryGet.GetAll();
																object res = result;
																return StatusCode(result.StatusCode, res);
												}
												catch (Exception ex)
												{
																var error = messageErrorBuilder.GetGenericErrorResponse(500, "Categories", "GetAll", "GeneralException", MessageTypes.danger.ToString(), null, ex.Message);

																return StatusCode(error.StatusCode, error);
												}
								}


								[HttpGet("JsonFromBigQuery")]
								public async Task<ActionResult> CategoriesFromBigQuery()
								{
												MessageErrorBuilder<Category> messageErrorBuilder = new();
												try
												{
																var result = await _categoryRepositoryGet.GetCategoriesFromBigQuery();
																object res = result;
																return StatusCode(result.StatusCode, res);
												}
												catch (Exception ex)
												{
																var error = messageErrorBuilder.GetGenericErrorResponse(500, "Categories", "GetAllBq", "GeneralException", MessageTypes.danger.ToString(), null, ex.Message);

																return StatusCode(error.StatusCode, error);
												}
								}


								[HttpGet("{id}")]
								public async Task<ActionResult> CategoriesById(string id)
								{
												MessageErrorBuilder<Category> messageErrorBuilder = new();
												try
												{
																var result = await _categoryRepositoryGet.GetById(id);
																object res = result;
																return StatusCode(result.StatusCode, res);
												}
												catch (Exception ex)
												{
																var error = messageErrorBuilder.GetGenericErrorResponse(500, "Categories", "GetById", "GeneralException", MessageTypes.danger.ToString(), null, ex.Message);

																return StatusCode(error.StatusCode, error);
												}
								}
				}
}
