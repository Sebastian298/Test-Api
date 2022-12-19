using Microsoft.AspNetCore.Mvc;
using Test_Api.Models.ResponseModels;
using Test_Api.Repositories;

namespace Test_Api.Controllers
{
				[ApiController]
				[Route("api/[controller]")]
				public class DalcecWebServicesController : ControllerBase
				{
								private readonly IDalcecRepository _dalcecRepository;

								public DalcecWebServicesController(IDalcecRepository dalcecRepository)
								{
												_dalcecRepository = dalcecRepository;
								}
								[HttpGet("{facData}")]
								public async Task<ActionResult> FacturasByFacData(string facData)
								{
												object res = new();
												try
												{
																var result = await _dalcecRepository.GetFacturasByFacData(facData);
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
