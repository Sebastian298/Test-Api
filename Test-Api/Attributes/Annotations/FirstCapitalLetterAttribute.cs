using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Test_Api.Attributes.Annotations
{
				public class FirstCapitalLetterAttribute : ValidationAttribute
				{
								protected override ValidationResult IsValid(object value, ValidationContext validationContext)
								{
												if (value is null | string.IsNullOrEmpty(value.ToString()))
												{
																return ValidationResult.Success;
												}

												string firstLetter = value.ToString()[0].ToString();
												if (firstLetter != firstLetter.ToUpper())
												{
																return new ValidationResult("The first letter must be capitalized");
												}

												return ValidationResult.Success;
								}
				}
}
