using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;
using Test_Api.Models.ResponseModels;
using Test_Api.Models.StoreModels;
using Test_Api.Repositories;

namespace Test_Api.Controllers
{
				[ApiController]
				[Route("api/products")]
				public class ProductsController : ControllerBase
				{
								private readonly IFakeStoreRepository _fakeStoreRepository;

								public ProductsController(IFakeStoreRepository fakeStoreRepository)
								{
												_fakeStoreRepository = fakeStoreRepository;
								}

								[HttpGet]
								public async Task<ActionResult> GetAllProducts()
								{
												object res = new();
												try
												{
																var result = await _fakeStoreRepository.GetAllProducts();
																res = result;
																return StatusCode(result.StatusCode, res);
												}
												catch (Exception ex)
												{
																var badResult = new GenericResponse<string>();
																badResult.Success = false;
																badResult.StatusCode = 500;
																//badResult.Description = ex.Message;
																return StatusCode(500, badResult);
												}
								}

								[HttpGet("{id:int}")]
								public async Task<ActionResult> GetProductrById(int id)
								{
												object res = new();
												try
												{
																var result = await _fakeStoreRepository.GetProductById(id);
																res = result;
																return StatusCode(result.StatusCode, res);
												}
												catch (Exception ex)
												{
																var badResult = new GenericResponse<string>();
																badResult.Success = false;
																badResult.StatusCode = 500;
																//badResult.Description = ex.Message;
																return StatusCode(500, badResult);
												}
								}
								[HttpPost("Create")]
								public async Task<ActionResult> AddProduct([FromBody] Product product)
								{
												object res = new();
												try
												{
																var result = await _fakeStoreRepository.AddProduct(product);
																res = result;
																return StatusCode(result.StatusCode, res);
												}
												catch (Exception ex)
												{
																var badResult = new GenericResponse<string>();
																badResult.Success = false;
																badResult.StatusCode = 500;
																//badResult.Description = ex.Message;
																return StatusCode(500, badResult);
												}
								}

								[HttpPut("Update/{id:int}")]
								public async Task<ActionResult> UpdateProduct(int id, [FromBody] Product product)
								{
												object res = new();
												try
												{
																var result = await _fakeStoreRepository.UpdateProduct(id, product);
																res = result;
																return StatusCode(result.StatusCode, res);
												}
												catch (Exception ex)
												{
																var badResult = new GenericResponse<string>();
																badResult.Success = false;
																badResult.StatusCode = 500;
																//badResult.Description = ex.Message;
																return StatusCode(500, badResult);
												}
								}

								[HttpDelete("{id:int}")]
								public async Task<ActionResult> DeleteProduct(int id)
								{
												object res = new();
												try
												{
																var result = await _fakeStoreRepository.DeleteProduct(id);
																res = result;
																return StatusCode(result.StatusCode, res);
												}
												catch (Exception ex)
												{
																var badResult = new GenericResponse<string>();
																badResult.Success = false;
																badResult.StatusCode = 500;
																//badResult.Description = ex.Message;
																return StatusCode(500, badResult);
												}
								}
				}
}
