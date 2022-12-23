using Microsoft.AspNetCore.Mvc;
using Test_Api.Models.ResponseModels;
using Test_Api.Repositories;

namespace Test_Api.Controllers
{
				[ApiController]
				[Route("api/invoices")]
				public class InvoicesController : ControllerBase
				{
								private readonly IInvoiceRepository _invoiceRepository;

								public InvoicesController(IInvoiceRepository invoiceRepository)
								{
												_invoiceRepository = invoiceRepository;
								}

								[HttpGet("InvoiceByDate/{date}")]
								public async Task<ActionResult> GetInvoiceByDate(string date)
								{
												object res = new();
												try
												{
																var result = await _invoiceRepository.GetInvoiceByDate(date);
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
