using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Test_Api.Helpers;
using Test_Api.Models.ResponseModels;
using Test_Api.Models.Responses;
using Test_Api.Repositories;
using static Test_Api.Constants.MessageSetting;

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
												MessageErrorBuilder<JObject> messageErrorBuilder = new();
												try
												{
																var result = await _invoiceRepository.GetInvoiceByDate(date);
															 object res = result;
																return StatusCode(result.StatusCode, res);
												}
												catch (Exception ex)
												{
																var error = messageErrorBuilder.GetGenericErrorResponse(500, "Invoices", "InvoiceByDate", "GeneralException", MessageTypes.danger.ToString(), null, ex.Message);

																return StatusCode(error.StatusCode, error);
												}
								}
				}
}
