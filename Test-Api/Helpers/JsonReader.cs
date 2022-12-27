using Newtonsoft.Json.Linq;
using System.Text;
using Test_Api.Models.ResponseModels;

namespace Test_Api.Helpers
{
				public class JsonReader
				{
								public GenericResponseData GetGenericErrorList(string controllerName, string methodName, string messageName, string innerException, string type, string title_ = null, string message_ = null)
								{

												var title = title_ ?? GetMessageString(@"Utils\GenericErrorMessages.json", controllerName, methodName, messageName, "i18Title");
												var message = message_ ?? GetMessageString(@"Utils\GenericErrorMessages.json", controllerName, methodName, messageName, "i18Message");

												GenericResponseData mesg = new GenericResponseData
												{
																Title = title,
																Message = message,
																InnerException = innerException,
																Type = type
												};
												return mesg;
								}


								public List<GenericResponseData> GetGenericResponseMessagesList(string jsonFile, string controllerName, string methodName, string messageName, string type, string title_ = null, string message_ = null)
								{
												string[] languages = GetLanguages();

												List<GenericResponseData> menssages = new();

												foreach (string leng in languages)
												{
																var title = title_ ?? GetMessageString(jsonFile, controllerName, methodName, messageName, "title");
																var message = message_ ?? GetMessageString(jsonFile, controllerName, methodName, messageName, "message");

																GenericResponseData mesg = new GenericResponseData
																{
																				Title = title,
																				Message = message,
																				Type = type,
																};

																menssages.Add(mesg);
												}

												return menssages;
								}

								private string GetMessageString(string jsonFile, string controllerName, string methodName, string messageName, string type)
								{
												var root = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, jsonFile);
												var json = File.ReadAllText(root, Encoding.Latin1);
												JObject rss = JObject.Parse(json);
												string rssTitle = (string)rss[controllerName][methodName][messageName][type];
												return rssTitle ?? "";
								}

								public string[] GetLanguages()
								{
												string pathFile = Directory.GetCurrentDirectory();
												IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(pathFile).AddJsonFile("appsettings.Development.json").Build();
												string[] languages = configuration["Localization"].Split(';');
												return (languages.Length>0) ? languages : new string[] { "es" };
								}

								public string GetArrayFromJson(string jsonFile,string controllerName,string endpointName,string dataType)
								{
												var root = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, jsonFile.ToString());
												var json = JObject.Parse(File.ReadAllText(root, Encoding.Latin1));
												string array = json[controllerName][endpointName][dataType].ToString();
												return array;
								}
				}
}
