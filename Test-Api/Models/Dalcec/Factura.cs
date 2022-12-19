using System.Text.Json.Serialization;

namespace Test_Api.Models.Dalcec
{
				public class Factura
				{
								public string Ldo { get; set; }
								[JsonPropertyName("Cliente")]
								public string Client { get; set; }
								[JsonPropertyName("Ticket")]
								public string Ticket { get; set; }
								public string Trailer { get; set; }
								public string Pedimento { get; set; }
								[JsonPropertyName("Referencia")]
								public string Reference { get; set; }
								[JsonPropertyName("Comentarios")]
								public string Comments { get; set; }
								[JsonPropertyName("Movimiento")]
								public string Movement { get; set; }
								[JsonPropertyName("Fecha Movimiento")]
								public string DateMovement { get; set; }
								[JsonPropertyName("Descripcion")]
								public string Description { get; set; }
								[JsonPropertyName("Codigo")]
								public string Code { get; set; }
								[JsonPropertyName("Contable")]
								public string Accountant { get; set; }
								[JsonPropertyName("Cantidad")]
								public int Quantity { get; set; }
								[JsonPropertyName("Tarifa")]
								public double Rate { get; set; }
								[JsonPropertyName("Cargos")]
								public double Charges { get; set; }
								[JsonPropertyName("Moneda")]
								public string Currency { get; set; }
								[JsonPropertyName("Reference")]
								public string Referencia { get; set; }
								[JsonPropertyName("Fecha")]
								public string Date { get; set; }
								[JsonPropertyName("Codigo2")]
								public string Code2 { get; set; }
				}
}
