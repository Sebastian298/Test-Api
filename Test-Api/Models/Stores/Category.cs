using System.ComponentModel.DataAnnotations;
using Test_Api.Attributes.Annotations;

namespace Test_Api.Models.StoreModels
{
				public class Category
				{
								[Required(ErrorMessage = "The filed {0} is required")]
								public string CategoryId { get; set; }
								[Required(ErrorMessage ="The field {0} is required")]
								[StringLength(maximumLength:40,ErrorMessage = "The field {0} must not have more than {1} characters")]
								[FirstCapitalLetter]
								public string Name { get; set; }
				}
}
