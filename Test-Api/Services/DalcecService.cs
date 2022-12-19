﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Test_Api.Models.Dalcec;
using Test_Api.Models.Responses;

namespace Test_Api.Services
{
				public class DalcecService : IDalcecService
				{
								public async Task<DalcecResponse> GetRowsByFacData(string facData)
								{
												try
												{
																HttpClient client = new HttpClient();
																string url = $"https://monitor.dalcec.com/direccion1.asmx/FacData?{facData}";
																HttpResponseMessage response = await client.GetAsync(url);
																if (response.IsSuccessStatusCode)
																{
																				var results = await response.Content.ReadAsStringAsync();
																				var json = JsonConvert.DeserializeObject<List<JObject>>(results);
																				return new DalcecResponse
																				{
																								HasError = false,
																								Message = "",
																								Results = json
																				};
																}
																else
																{
																				return new DalcecResponse
																				{
																								HasError = true,
																								Message = "Dalcec Response Bad"
																				};
																}
												}
												catch (Exception ex)
												{

																return new DalcecResponse { HasError = true, Message = ex.Message, Results = null }; ;
												}
								}
				}
}