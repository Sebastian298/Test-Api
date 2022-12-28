using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;
using Test_Api.Helpers;
using Test_Api.Models.ResponseModels;
using Test_Api.Models.Responses;
using Test_Api.Models.StoreModels;
using Test_Api.Repositories;
using static Test_Api.Constants.MessageSetting;

namespace Test_Api.Controllers
{
				[ApiController]
				[Route("api/products")]
				public class ProductsController : ControllerBase
				{
								private readonly IProductRepository _productRepository;

								public ProductsController(IProductRepository productRepository)
								{
												_productRepository = productRepository;
								}

								[HttpGet]
								public async Task<ActionResult> GetAllProducts()
								{
												MessageErrorBuilder<Product> messageErrorBuilder = new();
												try
												{
																var result = await _productRepository.GetAllProducts();
																object res = result;
																return StatusCode(result.StatusCode, res);
												}
												catch (Exception ex)
												{
																var error = messageErrorBuilder.GetGenericErrorResponse(500, "Products", "GetAll", "GeneralException", MessageTypes.danger.ToString(), null, ex.Message);

																return StatusCode(error.StatusCode, error);
												}
								}

								[HttpGet("{id:int}")]
								public async Task<ActionResult> GetProductById(int id)
								{
												MessageErrorBuilder<dynamic> messageErrorBuilder = new();
												try
												{
																var result = await _productRepository.GetProductById(id);
																object res = result;
																return StatusCode(result.StatusCode, res);
												}
												catch (Exception ex)
												{
																var error = messageErrorBuilder.GetGenericErrorResponse(500, "Products", "GetById", "GeneralException", MessageTypes.danger.ToString(), null, ex.Message);

																return StatusCode(error.StatusCode, error);
												}
								}

								[HttpPost("Create")]
								public async Task<ActionResult> AddProduct([FromBody] Product product)
								{
												MessageErrorBuilder<dynamic> messageErrorBuilder = new();
												try
												{
																var result = await _productRepository.AddProduct(product);
																object res = result;
																return StatusCode(result.StatusCode, res);
												}
												catch (Exception ex)
												{
																var error = messageErrorBuilder.GetGenericErrorResponse(500, "Products", "Add", "GeneralException", MessageTypes.danger.ToString(), null, ex.Message);

																return StatusCode(error.StatusCode, error);
												}
								}

								[HttpPut("Update/{id:int}")]
								public async Task<ActionResult> UpdateProduct(int id, [FromBody] Product product)
								{
												MessageErrorBuilder<dynamic> messageErrorBuilder = new();
												try
												{
																var result = await _productRepository.UpdateProduct(id, product);
																object res = result;
																return StatusCode(result.StatusCode, res);
												}
												catch (Exception ex)
												{
																var error = messageErrorBuilder.GetGenericErrorResponse(500, "Products", "Update", "GeneralException", MessageTypes.danger.ToString(), null, ex.Message);

																return StatusCode(error.StatusCode, error);
												}
								}

								[HttpDelete("{id:int}")]
								public async Task<ActionResult> DeleteProduct(int id)
								{
												MessageErrorBuilder<dynamic> messageErrorBuilder = new();
												try
												{
																
																var result = await _productRepository.DeleteProduct(id);
																object res = result;
																return StatusCode(result.StatusCode, res);
												}
												catch (Exception ex)
												{
																var error = messageErrorBuilder.GetGenericErrorResponse(500, "Products", "Delete", "GeneralException", MessageTypes.danger.ToString(), null, ex.Message);

																return StatusCode(error.StatusCode, error);
												}
								}
				}
}
